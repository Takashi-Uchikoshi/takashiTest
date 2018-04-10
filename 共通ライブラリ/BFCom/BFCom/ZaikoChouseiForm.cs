using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//PostgreSQL用
using Npgsql;
using NpgsqlTypes;

//B2共通LIB
using B2.Com;

#region 修正履歴
/*
 * UNDONE 20180330 打越 在庫調整ダイアログ製造着手
*/
#endregion


namespace B2.BestFunction
{
    public partial class ZaikoChouseiForm : Form
    {
        /// <summary>
        /// 呼び出し元への復帰情報
        /// </summary>
        public DialogResult ReturnValue = DialogResult.None;
  
        /// <summary>共通パラメータ</summary>
        private B2Com b2Com;

        //DB用アダプタ
        //NpgsqlDataAdapter oAdp;

        //商品コード
        static private string Shouhin_Code = string.Empty;
        //薬価
        decimal yakka = 0;
        //原価
        decimal Genka = 0;
        //最終仕入価格
        decimal SaisyuuGenka = 0;
        //麻薬、向精神薬　伝票区分
        int madoku_kubun = 0;

        //OTCフラグ
        private int otc_flag = 0;
        
        //消費税率
        decimal tax_ritu = 0.08m;
        decimal tax_ritu2 = 0.1m;

        /// <summary> Spreadの列インデックス</summary>
        private enum mainColum
        {
            check_haiki = 0,
            seizou_bangou,
            siyou_kigen,
            rironzaiko_suryo,
            chousei_suryo,
            chouseigo_suryo,
            biko
        }


        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ZaikoChouseiForm()
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
                this.Close();
                return;
            }

            // データベース初期化処理（接続） EntityFrameworkとは別の接続
            if (!b2Com.InitDb(true))
            {
                this.Close();
                return;
            }

