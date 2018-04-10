using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//SPREAD用
using FarPoint.Win;
using FarPoint.Win.Spread;
using FarPoint.Win.Spread.Model;
using FarPoint.Win.Spread.CellType;
//PostgreSQL用
using Npgsql;
using NpgsqlTypes;
//B2共通LIB
using B2.Com;

#region 修正履歴
/*
 * 20180314 打越 製造着手
*/
//UNDONE 商品検索　現在開発中
#endregion

namespace B2.BestFunction
{
    /// <summary>
    /// 商品検索ダイアログ（フォーム）
    /// </summary>
    public partial class KensakuSyouhinForm : Form
    {
#region 機能概要
/*
 * ファイル名　　　　　: frm_Kensaku_Syouhin.cs
 * 説明        　　　　: 商品検索ダイアログ
 *  
*/
#endregion

        /// <summary>呼び出し元への渡し用クラス</summary>
        public partial class kensaku_syouhin
        {
            /// <summary>GTINコード </summary>
            public string gtin_code;
            /// <summary>GTIN調剤コード </summary>
            public string gtin_code_chozaihosotani;
            /// <summary>YJコード </summary>
            public string yj_code;
            /// <summary>JANコード </summary>
            public string jan_code;
            /// <summary>後発フラグ </summary>
            public string kouhatu_flag;
            /// <summary>薬品名 </summary>
            public string yakuhin_mei;
            /// <summary>薬品名カナ </summary>
            public string yakuhin_kana;
            /// <summary>規格 </summary>
            public string kikaku_tanni;
            /// <summary>区分 </summary>
            public string kubun;
            /// <summary>包装形態 </summary>
            public string housou_keitai;
            /// <summary>箱入り数 </summary>
            public decimal? housou_souryou_qty;
            /// <summary>包装入り数 </summary>
            public decimal? housou_tanni_qty;
            /// <summary>製造会社名 </summary>
            public string seizou_kaisha_mei;
            /// <summary>販売会社名 </summary>
            public string hanbai_kaisha_mei;
            /// <summary>薬価 </summary>
            public decimal? yakka;
            /// <summary>レセコンコード </summary>
            public string meisai_code;
            /// <summary>現在庫数 </summary>
            public decimal? zaiko_total;
            /// <summary>包装単位　単位 </summary>
            public string housou_tanni_tanni;
            /// <summary>包装数量　単位 </summary>
            public string housou_suryou_tanni;

            /// <summary>初期化　</summary>
            public kensaku_syouhin()
            {
                gtin_code = string.Empty;
                gtin_code_chozaihosotani = string.Empty;
                yj_code = string.Empty;
                jan_code = string.Empty;
                kouhatu_flag = "0";
                yakuhin_mei = string.Empty;
                yakuhin_kana = string.Empty;
                kikaku_tanni = string.Empty;
                kubun = string.Empty;
                housou_keitai = string.Empty;
                housou_souryou_qty = 0m;
                housou_tanni_qty = 0m;
                seizou_kaisha_mei = string.Empty;
                hanbai_kaisha_mei = string.Empty;
                yakka = 0m;
                meisai_code = string.Empty;
                zaiko_total = 0m;
                housou_tanni_tanni = string.Empty;
                housou_suryou_tanni = string.Empty;
           }
        }
        
        /// <summary>　 呼び出し元への渡し用エリア </summary>
        public kensaku_syouhin kensaku_result = new kensaku_syouhin();

        /// <summary> Spreadの列インデックス</summary>
        private enum mainColum
        {
            gtin_code = 0,
            gtin_code_chozaihosotani,
            yj_code,
            jan_code,
            kouhatu_flag,
            yakuhin_mei,
            yakuhin_kana,
            kikaku_tanni,
            kubun,
            housou_keitai,
            housou_souryou_qty,
            housou_suryou_tanni,
            housou_tanni_qty,
            housou_tanni_tanni,
            seizou_kaisha_mei,
            hanbai_kaisha_mei,
            yakka,
            meisai_code,
            zaiko_total,
            tana
        }

        //行の高さ　・・・　未使用
        const int rows_hight = 20;         

        //データセット内のテーブル名定義
        const string YAKUHIN = "YAKUHIN_MASTER";

        /// <summary>共通パラメータ</summary>
        private B2Com b2Com;
        
        /// <summary> 起動情報　0：引数なし　1:引数あり        /// </summary>
        private int action_flag = 1;

        /// <summary> 起動情報　0：コード指定なし　1:コード指定あり  /// </summary>
        public int action_mode = 0;

        /// <summary>
        /// 呼び出し元への復帰情報
        /// </summary>
        public DialogResult ReturnValue = DialogResult.None;
  
        /// <summary> 紐付けＣｏｄｅ /// </summary>
        public string search_code = string.Empty;

        //------------------------------------------------------------------------------
        // データセット
        //------------------------------------------------------------------------------
        DataSet dSet = new DataSet(YAKUHIN);
      
        //NpgsqlDataAdapter oAdp;
        NpgsqlDataAdapter oAdp;
  
        /// <summary>
        ///  コンストラクタ　引数無しパターン
        /// </summary>
        public KensakuSyouhinForm()
        {
            InitializeComponent();

            //----------------------------------------------------
            // 二重起動をチェックする
            //----------------------------------------------------
            System.Diagnostics.Process[] ps =
                System.Diagnostics.Process.GetProcessesByName(System.Diagnostics.Process.GetCurrentProcess().ProcessName);
            if (1 < ps.Length)
            {
                //すでに起動していると判断して終了
                MessageBox.Show("既に起動しています。");
                return;
            }

            //----------------------------------------------------
            // 初期処理
            //----------------------------------------------------
            //B2共通パラメータの定義
            b2Com = new B2Com();

            // 初期処理　共通パラメータの情報設定
            if (!b2Com.Initialize(true))
            {
                return;
            }

            // データベース初期化処理（接続） EntityFrameworkとは別の接続
            if (!b2Com.InitDb(true))
            {
                return;
            }

            action_flag = 0;
        }

        /// <summary>
        /// コンストラクタ 引数有りパターン
        /// </summary>
        /// <param name="paramCom">共通パラメータ</param>
        public KensakuSyouhinForm(B2Com paramCom)
        {
            InitializeComponent();

            // 共通パラメータをセット
            b2Com = paramCom;
        }

