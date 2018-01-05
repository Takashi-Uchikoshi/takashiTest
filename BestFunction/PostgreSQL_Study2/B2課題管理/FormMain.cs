using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
//
using System.Data.Linq;             //
using System.Data.Entity;           //
//using System.Transactions;          //

using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//
using FarPoint.Win;
using FarPoint.Win.Spread;
using FarPoint.Win.Spread.Model;
using FarPoint.Win.Spread.CellType;
//
//using Oracle.DataAccess.Client;
using Npgsql;
using NpgsqlTypes;
using B2.Com;


#region 修正履歴
/*
 * 20171013 打越 KeyPress、KeyDown、KeyUpイベントをメインフォームを通過するように設定
*/
#endregion

namespace B2
{
    public partial class FormMain : Form
    {
        #region ローカル連番定義
        //******************************************************************************
        // ローカル連番定義
        //******************************************************************************

        private Entitis_Model dbc;
        //private 課題管理 allData;

        //==============================================================================
        /// <summary>fpSMainの列インデックス</summary>
        //==============================================================================
        //private enum mainColum
        //{
        //    PJ_NO = 0,
        //    PJ_NAME,
        //    ORDER_NO,
        //    USER_NAME,
        //    MAKER_NAME,
        //    MAKER_PARSON,
        //    MEMO,
        //    KANRYOU,
        //    SEQ_NO,
        //    KANRI_NO,
        //    BUNRUI,
        //    KINOU,
        //    KANRI_NAIYOU,
        //    SYOCHI_NAIYOU,
        //    SYUBETU,
        //    JYOUTAI,
        //    HASSEI_F,
        //    GENIN_F,
        //    GENIN_KUBUN,
        //    GENIN_SYOUSAI,
        //    JYUUYOUDO,
        //    HASSEIBI,
        //    YOTEIBI,
        //    KANRYOUBI,
        //    SHITEKISYA,
        //    SYOCHISYA,
        //    ZESEIKUBUN,
        //    CYUUSYUTU_G,
        //    TOUROKUSYA,
        //    TOUROKUBI,
        //    YOTEIKOUSUU,
        //    JISSEKIKOUSUU,
        //    KAIHATUCYAKUSYUBI,
        //    KAIHATUKANRYOUBI,
        //    SHINCYOKURITU,
        //    BIKOU
        //}

        private enum mainColum2
        {
            //ID = 0,
            PJ_NO = 0 ,
            PJ_KANRI,
            PJ_NAME,
            SEQ_NO,
            KANRI_NO,
            BUNRUI,
            KINOU,
            KANRI_NAIYOU,
            SYOCHI_NAIYOU,
            SYUBETU,
            JYOUTAI,
            HASSEI_F,
            GENIN_F,
            GENIN_KUBUN,
            GENIN_SYOUSAI,
            JYUUYOUDO,
            HASSEIBI,
            YOTEIBI,
            KANRYOUBI,
            SHITEKISYA,
            SYOCHISYA,
            ZESEIKUBUN,
            CYUUSYUTU_G,
            TOUROKUSYA,
            TOUROKUBI,
            YOTEIKOUSUU,
            JISSEKIKOUSUU,
            KAIHATUCYAKUSYUBI,
            KAIHATUKANRYOUBI,
            SHINCYOKURITU,
            BIKOU
        }

        //列の属性定義
        List<fspColumdata> kadai_list = new List<fspColumdata>
        {
            new fspColumdata(){colum_position = (int)mainColum2.PJ_NO, 
                               colum_width_size = 150,
                               colum_label = "プロジェクト番号",
                               hyouji_umu=true, 
                               font_name="MS UI Gothic",
                               font_size=8,  
                               suicyoku_ichi=0,
                               suihei_ichi=0,
                               cellType=0,  
                               ketasu=3,     
                               syousuu=0,      
                               ketakugiri=false,  
                               orikaeshi=false },
            
            new fspColumdata(){colum_position = (int)mainColum2.PJ_KANRI, 
                               colum_width_size = 50,
                               colum_label = "プロジェクト名管理表",
                               hyouji_umu=false},

            new fspColumdata(){colum_position = (int)mainColum2.PJ_NAME, 
                               colum_width_size = 200,
                               colum_label = "プロジェクト名",
                               hyouji_umu=true, 
                               font_name="MS UI Gothic",
                               font_size=8,  
                               suicyoku_ichi=1,
                               suihei_ichi=1,
                               cellType=0 },

            new fspColumdata(){colum_position = (int)mainColum2.SEQ_NO, 
                               colum_width_size = 50,
                               colum_label = "連番",
                               hyouji_umu=true, 
                               font_name="MS UI Gothic",
                               font_size=8,  
                               suicyoku_ichi=2,
                               suihei_ichi=2,
                               cellType=0 }
};


        const int rows_hight = 40;          //行の高さ
        const string KADAI_TB = "KADAI_TB";
        #endregion

        

        #region ローカル変数定義
        //******************************************************************************
        // ローカル変数定義
        //******************************************************************************

        //------------------------------------------------------------------------------
        // コンストラクタ引数
        //------------------------------------------------------------------------------
        /// <summary>上位からの共通パラメータ</summary>
        public clsB2Com PhCom;

        //------------------------------------------------------------------------------
        // データセット
        //------------------------------------------------------------------------------
        DS_Project dsP = new DS_Project();
        DS_Kadai_Data dsKadai = new DS_Kadai_Data();
        DataSet dSet = new DataSet(KADAI_TB);
        //NpgsqlDataAdapter oAdp;
        NpgsqlDataAdapter oAdp;

        #endregion

        #region コンストラクタ
        //**********************************************************************
        /// <summary>
        /// コンストラクタ
        /// </summary>
        //**********************************************************************
        public FormMain()
        {
            InitializeComponent();

            //ラムダ式のテスト　this.Click += (s, e) => { MessageBox.Show(((MouseEventArgs)e).Location.ToString()); };
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="PHCommon">共通パラメータ</param>
        public FormMain(clsB2Com PHCommon)
        {
            InitializeComponent();

            //--------------------------------------
            // 共通パラメータをセット
            //--------------------------------------
            PhCom = PHCommon;

        }

        //**********************************************************************
        /// <summary>
        /// フォームLoad
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //**********************************************************************
        private void FormMain_Load(object sender, EventArgs e)
        {
            try
            {
                //20171013 ADD
                this.KeyPreview = true;
            }
            catch (Exception ex)
            {
                PhCom.ShowErrMsg(ex);
            }
        }

        //**********************************************************************
        /// <summary>
        /// フォームShown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //**********************************************************************
        private void FormMain_Shown(object sender, EventArgs e)
        {
            try
            {
                //--------------------------------------
                // 初期化
                //--------------------------------------
                mfnc_setInitialize();

                //--------------------------------------
                // 取引先コンボボックス初期化
                //--------------------------------------
                //コンボボックス用のデータ取得
                getComboDs();
                gcComboBox1.Init(PhCom, "プロジェクト名管理表", "プロジェクト番号", "プロジェクト名");

                gcComboBox1.SelectedIndex = 0;

                this.Activate();
            }
            catch (Exception ex)
            {
                PhCom.ShowErrMsg(ex);
            }
        }

        //// コンボボックス用のデータソースをデータベースから取得
        private void getComboDs()
        {
            DataRow sRow;

            //---------------テーブルのクリア------------------
            dsP.PROJECT.Clear();
            dsP.PJ.Clear();

            //---------取引先情報　データベースからの読み込み------------------
            PhCom.PostLib.SQLClear();
            //   PhCom.PostLib.SQL.Append(" select \"プロジェクト番号\", \"プロジェクト名\", \"受注管理番号\",\"顧客名\", \"発注元名\", \"発注元担当者\", \"備考\" \r\n");
            //   PhCom.PostLib.SQL.Append(" from \"プロジェクト管理表\" \r\n");
            //   PhCom.PostLib.SQL.Append(" order by  \"プロジェクト番号\" \r\n");

            PhCom.PostLib.SQL.Append(" SELECT \"プロジェクト番号\", \"プロジェクト名\", \"受注管理番号\", \"顧客名\", \"発注元名\", \"発注元担当者\", \"備考\" \r\n");
            PhCom.PostLib.SQL.Append("   FROM \"プロジェクト名管理表\" \r\n");

            using (NpgsqlDataReader lOraDSRead = PhCom.PostLib.SelectSQL_NoCache())
            {
                if (lOraDSRead != null)
                {
                    int index = 0;
                    sRow = dsP.PJ.NewRow();
                    sRow["CODE"] = "00";
                    sRow["NAME"] = "";
                    sRow["INDEX"] = index;
                    dsP.PJ.Rows.Add(sRow);
                    index++;

                    while (lOraDSRead.Read())
                    {
                        // データセットへ表示データをセット
                        sRow = dsP.PROJECT.NewRow();
                        sRow["PJ_NO"] = lOraDSRead["プロジェクト番号"];
                        sRow["PJ_NAME"] = lOraDSRead["プロジェクト名"].ToString();
                        sRow["ORDER_NO"] = lOraDSRead["受注管理番号"].ToString();
                        sRow["USER_NAME"] = lOraDSRead["顧客名"].ToString();
                        sRow["MAKER_NAME"] = lOraDSRead["発注元名"].ToString();
                        sRow["MAKER_PARSON"] = lOraDSRead["発注元担当者"].ToString();
                        sRow["MEMO"] = lOraDSRead["備考"].ToString();
                        dsP.PROJECT.Rows.Add(sRow);

                        sRow = dsP.PJ.NewRow();
                        sRow["CODE"] = lOraDSRead["プロジェクト番号"];
                        sRow["NAME"] = lOraDSRead["プロジェクト名"];
                        sRow["INDEX"] = index;
                        dsP.PJ.Rows.Add(sRow);
                        index++;
                    }
                    lOraDSRead.Close();
                }
            }

            ////inputman ComboBox
            //gcComboBox1.DataSource = dsP.PJ;
            //gcComboBox1.ListColumns[0].Width = 28;
            //gcComboBox1.ListColumns[1].Width = 240;
            //gcComboBox1.ListColumns[2].Visible = false;
            //gcComboBox1.ListHeaderPane.Visible = false;
            //gcComboBox1.DropDown.AutoWidth = true;
            //gcComboBox1.TextSubItemIndex = 1;
            //// 検索モード
            ////gcComboBox1.AutoComplete.MatchingMode = GrapeCity.Win.Editors.AutoCompleteMatchingMode.MatchAll;
            //gcComboBox1.AutoComplete.MatchingMode = GrapeCity.Win.Editors.AutoCompleteMatchingMode.AmbiguousMatchAll;

        }

        /// <summary>
        /// コードからインデックス値を取得
        /// </summary>
        /// <param name="CODE"></param>
        /// <returns></returns>
        private int getCnvCodeToIndex(string CODE)
        {
            int rc = 0;
            //DataRow[] findRow = dsP.PJ.Select("CODE='" + CODE.ToString() + "'");
            //foreach (DataRow sRow in findRow)
            //{
            //    rc = (int)sRow["INDEX"];
            //}

            //return rc;
            return gcComboBox1.getIndex(CODE);
        }

        /// <summary>
        /// インデックス値からコードを取得
        /// </summary>
        /// <param name="INDEX"></param>
        /// <returns></returns>
        private string getCnvIndexToCode(int INDEX)
        {
            string str_rc = string.Empty;
            if (INDEX < 0) return str_rc;

            //DataTable tbl = dsP.PJ;
            //DataRow cus_row = tbl.Rows[INDEX];
            //str_rc = cus_row["CODE"].ToString();

            //return str_rc;
            return gcComboBox1.getCode(INDEX);
        }


        private void gcComboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            //Enterキーが押された時
            switch (e.KeyCode)
            {
                // エンターキー
                case Keys.Enter:
                    e.Handled = true;

                    if (gcComboBox1.SelectedIndex < 0) return;

                    decimal p_no = decimal.Parse(getCnvIndexToCode(gcComboBox1.SelectedIndex));
                    setPorjectInfo(p_no);

                　　//スプレッド初期化
                    mfnc_setInitialize();

                    break;
            }

        }
        private void gcComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(gcComboBox1.SelectedIndex < 0) return;

