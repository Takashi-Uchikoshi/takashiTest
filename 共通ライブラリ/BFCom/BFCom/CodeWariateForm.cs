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
 * 20180315 打越 製造着手
*/
//UNDONE 割当ダイアログ　現在開発中
#endregion

namespace B2.BestFunction
{
    public partial class CodeWariateForm : Form
    {
#region 機能概要
/*
 * ファイル名　　　　　: frm_Code_Wariate.cs
 * 説明        　　　　: レセコンコードを商品コード（GTIN,JAN)へ紐付ける
 *  
*/
#endregion


        #region
        /// <summary>
        /// 呼び出し元への復帰情報
        /// </summary>
        public DialogResult ReturnValue = DialogResult.None;
        #endregion

        /// <summary> コード情報　0：レセコンコード　1:GTINコード　2:ＪＡＮコード   /// </summary>
        public int action_mode = 1;
        
        /// <summary> 編集モード　0：新規　1:訂正　2:参照   /// </summary>
        public int edit_mode = 0;
        public string start_use_date = "0";

        /// <summary> 紐付けＣｏｄｅ /// </summary>
        public string search_code = string.Empty;

        /// <summary>共通パラメータ</summary>
        private B2Com b2Com;
        
        /// <summary>GTIN 退避用</summary>
        private string gtin_code_save = string.Empty;
        private decimal zaiko_total_save = 0m;

        //DB用アダプタ
        NpgsqlDataAdapter oAdp;

        //定数
        const string title = "割当ダイアログ";

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public CodeWariateForm()
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
        }

        /// <summary>
        /// フォーム起動ファンクション
        /// </summary>
        /// <param name="mode">コード情報　0：レセコンコード　1:GTINコード　2:ＪＡＮコード</param>
        /// <param name="code">レセコンコード　Or　GTINコード　OrＪＡＮコード</param>
        /// <returns></returns>
        static public DialogResult ShowForm(int mode, string code)
        {
            //引数エラーのチェック
            if(mode < 0 || mode > 2)
            {
                MessageBox.Show("引数が正しくありません。");
                return DialogResult.Abort;
            }

            CodeWariateForm f = new CodeWariateForm();
            f.action_mode = mode;
            f.search_code = code;
            //編集モード：新規　固定
            f.edit_mode = 0;
            f.ShowDialog();
            DialogResult receiveValue = f.ReturnValue;
            f.Dispose();
            return receiveValue;
        }