        /// <summary>
        /// LOADイベント時の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frm_Kensaku_Syouhin_Load(object sender, EventArgs e)
        {
            try
            {
                this.KeyPreview = true;
            }
            catch (Exception ex)
            {
                b2Com.ShowErrMsg(ex);
            }
        }

        /// <summary>
        /// Shownイベント時の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frm_Kensaku_Syouhin_Shown(object sender, EventArgs e)
        {
            try
            {
                //初期化　バックカラーの設定
                b2Com.SetBackColor(this);

                //検索キー入力エリアのクリア
                search_text.Text = "";
                
                //フィールドの初期化
                setInitialize();

                if(action_mode != 0)
                {
                    search_text.Text = search_code;
                    search_text.BackColor = Color.LemonChiffon;
                    search_text.ReadOnly = true;
                    kensaku_syori();
                }
                else
                {
                    search_text.BackColor = Color.White;
                    search_text.ReadOnly = false;
                }

                this.Activate();
            }
            catch (Exception ex)
            {
                b2Com.ShowErrMsg(ex);
            }

        }

        /// <summary>
        /// 初期化設定
        /// </summary>
        /// <param name="pnumState">状態情報</param>
        private void setInitialize()
        {
            try
            {
                // 初期化処理
                setSpreadInitialize();

                // 選択ボタンを非アクティブ
                btn_ok.Enabled = false;

            }
            catch (Exception ex)
            {
                b2Com.ShowErrMsg(ex);
            }
        }

        /// <summary>
        /// スプレッドの初期化
        /// </summary>
        private void setSpreadInitialize()
        {
            try
            {
                //--------------------------------------
                // Spread 表示セルを初期化（クリア）
                //--------------------------------------
                ClearMain();

                //--------------------------------------
                // 操作モードの設定
                //--------------------------------------
                //セル選択
                fpSMain.ActiveSheet.OperationMode = OperationMode.Normal;
                //行選択
                //fpSMain.ActiveSheet.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;

                fpSMain.HorizontalScrollBarPolicy = ScrollBarPolicy.AsNeeded;
                fpSMain.VerticalScrollBarPolicy = ScrollBarPolicy.AsNeeded;
                fpSMain.ClipboardOptions = FarPoint.Win.Spread.ClipboardOptions.NoHeaders;
                fpSMain.ActiveSheet.ClipboardPaste(FarPoint.Win.Spread.ClipboardPasteOptions.Values);

                ////--------------------------------------
                //// セルを選択した時のヘッダのハイライト表示を抑制
                ////--------------------------------------
                //FarPoint.Win.Spread.CellType.EnhancedColumnHeaderRenderer lcolRenderer = new FarPoint.Win.Spread.CellType.EnhancedColumnHeaderRenderer();
                //lcolRenderer.SelectedActiveBackgroundColor = Color.FromArgb(195, 202, 214);
                //lcolRenderer.SelectedBackgroundColor = Color.FromArgb(215, 223, 235);
                //lcolRenderer.SelectedGridLineColor = Color.FromArgb(158, 182, 206);
                //fpSMain.ActiveSheet.ColumnHeader.DefaultStyle.Renderer = lcolRenderer;

                ////--------------------------------------
                //// OperationMode制御時にセル背景色が変わらないようにする
                ////--------------------------------------
                //fpSMain.ActiveSheet.SelectionBackColor = Color.Empty;
                //fpSMain.ActiveSheet.SelectionStyle = FarPoint.Win.Spread.SelectionStyles.SelectionColors;

                ////--------------------------------------
                //// 行数列数設定
                ////--------------------------------------
                fpSMain.ActiveSheet.ColumnHeader.RowCount = 1;
                fpSMain.ActiveSheet.RowCount = 0;
                //fpSMain.ActiveSheet.ColumnCount = (int)mainColum.zaiko_total + 1;
                //fpSMain.ActiveSheet.ColumnHeader.Columns. = fpSMain.ActiveSheet.GetPreferredRowHeight(i);

                ////--------------------------------------
                //// Columnパラメータ 設定 編集不可　
                ////--------------------------------------
                //fpSMain.ActiveSheet.Columns[(int)mainColum.gtin_code].Locked = true;

                //列幅設定
                setSpreadInfo();

                //--------------------------------------
                // 一覧表再描画
                //--------------------------------------
                fpSMain.Refresh();
            }
            catch (Exception ex)
            {
                b2Com.ShowErrMsg(ex);
            }
        }


        /// <summary>
        /// 明細クリア
        /// </summary>
        private void ClearMain()
        {
            // 明細行数の設定
            fpSMain.ActiveSheet.RowCount = 0;

            //空明細をクリア
            for (int i = 0; i < fpSMain.ActiveSheet.RowCount; i++)
            {
                for (int j = 0; j < fpSMain.ActiveSheet.ColumnCount; j++)
                {
                    //クリア
                    fpSMain.ActiveSheet.Cells[i, j].Text = "";
                    fpSMain.ActiveSheet.Cells[i, j].Value = 0;

                    ////セル毎にLOCK　 編集不可
                    //fpSMain.ActiveSheet.Cells[i, j].Locked = true;
                }
            }
            fpSMain.Refresh();
        }