            decimal p_no = decimal.Parse(getCnvIndexToCode(gcComboBox1.SelectedIndex));
            setPorjectInfo(p_no);

            //スプレッド初期化
            mfnc_setInitialize();

        }

        private void setPorjectInfo(decimal p_no)
        {
            txt_pj_no.Text = "";
            txt_pj_name.Text = "";
            txt_order.Text = "";
            txt_user_name.Text = "";
            txt_maker.Text = "";
            txt_m_Person.Text = "";
            txt_bikou.Text = "";

            DataRow[] findRow = dsP.PROJECT.Select("PJ_NO='" + p_no.ToString() + "'");
            foreach (DataRow sRow in findRow)
            {
                txt_pj_no.Text = p_no.ToString();
                txt_pj_name.Text = DBNull.Value.Equals(sRow["PJ_NAME"]) ? "" : sRow["PJ_NAME"].ToString();
                txt_order.Text = DBNull.Value.Equals(sRow["ORDER_NO"]) ? "" : sRow["ORDER_NO"].ToString();
                txt_user_name.Text = DBNull.Value.Equals(sRow["USER_NAME"]) ? "" : sRow["USER_NAME"].ToString();
                txt_maker.Text = DBNull.Value.Equals(sRow["MAKER_NAME"]) ? "" : sRow["MAKER_NAME"].ToString();
                txt_m_Person.Text = DBNull.Value.Equals(sRow["MAKER_PARSON"]) ? "" : sRow["MAKER_PARSON"].ToString();
                txt_bikou.Text = DBNull.Value.Equals(sRow["MEMO"]) ? "" : sRow["MEMO"].ToString();
                break;
            }

        }

        #endregion

        #region イベント定義
        //******************************************************************************
        // イベント定義
        //******************************************************************************

        //==============================================================================
        // メインフォーム
        //==============================================================================

