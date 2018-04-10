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
 * UNDONE 20180326 打越 登録修正ダイアログ製造着手
*/
#endregion

namespace B2.BestFunction
{
    /// <summary>
    /// frm_Touroku_Syusei.cs
    /// 入庫、出庫、発注のワークテーブルへの登録・修正
    /// </summary>
    public partial class TourokuSyuseiForm : Form
    {
        #region
        /// <summary>
        /// 呼び出し元への復帰情報
        /// </summary>
        public DialogResult ReturnValue = DialogResult.None;
     
        /// <summary>呼び出し元への渡し用クラス</summary>
        public partial class Touroku_Syusei
        {
            //モード 0：新規　1:修正
            public int mode;
            //機能　 0:発注　1:入庫　2:出庫
            public int kinou;
            //処理   0:ワークテーブルへの更新　1：呼び出し元へ戻す
            public int syori;

            //伝票共通
            public string yakkyoku_code;
            public int ichi_bangou;
            //   伝票区分　-1 は未設定
            public int denpyou_kubun;
            //   取引区分　-1 は未設定
            public int torihiki_kubun;
            public DateTime shori_date;
            public int shohin_code_kubun;
            public string shohin_code;
            public string shohin_name_kikaku_yoryo;
            public decimal hako_suryo;
            public decimal hoso_suryo;
            public decimal bara_suryo;
            public string biko;
            public DateTime insert_nitiji;
 
            //発注WK固有
            public DateTime delivery_date;
            public int delivery_location;
            public int nyuuko_su;
            public int zan_kubun;

            //入出庫WK共通
            public decimal tanka;
            public decimal kingaku;
            public decimal? yakka;
            public decimal shohizei_kingaku;
            public decimal shoke_kingaku;
            public string shiyo_kigen;
            public string lot_bango;
            
            //入庫WK固有
            public int nyuko_basho;
            public int hacchu_meisai_bango;

            //出庫WK固有
            public DateTime shukko_date;
            
            //表示情報
            public string gtin_code;
            public string gtin_code_chozaihosotani;
            public string yj_code;
            public string jan_code;

            //HACK:後発は動作確認用　修正が必要
            public int? kouhatu_flag;

            public string yakuhin_mei;
            public string yakuhin_kana;
            public string kikaku_tanni;
            public string kubun;
            public string housou_keitai;

            public string seizou_kaisha_mei;
            public string hanbai_kaisha_mei;

 //           public string seizou_bangou;
 //           public string siyou_kigen;

            public decimal? hako_suryo_qty;
            public string hako_suryo_tanni;
            public decimal? hoso_suryo_qty;
            public string hoso_suryo_tanni;
            public decimal? bara_suryo_qty;
            public string bara_suryo_tanni;

            public decimal hako_suryo_torihiki;
            public decimal hoso_suryo_torihiki;
            public decimal bara_suryo_torihiki;

            public decimal hako_suryo_torihiki_all;
            public decimal hoso_suryo_torihiki_all;
            public decimal bara_suryo_torihiki_all;

            public decimal torihiki_total;
//            public decimal tanka;
            public decimal torihiki_goukeigaku;
            
            //薬価　薬品・OTCマスタ
//            public decimal? yakka;
            
            //購入価 手配管理マスタ
            public decimal? price;
 
            //在庫管理マスタ
            public decimal? genka;
            public decimal? saisyuu_genka;

            public string meisai_code;
            public decimal? zaiko_total;

            // 0:薬品　1:OTC
            public int otc_flag;

            /// <summary>初期化　</summary>
            public Touroku_Syusei()
            {
                yakkyoku_code = string.Empty;
                ichi_bangou = 0;
                denpyou_kubun = 0;
                torihiki_kubun = 0;
                //shori_date ;
                shohin_code_kubun = 0;
                shohin_code = string.Empty;
                shohin_name_kikaku_yoryo = string.Empty;
                hako_suryo = 0m;
                hoso_suryo = 0m;
                bara_suryo = 0m;
                biko = string.Empty;
                //insert_nitiji;
                //delivery_date;
                delivery_location = 0;
                nyuuko_su = 0;
                zan_kubun = 0;
                tanka = 0m;
                kingaku = 0m;
                yakka = 0m;
                shohizei_kingaku = 0m;
                shoke_kingaku = 0m;
                shiyo_kigen = string.Empty;
                lot_bango = string.Empty;
                nyuko_basho = 0;
                hacchu_meisai_bango = 0;
                //shukko_date;
                gtin_code = string.Empty;
                gtin_code_chozaihosotani = string.Empty;
                yj_code = string.Empty;
                jan_code = string.Empty;
                kouhatu_flag = 0;
                yakuhin_mei = string.Empty;
                yakuhin_kana = string.Empty;
                kikaku_tanni = string.Empty;
                kubun = string.Empty;
                housou_keitai = string.Empty;
                seizou_kaisha_mei = string.Empty;
                hanbai_kaisha_mei = string.Empty;
                hako_suryo_qty = 0m;
                hako_suryo_tanni = string.Empty;
                hoso_suryo_qty = 0m;
                hoso_suryo_tanni = string.Empty;
                bara_suryo_qty = 0m;
                bara_suryo_tanni = string.Empty;
                hako_suryo_torihiki = 0m;
                hoso_suryo_torihiki = 0m;
                bara_suryo_torihiki = 0m;
                hako_suryo_torihiki_all = 0m;
                hoso_suryo_torihiki_all = 0m;
                bara_suryo_torihiki_all = 0m;
                torihiki_total = 0m;
                torihiki_goukeigaku = 0m;
                price = 0m;
                genka = 0m;
                saisyuu_genka = 0m;
                meisai_code = string.Empty;
                zaiko_total = 0m;
                otc_flag = 0;
            }
        }

        /// <summary>　 呼び出し元への渡し用エリア </summary>
        //static public Touroku_Syusei Touroku_Syusei_result = new Touroku_Syusei();
        static public Touroku_Syusei Touroku_Syusei_result;

        //消費税率
        decimal tax_ritu = 0.08m;
        decimal tax_ritu2 = 0.1m;


        #endregion
          
        /// <summary>共通パラメータ</summary>
        private B2Com b2Com;

        //DB用アダプタ
        NpgsqlDataAdapter oAdp;


        /// <summary>
        /// コンストラクタ
        /// </summary>
        public TourokuSyuseiForm()
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
        /// <param name="param">呼び出しパラメータ</param>
        /// <param name="result">呼び出し元へ戻す値</param>
        /// <returns></returns>
        static public DialogResult ShowForm(Touroku_Syusei param, out Touroku_Syusei result)
        {
            //戻り値をセット
            result = null;
            //Touroku_Syusei_result = param;
            Touroku_Syusei_result = new Touroku_Syusei();
          
            //引数の複写
            copyParam(param);

            //引数エラーのチェック
            if (Touroku_Syusei_result.mode < 0 || Touroku_Syusei_result.mode > 1)
            {
                MessageBox.Show("引数が正しくありません。");
                return DialogResult.Abort;
            }

            if (Touroku_Syusei_result.kinou < 0 || Touroku_Syusei_result.kinou > 2)
            {
                MessageBox.Show("引数が正しくありません。");
                return DialogResult.Abort;
            }

            if (Touroku_Syusei_result.syori < 0 || Touroku_Syusei_result.syori > 1)
            {
                MessageBox.Show("引数が正しくありません。");
                return DialogResult.Abort;
            }

            //ダイアログのインスタンス化
            TourokuSyuseiForm f = new TourokuSyuseiForm();

            //画面の呼び出し
            f.ShowDialog();
            DialogResult receiveValue = f.ReturnValue;

            //戻り値をセット
            result = Touroku_Syusei_result;

            f.Dispose();
            return receiveValue;
        }

        static private void copyParam(Touroku_Syusei param)
        {
            Touroku_Syusei_result.mode = param.mode;
            Touroku_Syusei_result.kinou = param.kinou;
            Touroku_Syusei_result.syori = param.syori;


            Touroku_Syusei_result.yakkyoku_code = param.yakkyoku_code;
            Touroku_Syusei_result.ichi_bangou = param.ichi_bangou;
            Touroku_Syusei_result.denpyou_kubun = param.denpyou_kubun;
            Touroku_Syusei_result.torihiki_kubun = param.torihiki_kubun;
            Touroku_Syusei_result.shohin_code_kubun = param.shohin_code_kubun;
            Touroku_Syusei_result.shohin_code = param.shohin_code;
            Touroku_Syusei_result.shohin_name_kikaku_yoryo = param.shohin_name_kikaku_yoryo;
            Touroku_Syusei_result.hako_suryo = param.hako_suryo;
            Touroku_Syusei_result.hoso_suryo = param.hoso_suryo;
            Touroku_Syusei_result.bara_suryo = param.bara_suryo;
            Touroku_Syusei_result.biko = param.biko;
            Touroku_Syusei_result.delivery_location = param.delivery_location;
            Touroku_Syusei_result.nyuuko_su = param.nyuuko_su;
            Touroku_Syusei_result.zan_kubun = param.zan_kubun;
            Touroku_Syusei_result.tanka = param.tanka;
            Touroku_Syusei_result.kingaku = param.kingaku;
            Touroku_Syusei_result.yakka = param.yakka;
            Touroku_Syusei_result.shohizei_kingaku = param.shohizei_kingaku;
            Touroku_Syusei_result.shoke_kingaku = param.shoke_kingaku;
            Touroku_Syusei_result.shiyo_kigen = param.shiyo_kigen;
            Touroku_Syusei_result.lot_bango = param.lot_bango;
            Touroku_Syusei_result.nyuko_basho = param.nyuko_basho;
            Touroku_Syusei_result.hacchu_meisai_bango = param.hacchu_meisai_bango;
            Touroku_Syusei_result.gtin_code = param.gtin_code;
            Touroku_Syusei_result.gtin_code_chozaihosotani = param.gtin_code_chozaihosotani;
            Touroku_Syusei_result.yj_code = param.yj_code;
            Touroku_Syusei_result.jan_code = param.jan_code;
            Touroku_Syusei_result.kouhatu_flag = param.kouhatu_flag;
            Touroku_Syusei_result.yakuhin_mei = param.yakuhin_mei;
            Touroku_Syusei_result.yakuhin_kana = param.yakuhin_kana;
            Touroku_Syusei_result.kikaku_tanni = param.kikaku_tanni;
            Touroku_Syusei_result.kubun = param.kubun;
            Touroku_Syusei_result.housou_keitai = param.housou_keitai;
            Touroku_Syusei_result.seizou_kaisha_mei = param.seizou_kaisha_mei;
            Touroku_Syusei_result.hanbai_kaisha_mei = param.hanbai_kaisha_mei;
            Touroku_Syusei_result.hako_suryo_qty = param.hako_suryo_qty;
            Touroku_Syusei_result.hako_suryo_tanni = param.hako_suryo_tanni;
            Touroku_Syusei_result.hoso_suryo_qty = param.hoso_suryo_qty;
            Touroku_Syusei_result.hoso_suryo_tanni = param.hoso_suryo_tanni;
            Touroku_Syusei_result.bara_suryo_qty = param.bara_suryo_qty;
            Touroku_Syusei_result.bara_suryo_tanni = param.bara_suryo_tanni;
            Touroku_Syusei_result.hako_suryo_torihiki = param.hako_suryo_torihiki;
            Touroku_Syusei_result.hoso_suryo_torihiki = param.hoso_suryo_torihiki;
            Touroku_Syusei_result.bara_suryo_torihiki = param.bara_suryo_torihiki;
            Touroku_Syusei_result.hako_suryo_torihiki_all = param.hako_suryo_torihiki_all;
            Touroku_Syusei_result.hoso_suryo_torihiki_all = param.hoso_suryo_torihiki_all;
            Touroku_Syusei_result.bara_suryo_torihiki_all = param.bara_suryo_torihiki_all;
            Touroku_Syusei_result.torihiki_total = param.torihiki_total;
            Touroku_Syusei_result.torihiki_goukeigaku = param.torihiki_goukeigaku;
            Touroku_Syusei_result.price = param.price;
            Touroku_Syusei_result.genka = param.genka;
            Touroku_Syusei_result.saisyuu_genka = param.saisyuu_genka;
            Touroku_Syusei_result.meisai_code = param.meisai_code;
            Touroku_Syusei_result.zaiko_total = param.zaiko_total;
            Touroku_Syusei_result.otc_flag = param.otc_flag; 
        }