        /// <summary>
        /// スプレッドの属性設定
        /// </summary>
        private void setSpreadInfo()
        {
            //行ヘッダーの列幅
            fpSMain.ActiveSheet.RowHeader.Columns[0].Width = 35;
            fpSMain.ActiveSheet.RowHeader.Columns[0].Font = new Font("MS UI Gothic", 9);
            fpSMain.ActiveSheet.RowHeader.Columns[0].HorizontalAlignment = CellHorizontalAlignment.Right;

            // 列の非表示設定
            fpSMain.ActiveSheet.Columns[(int)mainColum.gtin_code_chozaihosotani].Visible = false;

//            fpSMain.ActiveSheet.Columns[(int)mainColum.housou_tanni_tanni].Visible = false;
//            fpSMain.ActiveSheet.Columns[(int)mainColum.housou_suryou_tanni].Visible = false;

            ////列幅,他の設定
            fpSMain.ActiveSheet.Columns[(int)mainColum.gtin_code].Width = (float)135;
            fpSMain.ActiveSheet.Columns[(int)mainColum.gtin_code_chozaihosotani].Width = (float)135;
            fpSMain.ActiveSheet.Columns[(int)mainColum.yj_code].Width = (float)125;
            fpSMain.ActiveSheet.Columns[(int)mainColum.jan_code].Width = (float)125;
            fpSMain.ActiveSheet.Columns[(int)mainColum.kouhatu_flag].Width = (float)60;
            fpSMain.ActiveSheet.Columns[(int)mainColum.yakuhin_mei].Width = (float)250;
            fpSMain.ActiveSheet.Columns[(int)mainColum.yakuhin_kana].Width = (float)250;
            fpSMain.ActiveSheet.Columns[(int)mainColum.kikaku_tanni].Width = (float)250;
            fpSMain.ActiveSheet.Columns[(int)mainColum.kubun].Width = (float)80;
            fpSMain.ActiveSheet.Columns[(int)mainColum.housou_keitai].Width = (float)120;
            fpSMain.ActiveSheet.Columns[(int)mainColum.housou_souryou_qty].Width = (float)60;
            fpSMain.ActiveSheet.Columns[(int)mainColum.housou_suryou_tanni].Width = (float)35;
            fpSMain.ActiveSheet.Columns[(int)mainColum.housou_tanni_qty].Width = (float)60;
            fpSMain.ActiveSheet.Columns[(int)mainColum.housou_tanni_tanni].Width = (float)35;
            fpSMain.ActiveSheet.Columns[(int)mainColum.seizou_kaisha_mei].Width = (float)150;
            fpSMain.ActiveSheet.Columns[(int)mainColum.hanbai_kaisha_mei].Width = (float)150;
            fpSMain.ActiveSheet.Columns[(int)mainColum.yakka].Width = (float)100;
            fpSMain.ActiveSheet.Columns[(int)mainColum.meisai_code].Width = (float)128;

            fpSMain.ActiveSheet.Columns[(int)mainColum.tana].Width = (float)250;

            ////　テキスト型セル　折り返し無し
            //FarPoint.Win.Spread.CellType.TextCellType textcell_row = new FarPoint.Win.Spread.CellType.TextCellType();
            //textcell_row.WordWrap = false;

            ////  // テキスト型セル　折り返し有り
            //FarPoint.Win.Spread.CellType.TextCellType textcell_rows = new FarPoint.Win.Spread.CellType.TextCellType();
            //textcell_rows.Multiline = true;         //改行の入力　Shift+Enterが可能となる。　シフト無しでもOKだった。確定はフォーカスを外すこと。
            //textcell_rows.WordWrap = true;
            //textcell_rows.MaxLength = 2000;         //デフォルトで切られていた為、DBの最大サイズとした。

            ////小数点、桁区切りの設定  
            //// 0
            //FarPoint.Win.Spread.CellType.NumberCellType lobjCellTypeNumberDecimalPlaces0 = new FarPoint.Win.Spread.CellType.NumberCellType();
            //lobjCellTypeNumberDecimalPlaces0.DecimalPlaces = 0;
            //lobjCellTypeNumberDecimalPlaces0.ShowSeparator = false;
            //lobjCellTypeNumberDecimalPlaces0.MaximumValue = 99999999;

            //// 1
            //FarPoint.Win.Spread.CellType.NumberCellType lobjCellTypeNumberDecimalPlaces1 = new FarPoint.Win.Spread.CellType.NumberCellType();
            //lobjCellTypeNumberDecimalPlaces1.DecimalPlaces = 1;
            //lobjCellTypeNumberDecimalPlaces1.ShowSeparator = true;

            //// 2
            //FarPoint.Win.Spread.CellType.NumberCellType lobjCellTypeNumberDecimalPlaces2 = new FarPoint.Win.Spread.CellType.NumberCellType();
            //lobjCellTypeNumberDecimalPlaces2.DecimalPlaces = 2;
            //lobjCellTypeNumberDecimalPlaces2.ShowSeparator = true;

            ////CELL タイプの設定
            ////fpSMain.ActiveSheet.Columns[(int)mainColum.KANRYOU].CellType = (FarPoint.Win.Spread.CellType.NumberCellType)textcell_row.Clone();
            //fpSMain.ActiveSheet.Columns[(int)mainColum2.SEQ_NO].CellType = (FarPoint.Win.Spread.CellType.NumberCellType)lobjCellTypeNumberDecimalPlaces0.Clone();
            //fpSMain.ActiveSheet.Columns[(int)mainColum2.KANRI_NO].CellType = (FarPoint.Win.Spread.CellType.NumberCellType)lobjCellTypeNumberDecimalPlaces0.Clone();
            //fpSMain.ActiveSheet.Columns[(int)mainColum2.BUNRUI].CellType = (FarPoint.Win.Spread.CellType.TextCellType)textcell_row.Clone();
            //fpSMain.ActiveSheet.Columns[(int)mainColum2.BUNRUI].CellPadding.Left = (int)5;

            // ◆フィルターバー形式（条件入力形式）
            fpSMain.ActiveSheet.AutoFilterMode = FarPoint.Win.Spread.AutoFilterMode.FilterBar;
            fpSMain.ActiveSheet.FilterBar.Height = 25;

            // フィルタ条件入力部分にIME設定
            fpSMain.ActiveSheet.FilterBar.Cells[(int)mainColum.gtin_code].ImeMode = ImeMode.Off;
            fpSMain.ActiveSheet.FilterBar.Cells[(int)mainColum.yakuhin_mei].ImeMode = ImeMode.Hiragana;
            fpSMain.ActiveSheet.FilterBar.Cells[(int)mainColum.yakuhin_kana].ImeMode = ImeMode.Katakana;
            fpSMain.ActiveSheet.FilterBar.Cells[(int)mainColum.kubun].ImeMode = ImeMode.Hiragana;

            fpSMain.ActiveSheet.FilterBar.Cells[(int)mainColum.gtin_code].ForeColor = Color.Black;
            fpSMain.ActiveSheet.FilterBar.Cells[(int)mainColum.yakuhin_mei].ForeColor = Color.Black;
            fpSMain.ActiveSheet.FilterBar.Cells[(int)mainColum.yakuhin_kana].ForeColor = Color.Black;
            fpSMain.ActiveSheet.FilterBar.Cells[(int)mainColum.kubun].ForeColor = Color.Black;

            // テキストフィルタ用のフィルタ形式を指定
            FarPoint.Win.Spread.CellType.FilterBarCellType fbtxt = new FarPoint.Win.Spread.CellType.FilterBarCellType();
            fbtxt.ContextMenuType = FarPoint.Win.Spread.CellType.FilterBarContextMenuType.Text;
            fbtxt.ShowLabel = false;
            fbtxt.ShowEditor = true;
            
            fpSMain.ActiveSheet.FilterBar.Cells[(int)mainColum.gtin_code].CellType = fbtxt;
            fpSMain.ActiveSheet.FilterBar.Cells[(int)mainColum.yakuhin_mei].CellType = fbtxt;
            fpSMain.ActiveSheet.FilterBar.Cells[(int)mainColum.yakuhin_kana].CellType = fbtxt;
            fpSMain.ActiveSheet.FilterBar.Cells[(int)mainColum.kubun].CellType = fbtxt;

            //// 日付フィルタ用のフィルタ形式を指定
            //FarPoint.Win.Spread.CellType.FilterBarCellType fbdt = new FarPoint.Win.Spread.CellType.FilterBarCellType();
            //fbdt.ContextMenuType = FarPoint.Win.Spread.CellType.FilterBarContextMenuType.DateTime;
            //fbdt.ShowLabel = false;
            //fbdt.ShowEditor = true;
            //fpSMain.ActiveSheet.FilterBar.Cells[7].CellType = fbdt;
          
            //性能悪の根源
            ////行の高さを設定
            //int rows_count = fpSMain.ActiveSheet.RowCount;
            //for (int i = 0; i < rows_count; i++)
            //{
            //    // 最も高さのあるテキストの高さに設定します
            //    fpSMain.ActiveSheet.Rows[i].Height = (rows_hight > fpSMain.ActiveSheet.GetPreferredRowHeight(i) ? rows_hight : fpSMain.ActiveSheet.GetPreferredRowHeight(i));
            //}

            //固定列数の設定
            fpSMain.ActiveSheet.FrozenColumnCount = (int)mainColum.yj_code;
        }