        /// <summary>
        /// フォーム起動ファンクション
        /// </summary>
        /// <param name="mode">コード情報　0：レセコンコード　1:GTINコード　2:ＪＡＮコード</param>
        /// <param name="code">レセコンコード　Or　GTINコード　OrＪＡＮコード</param>
        /// <param name="mode2">編集モード　0：新規　1:訂正 2:参照</param>
        /// <param name="use_date">使用開始日</param>
        /// <returns></returns>
        static public DialogResult ShowForm(int mode, string code, int mode2, string use_date)
        {
            //引数エラーのチェック
            if (mode < 0 || mode > 2)
            {
                MessageBox.Show("引数が正しくありません。");
                return DialogResult.Abort;
            }

            if (mode2 < 0 || mode2 > 2)
            {
                MessageBox.Show("引数が正しくありません。");
                return DialogResult.Abort;
            }

            CodeWariateForm f = new CodeWariateForm();
            f.action_mode = mode;
            f.search_code = code;
            f.edit_mode = mode2;
            f.start_use_date = use_date;
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
        private void frm_Code_Wariate_Load(object sender, EventArgs e)
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
        /// Shownイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frm_Code_Wariate_Shown(object sender, EventArgs e)
        {
            try
            {
                //--------------------------------------
                // 初期化
                //--------------------------------------
                //バックカラーの設定
                b2Com.SetBackColor(this);

                //表示エリアのクリア
                setInitialize();

                //仕入先コンボボックスの設定
                ctlCom_shiiresaki.Init(b2Com, "shiiresaki_master", "shiiresaki_cd", "name");

                //指定データの抽出と表示
                setSearchInfo();

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
        private void setInitialize()
        {
            try
            {
                //--------------------------------------
                // クリア処理 ヘッダ
                //--------------------------------------
                txt_yakkyoku_code.Text = "";
                gcTxt_resekon_code.Text = "";
                gcTxt_yj_code.Text = "";
                gcTxt_gtin_code.Text = "";
                gcTxt_gtin_chouzai.Text = "";
                gcTxt_jan_code.Text = "";

                //--------------------------------------
                // クリア処理 薬品情報
                //--------------------------------------
                lbl_senpatu.Text = "";
                txt_yakuhinmei.Text = "";
                txt_yakuhinmei_kana.Text = "";
                lbl_kikaku.Text = "";
                lbl_housoukeitai.Text = "";
                lbl_kubun.Text = "";
                gcNum_irisu.Value = 0;
                gcNum_heatsu.Value = 0;
                lbl_seizoukaisya.Text = "";
                lbl_hanbaikaisya.Text = "";
                gcNum_yakka.Value = 0;
                lbl_tanajyouhou.Text = "";

                //--------------------------------------
                // クリア処理 設定項目
                //--------------------------------------
                ctlCom_shiiresaki.Text = "";
                gcNum_kounyuuka.Value = 0;
                gcCom_hachuukubun.SelectedIndex = 1;
                gcNum_hachuuten.Value = 0;
                gcNum_anzenzaiko.Value = 0;
                gcNum_hachuusu.Value = 1;
                gcTxt_hachuutani.Text = "箱";
                gcCom_raikyokuyotei.SelectedIndex = 1;
                gcNum_leadtime.Value = 1;
                gcNum_yosokujyousu.Value = 1;
                gcCom_barahiito.SelectedIndex = 1;
                gcTxt_start_use_date.Text = "0";


                //--------------------------------------
                // 選択ボタンを非アクティブ
                //--------------------------------------
         //       btn_ok.Enabled = false;

            }
            catch (Exception ex)
            {
                b2Com.ShowErrMsg(ex);
            }
        }

        /// <summary>
        /// 起動パラメータ情報を表示エリアにセット
        /// </summary>
        private void setSearchInfo()
        {

            try 
            {
                //薬局コード
                txt_yakkyoku_code.Text = b2Com.YakkyokuCode;

                //action_mode
                /// <summary> 起動情報　0：レセコンコード　1:GTINコード　2:ＪＡＮコード   /// </summary>
                switch (action_mode)
                {
                    case 0:
                        //レセコンコード指定：　GTIN(JAN)紐付け未確定,手配管理に登録済み
                        btn_select.Visible = true;
                        gcTxt_gtin_code.BackColor = Color.White;
                        gcTxt_gtin_code.ReadOnly = false;
                        gcTxt_resekon_code.BackColor = Color.LemonChiffon;
                        gcTxt_resekon_code.ReadOnly = true;

                        gcTxt_resekon_code.Text = search_code;

                        break;

                    case 1:
                        //GTINコード指定　：　レセコンコード未確定,手配管理に未登録
                        btn_select.Visible = false;
                        gcTxt_gtin_code.BackColor = Color.LemonChiffon;
                        gcTxt_gtin_code.ReadOnly = true;
                        gcTxt_resekon_code.BackColor = Color.White;
                        gcTxt_resekon_code.ReadOnly = false;

                        gcTxt_gtin_code.Text = search_code;
                        break;

                    case 2:
                        //JANコード指定 　：　レセコンコード未確定,手配管理に未登録,OTCの時
                        btn_select.Visible = false;
                        gcTxt_gtin_code.BackColor = Color.LemonChiffon;
                        gcTxt_gtin_code.ReadOnly = true;
                        gcTxt_resekon_code.BackColor = Color.LemonChiffon;
                        gcTxt_resekon_code.ReadOnly = true;
                        gcTxt_resekon_code.Text = search_code;
                        gcTxt_jan_code.Text = search_code;
                        break;

                    default:
                        //引数エラー
                        MessageBox.Show("引数が正しくありません。");
                        this.DialogResult = DialogResult.None;
                        this.Close();
                        break;
                }


                //edit_mode　設定エリア
                /// <summary> 編集モード　0：新規　1:訂正　2:参照   /// </summary>
                switch (edit_mode)
                {
                    case 0:
                        //新規
                        lbl_title.Text = title + " 新規";

                        lbl_start_use_date.Visible = false;
                        gcTxt_start_use_date.Visible = false;
                        lbl_start_use_date_ex.Visible = false;

                        ctlCom_shiiresaki.Enabled = true;
                        gcNum_kounyuuka.Enabled = true;
                        gcCom_hachuukubun.Enabled = true;
                        gcNum_hachuuten.Enabled = true;
                        gcNum_anzenzaiko.Enabled = true;
                        gcNum_hachuusu.Enabled = true;
                        gcTxt_hachuutani.Enabled = true;
                        gcCom_raikyokuyotei.Enabled = true;
                        gcNum_leadtime.Enabled = true;
                        gcNum_yosokujyousu.Enabled = true;
                        gcCom_barahiito.Enabled = true;
//                        gcTxt_start_use_date.Enabled = true;
                        break;

                    case 1:
                        //訂正
                        lbl_title.Text = title + " 訂正";

                        lbl_start_use_date.Visible = true;
                        gcTxt_start_use_date.Visible = true;
                        lbl_start_use_date_ex.Visible = true;

                        ctlCom_shiiresaki.Enabled = true;
                        gcNum_kounyuuka.Enabled = true;
                        gcCom_hachuukubun.Enabled = true;
                        gcNum_hachuuten.Enabled = true;
                        gcNum_anzenzaiko.Enabled = true;
                        gcNum_hachuusu.Enabled = true;
                        gcTxt_hachuutani.Enabled = true;
                        gcCom_raikyokuyotei.Enabled = true;
                        gcNum_leadtime.Enabled = true;
                        gcNum_yosokujyousu.Enabled = true;
                        gcCom_barahiito.Enabled = true;
                        gcTxt_start_use_date.Enabled = true;
                        break;

                    case 2:
                        //参照
                        lbl_title.Text = title + " 参照";

                        lbl_start_use_date.Visible = true;
                        gcTxt_start_use_date.Visible = true;
                        lbl_start_use_date_ex.Visible = true;

                        ctlCom_shiiresaki.Enabled = false;
                        gcNum_kounyuuka.Enabled = false;
                        gcCom_hachuukubun.Enabled = false;
                        gcNum_hachuuten.Enabled = false;
                        gcNum_anzenzaiko.Enabled = false;
                        gcNum_hachuusu.Enabled = false;
                        gcTxt_hachuutani.Enabled = false;
                        gcCom_raikyokuyotei.Enabled = false;
                        gcNum_leadtime.Enabled = false;
                        gcNum_yosokujyousu.Enabled = false;
                        gcCom_barahiito.Enabled = false;
                        gcTxt_start_use_date.Enabled = false;

                        btn_ok.Enabled = false;
                        break;

                    default:
                        //引数エラー
                        MessageBox.Show("引数が正しくありません。");
                        this.DialogResult = DialogResult.None;
                        this.Close();
                        break;
                }



                //データの抽出
                dbSelect();
            }
            catch (Exception ex)
            {
                b2Com.ShowErrMsg(ex);
            }
        
        }

        /// <summary>
        /// 手配管理、薬品マスタ、発注点情報管理、棚情報　から情報の抽出
        /// </summary>
        private void dbSelect()
        {
            try
            {
                using (var context = new Entities.CodeWariateModel(b2Com))
                {
                    //SQL Log 出力
                    context.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);

                    switch(edit_mode)
                    {
                        case 0:
                            //手配管理マスタからデータの読込 レセコンコード、GTINコードをキーにして読み込み
                            var tehai = context.TehaiMaster.Where(w => w.YakkyokuCode == b2Com.YakkyokuCode &&
                                                                      ( w.MeisaiCode == gcTxt_resekon_code.Text ||
                                                                        w.GtinCode == gcTxt_gtin_code.Text)).ToList();
                            foreach (var v in tehai)
                            {
                                txt_yakkyoku_code.Text = v.YakkyokuCode;
                                //gcTxt_resekon_code.Text = v.MeisaiCode;
                                gcTxt_yj_code.Text = v.YjCode.Trim() == "0" ? "" : v.YjCode;
                                gcTxt_jan_code.Text = v.JanCode.Trim() == "0" ? "" : v.JanCode;
                                gcTxt_gtin_code.Text = v.GtinCode.Trim() == "0" ? "" : v.GtinCode;

                                ctlCom_shiiresaki.SelectedIndex = int.Parse(v.ShiiresakiCode);

                                gcNum_kounyuuka.Value = v.Price;


                                //ＹＪコードが存在すれば、ＧＴＩＮは選択
                                if (!string.IsNullOrWhiteSpace(gcTxt_yj_code.Text))
                                {
                                    gcTxt_gtin_code.BackColor = Color.LemonChiffon;
                                    gcTxt_gtin_code.ReadOnly = true;
                                }

                                break;
                            }

                            break;
                        case 1:
                        case 2:
                            //手配管理マスタからデータの読込 レセコンコード、GTINコード,使用開始日をキーにして読み込み
                            int record_ari_flag = 0;
                            Int64 start_ud = 0;
                            if(!Int64.TryParse(start_use_date,out start_ud))
                            {
                                start_ud = 0;
                            }

                            var tehai_edit = context.TehaiMaster.Where(w => w.YakkyokuCode == b2Com.YakkyokuCode &&
                                                                              (w.MeisaiCode == gcTxt_resekon_code.Text ||
                                                                               w.GtinCode == gcTxt_gtin_code.Text ||
                                                                               w.JanCode == gcTxt_jan_code.Text) &&
                                                                             w.StartUseDate == start_ud).ToList();
                            foreach (var v in tehai_edit)
                            {
                                if (edit_mode == 1 && v.EndUseDate != 99999999)
                                {
                                    MessageBox.Show("選択された指定コード:" + search_code + "　の情報が最新のものではありません\r\n" +
                                                    "訂正は、最新の情報しか編集出来ません。");
                                    ReturnValue = DialogResult.Abort;
                                    this.Close();
                                    return;
                                }

                                record_ari_flag = 1;
                                txt_yakkyoku_code.Text = v.YakkyokuCode;
                                //gcTxt_resekon_code.Text = v.MeisaiCode;
                                gcTxt_yj_code.Text = v.YjCode.Trim() == "0" ? "" : v.YjCode;
                                gcTxt_jan_code.Text = v.JanCode.Trim() == "0" ? "" : v.JanCode;
                                gcTxt_gtin_code.Text = v.GtinCode.Trim() == "0" ? "" : v.GtinCode;

                                ctlCom_shiiresaki.SelectedIndex = int.Parse(v.ShiiresakiCode);

                                gcNum_kounyuuka.Value = v.Price;

                                gcTxt_start_use_date.Text = v.StartUseDate.ToString();

                                //ＹＪコードが存在すれば、ＧＴＩＮは選択
                                if (!string.IsNullOrWhiteSpace(gcTxt_yj_code.Text))
                                {
                                    gcTxt_gtin_code.BackColor = Color.LemonChiffon;
                                    gcTxt_gtin_code.ReadOnly = true;
                                }

                                break;
                            }
                            //訂正、参照モードで一致するデータが無い時は、メッセージを出し復帰する。
                            if (record_ari_flag == 0)
                            {
                                MessageBox.Show("指定コード:" + search_code + " 使用開始日:" + start_use_date + "の\r\n" +
                                                "情報が登録されていません。");
                                ReturnValue = DialogResult.Abort;
                                this.Close();
                                return;
                            }
                            break;
                    }

                    //薬品マスタからデータの読込
                    var yakuhin = context.YakuhinMaster.Where(w => w.GtinCode == gcTxt_gtin_code.Text && w.ApplyEndYmd == " ").ToList();
                    foreach (var v in yakuhin)
                    {
                        gcTxt_yj_code.Text = v.YjCode;
                        gcTxt_jan_code.Text = v.JanCode;

                        //HACK 後発に変更が必要
                        lbl_senpatu.Text = v.MayakuFlag.ToString();
                        txt_yakuhinmei.Text = v.YakuhinMei;
                        txt_yakuhinmei_kana.Text = v.YakuhinKana;
                        lbl_kikaku.Text = v.KikakuTanni;
                        lbl_housoukeitai.Text = v.HousouKeitai;
                        lbl_kubun.Text = v.Kubun;
                        gcNum_irisu.Value = v.HousouSouryouQty;
                        gcNum_heatsu.Value = v.HousouTanniQty;
                        lbl_seizoukaisya.Text = v.SeizouKaishaMei;
                        lbl_hanbaikaisya.Text = v.HanbaiKaishaMei;
                        gcNum_yakka.Value = v.Yakka;
                        break;
                    }

                    //OTCマスタからデータの読込
                    var otc = context.OtcMaster.Where(w => w.JanCode == gcTxt_jan_code.Text).ToList();
                    foreach (var v in otc)
                    {
                        gcTxt_yj_code.Text = v.YjCode;
                        gcTxt_jan_code.Text = v.JanCode;
                        gcTxt_gtin_code.Text = v.GtinCode;

                        //OTCに先発、後発区分は無い
                        lbl_senpatu.Text = "";
                        txt_yakuhinmei.Text = v.YakuhinMei;
                        txt_yakuhinmei_kana.Text = v.YakuhinKana;
                        lbl_kikaku.Text = v.KikakuTanni;
                        lbl_housoukeitai.Text = v.HousouKeitai;
                        lbl_kubun.Text = v.Kubun;
                        gcNum_irisu.Value = v.HousouSouryouQty;
                        gcNum_heatsu.Value = v.HousouTanniQty;
                        lbl_seizoukaisya.Text = v.SeizouKaishaMei;
                        lbl_hanbaikaisya.Text = v.HanbaiKaishaMei;
                        gcNum_yakka.Value = v.Yakka;
                        break;
                    }



                    //棚番商品管理マスタからデータの読込
                    lbl_tanajyouhou.Text = "";
                    var tanasyouhin = context.TanabanSyouhin.Where(w => w.YakkyokuCode == b2Com.YakkyokuCode &&
                                                                        w.GtinCode == gcTxt_gtin_code.Text).ToList();
                    foreach (var v in tanasyouhin)
                    {
                        var tana = context.TanabanMaster.Where(w => w.TanabanCode == v.TanabanCode).ToList();
                        foreach (var x in tana)
                        {
                            lbl_tanajyouhou.Text += (x.TanabanMei + " ");
                        }
                    }

                    //発注点管理情報マスタからデータの読込
                    var hachuu = context.HachukanriMaster.Where(w => w.YakkyokuCode == b2Com.YakkyokuCode &&
                                                                     w.GtinCode == gcTxt_gtin_code.Text).ToList();
                    foreach (var v in hachuu)
                    {
                        gcCom_hachuukubun.SelectedIndex = (int)v.HachukohoKubun;
                        gcNum_hachuuten.Value = v.HachutenSuryo;
                        gcNum_anzenzaiko.Value = v.AnzenzaikoSuryo;
                        gcNum_hachuusu.Value = v.HachuSuryo;
                        gcTxt_hachuutani.Text = v.HachuTani;
                        gcCom_raikyokuyotei.SelectedIndex = (int)v.Raikyokubun;
                        gcNum_leadtime.Value = v.Leadtime;
                        gcNum_yosokujyousu.Value = v.YosokuJyousu;
                        gcCom_barahiito.SelectedIndex = (int)v.BarahitoGassan;
                        break;
                    }

                    //在庫情報マスタからデータの読込
                    var zaiko = context.ZaikoMaster.Where(w => w.YakkyokuCode == b2Com.YakkyokuCode &&
                                                                w.GtinCode == gcTxt_gtin_code.Text).ToList();
                    foreach (var v in zaiko)
                    {
                        zaiko_total_save = (decimal)v.ZaikoTotal;
                        break;
                    }

                
                }
            }
            catch (Exception ex)
            {
                b2Com.ShowErrMsg(ex);
            }

        }

        /// <summary>
        /// 薬品検索(GTIN or YJ)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_select_Click(object sender, EventArgs e)
        {
            //GTINコードの退避
            gtin_code_save = string.Empty;
            if (!string.IsNullOrWhiteSpace(gcTxt_gtin_code.Text))
            {
                gtin_code_save = gcTxt_gtin_code.Text;
            }
            
            //商品検索
            int search_flag = 0;
            string search_code = string.Empty;
            if (!string.IsNullOrWhiteSpace(gcTxt_yj_code.Text))
            {
                search_flag = 1;
                search_code = gcTxt_yj_code.Text;
            }
            else if (!string.IsNullOrWhiteSpace(gcTxt_gtin_code.Text))
            {
                search_code = gcTxt_gtin_code.Text;
            }
            else if (!string.IsNullOrWhiteSpace(gcTxt_jan_code.Text))
            {
                search_code = gcTxt_jan_code.Text;
            }


            KensakuSyouhinForm f = new KensakuSyouhinForm();
            f.search_code = search_code;
            f.action_mode = string.IsNullOrEmpty(search_code) ? 0 : 1;
            var result = f.ShowDialog();
            if (result == DialogResult.OK)
            {
                //--------------------------------------
                // チェック
                //--------------------------------------
                if (gtin_code_save.Trim() != f.kensaku_result.gtin_code.Trim() &&
                    zaiko_total_save > 0 )
                {
                    //紐付ける商品（GTIN)が変更になった。
                    MessageBox.Show("現在の商品コードに在庫があるため商品コードを変更出来ません。");
                    return;
                }

                if(!string.IsNullOrEmpty(f.kensaku_result.meisai_code)   &&
                    gcTxt_resekon_code.Text.Trim() != f.kensaku_result.meisai_code.Trim())
                {
                    //紐付ける商品（GTIN)に別のレセコンコードが割りあたっていた。
                    MessageBox.Show("選択された商品コード:" +  f.kensaku_result.gtin_code + "  に\r\n" +
                                    "レセコンコード:" + f.kensaku_result.meisai_code + "が\r\n" + 
                                    "既に割りあたっています。");
                    return;
                }

                //--------------------------------------
                // ヘッダ設定
                //--------------------------------------
                gcTxt_gtin_code.Text = f.kensaku_result.gtin_code;
                gcTxt_gtin_chouzai.Text = f.kensaku_result.gtin_code_chozaihosotani;
                gcTxt_jan_code.Text = f.kensaku_result.jan_code;

                if(search_flag == 0)
                {
                    gcTxt_yj_code.Text = f.kensaku_result.yj_code;
                }

                //--------------------------------------
                // クリア処理 薬品情報
                //--------------------------------------
                lbl_senpatu.Text = f.kensaku_result.kouhatu_flag.ToString();
                txt_yakuhinmei.Text = f.kensaku_result.yakuhin_mei;
                txt_yakuhinmei_kana.Text = f.kensaku_result.yakuhin_kana;
                lbl_kikaku.Text = f.kensaku_result.kikaku_tanni;
                lbl_housoukeitai.Text = f.kensaku_result.housou_keitai;
                lbl_kubun.Text = f.kensaku_result.kubun;
                gcNum_irisu.Value = f.kensaku_result.housou_souryou_qty;
                gcNum_heatsu.Value = f.kensaku_result.housou_tanni_qty;
                lbl_seizoukaisya.Text = f.kensaku_result.seizou_kaisha_mei;
                lbl_hanbaikaisya.Text = f.kensaku_result.hanbai_kaisha_mei;
                gcNum_yakka.Value = f.kensaku_result.yakka;
                lbl_tanajyouhou.Text = "";

                //登録ボタンの有効化
                btn_ok.Enabled = true;
            }
        }

        /// <summary>
        /// JANコードで薬品検索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_select_jan_Click(object sender, EventArgs e)
        {
            try
            {
                //NOTE:実装予定は、将来
            }
            catch (Exception ex)
            {
                b2Com.ShowErrMsg(ex);
            }
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
                ReturnValue = DialogResult.Cancel;
                b2Com.CloseDb();

                this.Close();
            }
            catch (Exception ex)
            {
                b2Com.ShowErrMsg(ex);
            }

        }
        /// <summary>
        /// 登録処理
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
                if (ctlCom_shiiresaki.SelectedIndex == 0)
                {
                    MessageBox.Show("仕入先が選択されていません。");
                    ctlCom_shiiresaki.Focus();
                    return;
                }
                
                //----------------------------------------------------
                //テーブルへの登録・更新処理
                //----------------------------------------------------
                if(dbInsert())
                {
                    ReturnValue = DialogResult.OK;
                }
                else
                {
                    ReturnValue = DialogResult.Abort;
                }

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
                this.Close();
            }
        }

        /// <summary>
        /// 手配管理、在庫管理、発注点情報管理へレコードの登録
        /// </summary>
        private bool dbInsert()
        {
            try
            {
                using (var context = new Entities.CodeWariateModel(b2Com))
                {
                    //SQL Log 出力
                    context.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);

                    //手配管理マスタからデータの読込 レセコンコード、GTINコードをキーにして読み込み
                    int start_ud = 0;
                    if (!int.TryParse(start_use_date, out start_ud))
                    {
                        start_ud = 0;
                    }
                    var tehai = context.TehaiMaster.FirstOrDefault(w => w.YakkyokuCode == b2Com.YakkyokuCode &&
                                                                      (w.MeisaiCode == gcTxt_resekon_code.Text ||
                                                                       w.GtinCode == gcTxt_gtin_code.Text) &&
                                                                       w.StartUseDate == start_ud);
                    if (tehai != null)
                    {
                        //データが存在した場合

                        //使用開始日が変更されているか
                        if (start_use_date != gcTxt_start_use_date.Text)
                        {
                            //string use_date = gcTxt_start_use_date.Text;
                            DateTime use_date;
                            if (!DateTime.TryParse(gcTxt_start_use_date.Text,out use_date))
                            {
                                use_date = DateTime.Now;
                            }

                            //変更されている
                            //　修正前のレコードを　履歴用に更新　使用終了
                            tehai.EndUseDate = int.Parse(use_date.AddDays(-1).ToString("yyyyMMdd"));

                            //新しいデータで新規追加
                            var tehai_new = context.TehaiMaster.Create();
                            {

                                //薬局
                                tehai_new.YakkyokuCode = txt_yakkyoku_code.Text;
                                //YJ
                                tehai_new.YjCode = gcTxt_yj_code.Text;
                                //GTIN
                                tehai_new.GtinCode = gcTxt_gtin_code.Text;
                                //JAN
                                tehai_new.JanCode = gcTxt_jan_code.Text;
                                //明細
                                if (gcTxt_yj_code.Text == "999999999999")
                                {
                                    tehai_new.MeisaiCode = gcTxt_jan_code.Text;
                                }
                                else
                                {
                                    tehai_new.MeisaiCode = gcTxt_resekon_code.Text;
                                }
                                //仕入先コード
                                tehai_new.ShiiresakiCode = ctlCom_shiiresaki.SelectedValue.ToString();
                                //購入価
                                tehai_new.Price = gcNum_kounyuuka.Value;
                                //登録日
                                tehai_new.InsertDate = DateTime.Now;
                                //更新日
                                tehai_new.UpdateDate = DateTime.Now;
                                //使用開始
                                tehai_new.StartUseDate = int.Parse(use_date.ToString("yyyyMMdd")); 
                                //使用終了
                                tehai_new.EndUseDate = 99999999;
                                //通知識別
                                tehai_new.TsuchiSikibetsu = 0;
                                //通知日時
                                //tehai_new.TsuchiDate
                                //削除フラグ
                                tehai_new.SakujyoFlag = 0;
                                // レコードををテーブルに登録。
                                context.TehaiMaster.Add(tehai_new);

                            }

                            //DBへの物理更新
                            context.SaveChanges();

                        }
                        else
                        {
                            //○使用開始日に変更が無い　単純更新

                            //薬局
                            //tehai.YakkyokuCode = txt_yakkyoku_code.Text;
                            //YJ
                            tehai.YjCode = gcTxt_yj_code.Text;
                            //GTIN
                            tehai.GtinCode = gcTxt_gtin_code.Text;
                            //JAN
                            tehai.JanCode = gcTxt_jan_code.Text;
                            //明細
                            if (gcTxt_yj_code.Text == "999999999999")
                            {
                                tehai.MeisaiCode = gcTxt_jan_code.Text;
                            }
                            else
                            {
                                tehai.MeisaiCode = gcTxt_resekon_code.Text;
                            }
                            //仕入先コード
                            // tehai.ShiiresakiCode = ctlCom_shiiresaki.SelectedValue.ToString();
                            tehai.ShiiresakiCode = ctlCom_shiiresaki.GetCode();
                            //購入価
                            tehai.Price = gcNum_kounyuuka.Value;
                            ////登録日
                            //tehai.InsertDate = DateTime.Now;
                            //更新日
                            tehai.UpdateDate = DateTime.Now;
                            //使用開始
                            //tehai.StartUseDate = 0;
                            //使用終了
                            //tehai.EndUseDate = 99999999;
                            //通知識別
                            tehai.TsuchiSikibetsu = 0;
                            //通知日時
                            //tehai.TsuchiDate
                            //削除フラグ
                            tehai.SakujyoFlag = 0;

                            //DBへの物理更新
                            context.SaveChanges();
                        }
                    }
                    else
                    {
                        //○データが存在しなかったた場合 新規追加
                        var tehai_new = context.TehaiMaster.Create();
                        {
                            //薬局
                            tehai_new.YakkyokuCode = txt_yakkyoku_code.Text;
                            //YJ
                            tehai_new.YjCode = gcTxt_yj_code.Text;
                            //GTIN
                            tehai_new.GtinCode = gcTxt_gtin_code.Text;
                            //JAN
                            tehai_new.JanCode = gcTxt_jan_code.Text;
                            //明細
                            if (gcTxt_yj_code.Text == "999999999999")
                            {
                                tehai_new.MeisaiCode = gcTxt_jan_code.Text;
                            }
                            else
                            {
                                tehai_new.MeisaiCode = gcTxt_resekon_code.Text;
                            }
                            //仕入先コード
                            tehai_new.ShiiresakiCode = ctlCom_shiiresaki.SelectedValue.ToString();
                            //購入価
                            tehai_new.Price = gcNum_kounyuuka.Value;
                            //登録日
                            tehai_new.InsertDate = DateTime.Now;
                            //更新日
                            tehai_new.UpdateDate = DateTime.Now;
                            //使用開始
                            tehai_new.StartUseDate = 0;
                            //使用終了
                            tehai_new.EndUseDate = 99999999;
                            //通知識別
                            tehai_new.TsuchiSikibetsu = 0;
                            //通知日時
                            //tehai_new.TsuchiDate
                            //削除フラグ
                            tehai_new.SakujyoFlag = 0;
                            // レコードををテーブルに登録。
                            context.TehaiMaster.Add(tehai_new);

                            //DBへの物理更新
                            context.SaveChanges();
                        }
                    }

                    //発注点管理情報
                    var hachuu = context.HachukanriMaster.FirstOrDefault(w => w.YakkyokuCode == b2Com.YakkyokuCode &&
                                                                               w.GtinCode == gcTxt_gtin_code.Text);
                    if (hachuu != null)
                    {
                        //○データが存在した場合
                        //薬局
                        hachuu.YakkyokuCode = txt_yakkyoku_code.Text;
                        //YJ
                        hachuu.YjCode = gcTxt_yj_code.Text;
                        //GTIN
                        hachuu.GtinCode = gcTxt_gtin_code.Text;
                        //JAN
                        hachuu.JanCode = gcTxt_jan_code.Text;
                        //発注候補区分
                        hachuu.HachukohoKubun = gcCom_hachuukubun.SelectedIndex;
                        //発注点
                        hachuu.HachutenSuryo = gcNum_hachuuten.Value;
                        //安全在庫数量
                        hachuu.AnzenzaikoSuryo = gcNum_anzenzaiko.Value;
                        //発注数
                        hachuu.HachuSuryo = (int)gcNum_hachuusu.Value;
                        //発注単位
                        hachuu.HachuTani = gcTxt_hachuutani.Text;
                        //リードタイム日数
                        hachuu.Leadtime = (int)gcNum_leadtime.Value;
                        //予測最大調剤数の乗数
                        hachuu.YosokuJyousu = gcNum_yosokujyousu.Value;
                        //バラとヒート合算
                        hachuu.BarahitoGassan = gcCom_barahiito.SelectedIndex;
                        //使用開始
                        hachuu.StartUseDate = 0;
                        //使用終了
                        hachuu.EndUseDate = 99999999;
                        //通知識別
                        hachuu.TsuchiSikibetsu = 0;
                        //通知日時
                        //　未設定
                        //削除フラグ
                        hachuu.SakujyoFlag = 0;

                        //DBへの物理更新
                        context.SaveChanges();
                    }
                    else
                    {
                        //○データが存在しなかったた場合 新規追加
                        var hachuu_new = context.HachukanriMaster.Create();
                        {
                            //○データが存在した場合
                            //薬局
                            hachuu_new.YakkyokuCode = txt_yakkyoku_code.Text;
                            //YJ
                            hachuu_new.YjCode = gcTxt_yj_code.Text;
                            //GTIN
                            hachuu_new.GtinCode = gcTxt_gtin_code.Text;
                            //JAN
                            hachuu_new.JanCode = gcTxt_jan_code.Text;
                            //発注候補区分
                            hachuu_new.HachukohoKubun = gcCom_hachuukubun.SelectedIndex;
                            //発注点
                            hachuu_new.HachutenSuryo = gcNum_hachuuten.Value;
                            //安全在庫数量
                            hachuu_new.AnzenzaikoSuryo = gcNum_anzenzaiko.Value;
                            //発注数
                            hachuu_new.HachuSuryo = (int)gcNum_hachuusu.Value;
                            //発注単位
                            hachuu_new.HachuTani = gcTxt_hachuutani.Text;
                            //リードタイム日数
                            hachuu_new.Leadtime = (int)gcNum_leadtime.Value;
                            //予測最大調剤数の乗数
                            hachuu_new.YosokuJyousu = gcNum_yosokujyousu.Value;
                            //バラとヒート合算
                            hachuu_new.BarahitoGassan = gcCom_barahiito.SelectedIndex;
                            //使用開始
                            hachuu_new.StartUseDate = 0;
                            //使用終了
                            hachuu_new.EndUseDate = 99999999;
                            //通知識別
                            hachuu_new.TsuchiSikibetsu = 0;
                            //通知日時
                            //　未設定
                            //削除フラグ
                            hachuu_new.SakujyoFlag = 0;

                            // レコードををテーブルに登録。
                            context.HachukanriMaster.Add(hachuu_new);

                            //DBへの物理更新
                            context.SaveChanges();
                        }

                    }
                 
                    //在庫情報マスタからデータの読込
                    var zaiko = context.ZaikoMaster.FirstOrDefault(w => w.YakkyokuCode == b2Com.YakkyokuCode &&
                                                                         w.GtinCode == gcTxt_gtin_code.Text);
                    if(zaiko != null)
                    {
                        //○データが存在した場合
                        //薬局
                        zaiko.YakkyokuCode = txt_yakkyoku_code.Text;
                        //YJ
                        zaiko.YjCode = gcTxt_yj_code.Text;
                        //GTIN
                        zaiko.GtinCode = gcTxt_gtin_code.Text;
                        //JAN
                        zaiko.JanCode = gcTxt_jan_code.Text;
                        ////在庫数 更新しない
                        //zaiko.ZaikoTotal = 0;
                        //箱数 更新しない
                        //zaiko.HakoSuryo = 0;
                        //包装数(ヒート数） 更新しない
                        //zaiko.HosoSuryo = 0;
                        //バラ指数 更新しない
                        //zaiko.BaraSuryo = 0;
                        //原価単価 更新しない
                        //zaiko.Genka = 0;
                        //最終仕入れ単価 更新しない
                        //zaiko.SaisyuuGenka = 0;
                        //登録日 更新しない
                        //zaiko.InsertDate = DateTime.Now;
                        //更新日
                        zaiko.UpdateDate = DateTime.Now;
                        //使用開始
                        zaiko.StartUseDate = 0;
                        //使用終了
                        zaiko.EndUseDate = 99999999;
                        //通知識別
                        zaiko.TsuchiSikibetsu = 0;
                        //通知日時 更新しない
                        //zaiko.TsuchiDate

                        //DBへの物理更新
                        context.SaveChanges();
                    }
                    else
                    {
                        //○データが存在しなかった場合 新規追加
                        //薬局
                        var zaiko_new = context.ZaikoMaster.Create();
                        {
                            zaiko_new.YakkyokuCode = txt_yakkyoku_code.Text;
                            //YJ
                            zaiko_new.YjCode = gcTxt_yj_code.Text;
                            //GTIN
                            zaiko_new.GtinCode = gcTxt_gtin_code.Text;
                            //JAN
                            zaiko_new.JanCode = string.IsNullOrWhiteSpace(gcTxt_jan_code.Text) ? "0" : gcTxt_jan_code.Text;
                            //在庫数 
                            zaiko_new.ZaikoTotal = 0;
                            //箱数 
                            zaiko_new.HakoSuryo = 0;
                            //包装数(ヒート数） 
                            zaiko_new.HosoSuryo = 0;
                            //バラ指数 
                            zaiko_new.BaraSuryo = 0;
                            //原価単価 
                            zaiko_new.Genka = 0;
                            //最終仕入れ単価 
                            zaiko_new.SaisyuuGenka = 0;
                            //登録日 
                            zaiko_new.InsertDate = DateTime.Now;
                            //更新日
                            zaiko_new.UpdateDate = DateTime.Now;
                            //使用開始
                            zaiko_new.StartUseDate = 0;
                            //使用終了
                            zaiko_new.EndUseDate = 99999999;
                            //通知識別
                            zaiko_new.TsuchiSikibetsu = 0;
                            //通知日時 設定しない
                            //zaiko.TsuchiDate

                            //DBへの物理更新
                            context.SaveChanges();
                        }
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

        //購入価のチェック
        private void gcNum_kounyuuka_Leave(object sender, EventArgs e)
        {
            if(gcNum_kounyuuka.Value > 0)
            {
                if(gcNum_yakka.Value <gcNum_kounyuuka.Value)
                {
                    MessageBox.Show("購入価が薬価より高く設定されています。");
                    gcNum_kounyuuka.Focus();
                }
            }
        }


    }
}