        /// <summary>
        /// Loadイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frm_Touroku_Syusei_Load(object sender, EventArgs e)
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
        private void frm_Touroku_Syusei_Shown(object sender, EventArgs e)
        {
            try
            {
                //--------------------------------------
                // 初期化
                //--------------------------------------
                //分割線を固定する
                splitContainer1.IsSplitterFixed = true;
                splitContainer2.IsSplitterFixed = true;

                //バックカラーの設定
                b2Com.SetBackColor(this);

                //表示エリアの初期化
                setInitialize();

                //指定データの設定および抽出と表示
                setSearchInfo();

                //表示制御
                setVisibleControl();

                //単価、合計の表示制御
                setTankaGoukeiControl();

                this.Activate();

                //店舗情報を取得　消費税率など
                dbSelectTenpo();
              　
                //TEST
                //Touroku_Syusei_result.gtin_code = "12345678901234";
            }
            catch (Exception ex)
            {
                b2Com.ShowErrMsg(ex);
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
                //伝票区分
                ctlCom_denpyou_kubun.SelectedIndex = -1;

                //取引区分
                ctlCom_torihiki_kubun.SelectedIndex = -1;

                //GTIN
                gcTxt_gtin_code.Text = "";

                //JAN
                gcTxt_jan_code.Text = "";

                //薬品名
                txt_yakuhinmei.Text = "";

                //規格・容量
                lbl_kikaku.Text = "";

                //包装形態
                lbl_housoukeitai.Text = "";

                //区分
                lbl_kubun.Text = "";

                //製造会社
                lbl_seizoukaisya_mei.Text = "";

                //販売会社
                lbl_hanbaikaisya_mei.Text = "";

                //内容量（包装総量）
                gcNum_housou_souryou.Value = 0;

                //製造番号
                ctlCom_seizou_bangou.Text = "";
                ctlCom_seizou_bangou.SelectedIndex = -1;

                //使用期限
                gcDate_siyou_kigen.Value = DateTime.Today;
                
                //数量　入り数
                gcNum_hako_suryo_qty.Value = 0;
                gcNum_hoso_suryo_qty.Value = 0;
                gcNum_bara_suryo_qty.Value = 0;

                //数量　処理数
                gcNum_hako_suryo_torihiki.Value = 0;
                gcNum_hoso_suryo_torihiki.Value = 0;
                gcNum_bara_suryo_torihiki.Value = 0;

                //数量　小計数
                gcNum_hako_suryo_torihiki_all.Value = 0;
                gcNum_hoso_suryo_torihiki_all.Value = 0;
                gcNum_bara_suryo_torihiki_all.Value = 0;

                //数量　合計
                gcNum_torihiki_total.Value = 0;

                //単価
                gcNum_tanka.Value = 0;
         
                //薬価
                gcNum_yakka.Value = 0;

                //合計
                gcNum_torihiki_goukeigaku.Value = 0;

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
                //伝票区分の設定
                if (Touroku_Syusei_result.denpyou_kubun != -1)
                {
                    ctlCom_denpyou_kubun.SelectedValue = Touroku_Syusei_result.denpyou_kubun;
                }

                //取引区分の設定
                if (Touroku_Syusei_result.torihiki_kubun != -1)
                {
                    ctlCom_torihiki_kubun.SelectedValue = Touroku_Syusei_result.torihiki_kubun;
                }

                //商品コード を　複写
                if(!string.IsNullOrEmpty(Touroku_Syusei_result.shohin_code))
                {
                    if(Touroku_Syusei_result.shohin_code.Length==14)
                    {
                        Touroku_Syusei_result.gtin_code = Touroku_Syusei_result.shohin_code;
                    }
                    else
                    {
                        Touroku_Syusei_result.jan_code = Touroku_Syusei_result.shohin_code;
                    }
                }

                //GTIN
                if (!string.IsNullOrEmpty(Touroku_Syusei_result.gtin_code))
                {
                    gcTxt_gtin_code.Text = Touroku_Syusei_result.gtin_code;
                }

                //JAN
                if (!string.IsNullOrEmpty(Touroku_Syusei_result.jan_code))
                {
                    gcTxt_jan_code.Text = Touroku_Syusei_result.jan_code;
                }

                //検索キーの取り出し
                string search_code = string.Empty;
                //　GTIN
                if (!string.IsNullOrEmpty(gcTxt_gtin_code.Text))
                {
                    search_code = gcTxt_gtin_code.Text;
                }

                //　JAN
                else if (!string.IsNullOrEmpty(gcTxt_jan_code.Text))
                {
                    search_code = gcTxt_jan_code.Text;
                }

                //データの抽出
                if (!string.IsNullOrEmpty(search_code))
                {
                    //薬品・OTC　マスタから入り数等の抽出
                    dbSelectYakuhin(search_code);

                //    //数量、合計金額の算出
                //    suryo_Calc(search_code);
                }

                //薬品名
                if (!string.IsNullOrEmpty(Touroku_Syusei_result.yakuhin_mei))
                {
                    txt_yakuhinmei.Text = Touroku_Syusei_result.yakuhin_mei;
                }

                //規格・容量
                if (!string.IsNullOrEmpty(Touroku_Syusei_result.kikaku_tanni))
                {
                    lbl_kikaku.Text = Touroku_Syusei_result.kikaku_tanni;
                }

                //包装形態
                if (!string.IsNullOrEmpty(Touroku_Syusei_result.housou_keitai))
                {
                    lbl_housoukeitai.Text = Touroku_Syusei_result.housou_keitai;
                }

                //区分
                if (!string.IsNullOrEmpty(Touroku_Syusei_result.kubun))
                {
                    lbl_kubun.Text = Touroku_Syusei_result.kubun;
                }

                //製造会社
                if (!string.IsNullOrEmpty(Touroku_Syusei_result.seizou_kaisha_mei))
                {
                    lbl_seizoukaisya_mei.Text = Touroku_Syusei_result.seizou_kaisha_mei;
                }

                //販売会社
                if (!string.IsNullOrEmpty(Touroku_Syusei_result.hanbai_kaisha_mei))
                {
                    lbl_hanbaikaisya_mei.Text = Touroku_Syusei_result.hanbai_kaisha_mei;
                }

                //内容量
                if (Touroku_Syusei_result.hako_suryo_qty > 0)
                {
                    gcNum_housou_souryou.Value = Touroku_Syusei_result.hako_suryo_qty;
                }

                //薬価
                if (Touroku_Syusei_result.yakka　>0)
                {
                    gcNum_yakka.Value = Touroku_Syusei_result.yakka;
                }


                //製造番号
                switch(Touroku_Syusei_result.kinou)
                {
                    case 0:
                    case 1:
                        //入庫[発注は該当しない]　設定済みのデータをセットするのみ。
　　　　                ctlCom_seizou_bangou.SelectedValue = Touroku_Syusei_result.lot_bango;
                        break;
                    case 2:
                        //出庫
                        //   製造番号情報をコンボボックスにセット
                        if (!string.IsNullOrEmpty(search_code))
                        {
                            string field_nm = "gtin_code";
                            if (search_code.Length <= 13)
                            {
                                field_nm = "jan_code";
                            }
                            ctlCom_seizou_bangou.Init(b2Com, "lotinfo_master", field_nm, search_code, "shiyo_kigen", "lot_bango");
                        }
                        //ctlCom_seizou_bangou.SelectedValue = Touroku_Syusei_result.lot_bango;
                        if (!string.IsNullOrEmpty(Touroku_Syusei_result.lot_bango))
                        {
                            ctlCom_seizou_bangou.SelectedText = Touroku_Syusei_result.lot_bango;
                        }
                        else
                        {
                            ctlCom_seizou_bangou.SelectedIndex = -1;
                            gcDate_siyou_kigen.Value = DateTime.Today;
                        }
                        break;
                }

                //使用期限
                if (!string.IsNullOrEmpty(Touroku_Syusei_result.shiyo_kigen))
                {
                    DateTime wk_date;
                    if (DateTime.TryParse(Touroku_Syusei_result.shiyo_kigen,out wk_date))
                    {
                        gcDate_siyou_kigen.Value = wk_date;
                    }
                    else
                    {
                        gcDate_siyou_kigen.Value = DateTime.Today;
                    }
                }

                //数量　処理数のセット
                if (Touroku_Syusei_result.hako_suryo > 0)
                {
                    gcNum_hako_suryo_torihiki.Value = Touroku_Syusei_result.hako_suryo;
                }
                else
                {
                    if (Touroku_Syusei_result.kinou == 0 && !string.IsNullOrEmpty(search_code))
                    {
                        //発注の時で値が０の時　発注単位記号とデフォルト発注数を取得しセットする。
                        dbSelectTani(search_code);
                    }
                }

                if (Touroku_Syusei_result.hoso_suryo > 0)
                {
                    gcNum_hoso_suryo_torihiki.Value = Touroku_Syusei_result.hoso_suryo;
                }

                if (Touroku_Syusei_result.bara_suryo > 0)
                {
                    gcNum_bara_suryo_torihiki.Value = Touroku_Syusei_result.bara_suryo;
                }

                ////データの抽出
                //if (!string.IsNullOrEmpty(search_code))
                //{
                //    //薬品・OTC　マスタから入り数等の抽出
                //    dbSelectYakuhin(search_code);

                //}
                //数量、合計金額の算出
                suryo_Calc(search_code);
                
            }
            catch (Exception ex)
            {
                b2Com.ShowErrMsg(ex);
            }

        }