        //**********************************************************************
        /// <summary>
        /// フォームFormClosing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //**********************************************************************
        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show(this.Text + "を終了します。\r\nよろしいですか？", "確認", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) != DialogResult.Yes)
            {
                e.Cancel = true;
                return;
            }
        }

        //**********************************************************************
        /// <summary>
        /// フォームKeyDown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //**********************************************************************
        private void FormMain_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                mfnc_key_furiwake(e.KeyCode);

                //20171013 ADD S
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
                //20171013 ADD E
            }
            catch (Exception ex)
            {
                PhCom.ShowErrMsg(ex);
            }
        }

        //==============================================================================
        // ボタン制御
        //==============================================================================

        //**********************************************************************
        /// <summary>
        /// 『閉じる』ボタンClick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //**********************************************************************
        private void btn_ESC_Click(object sender, EventArgs e)
        {
            try
            {
                //--------------------------------------
                // ※終了確認はFormClosingにて実施
                //--------------------------------------
                this.Close();
            }
            catch (Exception ex)
            {
                PhCom.ShowErrMsg(ex);
            }
        }

        private void btn_Select_Click(object sender, EventArgs e)
        {
            decimal pj_no = decimal.Parse(getCnvIndexToCode(gcComboBox1.SelectedIndex));
            if (pj_no == 0)
            {
                MessageBox.Show("プロジェクトが選択されていません。", this.Text);
                gcComboBox1.Focus();
                return;
            }

            //スプレッド初期化
            mfnc_setInitialize();

            ////列幅設定
            //mfnc_SetSpreadInfo();

            //データの取得
            //mfnc_dBselect_Kadai(pj_no);
            //スプレッドにデータセットをセット
            //fpSMain.ActiveSheet.DataSource = dsKadai.KADAI;

 
//+-------------------------------------            
            ////データの取得
            //dBselect_Kadai(pj_no);

            //if (dSet.Tables[KADAI_TB].Rows.Count <= 0)
            //{
            //    MessageBox.Show("指定のデータが存在しませんでした。", this.Text);
            //    // return;
            //}

            ////スプレッドにデータセットをセット
            //fpSMain.ActiveSheet.DataSource = dSet.Tables[KADAI_TB];

            try
            {
                //データの接続　本当はShown時とかに一回のみで良い。
                dbc = new Entitis_Model(PhCom);

     //           DbContextTransaction trn = dbc.Database.BeginTransaction();
     //           trn.Commit();
     //           trn.Rollback();     
                
                //NG 課題管理BindingSource.DataSource = dbc.課題管理.Where(w => w.プロジェクト番号 == pj_no).ToList();
                //NG fpSMain.ActiveSheet.DataSource = dbc.課題管理.Where(w => w.プロジェクト番号 == pj_no).ToList();

                //データの読込
                dbc.課題管理.Where(w => w.プロジェクト番号 == pj_no).OrderBy(w =>w.連番).Load();
                //スプレッドにデータセットをセット
                課題管理BindingSource.DataSource = dbc.課題管理.Local;
                
                //データの読込
                //              dbc.プロジェクト名管理表.Where(w => w.プロジェクト番号 == pj_no).Load();
                //スプレッドにデータセットをセット
                //              プロジェクト名管理表BindingSource.DataSource = dbc.プロジェクト名管理表.Local;
                //  MessageBox.Show("PJ-NAME:{0}", dbc.課題管理.プロジェクト名管理表.プロジェクト名);

                
                // 表示のみならOK　fpSMain.ActiveSheet.DataSource = dbc.課題管理.Local;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
//+-------------------------------------            

            
            //列幅設定
            mfnc_SetSpreadInfo();

            //行の高さを設定
            //int rows_count = fpSMain.ActiveSheet.RowCount;
            //for (int i = 0; i < rows_count; i++)
            //{
            //    // 最も高さのあるテキストの高さに設定します
            //    fpSMain.ActiveSheet.Rows[i].Height = (rows_hight > fpSMain.ActiveSheet.GetPreferredRowHeight(i) ? rows_hight : fpSMain.ActiveSheet.GetPreferredRowHeight(i));
            //}
            clsSpread.SetRowsHeight(fpSMain.ActiveSheet);

            //ボタン制御        閉る  検索  編集  行追加 行挿入 更新  行削除  印刷  Excel ﾌﾟﾛｼﾞｪｸﾄ  印刷2    --     --     --
            mfnc_setBtnEnabled(true, true, true, false, false, false, false, true, true, true, true, false, false);

            // 編集終了
            //fpSmain.Refresh();
            fpSMain.ResumeLayout(true);

            // Spread キーの透過設定　
            InitDispInputMap(fpSMain);

            //// 編集ロック 行
            //fpSMain.ActiveSheet.Rows[row].Locked = true;

            //// 直接編集不可とする。
            //fpSmain.EditMode = false;

            // 読み取り専用
            fpSMain.ActiveSheet.OperationMode = FarPoint.Win.Spread.OperationMode.ReadOnly; 

            
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
        
        private void btn_Edit_Click(object sender, EventArgs e)
        {
            // 直接編集可とする。
            //fpSMain.EditMode = true;

            // 読み取り専用解除
            fpSMain.ActiveSheet.OperationMode = FarPoint.Win.Spread.OperationMode.Normal;
            //課題管理BindingSource
          

            //                 閉る  検索  編集  行追加 行挿入 更新 行削除 印刷  Excel　ﾌﾟﾛｼﾞｪｸﾄ     --     --     --     --
            mfnc_setBtnEnabled(true, true, false, true, true, true, true, true, true, true, false, false, false);
        }

        //行追加
        private void btn_AddRow_Click(object sender, EventArgs e)
        {
            int index;

            //dbc.課題管理.Add(new 課題管理());

            decimal pj_no = decimal.Parse(txt_pj_no.Text.ToString());
            //連番取得
            decimal seq_no = get_Seq_No(pj_no);
            decimal seq_no2 = get_Seq_No2(pj_no);
            if (seq_no2 > seq_no)
            {
                seq_no = seq_no2;
            }

            if(fpSMain.ActiveSheet.RowCount > 0)
            {
                index = fpSMain.ActiveSheet.RowCount - 1;

                ////行追加 最終行の後に追加します
                //fpSMain.ActiveSheet.Rows.Add(fpSMain.ActiveSheet.RowCount, 1);

                //index = fpSMain.ActiveSheet.RowCount - 1;
                //fpSMain.ActiveSheet.Cells[index, (int)mainColum2.PJ_NO].Value = pj_no;
                //fpSMain.ActiveSheet.Cells[index, (int)mainColum2.SEQ_NO].Value = (seq_no + 1);
                //fpSMain.ActiveSheet.Rows[index].Height = rows_hight;

                ////追加行を下段付近に表示
                //fpSMain.ShowRow(0, index, FarPoint.Win.Spread.VerticalPosition.Nearest);  // Bottom か　Nearestka?, Center

                var data = dbc.課題管理.Create();
                data.プロジェクト番号 = int.Parse(pj_no.ToString());
//                data.PjId = int.Parse(pj_no.ToString());
                data.連番 = (seq_no + 1);
               // dbc.課題管理.Add(data);
                課題管理BindingSource.Add(data);
                課題管理BindingSource.ResetBindings(true);
               // fpSMain.ActiveSheet.DataSource = dbc.課題管理;

                //fpSMain.Show();
                //列幅設定
                mfnc_SetSpreadInfo();

                //行の高さを設定
                clsSpread.SetRowsHeight(fpSMain.ActiveSheet);

            }
            else
            {
                index = 0;

                ////行追加 最終行の後に追加します
                //fpSMain.ActiveSheet.Rows.Add(fpSMain.ActiveSheet.RowCount, 1);

                //fpSMain.ActiveSheet.Cells[index, (int)mainColum2.PJ_NO].Value = pj_no;
                //fpSMain.ActiveSheet.Cells[index, (int)mainColum2.SEQ_NO].Value = (seq_no + 1);
                //fpSMain.ActiveSheet.Rows[index].Height = rows_hight;

                var data = dbc.課題管理.Create();
                data.プロジェクト番号 = int.Parse(pj_no.ToString());
//                data.PjId = int.Parse(pj_no.ToString());
                data.連番 = (seq_no + 1);

            //    dbc.課題管理.Add(data);
                課題管理BindingSource.Add(data);
                課題管理BindingSource.ResetBindings(true);

                //fpSMain.ActiveSheet.DataSource = dbc.課題管理;

                //fpSMain.Show();
                //列幅設定
                mfnc_SetSpreadInfo();

                //行の高さを設定
                clsSpread.SetRowsHeight(fpSMain.ActiveSheet);

            }



        }

        //挿入 選択行の前に挿入
        private void btn_InsertRow_Click(object sender, EventArgs e)
        {
            int index;

            decimal pj_no =  decimal.Parse(txt_pj_no.Text.ToString());
            //連番取得
            decimal seq_no = get_Seq_No(pj_no);
            decimal seq_no2 = get_Seq_No2(pj_no);
            if (seq_no2 > seq_no)
            {
                seq_no = seq_no2;
            }

            if (fpSMain.ActiveSheet.RowCount > 0)
            {
                index = fpSMain.ActiveSheet.ActiveRowIndex;

                //行追加 選択行の前に追加します
                fpSMain.ActiveSheet.Rows.Add(index, 1);

                //index += 1;
                fpSMain.ActiveSheet.Cells[index, (int)mainColum2.PJ_NO].Value = pj_no;
                fpSMain.ActiveSheet.Cells[index, (int)mainColum2.SEQ_NO].Value = (seq_no + 1);
                fpSMain.ActiveSheet.Rows[index].Height = rows_hight;
              
                //挿入行を中央付近に表示
                fpSMain.ShowRow(0, index, FarPoint.Win.Spread.VerticalPosition.Center);  // Bottom か　Nearestka?, Center
            }
            else
            {
                index = 0;

                //行追加 選択行の前に追加します
                fpSMain.ActiveSheet.Rows.Add(index, 1);

                fpSMain.ActiveSheet.Cells[index, (int)mainColum2.PJ_NO].Value = pj_no;
                fpSMain.ActiveSheet.Cells[index, (int)mainColum2.SEQ_NO].Value = (seq_no + 1);
                fpSMain.ActiveSheet.Rows[index].Height = rows_hight;
            }

            //行の高さを設定
            clsSpread.SetRowsHeight(fpSMain.ActiveSheet);

        }
        
        //同一プロジェクト内の最大連番の取得
        private decimal get_Seq_No(decimal Pj_No)
        {
            decimal Seq_no = 0;

            PhCom.PostLib.SQL.Clear();

            PhCom.PostLib.SQL.Append(" select MAX(連番) as SEQ_NO   \r\n");
            PhCom.PostLib.SQL.Append(" from 課題管理   \r\n");
            PhCom.PostLib.SQL.Append(" where プロジェクト番号 = '" + Pj_No + "'  \r\n");
            PhCom.PostLib.SQL.Append(" group by プロジェクト番号   \r\n");


            using (NpgsqlDataReader lOraDSRead = PhCom.PostLib.SelectSQL_NoCache())
            {
                if (lOraDSRead != null)
                {
                    while (lOraDSRead.Read())
                    {
                        // データセットへ表示データをセット
                        Seq_no = decimal.Parse(lOraDSRead["SEQ_NO"].ToString());
                        break;
                    }
                    lOraDSRead.Close();
                }
            }

            return Seq_no;
        }

        //同一プロジェクト内の最大連番の取得 データセット上を検索
        private decimal get_Seq_No2(decimal Pj_No)
        {
            return fpSMain.ActiveSheet.RowCount;
            //decimal Seq_no = 0;
            //if( dSet.Tables[KADAI_TB].Rows.Count == 0)
            //{
            //    return Seq_no;
            //}

            //DataRow[] findRow = dSet.Tables[KADAI_TB].Select("","連番 desc");
            //foreach (DataRow sRow in findRow)
            //{
            //    Seq_no = decimal.Parse(sRow["連番"].ToString());
            //    break;
            //}

            //return Seq_no;
        }

        //データの更新
        private void btn_Update_Click(object sender, EventArgs e)
        {
            try
            {
                //更新
             //   oAdp.Update(dSet.Tables[KADAI_TB]);

                //int i = 0;
                //foreach(var data in dbc.課題管理)
                //for (int i = 0; i < fpSMain.ActiveSheet.RowCount; i++)
                //{
                //    var data = dbc.課題管理.Create();
                //    data.プロジェクト番号 = decimal.Parse(fpSMain.ActiveSheet.Cells[i, (int)mainColum2.PJ_NO].Text);
                //    data.連番 = decimal.Parse(fpSMain.ActiveSheet.Cells[i, (int)mainColum2.SEQ_NO].Text);
                //    data.分類 = fpSMain.ActiveSheet.Cells[i, (int)mainColum2.BUNRUI].Text;
                //    data.機能名称 = fpSMain.ActiveSheet.Cells[i, (int)mainColum2.KINOU].Text;
                //    dbc.課題管理.Add(data);
                //    //i++;
                //   // if (i >= fpSMain.ActiveSheet.RowCount) break;
                //}

                //課題管理BindingSource.EndEdit();
          
                dbc.SaveChanges();


                //確定
                //   PhCom.PostLib.ExecuteSQL("commit");

                //スプレッド初期化
                mfnc_setInitialize();
                
                //再検索表示
                btn_Select.PerformClick();

            }
            catch (NpgsqlException ex)
            {
                PhCom.ShowErrMsg(ex);
                return;
            }
            catch (Exception ex)
            {
                PhCom.ShowErrMsg(ex);
                return ;
            }
        }

        //選択行の削除
        private void btn_Delete_Click(object sender, EventArgs e)
        {
            int index = fpSMain.ActiveSheet.ActiveRowIndex;
            fpSMain.ActiveSheet.Rows.Remove(index, 1);
        }

        //印刷 PDF
        private void btn_Print_Click(object sender, EventArgs e)
        {
            try
            {   
                //--------------------------------------
                //PDF処理
                //--------------------------------------
                string filter = "PDF files(*.PDF)|*.PDF"; ;

                string fn = "";
                // ファイル保存ダイアログ起動
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = filter;
                    sfd.FileName = this.Text.ToString() + "_" + DateTime.Now.ToString("yyyyMMdd_HHmmss");
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        fn = sfd.FileName;
                    }
                    else
                    {
                        return;
                    }
                }

                //fpSMain.ActiveSheet.PrintInfo.Header = "/r/fz\"9\"印刷日時：/dl/ts";
                fpSMain.ActiveSheet.PrintInfo.Header = "/r/fz\"9\"印刷日時：/dl/ts" + Environment.NewLine + gcComboBox1.Text.ToString();

                //fpSpread1.ActiveSheet.PrintInfo.Footer = "/rグレープシティ株式会社";
                fpSMain.ActiveSheet.PrintInfo.Footer = "";

                //◆PDF出力
                fpSMain.ActiveSheet.PrintInfo.PrintToPdf = true;
                fpSMain.ActiveSheet.PrintInfo.Orientation = FarPoint.Win.Spread.PrintOrientation.Landscape;
                fpSMain.ActiveSheet.PrintInfo.PaperSize = new System.Drawing.Printing.PaperSize("A3", 1169, 1654);
                fpSMain.ActiveSheet.PrintInfo.PdfFileName = fn;
                fpSMain.PrintSheet(fpSMain.ActiveSheetIndex);

            }
            catch (Exception ex)
            {
                PhCom.ShowErrMsg(ex);
            }


        }

        private void btn_Print2_Click(object sender, EventArgs e)
        {
            try
            {
                //--------------------------------------
                //PDF処理
                //--------------------------------------
                string filter = "PDF files(*.PDF)|*.PDF"; ;

                string fn = "";
                // ファイル保存ダイアログ起動
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = filter;
                    sfd.FileName = this.Text.ToString() + "_" + DateTime.Now.ToString("yyyyMMdd_HHmmss");
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        fn = sfd.FileName;
                    }
                    else
                    {
                        return;
                    }
                }

                //// 列の非表示設定
                fpSMain.ActiveSheet.Columns[(int)mainColum2.PJ_NO].Visible = false;
                fpSMain.ActiveSheet.Columns[(int)mainColum2.JYOUTAI].Visible = false;
                fpSMain.ActiveSheet.Columns[(int)mainColum2.HASSEI_F].Visible = false;
                fpSMain.ActiveSheet.Columns[(int)mainColum2.GENIN_F].Visible = false;
                fpSMain.ActiveSheet.Columns[(int)mainColum2.GENIN_KUBUN].Visible = false;
                fpSMain.ActiveSheet.Columns[(int)mainColum2.GENIN_SYOUSAI].Visible = false;
                fpSMain.ActiveSheet.Columns[(int)mainColum2.JYUUYOUDO].Visible = false;
                fpSMain.ActiveSheet.Columns[(int)mainColum2.ZESEIKUBUN].Visible = false;
                fpSMain.ActiveSheet.Columns[(int)mainColum2.CYUUSYUTU_G].Visible = false;
                fpSMain.ActiveSheet.Columns[(int)mainColum2.YOTEIKOUSUU].Visible = false;
                fpSMain.ActiveSheet.Columns[(int)mainColum2.JISSEKIKOUSUU].Visible = false;
                fpSMain.ActiveSheet.Columns[(int)mainColum2.KAIHATUCYAKUSYUBI].Visible = false;
                fpSMain.ActiveSheet.Columns[(int)mainColum2.KAIHATUKANRYOUBI].Visible = false;
                fpSMain.ActiveSheet.Columns[(int)mainColum2.SHINCYOKURITU].Visible = false;
                fpSMain.ActiveSheet.Columns[(int)mainColum2.BIKOU].Visible = false;


                ////列幅,他の設定
                ////fpSMain.ActiveSheet.Columns[(int)mainColum2.SEQ_NO].Width = (float)40;
                ////fpSMain.ActiveSheet.Columns[(int)mainColum2.KANRI_NO].Width = (float)40;
                //fpSMain.ActiveSheet.Columns[(int)mainColum2.BUNRUI].Width = (float)60;
                //fpSMain.ActiveSheet.Columns[(int)mainColum2.KINOU].Width = (float)180;
                //fpSMain.ActiveSheet.Columns[(int)mainColum2.KANRI_NAIYOU].Width = (float)480;
                //fpSMain.ActiveSheet.Columns[(int)mainColum2.SYOCHI_NAIYOU].Width = (float)480;
                ////fpSMain.ActiveSheet.Columns[(int)mainColum2.SYUBETU].Width = (float)40;
                ////fpSMain.ActiveSheet.Columns[(int)mainColum2.JYOUTAI].Width = (float)40;
                ////fpSMain.ActiveSheet.Columns[(int)mainColum2.HASSEI_F].Width = (float)40;
                ////fpSMain.ActiveSheet.Columns[(int)mainColum2.GENIN_F].Width = (float)40;
                ////fpSMain.ActiveSheet.Columns[(int)mainColum2.GENIN_KUBUN].Width = (float)40;
                ////fpSMain.ActiveSheet.Columns[(int)mainColum2.GENIN_SYOUSAI].Width = (float)40;
                ////fpSMain.ActiveSheet.Columns[(int)mainColum2.JYUUYOUDO].Width = (float)40;
                //fpSMain.ActiveSheet.Columns[(int)mainColum2.HASSEIBI].Width = (float)70;
                //fpSMain.ActiveSheet.Columns[(int)mainColum2.YOTEIBI].Width = (float)70;
                //fpSMain.ActiveSheet.Columns[(int)mainColum2.KANRYOUBI].Width = (float)70;
                //fpSMain.ActiveSheet.Columns[(int)mainColum2.SHITEKISYA].Width = (float)70;
                //fpSMain.ActiveSheet.Columns[(int)mainColum2.SYOCHISYA].Width = (float)70;
                ////fpSMain.ActiveSheet.Columns[(int)mainColum2.ZESEIKUBUN].Width = (float)40;
                ////fpSMain.ActiveSheet.Columns[(int)mainColum2.CYUUSYUTU_G].Width = (float)70;
                //fpSMain.ActiveSheet.Columns[(int)mainColum2.TOUROKUSYA].Width = (float)70;
                //fpSMain.ActiveSheet.Columns[(int)mainColum2.TOUROKUBI].Width = (float)70;
                ////fpSMain.ActiveSheet.Columns[(int)mainColum2.YOTEIKOUSUU].Width = (float)50;
                ////fpSMain.ActiveSheet.Columns[(int)mainColum2.JISSEKIKOUSUU].Width = (float)50;
                ////fpSMain.ActiveSheet.Columns[(int)mainColum2.KAIHATUCYAKUSYUBI].Width = (float)70;
                ////fpSMain.ActiveSheet.Columns[(int)mainColum2.KAIHATUKANRYOUBI].Width = (float)70;
                ////fpSMain.ActiveSheet.Columns[(int)mainColum2.SHINCYOKURITU].Width = (float)50;
                ////fpSMain.ActiveSheet.Columns[(int)mainColum2.BIKOU].Width = (float)80;

                //fpSMain.ActiveSheet.PrintInfo.Header = "/r/fz\"9\"印刷日時：/dl/ts";
                fpSMain.ActiveSheet.PrintInfo.Header = "/r/fz\"9\"印刷日時：/dl/ts" + Environment.NewLine + gcComboBox1.Text.ToString();

                //fpSpread1.ActiveSheet.PrintInfo.Footer = "/rグレープシティ株式会社";
                fpSMain.ActiveSheet.PrintInfo.Footer = "";

                //◆PDF出力
                fpSMain.ActiveSheet.PrintInfo.PrintToPdf = true;
                fpSMain.ActiveSheet.PrintInfo.Orientation = FarPoint.Win.Spread.PrintOrientation.Landscape;
                fpSMain.ActiveSheet.PrintInfo.PaperSize = new System.Drawing.Printing.PaperSize("A3", 1169, 1654);
                fpSMain.ActiveSheet.PrintInfo.PdfFileName = fn;
                fpSMain.PrintSheet(fpSMain.ActiveSheetIndex);

                //検索を呼び出す
                btn_Select.PerformClick();

            }
            catch (Exception ex)
            {
                PhCom.ShowErrMsg(ex);
            }


        }
        
        
        //Excel出力
        private void btn_Excel_Click(object sender, EventArgs e)
        {
            try
            {
                //--------------------------------------
                // CSV出力処理
                //--------------------------------------
                //string　filter = "csv files(*.csv)|*.csv";

                //string fn = "";
                //// ファイル保存ダイアログ起動
                //using (SaveFileDialog sfd = new SaveFileDialog())
                //{
                //    sfd.Filter = filter;
                //    sfd.FileName = "部品管理表_" + DateTime.Now.ToString("yyyyMMdd_HHmmss");
                //    if (sfd.ShowDialog() == DialogResult.OK)
                //    {
                //        fn = sfd.FileName;
                //    }
                //    else
                //    {
                //        return;
                //    }
                //}

                //fpSMain.ActiveSheet.PrintInfo.Header = "/r/fz\"9\"印刷日時：/dl/ts";
                ////fpSpread1.ActiveSheet.PrintInfo.Footer = "/rグレープシティ株式会社";
                //fpSMain.ActiveSheet.PrintInfo.Footer = "";

                //// SPREADの機能で出力
                //// ◆CSV出力
                //fpSMain.ActiveSheet.SaveTextFile(fn, FarPoint.Win.Spread.TextFileFlags.ForceCellDelimiter, FarPoint.Win.Spread.Model.IncludeHeaders.ColumnHeadersCustomOnly, "\n", ",", "\"");

                //◆自前で出力
                mfnc_putOutCsv();

            }
            catch (Exception ex)
            {
                PhCom.ShowErrMsg(ex);
            }

        }
        //**********************************************************************
        /// <summary>
        /// CSV出力処理
        /// </summary>
        //**********************************************************************
        private void mfnc_putOutCsv()
        {
            try
            {
                //--------------------------------------
                // データが無ければ　戻る
                //--------------------------------------
                if (dSet.Tables[KADAI_TB].Rows.Count <= 0) { return; }

                clsCnvStr lclsCnvStr = new clsCnvStr();
                string lstrCsv = "";
                string lstrCsvDetail = "";
                string lstrCsvHeader = "";

                //**************************************
                // CSV出力文字作成
                //**************************************
                //--------------------------------------
                // CSVヘッダ部作成
                //--------------------------------------
                lstrCsvHeader = "";
                lstrCsvHeader += this.Text.ToString() + Environment.NewLine;
                lstrCsvHeader += "作成日付:," + DateTime.Today.ToString("yyyy/MM/dd") + Environment.NewLine;
                lstrCsvHeader += "プロジェクト名：," + gcComboBox1.Text.ToString() + Environment.NewLine + Environment.NewLine;
                for (int i = 1; i < fpSMain.ActiveSheet.ColumnHeader.Columns.Count;i++ )
                {
                    lstrCsvHeader += fpSMain.ActiveSheet.ColumnHeader.Columns[i].Label + ",";
                }
                    

                //--------------------------------------
                // CSV明細部作成
                //--------------------------------------
                //------------------
                // スプレッドの内容を取得
                //------------------
                lstrCsvDetail = clsSpread.SheetViewToCsv(fpSMain.ActiveSheet);

                //--------------------------------------
                // CSV出力文字生成
                //--------------------------------------
                //------------------
                // 明細部 列を右にずらす
                //------------------
                int lintAddColumn = 0;  // ※ずらす列数
                lstrCsvDetail = lstrCsvDetail.Trim().Replace(Environment.NewLine, Environment.NewLine + new string(',', lintAddColumn));
                lstrCsvDetail = new string(',', lintAddColumn) + lstrCsvDetail + Environment.NewLine;

                //------------------
                // ヘッダ部 ＋ 明細部
                //------------------
                lstrCsv = "";
                lstrCsv += lstrCsvHeader;
                //lstrCsv += Environment.NewLine;
                lstrCsv += lstrCsvDetail;
                //**************************************

                //--------------------------------------
                // 『名前を付けて保存』画面表示
                //--------------------------------------
                SaveFileDialog lobjSFD = new SaveFileDialog();
                lobjSFD.FileName = this.Text.ToString() + "_" + DateTime.Today.ToString("yyyyMMdd") + "_" + DateTime.Now.ToString("HHmmss") + "_" + Environment.MachineName + ".csv";
                lobjSFD.Filter = "CSVファイル(*.csv)|*.csv|すべてのファイル(*.*)|*.*";
                if (lobjSFD.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }

                //--------------------------------------
                // ファイル出力
                //--------------------------------------
                System.IO.Stream lobjStream = lobjSFD.OpenFile();
                System.IO.StreamWriter lobjStreamWriter = new System.IO.StreamWriter(lobjStream, Encoding.GetEncoding("shift_jis"));
                lobjStreamWriter.Write(lstrCsv.Trim() + Environment.NewLine);
                lobjStreamWriter.Close();
                lobjStream.Close();

                //--------------------------------------
                // メッセージ
                //--------------------------------------
                MessageBox.Show("ＣＳＶ出力を完了しました。", this.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ファイル保存に失敗しました。 " + Environment.NewLine + ex.Message);
            }
        }

        //プロジェクトの追加
        private void btn_Project_Click(object sender, EventArgs e)
        {
            //動作モード  0:追加　1:訂正
            FormProject frm = new FormProject(PhCom);
            frm.ShowDialog();

            //コンボ情報を再セット
            //getComboDs();
            gcComboBox1.Init(PhCom, "プロジェクト名管理表", "プロジェクト番号", "プロジェクト名");

        }
        #endregion

        #region ローカル関数定義
        //******************************************************************************
        // ローカル関数定義
        //******************************************************************************

        /// <summary>
        /// DB 課題管理表データの取得
        /// </summary>
        /// <returns></returns>
        private bool dBselect_Kadai(decimal pj_no)
        {
            try
            {
                PhCom.PostLib.SQL.Clear();

                PhCom.PostLib.SQL.Append("\r\n select \"プロジェクト番号\" ");
                PhCom.PostLib.SQL.Append("\r\n      , \"連番\"  ");
                PhCom.PostLib.SQL.Append("\r\n      , \"管理番号\" ");
                PhCom.PostLib.SQL.Append("\r\n      , \"分類\"  ");
                PhCom.PostLib.SQL.Append("\r\n      , \"機能名称\"  ");
                PhCom.PostLib.SQL.Append("\r\n      , \"管理内容\"  ");
                PhCom.PostLib.SQL.Append("\r\n      , \"処置内容\"  ");
                PhCom.PostLib.SQL.Append("\r\n      , \"種別\"  ");
                PhCom.PostLib.SQL.Append("\r\n      , \"状態\"  ");
                PhCom.PostLib.SQL.Append("\r\n      , \"発生フェーズ\"  ");
                PhCom.PostLib.SQL.Append("\r\n      , \"原因フェーズ\"  ");
                PhCom.PostLib.SQL.Append("\r\n      , \"原因区分\"  ");
                PhCom.PostLib.SQL.Append("\r\n      , \"原因詳細\"  ");
                PhCom.PostLib.SQL.Append("\r\n      , \"重要度\"  ");
                PhCom.PostLib.SQL.Append("\r\n      , to_char(\"発生日\",'HH') as \"発生日\" ");
                PhCom.PostLib.SQL.Append("\r\n      , to_char(\"対応予定日\",'HH') as \"対応予定日\"   ");
                PhCom.PostLib.SQL.Append("\r\n      , to_char(\"完了日\",'HH') as \"完了日\"   ");
                PhCom.PostLib.SQL.Append("\r\n      , \"指摘者\"  ");
                PhCom.PostLib.SQL.Append("\r\n      , \"処置者\"  ");
                PhCom.PostLib.SQL.Append("\r\n      , \"是正区分\"  ");
                PhCom.PostLib.SQL.Append("\r\n      , \"抽出グループ\"  ");
                PhCom.PostLib.SQL.Append("\r\n      , \"登録者\"  ");
                PhCom.PostLib.SQL.Append("\r\n      , to_char(\"登録日\",'HH') as \"登録日\"   ");
                PhCom.PostLib.SQL.Append("\r\n      , \"予定工数\"  ");
                PhCom.PostLib.SQL.Append("\r\n      , \"実績工数\"  ");
                PhCom.PostLib.SQL.Append("\r\n      , to_char(\"開発着手日\",'HH') as \"開発着手日\"   ");
                PhCom.PostLib.SQL.Append("\r\n      , to_char(\"開発完了日\",'HH') as \"開発完了日\"   ");
                PhCom.PostLib.SQL.Append("\r\n      , \"進捗率\"  ");
                PhCom.PostLib.SQL.Append("\r\n      , \"備考\"  ");
                PhCom.PostLib.SQL.Append("\r\n from \"課題管理\"  ");
                PhCom.PostLib.SQL.Append("\r\n where \"プロジェクト番号\" = '" + pj_no.ToString() + "' ");
                if (chk_tourokubi.Checked == true)
                {
                    PhCom.PostLib.SQL.Append("\r\n  and  trunc(\"発生日\",'HH')  between to_char(to_date('" + dateTimePicker1.Value.ToString("yyyy/MM/dd  HH:MM:SS") + "', 'YYYY-MM-DD HH:MM:SS'),'HH')  and  to_char(to_date('" + dateTimePicker2.Value.ToString("yyyy/MM/dd  HH:MM:SS") + "', 'YYYY-MM-DD HH:MM:SS'),'HH')");
                }

                if (chk_kanryou.Checked == true)
                {
                    if (radioButton1.Checked == true)
                    {
                        PhCom.PostLib.SQL.Append("\r\n  and  \"完了日\" is not null ");
                    }
                    else
                    {
                        PhCom.PostLib.SQL.Append("\r\n  and  \"完了日\" is null ");
                    }
                }

                if (chk_group.Checked == true)
                {
                    PhCom.PostLib.SQL.Append("\r\n  and  \"抽出グループ\" like '%" + txt_group.Text.ToString() + "%'  ");
                }

                PhCom.PostLib.SQL.Append("\r\n  ORDER BY \"管理番号\",\"連番\"  ");

                oAdp = new NpgsqlDataAdapter(PhCom.PostLib.SQL.ToString(),
                              PhCom.PostLib.Session);

             

                //2017-08-16 SQL Command 自動生成 ADD S
                NpgsqlCommandBuilder builder = new NpgsqlCommandBuilder(oAdp);
                
                //2017-08-24 ALT S create_Commandで行うように変更
                //oAdp.InsertCommand = builder.GetInsertCommand();
                //2017-08-24 ALT E

                //2017-08-23 ALT S
                //oAdp.UpdateCommand = builder.GetUpdateCommand();  
                create_Command();
                //2017-08-23 ALT E
                oAdp.DeleteCommand = builder.GetDeleteCommand();
                //2017-08-16 SQL Command 自動生成 ADD E

                if (dSet.Tables.Count > 0)
                {
                    int i;
                    i = dSet.Tables.Count;
                    for (int j = 0; j < i; j++)
                    {
                        if (dSet.Tables[j].TableName == KADAI_TB)
                        {
                            dSet.Tables.Remove(KADAI_TB);
                            break;
                        }
                    }
                }
                oAdp.Fill(dSet, KADAI_TB);

                //2017-08-16 SQL Command 自動生成 の為、コメントアウト
                //性能面では自動生成を使用しない方が良いらしい。
                //create_Command();

                return true;
            }
            catch (Exception ex)
            {
                PhCom.ShowErrMsg(ex);
                return false;
            }
        }


        //2017-08-16 SQL Command 自動生成 の為、コメントアウト 2017-08-23 復活　UPDATEのみ
        private void create_Command()
        {
            //NpgsqlDataAdapter   oAdp
            NpgsqlCommand cmd;

        //    //■Create the SelectCommand.
        //    //2017-08-16 ALT S
        //    cmd = new NpgsqlCommand("SELECT * FROM 課題管理 " +
        //                                     " WHERE プロジェクト番号 = :pjNo", PhCom.PostLib.Session);
        //    cmd.Parameters.Add("pjNO",DbType.Decimal,6,"プロジェクト番号");
        //    oAdp.SelectCommand = cmd;


            //■Create the InsertCommand.
            string ins_str = "insert into \"課題管理\" (\"プロジェクト番号\",\"連番\",\"管理番号\"," +
                                                   "\"分類\",\"機能名称\",\"管理内容\",\"処置内容\",\"種別\",\"状態\"," +
                                                   "\"発生フェーズ\",\"原因フェーズ\",\"原因区分\",\"原因詳細\"," +
                                                   "\"重要度\",\"発生日\",\"対応予定日\",\"完了日\",\"指摘者\",\"処置者\"," +
                                                   "\"是正区分\",\"抽出グループ\",\"登録者\",\"登録日\",\"予定工数\"," +
                                                   "\"実績工数\",\"開発着手日\",\"開発完了日\",\"進捗率\",\"備考\")" +
                                           "values (@pjNo,@SEQ_NO,@KANRI_NO,@BUNRUI,@KINOU," +
                                                   "@KANRI_NAIYOU,@SYOCHI_NAIYOU,@SYUBETU," +
                                                   "@JYOUTAI,@HASSEI_F,@GENIN_F,@GENIN_KUBUN," +
                                                   
//                                                   "@GENIN_SYOUSAI,@JYUUYOUDO,to_date(@HASSEIBI, 'YYYY-MM-DD'),to_date(@YOTEIBI, 'YYYY-MM-DD')," +
//                                                   "to_date(@KANRYOUBI, 'YYYY-MM-DD'),@SHITEKISYA,@SYOCHISYA,@ZESEIKUBUN," +
                                                   "@GENIN_SYOUSAI,@JYUUYOUDO,@HASSEIBI,@YOTEIBI," +
                                                   "@KANRYOUBI,@SHITEKISYA,@SYOCHISYA,@ZESEIKUBUN," +

                                                   "@CYUUSYUTU_G,@TOUROKUSYA,@TOUROKUBI,@YOTEIKOUSUU," +
                                                   "@JISSEKIKOUSUU,@KAIHATUCYAKUSYUBI,@KAIHATUKANRYOUBI," +
                                                   "@SHINCYOKURITU,@BIKOU)";

            cmd = new NpgsqlCommand(ins_str.ToString(), PhCom.PostLib.Session);
            
            cmd.Parameters.Add(new NpgsqlParameter("pjNo", NpgsqlDbType.Numeric, 6, "プロジェクト番号"));           //NUMBER
            cmd.Parameters.Add(new NpgsqlParameter("SEQ_NO", NpgsqlDbType.Numeric, 5, "連番"));                     //NUMBER
            cmd.Parameters.Add(new NpgsqlParameter("KANRI_NO", NpgsqlDbType.Numeric, 5, "管理番号"));               //NUMBER
            cmd.Parameters.Add(new NpgsqlParameter("BUNRUI", NpgsqlDbType.Varchar, 50, "分類"));                  //NVARCHAR2
            cmd.Parameters.Add(new NpgsqlParameter("KINOU", NpgsqlDbType.Varchar, 50, "機能名称"));               //NVARCHAR2
            cmd.Parameters.Add(new NpgsqlParameter("KANRI_NAIYOU", NpgsqlDbType.Varchar, 1000, "管理内容"));      //NVARCHAR2
            cmd.Parameters.Add(new NpgsqlParameter("SYOCHI_NAIYOU", NpgsqlDbType.Varchar, 2000, "処置内容"));     //NVARCHAR2
            cmd.Parameters.Add(new NpgsqlParameter("SYUBETU", NpgsqlDbType.Varchar, 6, "種別"));                  //NVARCHAR2
            cmd.Parameters.Add(new NpgsqlParameter("JYOUTAI", NpgsqlDbType.Varchar, 10, "状態"));                 //NVARCHAR2
            cmd.Parameters.Add(new NpgsqlParameter("HASSEI_F", NpgsqlDbType.Varchar, 10, "発生フェーズ"));        //NVARCHAR2
            cmd.Parameters.Add(new NpgsqlParameter("GENIN_F", NpgsqlDbType.Varchar, 10, "原因フェーズ"));         //NVARCHAR2
            cmd.Parameters.Add(new NpgsqlParameter("GENIN_KUBUN", NpgsqlDbType.Varchar, 10, "原因区分"));         //NVARCHAR2
            cmd.Parameters.Add(new NpgsqlParameter("GENIN_SYOUSAI", NpgsqlDbType.Varchar, 10, "原因詳細"));       //NVARCHAR2
            cmd.Parameters.Add(new NpgsqlParameter("JYUUYOUDO", NpgsqlDbType.Varchar, 2, "重要度"));               //VARCHAR2

            cmd.Parameters.Add(new NpgsqlParameter("HASSEIBI", NpgsqlDbType.Date, 10, "発生日"));                 //NUMBER
            cmd.Parameters.Add(new NpgsqlParameter("YOTEIBI", NpgsqlDbType.Date, 10, "対応予定日"));              //NUMBER
            cmd.Parameters.Add(new NpgsqlParameter("KANRYOUBI", NpgsqlDbType.Date, 10, "完了日"));                //NUMBER

            cmd.Parameters.Add(new NpgsqlParameter("SHITEKISYA", NpgsqlDbType.Varchar, 10, "指摘者"));            //NVARCHAR2
            cmd.Parameters.Add(new NpgsqlParameter("SYOCHISYA", NpgsqlDbType.Varchar, 10, "処置者"));             //NVARCHAR2
            cmd.Parameters.Add(new NpgsqlParameter("ZESEIKUBUN", NpgsqlDbType.Varchar, 10, "是正区分"));          //NVARCHAR2
            cmd.Parameters.Add(new NpgsqlParameter("CYUUSYUTU_G", NpgsqlDbType.Varchar, 10, "抽出グループ"));     //NVARCHAR2
            cmd.Parameters.Add(new NpgsqlParameter("TOUROKUSYA", NpgsqlDbType.Varchar, 10, "登録者"));            //NVARCHAR2

            cmd.Parameters.Add(new NpgsqlParameter("TOUROKUBI", NpgsqlDbType.Date, 10, "登録日"));                //NUMBER

            cmd.Parameters.Add(new NpgsqlParameter("YOTEIKOUSUU", NpgsqlDbType.Numeric, 4, "予定工数"));            //NUMBER
            cmd.Parameters.Add(new NpgsqlParameter("JISSEKIKOUSUU", NpgsqlDbType.Numeric, 4, "実績工数"));          //NUMBER

            cmd.Parameters.Add(new NpgsqlParameter("KAIHATUCYAKUSYUBI", NpgsqlDbType.Date, 10, "開発着手日"));    //NUMBER
            cmd.Parameters.Add(new NpgsqlParameter("KAIHATUKANRYOUBI", NpgsqlDbType.Date, 10, "開発完了日"));     //NUMBER

            cmd.Parameters.Add(new NpgsqlParameter("SHINCYOKURITU", NpgsqlDbType.Numeric, 4, "進捗率"));            //NUMBER
            cmd.Parameters.Add(new NpgsqlParameter("BIKOU", NpgsqlDbType.Varchar, 200, "備考"));                  //NVARCHAR2
            oAdp.InsertCommand = cmd;

            //■Create the UpdateCommand.
            string upd_str = "update \"課題管理\" " +
                             "set " +
                                " \"プロジェクト番号\" = @pjNo," +
                                " \"連番\" = @SEQ_NO," +
                                " \"管理番号\" = @KANRI_NO," +
                                " \"分類\" = @BUNRUI," +
                                " \"機能名称\" = @KINOU," +
                                " \"管理内容\" = @KANRI_NAIYOU," +
                                " \"処置内容\" = @SYOCHI_NAIYOU," +
                                " \"種別\" = @SYUBETU," +
                                " \"状態\" = @JYOUTAI," +
                                " \"発生フェーズ\" = @HASSEI_F," +
                                " \"原因フェーズ\" = @GENIN_F," +
                                " \"原因区分\" = @GENIN_KUBUN," +
                                " \"原因詳細\" = @GENIN_SYOUSAI," +
                                " \"重要度\" = @JYUUYOUDO," +
                                //" \"発生日\" = to_date(@HASSEIBI, 'YYYY-MM-DD')," +
                                //" \"対応予定日\" = to_date(@YOTEIBI, 'YYYY-MM-DD')," +
                                //" \"完了日\" = to_date(@KANRYOUBI, 'YYYY-MM-DD')," +
                                " \"発生日\" = @HASSEIBI," +
                                " \"対応予定日\" = @YOTEIBI," +
                                " \"完了日\" = @KANRYOUBI," +
                                " \"指摘者\" = @SHITEKISYA," +
                                " \"処置者\" = @SYOCHISYA," +
                                " \"是正区分\" = @ZESEIKUBUN," +
                                " \"抽出グループ\" = @CYUUSYUTU_G," +
                                " \"登録者\" = @TOUROKUSYA," +
                                " \"登録日\" = @TOUROKUBI," +
                                " \"予定工数\" = @YOTEIKOUSUU," +
                                " \"実績工数\" = @JISSEKIKOUSUU," +
                                " \"開発着手日\" = @KAIHATUCYAKUSYUBI," +
                                " \"開発完了日\" = @KAIHATUKANRYOUBI," +
                                " \"進捗率\" = @SHINCYOKURITU," +
                                " \"備考\" = @BIKOU " +
                              " where \"プロジェクト番号\" = @pjNo" +
                              "  and \"連番\" = @SEQ_NO";


            cmd = new NpgsqlCommand(upd_str.ToString(), PhCom.PostLib.Session);

            cmd.Parameters.Add(new NpgsqlParameter("pjNo", NpgsqlDbType.Numeric, 6, "プロジェクト番号"));           //NUMBER
            cmd.Parameters.Add(new NpgsqlParameter("SEQ_NO", NpgsqlDbType.Numeric, 5, "連番"));                     //NUMBER
            cmd.Parameters.Add(new NpgsqlParameter("KANRI_NO", NpgsqlDbType.Numeric, 5, "管理番号"));               //NUMBER
            cmd.Parameters.Add(new NpgsqlParameter("BUNRUI", NpgsqlDbType.Varchar, 50, "分類"));                  //NVARCHAR2
            cmd.Parameters.Add(new NpgsqlParameter("KINOU", NpgsqlDbType.Varchar, 50, "機能名称"));               //NVARCHAR2
            cmd.Parameters.Add(new NpgsqlParameter("KANRI_NAIYOU", NpgsqlDbType.Varchar, 1000, "管理内容"));      //NVARCHAR2
            cmd.Parameters.Add(new NpgsqlParameter("SYOCHI_NAIYOU", NpgsqlDbType.Varchar, 2000, "処置内容"));     //NVARCHAR2
            cmd.Parameters.Add(new NpgsqlParameter("SYUBETU", NpgsqlDbType.Varchar, 6, "種別"));                  //NVARCHAR2
            cmd.Parameters.Add(new NpgsqlParameter("JYOUTAI", NpgsqlDbType.Varchar, 10, "状態"));                 //NVARCHAR2
            cmd.Parameters.Add(new NpgsqlParameter("HASSEI_F", NpgsqlDbType.Varchar, 10, "発生フェーズ"));        //NVARCHAR2
            cmd.Parameters.Add(new NpgsqlParameter("GENIN_F", NpgsqlDbType.Varchar, 10, "原因フェーズ"));         //NVARCHAR2
            cmd.Parameters.Add(new NpgsqlParameter("GENIN_KUBUN", NpgsqlDbType.Varchar, 10, "原因区分"));         //NVARCHAR2
            cmd.Parameters.Add(new NpgsqlParameter("GENIN_SYOUSAI", NpgsqlDbType.Varchar, 10, "原因詳細"));       //NVARCHAR2
            cmd.Parameters.Add(new NpgsqlParameter("JYUUYOUDO", NpgsqlDbType.Varchar, 2, "重要度"));               //VARCHAR2

            cmd.Parameters.Add(new NpgsqlParameter("HASSEIBI", NpgsqlDbType.Date, 10, "発生日"));                 //NUMBER
            cmd.Parameters.Add(new NpgsqlParameter("YOTEIBI", NpgsqlDbType.Date, 10, "対応予定日"));              //NUMBER
            cmd.Parameters.Add(new NpgsqlParameter("KANRYOUBI", NpgsqlDbType.Date, 10, "完了日"));                //NUMBER

            cmd.Parameters.Add(new NpgsqlParameter("SHITEKISYA", NpgsqlDbType.Varchar, 10, "指摘者"));            //NVARCHAR2
            cmd.Parameters.Add(new NpgsqlParameter("SYOCHISYA", NpgsqlDbType.Varchar, 10, "処置者"));             //NVARCHAR2
            cmd.Parameters.Add(new NpgsqlParameter("ZESEIKUBUN", NpgsqlDbType.Varchar, 10, "是正区分"));          //NVARCHAR2
            cmd.Parameters.Add(new NpgsqlParameter("CYUUSYUTU_G", NpgsqlDbType.Varchar, 10, "抽出グループ"));     //NVARCHAR2
            cmd.Parameters.Add(new NpgsqlParameter("TOUROKUSYA", NpgsqlDbType.Varchar, 10, "登録者"));            //NVARCHAR2

            cmd.Parameters.Add(new NpgsqlParameter("TOUROKUBI", NpgsqlDbType.Date, 10, "登録日"));                //NUMBER

            cmd.Parameters.Add(new NpgsqlParameter("YOTEIKOUSUU", NpgsqlDbType.Numeric, 4, "予定工数"));            //NUMBER
            cmd.Parameters.Add(new NpgsqlParameter("JISSEKIKOUSUU", NpgsqlDbType.Numeric, 4, "実績工数"));          //NUMBER

            cmd.Parameters.Add(new NpgsqlParameter("KAIHATUCYAKUSYUBI", NpgsqlDbType.Date, 10, "開発着手日"));    //NUMBER
            cmd.Parameters.Add(new NpgsqlParameter("KAIHATUKANRYOUBI", NpgsqlDbType.Date, 10, "開発完了日"));     //NUMBER

            cmd.Parameters.Add(new NpgsqlParameter("SHINCYOKURITU", NpgsqlDbType.Numeric, 4, "進捗率"));            //NUMBER
            cmd.Parameters.Add(new NpgsqlParameter("BIKOU", NpgsqlDbType.Varchar, 200, "備考"));                  //NVARCHAR2
            oAdp.UpdateCommand = cmd;

        //    //■Create the DeleteCommand.
        //    string del_str = "delete from 課題管理  " + 
        //                      "where プロジェクト番号 = :pjNo" +
        //                      "  and 連番 = :SEQ_NO";

        //    cmd = new NpgsqlCommand(del_str.ToString(), PhCom.PostLib.Session);
        //    cmd.Parameters.Add("pjNo", DbType.Decimal, 6, "プロジェクト番号");           //NUMBER
        //    cmd.Parameters.Add("SEQ_NO", DbType.Decimal, 5, "連番");                     //NUMBER
        //    oAdp.DeleteCommand = cmd;


        }


        //**********************************************************************
        /// <summary>
        /// キー処理
        /// </summary>
        /// <param name="pnumKeys">キーコード</param>
        //**********************************************************************
        private void mfnc_key_furiwake(Keys pnumKeys)
        {
            try
            {
                switch (pnumKeys)
                {
                    case Keys.Escape:
                        btn_ESC.PerformClick();
                        break;

                    case Keys.F1:
                        btn_Select.PerformClick();
                        break;

                    case Keys.F2:
                        btn_Edit.PerformClick();
                        break;

                    case Keys.F3:
                        btn_AddRow.PerformClick();
                        break;

                    case Keys.F4:
                        btn_InsertRow.PerformClick();
                        break;

                    case Keys.F5:
                        btn_Update.PerformClick();
                        break;

                    case Keys.F6:
                        btn_Delete.PerformClick();
                        break;

                    case Keys.F7:
                        btn_Print.PerformClick();
                        break;

                    case Keys.F8:
                        btn_Excel.PerformClick();
                        break;

                    case Keys.F9:
                        btn_Project.PerformClick();
                        break;

                    case Keys.F10:
                        btn_print2.PerformClick();
                        break;

                    //case Keys.F11:
                    //    btn_F11.PerformClick();
                    //    break;

                    //case Keys.F12:
                    //    btn_F12.PerformClick();
                    //    break;

                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                PhCom.ShowErrMsg(ex);
            }
        }


        //**********************************************************************
        /// <summary>
        /// ボタン活性化制御
        /// </summary>
        /// <param name="pblnESC">閉る</param>
        /// <param name="pblnF01">検索</param>
        /// <param name="pblnF02">編集</param>
        /// <param name="pblnF03">行追加</param>
        /// <param name="pblnF04">行挿入</param>
        /// <param name="pblnF05">更新</param>
        /// <param name="pblnF06">行削除</param>
        /// <param name="pblnF07">印刷</param>
        /// <param name="pblnF08">Excel</param>
        /// <param name="pblnF09">プロジェクト</param>
        /// <param name="pblnF10">--</param>
        /// <param name="pblnF11">--</param>
        /// <param name="pblnF12">--</param>
        //**********************************************************************
        private void mfnc_setBtnEnabled(
              bool pblnESC
            , bool pblnF01
            , bool pblnF02
            , bool pblnF03
            , bool pblnF04
            , bool pblnF05
            , bool pblnF06
            , bool pblnF07
            , bool pblnF08
            , bool pblnF09
            , bool pblnF10
            , bool pblnF11
            , bool pblnF12
            )
        {
            try
            {
                //------------------
                btn_ESC.Enabled = pblnESC;
                //------------------
                btn_Select.Enabled = pblnF01;
                btn_Edit.Enabled = pblnF02;
                btn_AddRow.Enabled = pblnF03;
                btn_InsertRow.Enabled = pblnF03;
                btn_Update.Enabled = pblnF05;
                btn_Delete.Enabled = pblnF06;
                btn_Print.Enabled = pblnF07;
                btn_Excel.Enabled = pblnF08;
                btn_Project.Enabled = pblnF09;
                ////------------------
                btn_print2.Enabled = pblnF10;
                //btn_F11.Enabled = pblnF11;
                //btn_F12.Enabled = pblnF12;
                //------------------
            }
            catch (Exception ex)
            {
                PhCom.ShowErrMsg(ex);
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

                    //セル毎にLOCK
                    fpSMain.ActiveSheet.Cells[i, j].Locked = true;
                }
            }
            fpSMain.Refresh();
        }


        //**********************************************************************
        /// <summary>
        /// データセットの内容をスプレッドに表示
        /// </summary>
        //**********************************************************************
        private void mfnc_setSpreadAllline()
        {
            try
            {

            }
            catch (Exception ex)
            {
                PhCom.ShowErrMsg(ex);
            }
        }
 

        //**********************************************************************
        /// <summary>
        /// スプレッドの初期化
        /// </summary>
        //**********************************************************************
        private void mfnc_setSpreadInitialize()
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
                fpSMain.ActiveSheet.OperationMode = OperationMode.Normal;
                fpSMain.HorizontalScrollBarPolicy = ScrollBarPolicy.AsNeeded;
                fpSMain.VerticalScrollBarPolicy = ScrollBarPolicy.AsNeeded;
                fpSMain.ClipboardOptions = FarPoint.Win.Spread.ClipboardOptions.NoHeaders;
                fpSMain.ActiveSheet.ClipboardPaste(FarPoint.Win.Spread.ClipboardPasteOptions.Values);

                //--------------------------------------
                // セルを選択した時のヘッダのハイライト表示を抑制
                //--------------------------------------
                FarPoint.Win.Spread.CellType.EnhancedColumnHeaderRenderer lcolRenderer = new FarPoint.Win.Spread.CellType.EnhancedColumnHeaderRenderer();
                lcolRenderer.SelectedActiveBackgroundColor = Color.FromArgb(195, 202, 214);
                lcolRenderer.SelectedBackgroundColor = Color.FromArgb(215, 223, 235);
                lcolRenderer.SelectedGridLineColor = Color.FromArgb(158, 182, 206);
                fpSMain.ActiveSheet.ColumnHeader.DefaultStyle.Renderer = lcolRenderer;

                //--------------------------------------
                // OperationMode制御時にセル背景色が変わらないようにする
                //--------------------------------------
//                fpSMain.ActiveSheet.SelectionBackColor = Color.Empty;
//                fpSMain.ActiveSheet.SelectionStyle = FarPoint.Win.Spread.SelectionStyles.SelectionColors;

                ////--------------------------------------
                //// 行数列数設定
                ////--------------------------------------
                fpSMain.ActiveSheet.ColumnHeader.RowCount = 1;
                fpSMain.ActiveSheet.RowCount = 0;
                fpSMain.ActiveSheet.ColumnCount = (int)mainColum2.BIKOU + 1;
                //fpSMain.ActiveSheet.ColumnHeader.Columns. = fpSMain.ActiveSheet.GetPreferredRowHeight(i);

                //--------------------------------------
                // Columnパラメータ 設定
                //--------------------------------------
                fpSMain.ActiveSheet.Columns[(int)mainColum2.PJ_NO].Locked = true;
                fpSMain.ActiveSheet.Columns[(int)mainColum2.SEQ_NO].Locked = true;

                ////列幅設定
                //mfnc_SetSpreadInfo();

                ////--------------------------------------
                //// Spread 表示セルを初期化（クリア）
                ////--------------------------------------
                //ClearMain();

                //--------------------------------------
                // 一覧表再描画
                //--------------------------------------
                fpSMain.Refresh();
            }
            catch (Exception ex)
            {
                PhCom.ShowErrMsg(ex);
            }
        }

        /// <summary>
        /// スプレッドの属性設定
        /// </summary>
        private void mfnc_SetSpreadInfo()
        {
            //行ヘッダーの列幅
            fpSMain.ActiveSheet.RowHeader.Columns[0].Width = 25;
            fpSMain.ActiveSheet.RowHeader.Columns[0].Font = new Font("MS UI Gothic", 8);
            fpSMain.ActiveSheet.RowHeader.Columns[0].HorizontalAlignment = CellHorizontalAlignment.Right;
            //fpSMain.ActiveSheet.RowHeader.Columns[0].HorizontalAlignment = CellHorizontalAlignment.Center;
          
            ////20171227 TEST 列のタイトルを変更しても更新に問題無いか？　－－－＞　OK
            //for(int j = 0;j<fpSMain.ActiveSheet.ColumnHeader.Columns.Count;j++)
            //{
            //    fpSMain.ActiveSheet.ColumnHeader.Columns[j].Label += (":No." + j.ToString());
            //}


            //// 列の非表示設定
 //     fpSMain.ActiveSheet.Columns[(int)mainColum2.PJ_NO].Visible = false;
            //fpSMain.ActiveSheet.Columns[(int)mainColum2.HASSEI_F].Visible = false;
            //fpSMain.ActiveSheet.Columns[(int)mainColum2.GENIN_F].Visible = false;
            //fpSMain.ActiveSheet.Columns[(int)mainColum2.GENIN_KUBUN].Visible = false;
            //fpSMain.ActiveSheet.Columns[(int)mainColum2.GENIN_SYOUSAI].Visible = false;
            //fpSMain.ActiveSheet.Columns[(int)mainColum2.SHINCYOKURITU].Visible = false;
            
            
            //列幅,他の設定
            fpSMain.ActiveSheet.Columns[(int)mainColum2.SEQ_NO].Width = (float)40;
            fpSMain.ActiveSheet.Columns[(int)mainColum2.KANRI_NO].Width = (float)40;
            //fpSMain.ActiveSheet.Columns[(int)mainColum2.BUNRUI].Width = (float)40;
            fpSMain.ActiveSheet.Columns[(int)mainColum2.BUNRUI].Width = (float)60;
            
            //fpSMain.ActiveSheet.Columns[(int)mainColum2.KINOU].Width = (float)80;
            //fpSMain.ActiveSheet.Columns[(int)mainColum2.KANRI_NAIYOU].Width = (float)280;
            //fpSMain.ActiveSheet.Columns[(int)mainColum2.SYOCHI_NAIYOU].Width = (float)280;
            fpSMain.ActiveSheet.Columns[(int)mainColum2.KINOU].Width = (float)120;
            fpSMain.ActiveSheet.Columns[(int)mainColum2.KANRI_NAIYOU].Width = (float)380;
            fpSMain.ActiveSheet.Columns[(int)mainColum2.SYOCHI_NAIYOU].Width = (float)380;

            //fpSMain.ActiveSheet.Columns[(int)mainColum2.SYUBETU].Width = (float)40;
            fpSMain.ActiveSheet.Columns[(int)mainColum2.SYUBETU].Width = (float)60;
            fpSMain.ActiveSheet.Columns[(int)mainColum2.JYOUTAI].Width = (float)40;
            fpSMain.ActiveSheet.Columns[(int)mainColum2.HASSEI_F].Width = (float)40;
            fpSMain.ActiveSheet.Columns[(int)mainColum2.GENIN_F].Width = (float)40;
            fpSMain.ActiveSheet.Columns[(int)mainColum2.GENIN_KUBUN].Width = (float)40;
            fpSMain.ActiveSheet.Columns[(int)mainColum2.GENIN_SYOUSAI].Width = (float)40;
            fpSMain.ActiveSheet.Columns[(int)mainColum2.JYUUYOUDO].Width = (float)40;
            fpSMain.ActiveSheet.Columns[(int)mainColum2.HASSEIBI].Width = (float)70;
            fpSMain.ActiveSheet.Columns[(int)mainColum2.YOTEIBI].Width = (float)70;
            fpSMain.ActiveSheet.Columns[(int)mainColum2.KANRYOUBI].Width = (float)70;
            fpSMain.ActiveSheet.Columns[(int)mainColum2.SHITEKISYA].Width = (float)70;
            fpSMain.ActiveSheet.Columns[(int)mainColum2.SYOCHISYA].Width = (float)70;
            fpSMain.ActiveSheet.Columns[(int)mainColum2.ZESEIKUBUN].Width = (float)40;
            fpSMain.ActiveSheet.Columns[(int)mainColum2.CYUUSYUTU_G].Width = (float)70;
            fpSMain.ActiveSheet.Columns[(int)mainColum2.TOUROKUSYA].Width = (float)70;
            fpSMain.ActiveSheet.Columns[(int)mainColum2.TOUROKUBI].Width = (float)70;
            fpSMain.ActiveSheet.Columns[(int)mainColum2.YOTEIKOUSUU].Width = (float)50;
            fpSMain.ActiveSheet.Columns[(int)mainColum2.JISSEKIKOUSUU].Width = (float)50;
            fpSMain.ActiveSheet.Columns[(int)mainColum2.KAIHATUCYAKUSYUBI].Width = (float)70;
            fpSMain.ActiveSheet.Columns[(int)mainColum2.KAIHATUKANRYOUBI].Width = (float)70;
            fpSMain.ActiveSheet.Columns[(int)mainColum2.SHINCYOKURITU].Width = (float)50;
            fpSMain.ActiveSheet.Columns[(int)mainColum2.BIKOU].Width = (float)80;


            //　テキスト型セル　折り返し無し
            FarPoint.Win.Spread.CellType.TextCellType textcell_row = new FarPoint.Win.Spread.CellType.TextCellType();
            textcell_row.WordWrap = false;

            //  // テキスト型セル　折り返し有り
            FarPoint.Win.Spread.CellType.TextCellType textcell_rows = new FarPoint.Win.Spread.CellType.TextCellType();
            textcell_rows.Multiline = true;         //改行の入力　Shift+Enterが可能となる。　シフト無しでもOKだった。確定はフォーカスを外すこと。
            textcell_rows.WordWrap = true;
            textcell_rows.MaxLength = 2000;         //デフォルトで切られていた為、DBの最大サイズとした。

            //小数点、桁区切りの設定  
            // 0
            FarPoint.Win.Spread.CellType.NumberCellType lobjCellTypeNumberDecimalPlaces0 = new FarPoint.Win.Spread.CellType.NumberCellType();
            lobjCellTypeNumberDecimalPlaces0.DecimalPlaces = 0;
            lobjCellTypeNumberDecimalPlaces0.ShowSeparator = false;
            lobjCellTypeNumberDecimalPlaces0.MaximumValue = 99999999;

            // 1
            FarPoint.Win.Spread.CellType.NumberCellType lobjCellTypeNumberDecimalPlaces1 = new FarPoint.Win.Spread.CellType.NumberCellType();
            lobjCellTypeNumberDecimalPlaces1.DecimalPlaces = 1;
            lobjCellTypeNumberDecimalPlaces1.ShowSeparator = true;

            

            // 2
            FarPoint.Win.Spread.CellType.NumberCellType lobjCellTypeNumberDecimalPlaces2 = new FarPoint.Win.Spread.CellType.NumberCellType();
            lobjCellTypeNumberDecimalPlaces2.DecimalPlaces = 2;
            lobjCellTypeNumberDecimalPlaces2.ShowSeparator = true;

            //CELL タイプの設定
            //fpSMain.ActiveSheet.Columns[(int)mainColum.KANRYOU].CellType = (FarPoint.Win.Spread.CellType.NumberCellType)textcell_row.Clone();
            fpSMain.ActiveSheet.Columns[(int)mainColum2.SEQ_NO].CellType = (FarPoint.Win.Spread.CellType.NumberCellType)lobjCellTypeNumberDecimalPlaces0.Clone();
            fpSMain.ActiveSheet.Columns[(int)mainColum2.KANRI_NO].CellType = (FarPoint.Win.Spread.CellType.NumberCellType)lobjCellTypeNumberDecimalPlaces0.Clone();
            fpSMain.ActiveSheet.Columns[(int)mainColum2.BUNRUI].CellType = (FarPoint.Win.Spread.CellType.TextCellType)textcell_row.Clone();
            fpSMain.ActiveSheet.Columns[(int)mainColum2.BUNRUI].CellPadding.Left = (int)5;
            fpSMain.ActiveSheet.Columns[(int)mainColum2.KINOU].CellType = (FarPoint.Win.Spread.CellType.TextCellType)textcell_row.Clone();
            fpSMain.ActiveSheet.Columns[(int)mainColum2.KINOU].CellPadding.Left = (int)5;

            fpSMain.ActiveSheet.Columns[(int)mainColum2.KANRI_NAIYOU].CellType = (FarPoint.Win.Spread.CellType.TextCellType)textcell_rows.Clone();
            fpSMain.ActiveSheet.Columns[(int)mainColum2.KANRI_NAIYOU].CellPadding.Left = (int)5;
            fpSMain.ActiveSheet.Columns[(int)mainColum2.SYOCHI_NAIYOU].CellType = (FarPoint.Win.Spread.CellType.TextCellType)textcell_rows.Clone();
            fpSMain.ActiveSheet.Columns[(int)mainColum2.SYOCHI_NAIYOU].CellPadding.Left = (int)5;
            fpSMain.ActiveSheet.Columns[(int)mainColum2.SYUBETU].CellType = (FarPoint.Win.Spread.CellType.TextCellType)textcell_row.Clone();
            fpSMain.ActiveSheet.Columns[(int)mainColum2.SYUBETU].CellPadding.Left = (int)5;
            fpSMain.ActiveSheet.Columns[(int)mainColum2.JYOUTAI].CellType = (FarPoint.Win.Spread.CellType.TextCellType)textcell_row.Clone();
            fpSMain.ActiveSheet.Columns[(int)mainColum2.HASSEI_F].CellType = (FarPoint.Win.Spread.CellType.TextCellType)textcell_row.Clone();
            fpSMain.ActiveSheet.Columns[(int)mainColum2.GENIN_F].CellType = (FarPoint.Win.Spread.CellType.TextCellType)textcell_row.Clone();
            fpSMain.ActiveSheet.Columns[(int)mainColum2.GENIN_KUBUN].CellType = (FarPoint.Win.Spread.CellType.TextCellType)textcell_row.Clone();
            fpSMain.ActiveSheet.Columns[(int)mainColum2.GENIN_SYOUSAI].CellType = (FarPoint.Win.Spread.CellType.TextCellType)textcell_row.Clone();
            fpSMain.ActiveSheet.Columns[(int)mainColum2.JYUUYOUDO].CellType = (FarPoint.Win.Spread.CellType.TextCellType)textcell_row.Clone();
            
            //fpSMain.ActiveSheet.Columns[(int)mainColum2.HASSEIBI].CellType = (FarPoint.Win.Spread.CellType.NumberCellType)lobjCellTypeNumberDecimalPlaces0.Clone();
            //fpSMain.ActiveSheet.Columns[(int)mainColum2.YOTEIBI].CellType = (FarPoint.Win.Spread.CellType.NumberCellType)lobjCellTypeNumberDecimalPlaces0.Clone();
            //fpSMain.ActiveSheet.Columns[(int)mainColum2.KANRYOUBI].CellType = (FarPoint.Win.Spread.CellType.NumberCellType)lobjCellTypeNumberDecimalPlaces0.Clone();
            fpSMain.ActiveSheet.Columns[(int)mainColum2.HASSEIBI].CellType = new FarPoint.Win.Spread.CellType.DateTimeCellType();
            fpSMain.ActiveSheet.Columns[(int)mainColum2.HASSEIBI].HorizontalAlignment = CellHorizontalAlignment.Center;
            fpSMain.ActiveSheet.Columns[(int)mainColum2.YOTEIBI].CellType = new FarPoint.Win.Spread.CellType.DateTimeCellType();
            fpSMain.ActiveSheet.Columns[(int)mainColum2.YOTEIBI].HorizontalAlignment = CellHorizontalAlignment.Center;
            fpSMain.ActiveSheet.Columns[(int)mainColum2.KANRYOUBI].CellType = new FarPoint.Win.Spread.CellType.DateTimeCellType();
            fpSMain.ActiveSheet.Columns[(int)mainColum2.KANRYOUBI].HorizontalAlignment = CellHorizontalAlignment.Center;
            
            fpSMain.ActiveSheet.Columns[(int)mainColum2.SHITEKISYA].CellType = (FarPoint.Win.Spread.CellType.TextCellType)textcell_row.Clone();
            fpSMain.ActiveSheet.Columns[(int)mainColum2.SHITEKISYA].CellPadding.Left = (int)5;
            fpSMain.ActiveSheet.Columns[(int)mainColum2.SYOCHISYA].CellType = (FarPoint.Win.Spread.CellType.TextCellType)textcell_row.Clone();
            fpSMain.ActiveSheet.Columns[(int)mainColum2.SYOCHISYA].CellPadding.Left = (int)5;
            fpSMain.ActiveSheet.Columns[(int)mainColum2.ZESEIKUBUN].CellType = (FarPoint.Win.Spread.CellType.TextCellType)textcell_row.Clone();
            fpSMain.ActiveSheet.Columns[(int)mainColum2.CYUUSYUTU_G].CellType = (FarPoint.Win.Spread.CellType.TextCellType)textcell_row.Clone();
            fpSMain.ActiveSheet.Columns[(int)mainColum2.TOUROKUSYA].CellType = (FarPoint.Win.Spread.CellType.TextCellType)textcell_row.Clone();
            fpSMain.ActiveSheet.Columns[(int)mainColum2.TOUROKUSYA].CellPadding.Left = (int)5;
 
            //fpSMain.ActiveSheet.Columns[(int)mainColum2.TOUROKUBI].CellType = (FarPoint.Win.Spread.CellType.NumberCellType)lobjCellTypeNumberDecimalPlaces0.Clone();
            fpSMain.ActiveSheet.Columns[(int)mainColum2.TOUROKUBI].CellType = new FarPoint.Win.Spread.CellType.DateTimeCellType();
            
            fpSMain.ActiveSheet.Columns[(int)mainColum2.YOTEIKOUSUU].CellType = (FarPoint.Win.Spread.CellType.NumberCellType)lobjCellTypeNumberDecimalPlaces1.Clone();
            fpSMain.ActiveSheet.Columns[(int)mainColum2.JISSEKIKOUSUU].CellType = (FarPoint.Win.Spread.CellType.NumberCellType)lobjCellTypeNumberDecimalPlaces1.Clone();
            
            //fpSMain.ActiveSheet.Columns[(int)mainColum2.KAIHATUCYAKUSYUBI].CellType = (FarPoint.Win.Spread.CellType.NumberCellType)lobjCellTypeNumberDecimalPlaces0.Clone();
            //fpSMain.ActiveSheet.Columns[(int)mainColum2.KAIHATUKANRYOUBI].CellType = (FarPoint.Win.Spread.CellType.NumberCellType)lobjCellTypeNumberDecimalPlaces0.Clone();
            fpSMain.ActiveSheet.Columns[(int)mainColum2.KAIHATUCYAKUSYUBI].CellType = new FarPoint.Win.Spread.CellType.DateTimeCellType();
            fpSMain.ActiveSheet.Columns[(int)mainColum2.KAIHATUKANRYOUBI].CellType = new FarPoint.Win.Spread.CellType.DateTimeCellType();
            
            fpSMain.ActiveSheet.Columns[(int)mainColum2.SHINCYOKURITU].CellType = (FarPoint.Win.Spread.CellType.NumberCellType)lobjCellTypeNumberDecimalPlaces1.Clone();
            fpSMain.ActiveSheet.Columns[(int)mainColum2.BIKOU].CellType = (FarPoint.Win.Spread.CellType.TextCellType)textcell_rows.Clone();



            ////行の高さを設定
            //int rows_count = fpSMain.ActiveSheet.RowCount;
            //for (int i = 0; i < rows_count; i++)
            //{
            //    // 最も高さのあるテキストの高さに設定します
            //    fpSMain.ActiveSheet.Rows[i].Height = (rows_hight > fpSMain.ActiveSheet.GetPreferredRowHeight(i) ? rows_hight : fpSMain.ActiveSheet.GetPreferredRowHeight(i));
            //}

            //列を追加

            //列情報の再設定
            clsSpread.setSpreadColumInfo(fpSMain.ActiveSheet, kadai_list);

            //奇数行、偶数行の背景色設定
            clsSpread.SetColorAlternating(fpSMain.ActiveSheet);
        
            //固定列数の設定
            //fpSMain.ActiveSheet.FrozenColumnCount = (int)mainColum2.KANRI_NAIYOU;
            clsSpread.SetFrozenColumn(fpSMain.ActiveSheet, (int)mainColum2.SEQ_NO);

        }

        /// <summary>
        /// 初期化設定
        /// </summary>
        /// <param name="pnumState">状態情報</param>
        //**********************************************************************
        private void mfnc_setInitialize()
        {
            try
            {
                //--------------------------------------
                // データセット
                //--------------------------------------
                dsKadai.KADAI.Clear();

                //--------------------------------------
                // 初期化処理
                //--------------------------------------
                mfnc_setSpreadInitialize();

                //--------------------------------------
                // ボタン
                //--------------------------------------
                //                 閉る  検索  編集   行追加  行挿入 更新  行削除 印刷  Excel ﾌﾟﾛｼﾞｪｸﾄ   --     --     --     --     --     --
                mfnc_setBtnEnabled(true, true, false, false, false, false, false, false, false, true, false, false, false);

            }
            catch (Exception ex)
            {
                PhCom.ShowErrMsg(ex);
            }
        }

        

        #endregion

        private void chk_kanryou_CheckedChanged(object sender, EventArgs e)
        {
            if(chk_kanryou.Checked == true)
            {
                radioButton2.Checked = true;
            }
            else
            {
                radioButton1.Checked = false;
                radioButton2.Checked = false;
            }
        }

        /// <summary>Ctrl+Fキーで検索ダイアログを表示する</summary>
        private void fpSMain_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                //編集中に有効とする。
                if (btn_Edit.Enabled == true) return;

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

        private void fpSMain_CellClick(object sender, CellClickEventArgs e)
        {

        }


    }
}