        /// <summary>
        /// 閉じる
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_exit_Click(object sender, EventArgs e)
        {
            try
            {
                //----------------------------------------------------
                // 終了処理
                //----------------------------------------------------
                //DBのクローズ処理
                if (action_flag == 0)
                {
                    b2Com.CloseDb();
                }

                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;

                this.Close();
            }
            catch (Exception ex)
            {
                b2Com.ShowErrMsg(ex);
            }

        }
        /// <summary>
        /// ＯＫ　選択　戻し用のデータをセット
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ok_Click(object sender, EventArgs e)
        {
            try
            {
                //選択行の位置を取得
                int index = fpSMain.ActiveSheet.ActiveRowIndex;
                if(index < 0)
                {
                    this.Close();
                    return;
                }

                //選択行の情報をセット
                if (fpSMain.ActiveSheet.Cells[index, (int)mainColum.gtin_code].Value != null)
                {
                    kensaku_result.gtin_code = fpSMain.ActiveSheet.Cells[index, (int)mainColum.gtin_code].Value.ToString();
                }

                if (fpSMain.ActiveSheet.Cells[index, (int)mainColum.gtin_code_chozaihosotani].Value != null)
                {
                    kensaku_result.gtin_code_chozaihosotani = fpSMain.ActiveSheet.Cells[index, (int)mainColum.gtin_code_chozaihosotani].Value.ToString();
                }

                if (fpSMain.ActiveSheet.Cells[index, (int)mainColum.yj_code].Value != null)
                {
                    kensaku_result.yj_code = fpSMain.ActiveSheet.Cells[index, (int)mainColum.yj_code].Value.ToString();
                }

                if(fpSMain.ActiveSheet.Cells[index, (int)mainColum.jan_code].Value != null)
                {
                    kensaku_result.jan_code = fpSMain.ActiveSheet.Cells[index, (int)mainColum.jan_code].Value.ToString();
                }
                
                //後発
                if (fpSMain.ActiveSheet.Cells[index, (int)mainColum.kouhatu_flag].Value != null)
                {
                    kensaku_result.kouhatu_flag = fpSMain.ActiveSheet.Cells[index, (int)mainColum.kouhatu_flag].Value.ToString();
                }

                if (fpSMain.ActiveSheet.Cells[index, (int)mainColum.yakuhin_mei].Value != null)
                {
                    kensaku_result.yakuhin_mei = fpSMain.ActiveSheet.Cells[index, (int)mainColum.yakuhin_mei].Value.ToString();
                }

                if (fpSMain.ActiveSheet.Cells[index, (int)mainColum.yakuhin_kana].Value != null)
                {
                    kensaku_result.yakuhin_kana = fpSMain.ActiveSheet.Cells[index, (int)mainColum.yakuhin_kana].Value.ToString();
                }

                if (fpSMain.ActiveSheet.Cells[index, (int)mainColum.kikaku_tanni].Value != null)
                {
                    kensaku_result.kikaku_tanni = fpSMain.ActiveSheet.Cells[index, (int)mainColum.kikaku_tanni].Value.ToString();
                }

                if (fpSMain.ActiveSheet.Cells[index, (int)mainColum.kubun].Value != null)
                {
                    kensaku_result.kubun = fpSMain.ActiveSheet.Cells[index, (int)mainColum.kubun].Value.ToString();
                }

                if (fpSMain.ActiveSheet.Cells[index, (int)mainColum.housou_keitai].Value != null)
                {
                    kensaku_result.housou_keitai = fpSMain.ActiveSheet.Cells[index, (int)mainColum.housou_keitai].Value.ToString();
                }

                if (fpSMain.ActiveSheet.Cells[index, (int)mainColum.housou_souryou_qty].Value != null)
                {
                    decimal wk_dec = 0m;
                    if (decimal.TryParse(fpSMain.ActiveSheet.Cells[index, (int)mainColum.housou_souryou_qty].Value.ToString(), out wk_dec))
                    {
                        kensaku_result.housou_souryou_qty = wk_dec;
                    }
                }

                if (fpSMain.ActiveSheet.Cells[index, (int)mainColum.housou_tanni_tanni].Value != null)
                {
                    kensaku_result.housou_tanni_tanni = fpSMain.ActiveSheet.Cells[index, (int)mainColum.housou_tanni_tanni].Value.ToString();
                }

                if (fpSMain.ActiveSheet.Cells[index, (int)mainColum.housou_suryou_tanni].Value != null)
                {
                    kensaku_result.housou_suryou_tanni = fpSMain.ActiveSheet.Cells[index, (int)mainColum.housou_suryou_tanni].Value.ToString();
                }

                if (fpSMain.ActiveSheet.Cells[index, (int)mainColum.housou_tanni_qty].Value != null)
                {
                    decimal wk_dec = 0m;
                    if (decimal.TryParse(fpSMain.ActiveSheet.Cells[index, (int)mainColum.housou_tanni_qty].Value.ToString(), out wk_dec))
                    {
                        kensaku_result.housou_tanni_qty = wk_dec;
                    }
                }
                
                if (fpSMain.ActiveSheet.Cells[index, (int)mainColum.seizou_kaisha_mei].Value != null)
                {
                    kensaku_result.seizou_kaisha_mei = fpSMain.ActiveSheet.Cells[index, (int)mainColum.seizou_kaisha_mei].Value.ToString();
                }
             
                if (fpSMain.ActiveSheet.Cells[index, (int)mainColum.hanbai_kaisha_mei].Value != null)
                {
                    kensaku_result.hanbai_kaisha_mei = fpSMain.ActiveSheet.Cells[index, (int)mainColum.hanbai_kaisha_mei].Value.ToString();
                }

                if (fpSMain.ActiveSheet.Cells[index, (int)mainColum.yakka].Value != null)
                {
                    decimal wk_dec = 0m;
                    if (decimal.TryParse(fpSMain.ActiveSheet.Cells[index, (int)mainColum.yakka].Value.ToString(), out wk_dec))
                    {
                        kensaku_result.yakka = wk_dec;
                    }
                }

                if (fpSMain.ActiveSheet.Cells[index, (int)mainColum.meisai_code].Value != null)
                {
                    kensaku_result.meisai_code = fpSMain.ActiveSheet.Cells[index, (int)mainColum.meisai_code].Value.ToString();
                }

                if (fpSMain.ActiveSheet.Cells[index, (int)mainColum.zaiko_total].Value != null)
                {
                    decimal wk_dec = 0m;
                    if (decimal.TryParse(fpSMain.ActiveSheet.Cells[index, (int)mainColum.zaiko_total].Value.ToString(), out wk_dec))
                    {
                        kensaku_result.zaiko_total = wk_dec;
                    }
                }


                //----------------------------------------------------
                // 終了処理
                //----------------------------------------------------
                //DBのクローズ処理
                if (action_flag == 0)
                {
                    b2Com.CloseDb();
                }

                this.DialogResult = System.Windows.Forms.DialogResult.OK;

                this.Close();
                
            }
            catch (Exception ex)
            {
                b2Com.ShowErrMsg(ex);
            }
        }

        
        /// <summary>
        /// 検索ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_select_Click(object sender, EventArgs e)
        {
            kensaku_syori();
        }