        /// <summary>
        /// コントロールの活性、非活性や表示、非表示の設定を行う
        /// </summary>
        private void setVisibleControl()
        {
            //------------------------
            //起動モードによる制御
            //------------------------
            switch (Touroku_Syusei_result.mode)
            {
                case 0:
                    //新規
                    ctlCom_denpyou_kubun.Enabled = true;
                    ctlCom_torihiki_kubun.Enabled = true;
                    gcTxt_gtin_code.Enabled = true;
                    gcTxt_gtin_code.ReadOnly = false;
                    gcTxt_jan_code.Enabled = true;
                    gcTxt_jan_code.ReadOnly = false;
                    btn_select.Visible = true;
                    break;

                case 1:
                    //修正
                    ctlCom_denpyou_kubun.Enabled = false;
                    ctlCom_torihiki_kubun.Enabled = false;
                    gcTxt_gtin_code.Enabled = false;
                    gcTxt_gtin_code.ReadOnly = true;
                    gcTxt_jan_code.Enabled = false;
                    gcTxt_jan_code.ReadOnly = true;
                    btn_select.Visible = false;
                    break;
            }

            //------------------------
            //機能区分による制御
            //------------------------
            //製造番号、使用期限関連の表示設定
            lbl_seizou_bangou.Visible = true;
            ctlCom_seizou_bangou.Visible = true;
            lbl_siyou_kigen.Visible = true;
            gcDate_siyou_kigen.Visible = true;

            //数量情報の表示
            lbl_hoso.Visible = true;
            gcNum_hoso_suryo_qty.Visible = true;
            gcNum_hoso_suryo_torihiki.Visible = true;
            gcNum_hoso_suryo_torihiki_all.Visible = true;
            lbl_hoso_suryo_tanni.Visible = true;

            lbl_bara.Visible = true;
            gcNum_bara_suryo_qty.Visible = true;
            gcNum_bara_suryo_torihiki.Visible = true;
            gcNum_bara_suryo_torihiki_all.Visible = true;
            lbl_bara_suryo_tanni.Visible = true;

            lbl_hoso_kakeru.Visible = true;
            lbl_hoso_ikouru.Visible = true;
            lbl_bara_kakeru.Visible = true;
            lbl_bara_ikouru.Visible = true;

            //単価、合計金額欄
            lbl_tanka.Visible = true;
            gcNum_tanka.Visible = true;
            lbl_tanka2.Visible = true;
            lbl_goukeigaku.Visible = true;
            gcNum_torihiki_goukeigaku.Visible = true;
            lbl_goukeigaku2.Visible = true;


            //コンボボックス値の設定 & 非表示設定
            switch (Touroku_Syusei_result.kinou)
            {
                case 0:
                    //発注
                    // 伝票区分コンボボックスの設定
                    ctlCom_denpyou_kubun.Init(b2Com, "combodata", "program_id", "発注伝票", "seq_no", "field_data");

                    // 取引区分コンボボックスの設定
                    ctlCom_torihiki_kubun.Init(b2Com, "combodata", "program_id", "発注取引", "seq_no", "field_data");

                    //製造番号、使用期限関連の非表示
                    lbl_seizou_bangou.Visible = false;
                    ctlCom_seizou_bangou.Visible = false;
                    lbl_siyou_kigen.Visible = false;
                    gcDate_siyou_kigen.Visible = false;

                    //数量情報の非表示
                    lbl_hoso.Visible = false;
                    gcNum_hoso_suryo_qty.Visible = false;
                    gcNum_hoso_suryo_torihiki.Visible = false;
                    gcNum_hoso_suryo_torihiki_all.Visible = false;
                    lbl_hoso_suryo_tanni.Visible = false;

                    lbl_bara.Visible = false;
                    gcNum_bara_suryo_qty.Visible = false;
                    gcNum_bara_suryo_torihiki.Visible = false;
                    gcNum_bara_suryo_torihiki_all.Visible = false;
                    lbl_bara_suryo_tanni.Visible = false;

                    lbl_hoso_kakeru.Visible = false;
                    lbl_hoso_ikouru.Visible = false;
                    lbl_bara_kakeru.Visible = false;
                    lbl_bara_ikouru.Visible = false;

                    //単価、合計金額欄
                    lbl_tanka.Visible = true;
                    gcNum_tanka.Visible = true;
                    lbl_tanka2.Visible = true;
                    lbl_goukeigaku.Visible = true;
                    gcNum_torihiki_goukeigaku.Visible = true;
                    lbl_goukeigaku2.Visible = true;

                    break;

                case 1:
                    //入庫
                    // 伝票区分コンボボックスの設定
                    ctlCom_denpyou_kubun.Init(b2Com, "combodata", "program_id", "入庫伝票", "seq_no", "field_data");

                    // 取引区分コンボボックスの設定
                    ctlCom_torihiki_kubun.Init(b2Com, "combodata", "program_id", "入庫取引", "seq_no", "field_data");

                    //合計金額欄
                    gcNum_torihiki_goukeigaku.BackColor = Color.White;
                    gcNum_torihiki_goukeigaku.Enabled = true;
                    gcNum_torihiki_goukeigaku.ReadOnly = false;

                    break;

                case 2:
                    //出庫
                    // 伝票区分コンボボックスの設定
                    ctlCom_denpyou_kubun.Init(b2Com, "combodata", "program_id", "出庫伝票", "seq_no", "field_data");

                    // 取引区分コンボボックスの設定
                    ctlCom_torihiki_kubun.Init(b2Com, "combodata", "program_id", "出庫取引", "seq_no", "field_data");

                    //合計金額欄
                    gcNum_torihiki_goukeigaku.BackColor = Color.LemonChiffon;
                    gcNum_torihiki_goukeigaku.Enabled = false;
                    gcNum_torihiki_goukeigaku.ReadOnly = true;
                    break;
                default:
                    //不明
                    break;
            }

        }


        /// <summary>
        /// 単価欄、合計金額欄のコントロール
        /// </summary>
        private void setTankaGoukeiControl()
        {
            //------------------------
            //起動モード
            //------------------------
            switch (Touroku_Syusei_result.mode)
            {
                case 0: //新規
                case 1: //修正
                    //------------------------
                    //機能区分による制御
                    //------------------------
                    switch (Touroku_Syusei_result.kinou)
                    {
                        case 0:
                            //発注
                            //setVisibleControlでの制御以外、何もしない
                            break;

                        case 1:
                            //入庫
                            //------------------------
                            //伝票区分による制御
                            //------------------------
                            switch ((int)ctlCom_denpyou_kubun.SelectedValue)
                            {
                                case 0:  //仕入れ
                                    //------------------------
                                    //取引区分による制御
                                    //------------------------
                                    switch ((int)ctlCom_torihiki_kubun.SelectedValue)
                                    {
                                        case 0:  //入庫
                                        case 1:  //返品
                                            gcNum_tanka.ReadOnly = true;
                                            gcNum_tanka.BackColor = Color.LemonChiffon;
                                            gcNum_torihiki_goukeigaku.ReadOnly = false;
                                            gcNum_tanka.BackColor = Color.White;
                                            break;
                                        case 2:  //値引き
                                        case 3:  //値増し
                                            gcNum_tanka.ReadOnly = false;
                                            gcNum_tanka.BackColor = Color.White;
                                            gcNum_torihiki_goukeigaku.ReadOnly = true;
                                            gcNum_tanka.BackColor = Color.LemonChiffon;
                                            break;
                                    }
                                    break;
                                case 1:  //店舗間移動
                                case 2:  //譲受
                                case 3:  //在庫調整
                                case 4:  //サンプル品
                                    gcNum_tanka.ReadOnly = false;
                                    gcNum_tanka.BackColor = Color.White;
                                    gcNum_torihiki_goukeigaku.ReadOnly = true;
                                    gcNum_tanka.BackColor = Color.LemonChiffon;
                                    break;
                            }
                            break;

                        case 2:
                            //出庫
                            gcNum_tanka.ReadOnly = false;
                            gcNum_tanka.BackColor = Color.White;
                            gcNum_torihiki_goukeigaku.ReadOnly = true;
                            gcNum_tanka.BackColor = Color.LemonChiffon;
                            break;

                        default:
                            //不明
                            break;
                    }

                    break;
            }

        }