            return;
        }

        /// <summary>
        /// フォーム起動ファンクション
        /// </summary>
        /// <param name="shouhin_code">商品コード</param>
        /// <returns></returns>
        static public DialogResult ShowForm(string shouhin_code)
        {

            //引数エラーのチェック
            if (string.IsNullOrEmpty(shouhin_code))
            {
                MessageBox.Show("引数が正しくありません。");
                return DialogResult.Abort;
            }

            Shouhin_Code = shouhin_code;

            //ダイアログのインスタンス化
            ZaikoChouseiForm f = new ZaikoChouseiForm();

            //画面の呼び出し
            f.ShowDialog();
            DialogResult receiveValue = f.ReturnValue;

            f.Dispose();
            return receiveValue;
        }

        /// <summary>
        /// Loadイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frm_Zaiko_Chousei_Load(object sender, EventArgs e)
        {
            try
            {
                this.KeyPreview = true;
                return;
            }
            catch (Exception ex)
            {
                b2Com.ShowErrMsg(ex);
                return;
            }
        }

        /// <summary>
        /// Shownイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frm_Zaiko_Chousei_Shown(object sender, EventArgs e)
        {
            try
            {
                //--------------------------------------
                // 初期化
                //--------------------------------------

                //バックカラーの設定
                b2Com.SetBackColor(this);

                //表示エリアの初期化
                setInitialize();

                //指定データの設定および抽出と表示
                setSearchInfo();

                this.Activate();
                return;

            }
            catch (Exception ex)
            {
                b2Com.ShowErrMsg(ex);
                return;
            }
        }


        /// <summary>
        /// 表示エリアの初期化
        /// </summary>
        /// <param name="pnumState">状態情報</param>
        private void setInitialize()
        {
            try
            {
                //商品コード
                gcTxt_gtin_code.Text = "";

                //商品名
                txt_yakuhinmei.Text = "";
                
                //スプレッドの行数を0に変更
                fpS_Chousei.ActiveSheet.RowCount = 0;
                
                return;
            }
            catch (Exception ex)
            {
                b2Com.ShowErrMsg(ex);
                return;
            }
        }


        /// <summary>
        /// パラメータ情報を元にＬＯＴ情報を取得し表示エリアにセット
        /// </summary>
        private void setSearchInfo()
        {
            try
            {
                //商品コードをセット
                if(!string.IsNullOrEmpty(Shouhin_Code))
                {
                    gcTxt_gtin_code.Text = Shouhin_Code;
                }
                else
                {
                    return;
                }

                //商品名を取得しセット
                if(!dbSelectYakuhin(Shouhin_Code))
                {
                    MessageBox.Show("指定の商品情報が見つかりません。\r\n処理を終了します。");
                    this.Close();
                    return;
                }

                //消費税率を取得
                dbSelectTenpo();

                //単価を取得
                if(!dbSelectTanka(Shouhin_Code))
                {
                    MessageBox.Show("指定の在庫情報が見つかりません。\r\n処理を終了します。");
                    this.Close();
                    return;
                }

                //LOT情報を取得しセット
                if (!dbSelectLotinfo(Shouhin_Code))
                {
                    MessageBox.Show("指定のLOT情報が見つかりません。\r\n処理を終了します。");
                    this.Close();
                    return;
                }
                return;
            }
            catch (Exception ex)
            {
                b2Com.ShowErrMsg(ex);
                return;
            }
        }


        /// <summary>
        /// 薬品マスタから情報の抽出
        /// </summary>
        private bool dbSelectYakuhin(string search_code)
        {
            try
            {
                //データの存在チェックフラグ
                int sonzai_flag = 0;

                using (var context = new Entities.ZaikoChouseiModel(b2Com))
                {
                    //SQL Log 出力
                    context.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);

                    //薬品マスタからデータの読込
                    var yakuhin = context.YakuhinMaster.FirstOrDefault(w => (w.GtinCode == search_code || w.JanCode == search_code) &&
                                                                    w.ApplyEndYmd == " ");
                    if (yakuhin != null)
                    {
                        sonzai_flag = 1;

                        //薬品情報取得　取得したコードで商品コードを再設定
                        if (!string.IsNullOrEmpty(yakuhin.GtinCode))
                        {
                            gcTxt_gtin_code.Text = yakuhin.GtinCode;
                        }
                        else if (!string.IsNullOrEmpty(yakuhin.JanCode))
                        {
                            gcTxt_gtin_code.Text = yakuhin.JanCode;
                        }

                        //薬品名称をセット
                        txt_yakuhinmei.Text = yakuhin.YakuhinMei + Environment.NewLine + yakuhin.KikakuTanni;

                        //薬価
                        yakka = (decimal)yakuhin.Yakka;

                        //麻薬毒薬向精神薬の情報をセット
                        if(yakuhin.DokuyakuFlag == "0")
                        {
                            //毒薬
                            madoku_kubun = Teisu.ShukkoDenpyouKubunHaikiYakuhin;
                        }
                        else if (yakuhin.GekiyakuFlag == "0")
                        {
                            //劇薬
                            madoku_kubun = Teisu.ShukkoDenpyouKubunHaikiYakuhin;
                        }
                        else if (yakuhin.MayakuFlag == "0")
                        {
                            //麻薬
                            madoku_kubun = Teisu.ShukkoDenpyouKubunHaikiMayaku;
                        }
                        else if (yakuhin.KouseishinyakuFlag == "0")
                        {
                            //向精神薬
                            madoku_kubun = Teisu.ShukkoDenpyouKubunHaikiKouseisinyaku;
                        }
                        else
                        {
                            //薬品
                            madoku_kubun = Teisu.ShukkoDenpyouKubunHaikiYakuhin;
                        }

                        //OTCフラグを０：ＯＴＣ以外でセット
                        otc_flag = 0;

                    }

                    //データがあったのなら抜ける
                    if (sonzai_flag == 1)
                    {
                        return true;
                    }

                    //OTCマスタからデータの読込
                    var otc = context.OtcMaster.FirstOrDefault(w => (w.GtinCode == search_code || w.JanCode == search_code) &&
                                                                      w.ApplyEndYmd == " ");
                    if (otc != null)
                    {
                        sonzai_flag = 2;

                        //薬品情報取得　取得したコードで商品コードを再設定
                        if (!string.IsNullOrEmpty(otc.GtinCode))
                        {
                            gcTxt_gtin_code.Text = otc.GtinCode;
                        }
                        else if (!string.IsNullOrEmpty(otc.JanCode))
                        {
                            gcTxt_gtin_code.Text = otc.JanCode;
                        }

                        //薬品名称をセット
                        txt_yakuhinmei.Text = otc.YakuhinMei;

                        //薬価
                        yakka = (decimal)otc.Yakka;

                        //OTCフラグを1：ＯＴＣでセット
                        otc_flag = 1;
                        
                    }

                }

                //データが無かった！
                if (sonzai_flag == 0)
                {
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                b2Com.ShowErrMsg(ex);
                return false;
            }
        }

        /// <summary>
        /// ロット情報管理マスタから情報の抽出
        /// </summary>
        private bool dbSelectLotinfo(string search_code)
        {
            try
            {
                //データの存在チェックフラグ
                int sonzai_flag = 0;

                using (var context = new Entities.ZaikoChouseiModel(b2Com))
                {
                    //SQL Log 出力
                    context.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);

                    //スプレッドカウント
                    int rows_count = 0;

                    //ロット情報管理マスタからデータの読込
                    var lotinfo = context.LotinfoMaster.Where(w => (w.GtinCode == search_code || w.JanCode == search_code) &&
                                                                    w.InCount > w.OutCount).OrderBy(x => x.ShiyoKigen).ToList();

                    foreach (var v in lotinfo)
                    {
                        sonzai_flag = 1;
                        fpS_Chousei.ActiveSheet.RowCount = rows_count + 1;
                        fpS_Chousei.ActiveSheet.Cells[rows_count, (int)mainColum.check_haiki].Value = false;
                        fpS_Chousei.ActiveSheet.Cells[rows_count, (int)mainColum.seizou_bangou].Value = v.LotBango;
                        if (v.ShiyoKigen.Length == 8)
                        {
                            fpS_Chousei.ActiveSheet.Cells[rows_count, (int)mainColum.siyou_kigen].Text = v.ShiyoKigen.Substring(0,4) + "年" + v.ShiyoKigen.Substring(4,2) + "月" + v.ShiyoKigen.Substring(6,2) + "日";
                            fpS_Chousei.ActiveSheet.Cells[rows_count, (int)mainColum.siyou_kigen].Value = v.ShiyoKigen;
                        }
                        else
                        {
                            fpS_Chousei.ActiveSheet.Cells[rows_count, (int)mainColum.siyou_kigen].Value = v.ShiyoKigen;
                        }
                        fpS_Chousei.ActiveSheet.Cells[rows_count, (int)mainColum.rironzaiko_suryo].Value = v.InCount - v.OutCount;
                        fpS_Chousei.ActiveSheet.Cells[rows_count, (int)mainColum.chousei_suryo].Value = 0;
                        //自動計算 rironzaiko_suryo + chousei_suryo fpS_Chousei.ActiveSheet.Cells[rows_count, (int)mainColum.chouseigo_suryo].Value = v.InCount - v.OutCount;
                        fpS_Chousei.ActiveSheet.Cells[rows_count, (int)mainColum.biko].Value = "";

                        //if(v.YjCode =="999999999999")
                        //{
                        //    otc_flag = 1;
                        //}

                        rows_count += 1;
                    }
                    
                }

                //データが無かった！
                if (sonzai_flag == 0)
                {
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                b2Com.ShowErrMsg(ex);
                return false;
            }

        }


        /// <summary>
        /// キャンセル（閉じる）
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
                ReturnValue = DialogResult.Cancel;
                b2Com.CloseDb();

                this.Close();
            }
            catch (Exception ex)
            {
                b2Com.ShowErrMsg(ex);
                b2Com.CloseDb();
                this.Close();
            }

        }

        /// <summary>
        /// ＯＫ（登録－＞終了）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ok_Click(object sender, EventArgs e)
        {
            try
            {
                //----------------------------------------------------
                //チェック処理
                //----------------------------------------------------
                if (!checkReturnData())
                {
                    return;
                }

                //----------------------------------------------------
                //テーブルへの登録・更新処理
                //----------------------------------------------------
                    if (!dbInsert())
                    {
                        ReturnValue = DialogResult.Abort;
                        b2Com.CloseDb();
                        this.Close();
                    }

                ReturnValue = DialogResult.OK;
                //----------------------------------------------------
                // 終了処理
                //----------------------------------------------------
                b2Com.CloseDb();
                this.Close();
            }
            catch (Exception ex)
            {
                b2Com.ShowErrMsg(ex);
                ReturnValue = DialogResult.Abort;
                b2Com.CloseDb();
                this.Close();
            }
        }

        /// <summary>
        /// 編集データの妥当性チェック
        /// </summary>
        /// <returns></returns>
        private bool checkReturnData()
        {
            //伝票区分
            //if (!check_denpyou_kubun())
            //{
                //return false;
            //}

 

            return true;
        }

        /// <summary>
        /// データベースへの登録処理
        /// </summary>
        /// <returns></returns>
        private bool dbInsert()
        {
            try
            {
                //登録処理の実施フラグ
                int result_flag = 0;
                for (int i = 0; i < fpS_Chousei.ActiveSheet.RowCount;i++)
                {

                    //廃棄数
                    decimal wk_haiki_suryo = 0m;
                    if (fpS_Chousei.ActiveSheet.Cells[i, (int)mainColum.chousei_suryo].Value != null)
                    {
                        if (!decimal.TryParse(fpS_Chousei.ActiveSheet.Cells[i, (int)mainColum.rironzaiko_suryo].Value.ToString(), out wk_haiki_suryo))
                        {
                            wk_haiki_suryo = 0m;
                        }
                    }

                    //入出庫数
                    decimal wk_chousei_suryo = 0m;
                    if (fpS_Chousei.ActiveSheet.Cells[i, (int)mainColum.chousei_suryo].Value != null)
                    {
                        if (!decimal.TryParse(fpS_Chousei.ActiveSheet.Cells[i, (int)mainColum.chousei_suryo].Value.ToString(), out wk_chousei_suryo))
                        {
                            wk_chousei_suryo = 0m;
                        }
                    }

                    //ＬＯＴ番号
                    string wk_LotBango = string.Empty;
                    if (fpS_Chousei.ActiveSheet.Cells[i, (int)mainColum.seizou_bangou].Value != null)
                    {
                        wk_LotBango = (string)fpS_Chousei.ActiveSheet.Cells[i, (int)mainColum.seizou_bangou].Value;
                    }

                    //使用期限
                    string wk_SiyouKigeno = string.Empty;
                    if (fpS_Chousei.ActiveSheet.Cells[i, (int)mainColum.siyou_kigen].Value != null)
                    {
                        wk_SiyouKigeno = (string)fpS_Chousei.ActiveSheet.Cells[i, (int)mainColum.siyou_kigen].Value;
                    }

                    //備考
                    string wk_Biko = string.Empty;
                    if (fpS_Chousei.ActiveSheet.Cells[i, (int)mainColum.biko].Value != null)
                    {
                        wk_Biko = (string)fpS_Chousei.ActiveSheet.Cells[i, (int)mainColum.biko].Value;
                    }

                    //廃棄処理 出庫
                    if (fpS_Chousei.ActiveSheet.Cells[i, (int)mainColum.check_haiki].Value != null && (bool)fpS_Chousei.ActiveSheet.Cells[i, (int)mainColum.check_haiki].Value == true)
                    {
                        if (wk_haiki_suryo == 0 && wk_chousei_suryo == 0)
                        {
                            continue;
                        }
                        
                        //調整数が入っていなければ在庫数全てを廃棄
                        decimal sitei_su = wk_chousei_suryo == 0 ? wk_haiki_suryo : wk_chousei_suryo;
                        
                        //----------------------------------------------------
                        //テーブルへの登録・更新処理
                        //----------------------------------------------------
                        if (!dbInsert_shukko_meisai_wk(sitei_su, wk_LotBango, wk_SiyouKigeno, wk_Biko, 1))
                        {
                            return false;
                        }
                        result_flag = 1;
                        continue;
                    }

                    if(wk_chousei_suryo == 0)
                    {
                        continue;
                    }

                    if(wk_chousei_suryo > 0)
                    {
                        //入庫
                        //----------------------------------------------------
                        //テーブルへの登録・更新処理
                        //----------------------------------------------------
                        if (!dbInsert_nyuko_meisai_wk(wk_chousei_suryo, wk_LotBango, wk_SiyouKigeno, wk_Biko))
                        {
                            return false;
                        }
                        result_flag = 1;
                    }
                    else
                    {
                        //出庫
                        //----------------------------------------------------
                        //テーブルへの登録・更新処理
                        //----------------------------------------------------
                        if (!dbInsert_shukko_meisai_wk(wk_chousei_suryo, wk_LotBango, wk_SiyouKigeno, wk_Biko, 0))
                        {
                            return false;
                        }
                        result_flag = 1;
                    }
                }

                if (result_flag == 0)
                {
                    MessageBox.Show("登録対象となるものがありませんでした。");
                }

                return true;
            }
            catch (Exception ex)
            {
                b2Com.ShowErrMsg(ex);
                return false;
            }

        }

        /// <summary>
        ///入庫データWKへの書き込み 
        /// </summary>
        /// <param name="rows_no">スプレッドの行番号</param>
        /// <returns></returns>
        private bool dbInsert_nyuko_meisai_wk(decimal Suryou,string LotBango,string SiyouKigen,string Biko)
        {
            try
            {
                decimal Count = Math.Abs(Suryou);

                using (var context = new Entities.ZaikoChouseiModel(b2Com))
                {
                    //SQL Log 出力
                    context.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);

                    //入庫データＷＫへ新規書き込み
                    var nyuko_new = context.NyukoMeisai_wk.Create();
                    {
                        //薬局コード
                        nyuko_new.YakkyokuCode = b2Com.YakkyokuCode;
                        //一意キー
                        //nyuko_new.IchiBango AUTO
                        
                        //伝票区分
                        nyuko_new.DenpyoKubun = Teisu.NyukoDenpyouKubunZaikoChousei;
                        //取引区分
                        nyuko_new.TorihikiKubun = Teisu.NyukoTorihikiKubunNyuko;
                        //処理日
                        nyuko_new.ShoriDate = DateTime.Today;
                        //商品コード区分
                        if (Shouhin_Code.Length == 14)
                        {
                            nyuko_new.ShohinCodeKubun = Teisu.ShouhinCodeKubunGtin;
                        }
                        else if (Shouhin_Code.Length == 13)
                        {
                            nyuko_new.ShohinCodeKubun = Teisu.ShouhinCodeKubunJan;
                        }
                        else
                        {
                            nyuko_new.ShohinCodeKubun = Teisu.ShouhinCodeKubunSonota;
                        }
                        //商品コード
                        nyuko_new.ShohinCode = Shouhin_Code;
                        //商品名、規格、容量
                        nyuko_new.ShohinNameKikakuYoryo = txt_yakuhinmei.Text;
                        //箱数
                        nyuko_new.HakoSuryo = 0;
                        //包装数
                        nyuko_new.HosoSuryo = 0;
                        
                        //バラ数
                        nyuko_new.BaraSuryo = Count;
 
                        //単価 最終仕入価格をセット
                        nyuko_new.Tanka = SaisyuuGenka;
                        //金額
                        nyuko_new.Kingaku = Count * SaisyuuGenka;
                        //薬価
                        nyuko_new.Yakka = yakka;
                        //消費税金額
                        nyuko_new.ShohizeiKingaku = Math.Round(((Count * SaisyuuGenka) * tax_ritu), 2); 
                        //小計金額
                        nyuko_new.ShokeKingaku = nyuko_new.Kingaku + nyuko_new.ShohizeiKingaku;
                        
                        //使用期限
                        nyuko_new.ShiyoKigen = SiyouKigen;
                        //ロット番号（製造番号）
                        nyuko_new.LotBango = LotBango;
                        //入庫日
                        nyuko_new.NyukoDate = DateTime.Today;
                        //入庫場所
                        nyuko_new.NyukoBasho = 0;
                        //発注明細番号
                        nyuko_new.HacchuMeisaiBango = 0;
                        //備考
                        nyuko_new.Biko = Biko;
                        //登録日時
                        nyuko_new.InsertNitiji = DateTime.Now;

                        // レコードををテーブルに登録。
                        context.NyukoMeisai_wk.Add(nyuko_new);

                        //DBへの物理更新
                        context.SaveChanges();
                         
                    }

                }

                return true;
            }
            catch (Exception ex)
            {
                b2Com.ShowErrMsg(ex);
                return false;
            }
        }

        /// <summary>
        ///出庫データWKへの書き込み 
        /// </summary>
        /// <param name="rows_no">スプレッドの行番号</param>
        /// <param name="mode">0:訂正出庫　1:廃棄出庫</param>
        /// <returns></returns>
        private bool dbInsert_shukko_meisai_wk(decimal Suryou, string LotBango,string SiyouKigen,string Biko,int mode)
        {
            try
            {
                decimal Count = Math.Abs(Suryou);

                using (var context = new Entities.ZaikoChouseiModel(b2Com))
                {
                    //SQL Log 出力
                    context.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);

                    //出庫データＷＫへ新規書き込み
                    var shukko_new = context.ShukkoMeisai_wk.Create();
                    {
                        //薬局コード
                        shukko_new.YakkyokuCode = b2Com.YakkyokuCode;
                        //一意キー
                        //shukko_new.IchiBango AUTO
                        
                        //伝票区分
                        if(mode == 0)
                        {
                            shukko_new.DenpyoKubun = Teisu.ShukkoDenpyouKubunZaikoChousei;
                        }
                        else
                        {
                            //廃棄伝票区分
                            shukko_new.DenpyoKubun = madoku_kubun;
                        }

                        //取引区分
                        shukko_new.TorihikiKubun = Teisu.ShukkoTorihikiKubunShukko;
                        //処理日
                        shukko_new.ShoriDate = DateTime.Today;
                        //商品コード区分
                        if (Shouhin_Code.Length == 14)
                        {
                            shukko_new.ShohinCodeKubun = Teisu.ShouhinCodeKubunGtin;
                        }
                        else if (Shouhin_Code.Length == 13)
                        {
                            shukko_new.ShohinCodeKubun = Teisu.ShouhinCodeKubunJan;
                        }
                        else
                        {
                            shukko_new.ShohinCodeKubun = Teisu.ShouhinCodeKubunSonota;
                        }
                        //商品コード
                        shukko_new.ShohinCode = Shouhin_Code;
                        //商品名、規格、容量
                        shukko_new.ShohinNameKikakuYoryo = txt_yakuhinmei.Text;
                        //箱数
                        shukko_new.HakoSuryo = 0;
                        //包装数
                        shukko_new.HosoSuryo = 0;
                        //バラ数
                        shukko_new.BaraSuryo = Count;
                        //単価
                        shukko_new.Tanka = Genka;
                        //金額
                        shukko_new.Kingaku = Count * Genka; ;
                        //薬価
                        shukko_new.Yakka = yakka;
                        
                        //消費税金額
                        shukko_new.ShohizeiKingaku = Math.Round(((Count * Genka) * tax_ritu), 2); 
                        //小計金額
                        shukko_new.ShokeKingaku = shukko_new.Kingaku + shukko_new.ShohizeiKingaku;
                        //使用期限
                        shukko_new.ShiyoKigen = SiyouKigen;
                        //ロット番号（製造番号）
                        shukko_new.LotBango = LotBango;
                        //出庫日
                        shukko_new.ShukkoDate = DateTime.Today;
                        //備考
                        shukko_new.Biko = Biko;
                        //登録日時
                        shukko_new.InsertNitiji = DateTime.Now;

                        // レコードををテーブルに登録。
                        context.ShukkoMeisai_wk.Add(shukko_new);

                        //DBへの物理更新
                        context.SaveChanges();

                    }

                }

                return true;
            }
            catch (Exception ex)
            {
                b2Com.ShowErrMsg(ex);
                return false;
            }
        }

        /// <summary>
        /// 店舗情報（消費税率等の取得）
        /// </summary>
        private void dbSelectTenpo()
        {
            try
            {
                using (var context = new Entities.ZaikoChouseiModel(b2Com))
                {
                    //SQL Log 出力
                    context.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);

                    //店舗管理マスタからデータの読込
                    var tenpo = context.TenpoMaster.FirstOrDefault(w => w.YakkyokuCode == b2Com.YakkyokuCode);

                    if (tenpo != null)
                    {
                        tax_ritu = (decimal)tenpo.SyouhiZeiritu1;
                        tax_ritu2 = (decimal)tenpo.SyouhiZeiritu2;
                    }
                }
            }
            catch (Exception ex)
            {
                b2Com.ShowErrMsg(ex);
            }

        }

        /// <summary>
        /// 単価情報の抽出　手配管理　在庫管理
        /// </summary>
        private bool dbSelectTanka(string search_code)
        {
            try
            {
                if (string.IsNullOrEmpty(search_code))
                {
                    return false;
                }

                Genka = 0m;
                SaisyuuGenka = 0m;

                using (var context = new Entities.ZaikoChouseiModel(b2Com))
                {
                    //SQL Log 出力
                    context.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);

                    //在庫情報マスタからデータの読込
                    var zaiko = context.ZaikoMaster.FirstOrDefault(w => w.YakkyokuCode == b2Com.YakkyokuCode &&
                                                              (w.GtinCode == search_code ||
                                                               w.JanCode == search_code));
                    if (zaiko != null)
                    {
                        Genka = (decimal)zaiko.Genka;
                        SaisyuuGenka = (decimal)zaiko.SaisyuuGenka;
                    }
                    else
                    {
                        return false;
                    }

                }
                return true;
            }
            catch (Exception ex)
            {
                b2Com.ShowErrMsg(ex);
                return false;
            }

        }


    }
}