        /// <summary>
        /// データ抽出処理
        /// </summary>
        private void kensaku_syori()
        {
            // 元のカーソルを保持
            Cursor preCursor = Cursor.Current;

            // カーソルを待機カーソルに変更
            Cursor.Current = Cursors.WaitCursor;

            string search_string = search_text.Text;
            if (string.IsNullOrWhiteSpace(search_string))
            {
                // カーソルを元に戻す
                Cursor.Current = preCursor;
                //MessageBox.Show("キー文字列が入力されていません。", this.Text);
                search_text.Focus();
                return;
            }

            //スプレッド初期化
            setInitialize();

            //データの取得
            dBselect_Yakuhin(search_string);

            if (dSet.Tables[YAKUHIN].Rows.Count <= 0)
            {
                // カーソルを元に戻す
                Cursor.Current = preCursor;

                MessageBox.Show("指定のデータが存在しませんでした。", this.Text);
                return;
            }

            //スプレッドにデータセットをセット
            fpSMain.ActiveSheet.DataSource = dSet.Tables[YAKUHIN];

            //列幅設定
            setSpreadInfo();

            //ボタン制御 
            btn_ok.Enabled = true;

            // 編集終了
            //fpSmain.Refresh();
            fpSMain.ResumeLayout(true);

            // Spread キーの透過設定　
            InitDispInputMap(fpSMain);

            //// 読み取り専用
            fpSMain.ActiveSheet.OperationMode = FarPoint.Win.Spread.OperationMode.ReadOnly; 

            // カーソルを元に戻す
            Cursor.Current = preCursor;

            //フォーカス位置 アクティブセルの設定
            fpSMain.Focus();
            fpSMain.ActiveSheet.SetActiveCell(0, 0, true);
        }