        /// <summary>
        /// 薬品マスタから情報の抽出
        /// </summary>
        private void dbSelectYakuhin(string search_code)
        {
            try
            {
                using (var context = new Entities.TourokuSyuseiModel(b2Com))
                {
                    //SQL Log 出力
                    context.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);

                    //データの存在チェックフラグ
                    int sonzai_flag = 0;

                    //薬品マスタからデータの読込
                    var yakuhin = context.YakuhinMaster.FirstOrDefault(w => (w.GtinCode == search_code || w.JanCode == search_code) &&
                                                                    w.ApplyEndYmd == " ");
                    if(yakuhin != null)
                    {
                        sonzai_flag = 1;
                        
                        //薬品情報
                        Touroku_Syusei_result.gtin_code = yakuhin.GtinCode;
                        gcTxt_gtin_code.Text = yakuhin.GtinCode;
                        Touroku_Syusei_result.jan_code = yakuhin.JanCode;
                        gcTxt_jan_code.Text = yakuhin.JanCode;
                        Touroku_Syusei_result.yj_code = yakuhin.YjCode;
                        Touroku_Syusei_result.gtin_code_chozaihosotani = yakuhin.GtinCodeChozaihosotani;

                        if (yakuhin.KanriZokusei != null)
                        {
                            //NOTE 後発
                            Touroku_Syusei_result.kouhatu_flag = (int)yakuhin.KanriZokusei;  
                        }
                        else
                        {
                            Touroku_Syusei_result.kouhatu_flag = 0;
                        }

                        Touroku_Syusei_result.yakuhin_mei = yakuhin.YakuhinMei;
                        Touroku_Syusei_result.yakuhin_kana = yakuhin.YakuhinKana;
                        Touroku_Syusei_result.kikaku_tanni = yakuhin.KikakuTanni;
                        Touroku_Syusei_result.kubun = yakuhin.Kubun;
                        Touroku_Syusei_result.housou_keitai = yakuhin.HousouKeitai;
                        Touroku_Syusei_result.seizou_kaisha_mei = yakuhin.SeizouKaishaMei;
                        Touroku_Syusei_result.hanbai_kaisha_mei = yakuhin.HanbaiKaishaMei;
                        Touroku_Syusei_result.hako_suryo_qty = yakuhin.HousouSouryouQty;
                        Touroku_Syusei_result.hako_suryo_tanni = yakuhin.HousouSuryouTanni;
                        Touroku_Syusei_result.hoso_suryo_qty = yakuhin.HousouTanniQty;
                        Touroku_Syusei_result.hoso_suryo_tanni = yakuhin.HousouTanniTanni;
                        Touroku_Syusei_result.bara_suryo_qty = 1;
                        Touroku_Syusei_result.bara_suryo_tanni = yakuhin.HousouSuryouTanni;

                        //内容量（包装総量） 
                        //数量　入り数 
                        gcNum_housou_souryou.Value = yakuhin.HousouSouryouQty;
                        gcNum_hako_suryo_qty.Value = yakuhin.HousouSouryouQty;
                        gcNum_hoso_suryo_qty.Value = yakuhin.HousouTanniQty;
                        gcNum_bara_suryo_qty.Value = 1;

                        lbl_hako_suryo_tanni.Text = yakuhin.HousouSuryouTanni;
                        lbl_hoso_suryo_tanni.Text = yakuhin.HousouTanniTanni;
                        lbl_bara_suryo_tanni.Text = yakuhin.HousouSuryouTanni;
                        lbl_housou_souryou_tanni.Text = yakuhin.HousouSuryouTanni;

                        //薬価
                        Touroku_Syusei_result.yakka = yakuhin.Yakka;
                        gcNum_yakka.Value = Touroku_Syusei_result.yakka;

                        Touroku_Syusei_result.otc_flag = 0;
                     
                    }

                    //データがあったのなら抜ける
                    if(sonzai_flag == 1)
                    {
                        return;
                    }

                    //OTCマスタからデータの読込
                    var otc = context.OtcMaster.FirstOrDefault(w => (w.GtinCode == search_code || w.JanCode == search_code) &&
  　　　                                                                 w.ApplyEndYmd == " ");
                    if(otc != null)
                    {
                        sonzai_flag = 2;

                        //薬品情報
                        Touroku_Syusei_result.gtin_code = otc.GtinCode;
                        Touroku_Syusei_result.jan_code = otc.JanCode;
                        Touroku_Syusei_result.yj_code = otc.YjCode;
                        //Touroku_Syusei_result.gtin_code_chozaihosotani = v.GtinCodeChozaihosotani;
                        Touroku_Syusei_result.kouhatu_flag = (int)otc.KanriZokusei;  //NOTE 後発
                        Touroku_Syusei_result.yakuhin_mei = otc.YakuhinMei;
                        Touroku_Syusei_result.yakuhin_kana = otc.YakuhinKana;
                        Touroku_Syusei_result.kikaku_tanni = otc.KikakuTanni;
                        Touroku_Syusei_result.kubun = otc.Kubun;
                        Touroku_Syusei_result.housou_keitai = otc.HousouKeitai;
                        Touroku_Syusei_result.seizou_kaisha_mei = otc.SeizouKaishaMei;
                        Touroku_Syusei_result.hanbai_kaisha_mei = otc.HanbaiKaishaMei;
                        Touroku_Syusei_result.hako_suryo_qty = otc.HousouSouryouQty;
                        Touroku_Syusei_result.hako_suryo_tanni = otc.HousouSuryouTanni;
                        Touroku_Syusei_result.hoso_suryo_qty = otc.HousouTanniQty;
                        Touroku_Syusei_result.hoso_suryo_tanni = otc.HousouTanniTanni;
                        Touroku_Syusei_result.bara_suryo_qty = 1;
                        Touroku_Syusei_result.bara_suryo_tanni = otc.HousouSuryouTanni;

                        //内容量（包装総量） 
                        //数量　入り数 
                        gcNum_housou_souryou.Value = otc.HousouSouryouQty;
                        gcNum_hako_suryo_qty.Value = otc.HousouSouryouQty;
                        gcNum_hoso_suryo_qty.Value = otc.HousouTanniQty;
                        gcNum_bara_suryo_qty.Value = 1;

                        lbl_hako_suryo_tanni.Text = otc.HousouSuryouTanni;
                        lbl_hoso_suryo_tanni.Text = otc.HousouTanniTanni;
                        lbl_bara_suryo_tanni.Text = otc.HousouSuryouTanni;
                        lbl_housou_souryou_tanni.Text = otc.HousouSuryouTanni;

                        //薬価
                        Touroku_Syusei_result.yakka = otc.Yakka;
                        gcNum_yakka.Value = Touroku_Syusei_result.yakka;

                        Touroku_Syusei_result.otc_flag = 1;
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
        private void dbSelectTanka(string search_code)
        {
            try
            {
                if(string.IsNullOrEmpty(search_code))
                {
                    return;
                }


                using (var context = new Entities.TourokuSyuseiModel(b2Com))
                {
                    //SQL Log 出力
                    context.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);

                    //データの存在チェックフラグ
                    int sonzai_flag = 0;

                    //手配管理マスタからデータの読込 レセコンコード、GTINコードをキーにして読み込み
                    var tehai = context.TehaiMaster.FirstOrDefault(w => w.YakkyokuCode == b2Com.YakkyokuCode &&
                                                              (w.GtinCode == search_code ||
                                                               w.JanCode  == search_code));
                    if(tehai != null)
                    {
                        sonzai_flag = 1;
                        //購入価格をセット
                        Touroku_Syusei_result.price = tehai.Price;

                    }

                    //手配管理マスタにデータが無いのなら在庫管理マスタにも無いので抜ける
                    if (sonzai_flag == 0)
                    {
                        return;
                    }

                    //在庫情報マスタからデータの読込
                    var zaiko = context.ZaikoMaster.FirstOrDefault(w => w.YakkyokuCode == b2Com.YakkyokuCode &&
                                                              (w.GtinCode == search_code ||
                                                               w.JanCode == search_code));
                    if(zaiko != null)
                    {
                        Touroku_Syusei_result.genka = zaiko.Genka;
                        Touroku_Syusei_result.saisyuu_genka = zaiko.SaisyuuGenka;
                    }

                }
            }
            catch (Exception ex)
            {
                b2Com.ShowErrMsg(ex);
            }

        }

        /// <summary>
        /// 発注単位の抽出
        /// </summary>
        private void dbSelectTani(string search_code)
        {
            try
            {
                using (var context = new Entities.TourokuSyuseiModel(b2Com))
                {
                    //SQL Log 出力
                    context.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);

                    //発注管理マスタからデータの読込 レセコンコード、GTINコードをキーにして読み込み
                    var tehai = context.HachukanriMaster.FirstOrDefault(w => w.YakkyokuCode == b2Com.YakkyokuCode &&
                                                              (w.GtinCode == search_code ||
                                                               w.JanCode == search_code));
                    if (tehai != null)
                    {
                        //単位をセット
                        lbl_hako.Text = tehai.HachuTani;
                        //デフォルト発注数のセット
                        gcNum_hako_suryo_torihiki.Value = tehai.HachuSuryo;
                    }
                
                }
            }
            catch (Exception ex)
            {
                b2Com.ShowErrMsg(ex);
            }

        }


        /// <summary>
        /// 店舗情報（消費税率等の取得）
        /// </summary>
        private void dbSelectTenpo()
        {
            try
            {
                using (var context = new Entities.TourokuSyuseiModel(b2Com))
                {
                    //SQL Log 出力
                    context.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);

                    //店舗管理マスタからデータの読込
                    var tenpo = context.TenpoMaster.FirstOrDefault(w => w.YakkyokuCode == b2Com.YakkyokuCode);

                    if(tenpo != null)
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
        /// キャンセル終了
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
        /// 登録－＞終了
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
                if(!checkReturnData())
                {
                    return;
                }

     　　　　　 //----------------------------------------------------
                //データの格納
                //----------------------------------------------------
                setReturnData();

                //----------------------------------------------------
                //テーブルへの登録・更新処理
                //----------------------------------------------------
                if(Touroku_Syusei_result.syori == 0)
                {
                    if (!dbInsert())
                    {
                        ReturnValue = DialogResult.Abort;
                        b2Com.CloseDb();
                        this.Close();
                    }
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
            if (!check_denpyou_kubun())
            {
                return false;
            }

            //取引区分
            if (!check_torihiki_kubun())
            {
                return false;
            }

            //商品コード　GTIN　or JAN
            if (!check_syouhin_code())
            {
                return false;
            }

            //製造番号
            if (!check_seizou_bangou())
            {
                return false;
            }

            //使用期限
            if (!check_siyou_kigen())
            {
                return false;
            }
            
            //取引数
            if(!check_torihiki_suryo())
            {
                return false;
            }

            //単価
            if (!check_tanka())
            {
                return false;
            }

            //合計金額
            if (!check_goukeigaku())
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 伝票区分のチェック
        /// </summary>
        /// <returns></returns>
        private bool check_denpyou_kubun()
        {
            try
            {
                if (ctlCom_denpyou_kubun.SelectedIndex < 0)
                {
                    MessageBox.Show("伝票区分が選択されていません。");
                    ctlCom_denpyou_kubun.Focus();
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
        /// 取引区分のチェック
        /// </summary>
        /// <returns></returns>
        private bool check_torihiki_kubun()
        {
            try
            {
                if (ctlCom_torihiki_kubun.SelectedIndex < 0)
                {
                    MessageBox.Show("取引区分が選択されていません。");
                    ctlCom_torihiki_kubun.Focus();
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
        /// 商品コードのチェック
        /// </summary>
        /// <returns></returns>
        private bool check_syouhin_code()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(gcTxt_gtin_code.Text) && string.IsNullOrWhiteSpace(gcTxt_jan_code.Text))
                {
                    MessageBox.Show("商品コードが設定されていません。");
                    gcTxt_gtin_code.Focus();
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
        /// 製造番号のチェック
        /// </summary>
        /// <returns></returns>
        private bool check_seizou_bangou()
        {
            try
            {
                switch (Touroku_Syusei_result.kinou)
                {
                    case 0:  //発注
                        break;

                    case 1:  //入庫
                        if (string.IsNullOrWhiteSpace(ctlCom_seizou_bangou.Text))
                        {
                            MessageBox.Show("製造番号が設定されていません。");
                            ctlCom_seizou_bangou.Focus();
                            return false;
                        }
                        break;

                    case 2:  //出庫
                        if (string.IsNullOrWhiteSpace(ctlCom_seizou_bangou.SelectedText) &&
                            string.IsNullOrWhiteSpace(ctlCom_seizou_bangou.Text))
                        {
                            MessageBox.Show("製造番号が設定されていません。");
                            ctlCom_seizou_bangou.Focus();
                            return false;
                        }
                        break;
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
        /// 使用期限のチェック
        /// </summary>
        /// <returns></returns>
        private bool check_siyou_kigen()
        {
            try
            {
                switch (Touroku_Syusei_result.kinou)
                {
                    case 0:  //発注
                        break;

                    case 1:  //入庫
                    case 2:  //出庫

                    //NOTE チェック方法が不明
                        if (gcDate_siyou_kigen.Value == null)
                        {
                            MessageBox.Show("使用期限が設定されていません。");
                            ctlCom_seizou_bangou.Focus();
                            return false;
                        }
                        break;
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
        /// 取引数のチェック
        /// </summary>
        /// <returns></returns>
        private bool check_torihiki_suryo()
        {
            try
            {
                switch (Touroku_Syusei_result.kinou)
                {
                    case 0:  //発注
                        if (gcNum_hako_suryo_torihiki.Value == null || gcNum_hako_suryo_torihiki.Value <= 0)
                        {
                            MessageBox.Show("取引数が設定されていません。");
                            gcNum_hako_suryo_torihiki.Focus();
                            return false;
                        }
                        break;

                    case 1:  //入庫
                    case 2:  //出庫

                        if ((gcNum_hako_suryo_torihiki.Value == null || gcNum_hako_suryo_torihiki.Value <= 0) &&
                             (gcNum_hoso_suryo_torihiki.Value == null || gcNum_hoso_suryo_torihiki.Value <= 0) &&
                             (gcNum_bara_suryo_torihiki.Value == null || gcNum_bara_suryo_torihiki.Value <= 0))
                        {
                            MessageBox.Show("取引数が設定されていません。");
                            gcNum_hako_suryo_torihiki.Focus();
                            return false;
                        }
                        break;
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
        /// 単価のチェック
        /// </summary>
        /// <returns></returns>
        private bool check_tanka()
        {
            try
            {
                switch (Touroku_Syusei_result.kinou)
                {
                    case 0:  //発注
                        break;

                    case 1:  //入庫
                    case 2:  //出庫
                        if (gcNum_tanka.Value == null || gcNum_tanka.Value <= 0)
                        {
                            MessageBox.Show("単価が設定されていません。");
                            gcNum_tanka.Focus();
                            return false;
                        }
                        break;
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
        /// 合計金額のチェック
        /// </summary>
        /// <returns></returns>
        private bool check_goukeigaku()
        {
            try
            {
                switch (Touroku_Syusei_result.kinou)
                {
                    case 0:  //発注
                        break;

                    case 1:  //入庫
                    case 2:  //出庫
                        if (gcNum_torihiki_goukeigaku.Value == null || gcNum_torihiki_goukeigaku.Value <= 0)
                        {
                            MessageBox.Show("合計額が設定されていません。");
                            gcNum_torihiki_goukeigaku.Focus();
                            return false;
                        }
                        break;

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
        /// 戻りデータのセット
        /// </summary>
        private void setReturnData()
        {
            Touroku_Syusei_result.yakkyoku_code = b2Com.YakkyokuCode;
//          Touroku_Syusei_result.ichi_bangou;  DB更新後にセットされる。
            Touroku_Syusei_result.denpyou_kubun = (int)ctlCom_denpyou_kubun.SelectedValue;
            Touroku_Syusei_result.torihiki_kubun = (int)ctlCom_torihiki_kubun.SelectedValue;

            Touroku_Syusei_result.shori_date = DateTime.Today;
            Touroku_Syusei_result.shohin_code_kubun = string.IsNullOrEmpty(gcTxt_gtin_code.Text) ? 1 : 2;
            Touroku_Syusei_result.shohin_code = string.IsNullOrEmpty(gcTxt_gtin_code.Text) ? gcTxt_jan_code.Text : gcTxt_gtin_code.Text;
            Touroku_Syusei_result.shohin_name_kikaku_yoryo = txt_yakuhinmei.Text + "  " + lbl_kikaku.Text;
            Touroku_Syusei_result.hako_suryo = (decimal)gcNum_hako_suryo_torihiki.Value;
            Touroku_Syusei_result.hoso_suryo = (decimal)gcNum_hoso_suryo_torihiki.Value;
            Touroku_Syusei_result.bara_suryo = (decimal)gcNum_bara_suryo_torihiki.Value;
            Touroku_Syusei_result.biko = "";
            Touroku_Syusei_result.insert_nitiji = DateTime.Now;

            //発注WK固有
            Touroku_Syusei_result.delivery_date = DateTime.Today.AddDays(1);
            Touroku_Syusei_result.delivery_location = 0;
            Touroku_Syusei_result.nyuuko_su = 0;
            Touroku_Syusei_result.zan_kubun = 0;
            
            //入出庫WK共通
            Touroku_Syusei_result.tanka = (decimal)gcNum_tanka.Value;
            Touroku_Syusei_result.kingaku = (decimal)gcNum_torihiki_goukeigaku.Value;
// 　　　　 Touroku_Syusei_result.yakka;　薬品検索時にセットされる。
            Touroku_Syusei_result.shohizei_kingaku = Math.Round((Touroku_Syusei_result.torihiki_goukeigaku * tax_ritu), 2);
            Touroku_Syusei_result.shoke_kingaku = Math.Round((decimal)(Touroku_Syusei_result.shohizei_kingaku + Touroku_Syusei_result.kingaku), 2);
            Touroku_Syusei_result.shiyo_kigen = gcDate_siyou_kigen.Value.Value.ToString("yyyyMMdd");
            Touroku_Syusei_result.lot_bango = string.IsNullOrWhiteSpace(ctlCom_seizou_bangou.SelectedText) ? ctlCom_seizou_bangou.Text : ctlCom_seizou_bangou.SelectedText;

            //入庫WK固有
//          Touroku_Syusei_result.nyuko_basho;
//          Touroku_Syusei_result.hacchu_meisai_bango;

            //出庫WK固有
            Touroku_Syusei_result.shukko_date = DateTime.Today;

            //表示情報   殆どが薬品検索時にセット
            //Touroku_Syusei_result.gtin_code = gcTxt_gtin_code.Text;
            //Touroku_Syusei_result.gtin_code_chozaihosotani;　　           
            //Touroku_Syusei_result.yj_code;　　　　　　　　　　　          
            //Touroku_Syusei_result.jan_code = gcTxt_jan_code.Text;
//HACK:後発は動作確認用　修正が必要
            //Touroku_Syusei_result.kouhatu_flag;　　　　　　　　           
            //Touroku_Syusei_result.yakuhin_mei = txt_yakuhinmei.Text;
            //Touroku_Syusei_result.yakuhin_kana;                           
            //Touroku_Syusei_result.kikaku_tanni = lbl_kikaku.Text;
            //Touroku_Syusei_result.kubun = lbl_kubun.Text;
            //Touroku_Syusei_result.housou_keitai = lbl_housoukeitai.Text;
            //Touroku_Syusei_result.seizou_kaisha_mei = lbl_seizoukaisya_mei.Text;
            //Touroku_Syusei_result.hanbai_kaisha_mei = lbl_hanbaikaisya_mei.Text;
            //Touroku_Syusei_result.hako_suryo_qty = (decimal)gcNum_hako_suryo_qty.Value;
            //Touroku_Syusei_result.hako_suryo_tanni = lbl_hako_suryo_tanni.Text;
            //Touroku_Syusei_result.hoso_suryo_qty = (decimal)gcNum_hoso_suryo_qty.Value;
            //Touroku_Syusei_result.hoso_suryo_tanni = lbl_hoso_suryo_tanni.Text;
            //Touroku_Syusei_result.bara_suryo_qty = (decimal)gcNum_bara_suryo_qty.Value;
            //Touroku_Syusei_result.bara_suryo_tanni = lbl_bara_suryo_tanni.Text;
            Touroku_Syusei_result.hako_suryo_torihiki = (decimal)gcNum_hako_suryo_torihiki.Value;
            Touroku_Syusei_result.hoso_suryo_torihiki = (decimal)gcNum_hoso_suryo_torihiki.Value;
            Touroku_Syusei_result.bara_suryo_torihiki = (decimal)gcNum_bara_suryo_torihiki.Value;
            Touroku_Syusei_result.hako_suryo_torihiki_all = (decimal)gcNum_hako_suryo_torihiki_all.Value;
            Touroku_Syusei_result.hoso_suryo_torihiki_all = (decimal)gcNum_hoso_suryo_torihiki_all.Value;
            Touroku_Syusei_result.bara_suryo_torihiki_all = (decimal)gcNum_bara_suryo_torihiki_all.Value;
            Touroku_Syusei_result.torihiki_total = (decimal)gcNum_torihiki_total.Value;
            Touroku_Syusei_result.torihiki_goukeigaku = (decimal)gcNum_torihiki_goukeigaku.Value;
//            Touroku_Syusei_result.price;
//            Touroku_Syusei_result.genka;
//            Touroku_Syusei_result.saisyuu_genka;
//            Touroku_Syusei_result.meisai_code;
//            Touroku_Syusei_result.zaiko_total;

        }


        /// <summary>
        /// データベースへの登録処理
        /// </summary>
        /// <returns></returns>
        private bool dbInsert()
        {
            try
            {

                switch(Touroku_Syusei_result.kinou)
                {
                    case 0:  //発注
                        //----------------------------------------------------
                        //テーブルへの登録・更新処理
                        //----------------------------------------------------
                        if (!dbInsert_hacchu_meisai_wk())
                        {
                            return false;
                        }
                        break;
                    
                    case 1:  //入庫
                        //----------------------------------------------------
                        //テーブルへの登録・更新処理
                        //----------------------------------------------------
                        if (!dbInsert_nyuko_meisai_wk())
                        {
                            return false;
                        }
                        break;

                    case 2:  //出庫
                        //----------------------------------------------------
                        //テーブルへの登録・更新処理
                        //----------------------------------------------------
                        if (!dbInsert_shukko_meisai_wk())
                        {
                            return false;
                        }
                        break;
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
        /// 発注データWKへの書き込み
        /// </summary>
        /// <returns></returns>
        private bool dbInsert_hacchu_meisai_wk()
        {
            try
            {
                using (var context = new Entities.TourokuSyuseiModel(b2Com))
                {
                    //SQL Log 出力
                    context.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);

                    switch (Touroku_Syusei_result.mode)
                    {
                        case 0:   //新規
                            //発注データＷＫへ新規書き込み
                            var hacchu_new = context.HacchuMeisai_wk.Create();
                            {
                                //薬局コード
                                hacchu_new.YakkyokuCode = Touroku_Syusei_result.yakkyoku_code;
                                //一意キー
                                //hacchu_new.IchiBango AUTO
                                //hacchu_new.IchiBango = 0;
                                //伝票区分
                                hacchu_new.DenpyoKubun = Touroku_Syusei_result.denpyou_kubun;
                                //取引区分
                                hacchu_new.TorihikiKubun = Touroku_Syusei_result.torihiki_kubun;
                                //処理日
                                hacchu_new.ShoriDate = Touroku_Syusei_result.shori_date;
                                //商品コード区分
                                hacchu_new.ShohinCodeKubun = Touroku_Syusei_result.shohin_code_kubun;
                                //商品コード
                                hacchu_new.ShohinCode = Touroku_Syusei_result.shohin_code;
                                //商品名、規格、容量
                                hacchu_new.ShohinNameKikakuYoryo = Touroku_Syusei_result.shohin_name_kikaku_yoryo.Substring(0, (Touroku_Syusei_result.shohin_name_kikaku_yoryo.Length > 40 ? 40 : Touroku_Syusei_result.shohin_name_kikaku_yoryo.Length));
                                //箱数
                                hacchu_new.HakoSuryo = Touroku_Syusei_result.hako_suryo_torihiki;
                                //包装数
                                hacchu_new.HosoSuryo = Touroku_Syusei_result.hoso_suryo_torihiki;
                                //バラ数
                                hacchu_new.BaraSuryo = Touroku_Syusei_result.bara_suryo_torihiki;
                                //納品指定日
                                hacchu_new.DeliveryDate = Touroku_Syusei_result.delivery_date;
                                //納品指定場所
                                hacchu_new.DeliveryLocation = Touroku_Syusei_result.delivery_location;
                                //備考
                                hacchu_new.Biko = Touroku_Syusei_result.biko;
                                //入庫数
                                hacchu_new.NyuukoSu = Touroku_Syusei_result.nyuuko_su;
                                //残区分
                                hacchu_new.ZanKubun = Touroku_Syusei_result.zan_kubun;
                                //登録日時
                                hacchu_new.InsertNitiji = Touroku_Syusei_result.insert_nitiji;

                                // レコードををテーブルに登録。
                                context.HacchuMeisai_wk.Add(hacchu_new);

                                //DBへの物理更新
                                context.SaveChanges();

                                //更新（新規）時の一意キーを設定
                                Touroku_Syusei_result.ichi_bangou = hacchu_new.IchiBango;
                            }
                           
                            break;
                        case 1:   //修正
                            //発注データＷＫへアップデート
                            //  読込
                            var hacchu = context.HacchuMeisai_wk.FirstOrDefault(w => w.YakkyokuCode == b2Com.YakkyokuCode &&
                                                                                     w.IchiBango == Touroku_Syusei_result.ichi_bangou);
                            //  更新
                            if (hacchu != null)
                            {
                                // 処理日
                                hacchu.ShoriDate = Touroku_Syusei_result.shori_date;
                                // 箱数
                                hacchu.HakoSuryo = Touroku_Syusei_result.hako_suryo_torihiki;
                                // 包装数
                                hacchu.HosoSuryo = Touroku_Syusei_result.hoso_suryo_torihiki;
                                // バラ数
                                hacchu.BaraSuryo = Touroku_Syusei_result.bara_suryo_torihiki;

                                //DBへの物理更新
                                context.SaveChanges();
                            }
                            else
                            {
                                MessageBox.Show("更新すべき一致する発注データが見つかりません。\r\n担当ＳＥへ連絡して下さい。");
                                return false;
                            }
                            break;
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
        /// 入庫データWKへの書き込み
        /// </summary>
        /// <returns></returns>
        private bool dbInsert_nyuko_meisai_wk()
        {
            try
            {
                using (var context = new Entities.TourokuSyuseiModel(b2Com))
                {
                    //SQL Log 出力
                    context.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);

                    switch (Touroku_Syusei_result.mode)
                    {
                        case 0:   //新規
                            //入庫データＷＫへ新規書き込み
                            var nyuko_new = context.NyukoMeisai_wk.Create();
                            {
                                //薬局コード
                                nyuko_new.YakkyokuCode = Touroku_Syusei_result.yakkyoku_code;
                                //一意キー
                                //nyuko_new.IchiBango AUTO
                                //伝票区分
                                nyuko_new.DenpyoKubun = Touroku_Syusei_result.denpyou_kubun;
                                //取引区分
                                nyuko_new.TorihikiKubun = Touroku_Syusei_result.torihiki_kubun;
                                //処理日
                                nyuko_new.ShoriDate = Touroku_Syusei_result.shori_date;
                                //商品コード区分
                                nyuko_new.ShohinCodeKubun = Touroku_Syusei_result.shohin_code_kubun;
                                //商品コード
                                nyuko_new.ShohinCode = Touroku_Syusei_result.shohin_code;
                                //商品名、規格、容量
                                nyuko_new.ShohinNameKikakuYoryo = Touroku_Syusei_result.shohin_name_kikaku_yoryo.Substring(0, (Touroku_Syusei_result.shohin_name_kikaku_yoryo.Length > 40 ? 40 : Touroku_Syusei_result.shohin_name_kikaku_yoryo.Length));
                                //箱数
                                nyuko_new.HakoSuryo = Touroku_Syusei_result.hako_suryo_torihiki;
                                //包装数
                                nyuko_new.HosoSuryo = Touroku_Syusei_result.hoso_suryo_torihiki;
                                //バラ数
                                nyuko_new.BaraSuryo = Touroku_Syusei_result.bara_suryo_torihiki;
                                //単価
                                nyuko_new.Tanka = Touroku_Syusei_result.tanka;
                                //金額
                                nyuko_new.Kingaku = Touroku_Syusei_result.torihiki_goukeigaku;
                                //薬価
                                nyuko_new.Yakka = Touroku_Syusei_result.yakka;
                                //NOTE 税率を店舗マスタから引用すること。
                                //消費税金額
                                nyuko_new.ShohizeiKingaku = Touroku_Syusei_result.shohizei_kingaku;
                                //小計金額
                                nyuko_new.ShokeKingaku = Touroku_Syusei_result.shoke_kingaku;
                                //使用期限
                                nyuko_new.ShiyoKigen = Touroku_Syusei_result.shiyo_kigen;
                                //ロット番号（製造番号）
                                nyuko_new.LotBango = Touroku_Syusei_result.lot_bango;
                                //入庫日
                                nyuko_new.NyukoDate = DateTime.Today;
                                //入庫場所
                                nyuko_new.NyukoBasho = 0;
                                //発注明細番号
                                nyuko_new.HacchuMeisaiBango = 0;
                                //備考
                                nyuko_new.Biko = Touroku_Syusei_result.biko;
                                //登録日時
                                nyuko_new.InsertNitiji = Touroku_Syusei_result.insert_nitiji;

                                // レコードををテーブルに登録。
                                context.NyukoMeisai_wk.Add(nyuko_new);

                                //DBへの物理更新
                                context.SaveChanges();

                                //更新（新規）時の一意キーを設定
                                Touroku_Syusei_result.ichi_bangou = nyuko_new.IchiBango;
                            }

                            break;
                        case 1:   //修正
                            //入庫データＷＫへアップデート
                            //  読込
                            var nyuko = context.NyukoMeisai_wk.FirstOrDefault(w => w.YakkyokuCode == b2Com.YakkyokuCode &&
                                                                                     w.IchiBango == Touroku_Syusei_result.ichi_bangou);
                            //  更新
                            if (nyuko != null)
                            {
                                // 処理日
                                nyuko.ShoriDate = Touroku_Syusei_result.shori_date;
                                // 箱数
                                nyuko.HakoSuryo = Touroku_Syusei_result.hako_suryo_torihiki;
                                // 包装数
                                nyuko.HosoSuryo = Touroku_Syusei_result.hoso_suryo_torihiki;
                                // バラ数
                                nyuko.BaraSuryo = Touroku_Syusei_result.bara_suryo_torihiki;

                                //単価
                                nyuko.Tanka = Touroku_Syusei_result.tanka;
                                //金額
                                nyuko.Kingaku = Touroku_Syusei_result.torihiki_goukeigaku;
                                //薬価
                                nyuko.Yakka = Touroku_Syusei_result.yakka;
                                //NOTE 税率を店舗マスタから引用すること。
                                //消費税金額
                                nyuko.ShohizeiKingaku = Touroku_Syusei_result.shohizei_kingaku;
                                //小計金額
                                nyuko.ShokeKingaku = Touroku_Syusei_result.shoke_kingaku;
                                //使用期限
                                nyuko.ShiyoKigen = Touroku_Syusei_result.shiyo_kigen;
                                //ロット番号（製造番号）
                                nyuko.LotBango = Touroku_Syusei_result.lot_bango;
                                
                                //DBへの物理更新
                                context.SaveChanges();
                            }
                            else
                            {
                                MessageBox.Show("更新すべき一致する入庫データが見つかりません。\r\n担当ＳＥへ連絡して下さい。");
                                return false;
                            }
                            break;
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
        /// 出庫データWKへの書き込み
        /// </summary>
        /// <returns></returns>
        private bool dbInsert_shukko_meisai_wk()
        {
            try
            {
                using (var context = new Entities.TourokuSyuseiModel(b2Com))
                {
                    //SQL Log 出力
                    context.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);

                    switch (Touroku_Syusei_result.mode)
                    {
                        case 0:   //新規
                            //出庫データＷＫへ新規書き込み
                            var shukko_new = context.ShukkoMeisai_wk.Create();
                            {
                                //薬局コード
                                shukko_new.YakkyokuCode = Touroku_Syusei_result.yakkyoku_code;
                                //一意キー
                                //shukko_new.IchiBango AUTO
                                //伝票区分
                                shukko_new.DenpyoKubun = Touroku_Syusei_result.denpyou_kubun;
                                //取引区分
                                shukko_new.TorihikiKubun = Touroku_Syusei_result.torihiki_kubun;
                                //処理日
                                shukko_new.ShoriDate = Touroku_Syusei_result.shori_date;
                                //商品コード区分
                                shukko_new.ShohinCodeKubun = Touroku_Syusei_result.shohin_code_kubun;
                                //商品コード
                                shukko_new.ShohinCode = Touroku_Syusei_result.shohin_code;
                                //商品名、規格、容量
                                shukko_new.ShohinNameKikakuYoryo = Touroku_Syusei_result.shohin_name_kikaku_yoryo.Substring(0, (Touroku_Syusei_result.shohin_name_kikaku_yoryo.Length > 40 ? 40 : Touroku_Syusei_result.shohin_name_kikaku_yoryo.Length));
                                //箱数
                                shukko_new.HakoSuryo = Touroku_Syusei_result.hako_suryo_torihiki;
                                //包装数
                                shukko_new.HosoSuryo = Touroku_Syusei_result.hoso_suryo_torihiki;
                                //バラ数
                                shukko_new.BaraSuryo = Touroku_Syusei_result.bara_suryo_torihiki;
                                //単価
                                shukko_new.Tanka = Touroku_Syusei_result.tanka;
                                //金額
                                shukko_new.Kingaku = Touroku_Syusei_result.torihiki_goukeigaku;
                                //薬価
                                shukko_new.Yakka = Touroku_Syusei_result.yakka;
                                //NOTE 税率を店舗マスタから引用すること。
                                //消費税金額
                                shukko_new.ShohizeiKingaku = Touroku_Syusei_result.shohizei_kingaku;
                                //小計金額
                                shukko_new.ShokeKingaku = Touroku_Syusei_result.shoke_kingaku;
                                //使用期限
                                shukko_new.ShiyoKigen = Touroku_Syusei_result.shiyo_kigen;
                                //ロット番号（製造番号）
                                shukko_new.LotBango = Touroku_Syusei_result.lot_bango;
                                //出庫日
                                shukko_new.ShukkoDate = Touroku_Syusei_result.shukko_date;
                                //備考
                                shukko_new.Biko = Touroku_Syusei_result.biko;
                                //登録日時
                                shukko_new.InsertNitiji = Touroku_Syusei_result.insert_nitiji;

                                // レコードををテーブルに登録。
                                context.ShukkoMeisai_wk.Add(shukko_new);

                                //DBへの物理更新
                                context.SaveChanges();

                                //更新（新規）時の一意キーを設定
                                Touroku_Syusei_result.ichi_bangou = shukko_new.IchiBango;
                            }

                            break;
                        case 1:   //修正
                            //出庫データＷＫへアップデート
                            //  読込
                            var shukko = context.ShukkoMeisai_wk.FirstOrDefault(w => w.YakkyokuCode == b2Com.YakkyokuCode &&
                                                                                     w.IchiBango == Touroku_Syusei_result.ichi_bangou);
                            //  更新
                            if (shukko != null)
                            {
                                // 処理日
                                shukko.ShoriDate = Touroku_Syusei_result.shori_date;
                                // 箱数
                                shukko.HakoSuryo = Touroku_Syusei_result.hako_suryo_torihiki;
                                // 包装数
                                shukko.HosoSuryo = Touroku_Syusei_result.hoso_suryo_torihiki;
                                // バラ数
                                shukko.BaraSuryo = Touroku_Syusei_result.bara_suryo_torihiki;

                                //単価
                                shukko.Tanka = Touroku_Syusei_result.tanka;
                                //金額
                                shukko.Kingaku = Touroku_Syusei_result.torihiki_goukeigaku;
                                //薬価
                                shukko.Yakka = Touroku_Syusei_result.yakka;
                                //NOTE 税率を店舗マスタから引用すること。
                                //消費税金額
                                shukko.ShohizeiKingaku = Touroku_Syusei_result.shohizei_kingaku;
                                //小計金額
                                shukko.ShokeKingaku = Touroku_Syusei_result.shoke_kingaku;
                                //使用期限
                                shukko.ShiyoKigen = Touroku_Syusei_result.shiyo_kigen;
                                //ロット番号（製造番号）
                                shukko.LotBango = Touroku_Syusei_result.lot_bango;

                                //DBへの物理更新
                                context.SaveChanges();
                            }
                            else
                            {
                                MessageBox.Show("更新すべき一致する出庫データが見つかりません。\r\n担当ＳＥへ連絡して下さい。");
                                return false;
                            }
                            break;
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
        /// 薬品検索(GTIN or JAN)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_select_Click(object sender, EventArgs e)
        {

            //商品検索
            string search_code = string.Empty;
            if (!string.IsNullOrWhiteSpace(gcTxt_gtin_code.Text))
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

                //コード情報の確定　設定
                gcTxt_gtin_code.Text = f.kensaku_result.gtin_code;
                gcTxt_jan_code.Text = f.kensaku_result.jan_code;
                if (!string.IsNullOrWhiteSpace(gcTxt_gtin_code.Text))
                {
                    search_code = gcTxt_gtin_code.Text;
                }
                else if (!string.IsNullOrWhiteSpace(gcTxt_jan_code.Text))
                {
                    search_code = gcTxt_jan_code.Text;
                }

                //薬品情報のセット
                txt_yakuhinmei.Text = f.kensaku_result.yakuhin_mei;
                Touroku_Syusei_result.yakuhin_mei = f.kensaku_result.yakuhin_mei;
                Touroku_Syusei_result.yakuhin_kana = f.kensaku_result.yakuhin_kana;

                lbl_kikaku.Text = f.kensaku_result.kikaku_tanni;
                Touroku_Syusei_result.kikaku_tanni = f.kensaku_result.kikaku_tanni;

                lbl_housoukeitai.Text = f.kensaku_result.housou_keitai;
                Touroku_Syusei_result.housou_keitai = f.kensaku_result.housou_keitai;

                lbl_kubun.Text = f.kensaku_result.kubun;
                Touroku_Syusei_result.kubun = f.kensaku_result.kubun;

                lbl_seizoukaisya_mei.Text = f.kensaku_result.seizou_kaisha_mei;
                Touroku_Syusei_result.seizou_kaisha_mei = f.kensaku_result.seizou_kaisha_mei;

                lbl_hanbaikaisya_mei.Text = f.kensaku_result.hanbai_kaisha_mei;
                Touroku_Syusei_result.hanbai_kaisha_mei = f.kensaku_result.hanbai_kaisha_mei; ;

                gcNum_housou_souryou.Value = f.kensaku_result.housou_souryou_qty;
                Touroku_Syusei_result.hako_suryo_qty = f.kensaku_result.housou_souryou_qty;

                gcNum_hako_suryo_qty.Value = f.kensaku_result.housou_souryou_qty;
                Touroku_Syusei_result.hako_suryo_qty = f.kensaku_result.housou_souryou_qty;
                
                gcNum_hoso_suryo_qty.Value = f.kensaku_result.housou_tanni_qty;
                Touroku_Syusei_result.hoso_suryo_qty = f.kensaku_result.housou_tanni_qty;
                
                gcNum_bara_suryo_qty.Value = 1;
                Touroku_Syusei_result.bara_suryo_qty = 1;

                //薬価
                Touroku_Syusei_result.yakka = f.kensaku_result.yakka;
                gcNum_yakka.Value = Touroku_Syusei_result.yakka;

                lbl_hako_suryo_tanni.Text = f.kensaku_result.housou_suryou_tanni;
                Touroku_Syusei_result.hako_suryo_tanni = f.kensaku_result.housou_suryou_tanni;

                lbl_hoso_suryo_tanni.Text = f.kensaku_result.housou_tanni_tanni;
                Touroku_Syusei_result.hoso_suryo_tanni = f.kensaku_result.housou_tanni_tanni;
                
                lbl_bara_suryo_tanni.Text = f.kensaku_result.housou_suryou_tanni;
                Touroku_Syusei_result.bara_suryo_tanni = f.kensaku_result.housou_suryou_tanni;

                lbl_housou_souryou_tanni.Text = f.kensaku_result.housou_suryou_tanni;

                //製造番号
                switch (Touroku_Syusei_result.kinou)
                {
                    case 0:
                    case 1:
                        //入庫[発注は該当しない]　設定済みのデータをセットするのみ。
                        break;
                    case 2:
                        //出庫
                        //   製造番号情報をコンボボックスにセット
                        if (!string.IsNullOrEmpty(search_code))
                        {
                            string field_nm = "gtin_code";
                            if (search_code.Length <= 13)
                            {
                                field_nm = "jan_code";
                            }
                            ctlCom_seizou_bangou.Init(b2Com, "lotinfo_master", field_nm, search_code, "shiyo_kigen", "lot_bango");
                            ctlCom_seizou_bangou.SelectedIndex = -1;
                            gcDate_siyou_kigen.Value = DateTime.Today;
                        }
                        break;
                }
            }
        }

        /// <summary>
        /// 箱　取引数変更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gcNum_hako_suryo_torihiki_ValueChanged(object sender, EventArgs e)
        {
            //検索キーの取り出し
            string search_code = string.Empty;
            //　GTIN
            if (!string.IsNullOrEmpty(gcTxt_gtin_code.Text))
            {
                search_code = gcTxt_gtin_code.Text;
            }

            //　JAN
            else if (!string.IsNullOrEmpty(gcTxt_jan_code.Text))
            {
                search_code = gcTxt_jan_code.Text;
            }

            //データの抽出
            if (!string.IsNullOrEmpty(search_code))
            {
                //数量、合計金額の算出
                suryo_Calc(search_code);
            }
        }

        /// <summary>
        /// ヒート　取引数変更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gcNum_hoso_suryo_torihiki_ValueChanged(object sender, EventArgs e)
        {
            //検索キーの取り出し
            string search_code = string.Empty;
            //　GTIN
            if (!string.IsNullOrEmpty(gcTxt_gtin_code.Text))
            {
                search_code = gcTxt_gtin_code.Text;
            }

            //　JAN
            else if (!string.IsNullOrEmpty(gcTxt_jan_code.Text))
            {
                search_code = gcTxt_jan_code.Text;
            }

            //データの抽出
            if (!string.IsNullOrEmpty(search_code))
            {
                //数量、合計金額の算出
                suryo_Calc(search_code);
            }
        }

        /// <summary>
        /// バラ　取引数変更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gcNum_bara_suryo_torihiki_ValueChanged(object sender, EventArgs e)
        {
            //検索キーの取り出し
            string search_code = string.Empty;
            //　GTIN
            if (!string.IsNullOrEmpty(gcTxt_gtin_code.Text))
            {
                search_code = gcTxt_gtin_code.Text;
            }

            //　JAN
            else if (!string.IsNullOrEmpty(gcTxt_jan_code.Text))
            {
                search_code = gcTxt_jan_code.Text;
            }

            //データの抽出
            if (!string.IsNullOrEmpty(search_code))
            {
                //数量、合計金額の算出
                suryo_Calc(search_code);
            }
        }

        /// <summary>
        /// 数量、合計金額の算出
        /// </summary>
        /// <param name="search_code"></param>
        private void suryo_Calc(string search_code)
        {
            //数量　小計数
            gcNum_hako_suryo_torihiki_all.Value = gcNum_hako_suryo_qty.Value * gcNum_hako_suryo_torihiki.Value;
            gcNum_hoso_suryo_torihiki_all.Value = gcNum_hoso_suryo_qty.Value * gcNum_hoso_suryo_torihiki.Value;
            gcNum_bara_suryo_torihiki_all.Value = gcNum_bara_suryo_qty.Value * gcNum_bara_suryo_torihiki.Value;

            //数量　合計
            gcNum_torihiki_total.Value = (gcNum_bara_suryo_torihiki_all.Value +
                                           gcNum_hako_suryo_torihiki_all.Value +
                                           gcNum_hoso_suryo_torihiki_all.Value);
            //単価の取得
            if(gcNum_tanka.Value == 0)
            {
                tankaInfo(search_code);
            }

            //合計
            gcNum_torihiki_goukeigaku.Value = gcNum_torihiki_total.Value * gcNum_tanka.Value;

        }

        //単価の取得
        private void tankaInfo(string search_code)
        {
            //単価情報の抽出
            dbSelectTanka(search_code);

            //単価 伝票区分で設定内容を制御する。
            //gcNum_tanka.Value = 0;
            switch (Touroku_Syusei_result.kinou)
            {
                case 0:
                    //発注 購入価（契約単価)
                    gcNum_tanka.Value = Touroku_Syusei_result.price;
                    break;
                case 1:
                    //入庫 最終仕入単価
                    gcNum_tanka.Value = Touroku_Syusei_result.saisyuu_genka;
                    break;
                case 2:
                    //出庫 原価
                    switch (Touroku_Syusei_result.denpyou_kubun)
                    {
                        case 0:
                            //売上（零売)
                            gcNum_tanka.Value = Touroku_Syusei_result.yakka;
                            break;
                        case 1:
                            //店舗間移動
                            gcNum_tanka.Value = Touroku_Syusei_result.genka;
                            break;
                        case 2:
                            //譲与
                            gcNum_tanka.Value = Touroku_Syusei_result.yakka;
                            break;
                        case 3:
                            //在庫調整
                            gcNum_tanka.Value = Touroku_Syusei_result.genka;
                            break;
                        case 4:
                            //サンプル品
                            gcNum_tanka.Value = Touroku_Syusei_result.genka;
                            break;
                        case 5:
                            //廃棄（薬品）
                            gcNum_tanka.Value = Touroku_Syusei_result.genka;
                            break;
                        case 6:
                            //廃棄（麻薬）
                            gcNum_tanka.Value = Touroku_Syusei_result.genka;
                            break;
                        case 7:
                            //廃棄（向精神薬）
                            gcNum_tanka.Value = Touroku_Syusei_result.genka;
                            break;
                        case 8:
                            //自社消費
                            gcNum_tanka.Value = Touroku_Syusei_result.genka;
                            break;
                        case 9:
                            //社内販売
                            gcNum_tanka.Value = Touroku_Syusei_result.genka;
                            break;
                        case 10:
                            //OTC売上
                            gcNum_tanka.Value = Touroku_Syusei_result.yakka;
                            break;
                        case 20:
                            //調剤
                            gcNum_tanka.Value = Touroku_Syusei_result.yakka;
                            break;
                        default:
                            gcNum_tanka.Value = Touroku_Syusei_result.genka;
                            break;
                    }

                    break;
            }
        }


        /// <summary>
        /// 単価欄でフォーカスが離れた時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gcNum_tanka_Leave(object sender, EventArgs e)
        {
            tankaCalc();
        }
        private void gcNum_tanka_KeyDown(object sender, KeyEventArgs e)
        {
            // イベントの処理
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    //エンターキーが押下された
                    tankaCalc();
                    break;
            }

        }
        private void tankaCalc()
        {
            //単価をセットした時、合計額を算出する
            if (gcNum_torihiki_total.Value > 0 && gcNum_tanka.Value > 0)
            {
                if ((int)ctlCom_torihiki_kubun.SelectedValue == 1)
                {
                    //返品の時　マイナス表示
                    gcNum_torihiki_goukeigaku.Value = 0 - Math.Round((decimal)(gcNum_tanka.Value * gcNum_torihiki_total.Value), 2);
                }
                else
                {
                    //返品以外
                    gcNum_torihiki_goukeigaku.Value = Math.Round((decimal)(gcNum_tanka.Value * gcNum_torihiki_total.Value), 2);
                }

                if (gcNum_yakka.Value > 0)
                {
                    if (gcNum_yakka.Value < gcNum_tanka.Value)
                    {
                        MessageBox.Show("単価が薬価より高くなっています。");
                    }
                }

            }
        }


        /// <summary>
        /// 合計金額欄でフォーカスが離れた時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gcNum_torihiki_goukeigaku_Leave(object sender, EventArgs e)
        {
            goukeigakuCalc();
        }
        private void gcNum_torihiki_goukeigaku_KeyDown(object sender, KeyEventArgs e)
        {
            // イベントの処理
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    //エンターキーが押下された
                    goukeigakuCalc();
                    break;
            }
        }

        private void goukeigakuCalc()
        {
            //入庫の時のみ再計算の処理を行う
            if (Touroku_Syusei_result.kinou == 1)
            {
                //合計金額をセットした時、単価を算出 少数第2位
                if (gcNum_torihiki_total.Value > 0 && gcNum_torihiki_goukeigaku.Value > 0)
                {
                    //セットするのは絶対値　マイナスは有り得ない。
                    gcNum_tanka.Value = Math.Abs(Math.Round((decimal)(gcNum_torihiki_goukeigaku.Value / gcNum_torihiki_total.Value), 2));
                   if(gcNum_yakka.Value > 0)
                   {
                       decimal wk_total_yakka = (decimal)(gcNum_yakka.Value * gcNum_torihiki_total.Value);
                       if(wk_total_yakka <(decimal)gcNum_torihiki_goukeigaku.Value)
                       {
                           MessageBox.Show("合計額が薬価での計算より高くなっています。");
                       }
                   }
                }
            }
        }


        /// <summary>
        /// 伝票区分が変更された時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ctlCom_denpyou_kubun_SelectedValueChanged(object sender, EventArgs e)
        {
            setTankaGoukeiControl();
        }

        /// <summary>
        /// 取引区分が変更された時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ctlCom_torihiki_kubun_SelectedValueChanged(object sender, EventArgs e)
        {
            setTankaGoukeiControl();
        }

        
        /// <summary>
        /// 製造番号コンボボックスのインデックスが変更された。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ctlCom_seizou_bangou_SelectedIndexChanged(object sender, EventArgs e)
        {
            seizou_bangou_reset();

        }

        private void ctlCom_seizou_bangou_KeyDown(object sender, KeyEventArgs e)
        {
            // イベントの処理
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    //エンターキーが押下された
                    seizou_bangou_reset();
                    break;
            }

        }
        private void seizou_bangou_reset()
        {
            if (ctlCom_seizou_bangou.SelectedIndex < 0)
            {
                return;
            }

            switch (Touroku_Syusei_result.kinou)
            {
                case 0:
                case 1:
                    //入庫[発注は該当しない]　
                    break;
                case 2:
                    //出庫
                    //   使用期限をセット
                    string wk_kigen = (string)ctlCom_seizou_bangou.SelectedValue;
                    if (wk_kigen.Length == 8)
                    {
                        string wk_cnv = wk_kigen.Substring(0, 4) + "/" + wk_kigen.Substring(4, 2) + "/" + wk_kigen.Substring(6, 2);
                        DateTime wk_date;
                        if (DateTime.TryParse(wk_cnv, out wk_date))
                        {
                            gcDate_siyou_kigen.Value = wk_date;
                        }
                    }
                    break;
            }
        }
    }
}