        /// <summary>スプレッド標準キー を無効にし上位へスルー通知を行う処理</summary>
        /// <param name="pspdObj">スプレッドシートインスタンス</param>
        /// <returns>true：正常終了　false：エラー</returns>
        /// <remark>
        /// 各起動時に実行してください。
        /// TAB：フォーカス移動用にします
        /// ESC：通常画面の終了に使用します など
        /// 
        /// ※　スプレッド読み取り専用の場合必要なし(OperationModeの設定だけ)
        /// 　　標準でキーを取得したい場合に使用します
        /// </remark>
        public static bool InitDispInputMap(FpSpread pspdObj)
        {
            try
            {
                InputMap im = new InputMap();

                //【非編集セル】での［Enter］キーを「次行へ移動」とします
                // WhenFocused 入力マップ 
                // コントロールにフォーカスがある場合（セル非編集モード）
                //     im = pspdObj.GetInputMap(FarPoint.Win.Spread.InputMapMode.WhenFocused);
                //im.Put(new Keystroke(Keys.Enter, Keys.None), SpreadActions.MoveToNextRow);    // Enter  次の行
                //     im.Put(new Keystroke(Keys.Enter, Keys.None), SpreadActions.None);        // Enter　何もしない
                //     im.Put(new Keystroke(Keys.Down, Keys.None), SpreadActions.None);         //  ↓ 　 何もしない

                //【編集中セル】での［Enter］キーを「次行へ移動」とします
                // WhenAncestorOfFocused 入力マップ 
                // コントロールまたはその子にフォーカスがある場合（セル編集モード）　
                im = pspdObj.GetInputMap(FarPoint.Win.Spread.InputMapMode.WhenAncestorOfFocused);
                //im.Put(new Keystroke(Keys.Enter, Keys.None), SpreadActions.None);               // Enter　何もしない
                //im.Put(new Keystroke(Keys.Down, Keys.Alt), SpreadActions.None);                 // ALT + ↓ 　何もしない
                //im.Put(new Keystroke(Keys.Down, Keys.None), SpreadActions.None);                //  ↓ 　何もしない
                //im.Put(new Keystroke(Keys.Enter, Keys.None), SpreadActions.MoveToNextRow);      // Enter  次の行
                //im.Put(new Keystroke(Keys.Tab, Keys.None), SpreadActions.None);                 // TAB
                //im.Put(new Keystroke(Keys.Tab, Keys.Shift, false), SpreadActions.None);         // TAB + Shift
                im.Put(new Keystroke(Keys.Escape, Keys.None), SpreadActions.None);            // ESC
                im.Put(new Keystroke(Keys.F1, Keys.None), SpreadActions.None);                // F1
                im.Put(new Keystroke(Keys.F2, Keys.None), SpreadActions.None);                // F2
                im.Put(new Keystroke(Keys.F3, Keys.None), SpreadActions.None);                // F3
                im.Put(new Keystroke(Keys.F4, Keys.None), SpreadActions.None);                // F4
                im.Put(new Keystroke(Keys.F5, Keys.None), SpreadActions.None);                // F5
                im.Put(new Keystroke(Keys.F6, Keys.None), SpreadActions.None);                // F6
                im.Put(new Keystroke(Keys.F7, Keys.None), SpreadActions.None);                // F7
                im.Put(new Keystroke(Keys.F8, Keys.None), SpreadActions.None);                // F8
                im.Put(new Keystroke(Keys.F9, Keys.None), SpreadActions.None);                // F9
                im.Put(new Keystroke(Keys.F10, Keys.None), SpreadActions.None);               // F10
                im.Put(new Keystroke(Keys.F11, Keys.None), SpreadActions.None);               // F11
                im.Put(new Keystroke(Keys.F12, Keys.None), SpreadActions.None);               // F12

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        

        /// <summary>
        /// データの抽出
        /// </summary>
        /// <param name="search_key"></param>
        /// <returns></returns>
        private bool dBselect_Yakuhin(string search_key)
        {
            try
            {
                if (search_key.Length <= 0)
                {
                    return false;
                }

                b2Com.PgLib.Sql.Clear();
                b2Com.PgLib.Sql.Append("\r\n  select YAKUHIN.*,  ");
                b2Com.PgLib.Sql.Append("\r\n         CASE WHEN TANAINFO.tana1 IS NULL  ");
                b2Com.PgLib.Sql.Append("\r\n              THEN  ");
                b2Com.PgLib.Sql.Append("\r\n                ' '  ");
                b2Com.PgLib.Sql.Append("\r\n              ELSE   ");
                b2Com.PgLib.Sql.Append("\r\n                CASE WHEN TANAINFO.tana2 IS NULL  ");
                b2Com.PgLib.Sql.Append("\r\n                     THEN   ");
                b2Com.PgLib.Sql.Append("\r\n                       TANAINFO.tana1  ");
                b2Com.PgLib.Sql.Append("\r\n                     ELSE   ");
                b2Com.PgLib.Sql.Append("\r\n  		              CASE WHEN TANAINFO.tana3 IS NULL  ");
                b2Com.PgLib.Sql.Append("\r\n  		                   THEN   ");
                b2Com.PgLib.Sql.Append("\r\n  		                     (TANAINFO.tana1 || ',' || TANAINFO.tana2)  ");
                b2Com.PgLib.Sql.Append("\r\n  		                   ELSE   ");
                b2Com.PgLib.Sql.Append("\r\n  				              CASE WHEN TANAINFO.tana4 IS NULL  ");
                b2Com.PgLib.Sql.Append("\r\n  				                   THEN   ");
                b2Com.PgLib.Sql.Append("\r\n  				                     (TANAINFO.tana1 || ',' || TANAINFO.tana2 || ',' || TANAINFO.tana3)  ");
                b2Com.PgLib.Sql.Append("\r\n  				                   ELSE   ");
                b2Com.PgLib.Sql.Append("\r\n  						              CASE WHEN TANAINFO.tana5 IS NULL  ");
                b2Com.PgLib.Sql.Append("\r\n  						                   THEN   ");
                b2Com.PgLib.Sql.Append("\r\n  						                     (TANAINFO.tana1 || ',' || TANAINFO.tana2 || ',' || TANAINFO.tana3 || ',' || TANAINFO.tana4)  ");
                b2Com.PgLib.Sql.Append("\r\n  						                   ELSE   ");
                b2Com.PgLib.Sql.Append("\r\n  						                     (TANAINFO.tana1 || ',' || TANAINFO.tana2 || ',' || TANAINFO.tana3 || ',' || TANAINFO.tana4 || ',' || TANAINFO.tana5)  ");
                b2Com.PgLib.Sql.Append("\r\n  						              END  ");
                b2Com.PgLib.Sql.Append("\r\n  				              END  ");
                b2Com.PgLib.Sql.Append("\r\n  		              END  ");
                b2Com.PgLib.Sql.Append("\r\n                END  ");
                b2Com.PgLib.Sql.Append("\r\n          END as 棚   ");
                b2Com.PgLib.Sql.Append("\r\n from  ");
                b2Com.PgLib.Sql.Append("\r\n (  ");
                
                    //薬品
                b2Com.PgLib.Sql.Append("\r\n select yakuhin_master.gtin_code as ＧＴＩＮ販売  ");
                b2Com.PgLib.Sql.Append("\r\n      , yakuhin_master.gtin_code_chozaihosotani as ＧＴＩＮ調剤  ");
                b2Com.PgLib.Sql.Append("\r\n      , yakuhin_master.yj_code as ＹＪ  ");
                b2Com.PgLib.Sql.Append("\r\n 	 , yakuhin_master.jan_code as ＪＡＮ  ");
                b2Com.PgLib.Sql.Append("\r\n      , yakuhin_master.kohatsu_flag as 後発  ");
                b2Com.PgLib.Sql.Append("\r\n      , yakuhin_master.yakuhin_mei as 薬品名  ");
                b2Com.PgLib.Sql.Append("\r\n      , yakuhin_master.yakuhin_kana as 薬品名カナ  ");
                b2Com.PgLib.Sql.Append("\r\n      , yakuhin_master.kikaku_tanni as 規格・容量  ");
                b2Com.PgLib.Sql.Append("\r\n      , yakuhin_master.kubun as 区分  ");
                b2Com.PgLib.Sql.Append("\r\n      , yakuhin_master.housou_keitai as 包装形態  ");
                b2Com.PgLib.Sql.Append("\r\n      , yakuhin_master.housou_souryou_qty as 入り数  ");
                b2Com.PgLib.Sql.Append("\r\n      , yakuhin_master.housou_suryou_tanni as 単位1 ");

                b2Com.PgLib.Sql.Append("\r\n      , yakuhin_master.housou_tanni_qty as ヒート  ");
                b2Com.PgLib.Sql.Append("\r\n      , yakuhin_master.housou_tanni_tanni as 単位2 ");
                
                b2Com.PgLib.Sql.Append("\r\n      , yakuhin_master.seizou_kaisha_mei as 製造会社  ");
                b2Com.PgLib.Sql.Append("\r\n      , yakuhin_master.hanbai_kaisha_mei as 販売会社  ");
                b2Com.PgLib.Sql.Append("\r\n      , yakuhin_master.yakka as 薬価  ");
                b2Com.PgLib.Sql.Append("\r\n      , tehai_master.meisai_code as レセコンコード  ");
                b2Com.PgLib.Sql.Append("\r\n      , zaiko_master.zaiko_total as 在庫数  ");

                b2Com.PgLib.Sql.Append("\r\n from yakuhin_master ");

                b2Com.PgLib.Sql.Append("\r\n left outer join tehai_master   ");
                b2Com.PgLib.Sql.Append("\r\n         on yakuhin_master.gtin_code = tehai_master.gtin_code  ");

                b2Com.PgLib.Sql.Append("\r\n     left outer join zaiko_master  ");
                b2Com.PgLib.Sql.Append("\r\n         on yakuhin_master.gtin_code = zaiko_master.gtin_code  ");
                
                b2Com.PgLib.Sql.Append("\r\n where yakuhin_master.apply_end_ymd = '' ");
                b2Com.PgLib.Sql.Append("\r\n   and yakuhin_master.hanbai_chushi_ymd = '' ");
                b2Com.PgLib.Sql.Append("\r\n   and ( yakuhin_master.keika_sochi_ymd = '' or  yakuhin_master.keika_sochi_ymd >= to_char(timestamp 'now','YYYYMMDD') ) ");

                decimal wk_dec = 0m;
                if(decimal.TryParse(search_key,out wk_dec))
                {
                    b2Com.PgLib.Sql.Append("\r\n and ( yakuhin_master.gtin_code like '" + search_key + "%' ");
                    b2Com.PgLib.Sql.Append("\r\n       or yakuhin_master.jan_code like '" + search_key + "%' ");
                    b2Com.PgLib.Sql.Append("\r\n       or yakuhin_master.yj_code like '" + search_key + "%'  )");
                }
                else
                {
                    if (!string.IsNullOrEmpty(search_key))
                    {
                        b2Com.PgLib.Sql.Append("\r\n and ( yakuhin_master.yakuhin_mei like '" + search_key + "%' ");
                        b2Com.PgLib.Sql.Append("\r\n    or yakuhin_master.yakuhin_kana like '" + search_key + "%' ");
                        b2Com.PgLib.Sql.Append("\r\n    or yakuhin_master.yj_code like '" + search_key + "%' )");
                    }
                }

                b2Com.PgLib.Sql.Append("\r\n union all ");

                //ＯＴＣ
                b2Com.PgLib.Sql.Append("\r\n select otc_master.gtin_code as ＧＴＩＮ販売  ");
                b2Com.PgLib.Sql.Append("\r\n      , '' as ＧＴＩＮ調剤  ");
                b2Com.PgLib.Sql.Append("\r\n      , otc_master.yj_code as ＹＪ  ");
                b2Com.PgLib.Sql.Append("\r\n 	 , otc_master.jan_code as ＪＡＮ  ");
                b2Com.PgLib.Sql.Append("\r\n      , '0' as 後発  ");
                b2Com.PgLib.Sql.Append("\r\n      , otc_master.yakuhin_mei as 薬品名  ");
                b2Com.PgLib.Sql.Append("\r\n      , otc_master.yakuhin_kana as 薬品名カナ  ");
                b2Com.PgLib.Sql.Append("\r\n      , otc_master.kikaku_tanni as 規格・容量  ");
                b2Com.PgLib.Sql.Append("\r\n      , otc_master.kubun as 区分  ");
                b2Com.PgLib.Sql.Append("\r\n      , otc_master.housou_keitai as 包装形態  ");
                b2Com.PgLib.Sql.Append("\r\n      , otc_master.housou_souryou_qty as 入り数  ");
                b2Com.PgLib.Sql.Append("\r\n      , otc_master.housou_suryou_tanni as 単位1 ");
                b2Com.PgLib.Sql.Append("\r\n      , otc_master.housou_tanni_qty as ヒート  ");
                b2Com.PgLib.Sql.Append("\r\n      , otc_master.housou_tanni_tanni as 単位2 ");
                b2Com.PgLib.Sql.Append("\r\n      , otc_master.seizou_kaisha_mei as 製造会社  ");
                b2Com.PgLib.Sql.Append("\r\n      , otc_master.hanbai_kaisha_mei as 販売会社  ");
                b2Com.PgLib.Sql.Append("\r\n      , otc_master.yakka as 薬価  ");
                b2Com.PgLib.Sql.Append("\r\n      , tehai_master.meisai_code as レセコンコード  ");
                b2Com.PgLib.Sql.Append("\r\n      , zaiko_master.zaiko_total as 在庫数  ");

                b2Com.PgLib.Sql.Append("\r\n from otc_master ");

                b2Com.PgLib.Sql.Append("\r\n left outer join tehai_master   ");
                b2Com.PgLib.Sql.Append("\r\n         on otc_master.gtin_code = tehai_master.gtin_code  ");

                b2Com.PgLib.Sql.Append("\r\n     left outer join zaiko_master  ");
                b2Com.PgLib.Sql.Append("\r\n         on otc_master.gtin_code = zaiko_master.gtin_code  ");

                b2Com.PgLib.Sql.Append("\r\n where otc_master.apply_end_ymd = '' ");
                b2Com.PgLib.Sql.Append("\r\n   and otc_master.hanbai_chushi_ymd = '' ");
                b2Com.PgLib.Sql.Append("\r\n   and ( otc_master.keika_sochi_ymd = '' or  otc_master.keika_sochi_ymd >= to_char(timestamp 'now','YYYYMMDD') ) ");

                //decimal wk_dec = 0m;
                if (decimal.TryParse(search_key, out wk_dec))
                {
                    b2Com.PgLib.Sql.Append("\r\n and ( otc_master.gtin_code like '" + search_key + "%' ");
                    b2Com.PgLib.Sql.Append("\r\n       or otc_master.jan_code like '" + search_key + "%' ");
                    b2Com.PgLib.Sql.Append("\r\n       or otc_master.yj_code like '" + search_key + "%'  )");
                }
                else
                {
                    if (!string.IsNullOrEmpty(search_key))
                    {
                        b2Com.PgLib.Sql.Append("\r\n and ( otc_master.yakuhin_mei like '" + search_key + "%' ");
                        b2Com.PgLib.Sql.Append("\r\n    or otc_master.yakuhin_kana like '" + search_key + "%' ");
                        b2Com.PgLib.Sql.Append("\r\n    or otc_master.yj_code like '" + search_key + "%' )");
                    }
                }


                b2Com.PgLib.Sql.Append("\r\n order by 薬品名カナ ");

　              b2Com.PgLib.Sql.Append("\r\n limit 5000 ");

　              b2Com.PgLib.Sql.Append("\r\n ) as YAKUHIN ");
　              b2Com.PgLib.Sql.Append("\r\n  left outer join ");
　              b2Com.PgLib.Sql.Append("\r\n ( ");
　              b2Com.PgLib.Sql.Append("\r\n 			SELECT * FROM crosstab ");
　              b2Com.PgLib.Sql.Append("\r\n 			(' ");
　              b2Com.PgLib.Sql.Append("\r\n 			select A.gtin_code, A.tanaban_code,B.tanaban_mei ");
　              b2Com.PgLib.Sql.Append("\r\n 			  from tanaban_syouhin A ");
　              b2Com.PgLib.Sql.Append("\r\n 			inner join tanaban_master  B  on  A.tanaban_code = B.tanaban_code ");
　              b2Com.PgLib.Sql.Append("\r\n 			group by A.yakkyoku_code, A.gtin_code, A.tanaban_code,B.tanaban_mei ");
　              b2Com.PgLib.Sql.Append("\r\n 			order by A.gtin_code,A.tanaban_code ");
　              b2Com.PgLib.Sql.Append("\r\n 			') ");
　              b2Com.PgLib.Sql.Append("\r\n 			 AS tana(gtin character(14),  ");
　              b2Com.PgLib.Sql.Append("\r\n 			         tana1 character varying, tana2 character varying, tana3 character varying, tana4 character varying, tana5 character varying) ");
                b2Com.PgLib.Sql.Append("\r\n  ) AS TANAINFO on YAKUHIN.ＧＴＩＮ販売 = TANAINFO.gtin ");


                oAdp = new NpgsqlDataAdapter(b2Com.PgLib.Sql.ToString(),
                              b2Com.PgLib.Connection);


                //データセットをクリア
                if (dSet.Tables.Count > 0)
                {
                    int i;
                    i = dSet.Tables.Count;
                    for (int j = 0; j < i; j++)
                    {
                        if (dSet.Tables[j].TableName == YAKUHIN)
                        {
                            dSet.Tables.Remove(YAKUHIN);
                            break;
                        }
                    }
                }
                //データセットに読み込む
                oAdp.Fill(dSet, YAKUHIN);

                return true;
            }
            catch (Exception ex)
            {
                b2Com.ShowErrMsg(ex);
                return false;
            }
        }


        /// <summary>
        /// キースルー設定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frm_Kensaku_Syouhin_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                switch (e.KeyCode)
                {
                    case Keys.Escape:
                    case Keys.F1:
                    case Keys.F2:
                    case Keys.F3:
                    case Keys.F4:
                    case Keys.F5:
                    case Keys.F6:
                    case Keys.F7:
                    case Keys.F8:
                    case Keys.F9:
                    case Keys.F10:
                    case Keys.F11:
                    case Keys.F12:
                        e.Handled = true;   //他コントロールへ渡らない様に、ここで終了とする。
                        break;

                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                b2Com.ShowErrMsg(ex);
            }

        }


        /// <summary>
        /// 検索ダイアログの表示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fpSMain_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                // Ctrl+Fキー
                if ((e.KeyCode == Keys.F) && (e.Control == true))
                {
                    if (fpSMain.SearchDialog == null)
                    {
                        // 検索ダイアログを表示する
                        fpSMain.SearchWithDialog("");
                    }
                    else
                    {
                        // 検索ダイアログをアクティブにする
                        fpSMain.SearchDialog.Activate();
                    }
                }

                return;
            }
            catch
            {
                return;
            }
        }


        /// <summary>
        /// 検索文字列フィールドでEnterキーで実行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void search_text_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                // Enterキー
                if (e.KeyCode == Keys.Enter)
                {
                    kensaku_syori();
                }

                return;
            }
            catch
            {
                return;
            }

        }

        /// <summary>
        /// 明細行でダブルクリック　行選択確定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fpSMain_CellDoubleClick(object sender, CellClickEventArgs e)
        {
            btn_ok.PerformClick();
        }

    }
}
