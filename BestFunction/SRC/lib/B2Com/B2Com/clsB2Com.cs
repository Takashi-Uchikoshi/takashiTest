using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Reflection;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using Npgsql;

/*---------------------------------------------------------------------------------
 *
 *    ファイル名　　 : clsB2Com.cs
 *    説明           : 共通クラス
 *    修正履歴　　　 : 
 *
---------------------------------------------------------------------------------*/

namespace B2.Com
{
    /// <summary>
    /// 共通クラス
    /// </summary>
    public class clsB2Com : IDisposable
    {
        #region  グローバル定数 
        //---------------------------------------------------------------------------------
        //▼カラー設定情報
        //---------------------------------------------------------------------------------
        /// <summary>カラー設定情報</summary>
        public enum FROM_COLOR_MODE
        {
            /// <summary>通常設定カラー</summary>
            NORMAL = 0,                                 // [0:通常]
            /// <summary>テーマカラー</summary>
            TERMA,                                      // [1:テーマカラー]
        }

        #endregion

        //---------------------------------------------------------------------------------
        #region // ■ グローバル構造体 
        //---------------------------------------------------------------------------------
        #endregion

        //---------------------------------------------------------------------------------
        #region // ■ グローバル変数
        //---------------------------------------------------------------------------------
        /// <summary> postgreSQL接続クラスの定義 </summary>
        public clsPostgre PostLib = new clsPostgre();

        #endregion

        #region ローカル定数 
        //値を取得するレジストリキー名
        const string B2_regkey = @"Software\BestFunction";

        //値（Value取得用）
        const string B2_Server_key = @"Server";                     //サーバー名
        const string B2_Port_key = @"Port";                         //ポート番号
        const string B2_Database_key = @"Database";                 //データベース名
        const string B2_UserName_key = @"UserID";                   //店舗DB用ユーザ名
        const string B2_Password_key = @"Password";                 //店舗DB用パスワード
        const string B2_Schema_key = @"Schema";                     //スキーマー（ユーザー名と同一とする）
        const string B2_Honbu_UserName_key = @"HonbuUserID";        //本部DB用ユーザ名
        const string B2_Honbu_Password_key = @"HonbuPassword";      //本部DB様パスワード
        const string B2_Yakkyoku_Code_key = @"Yakkyoku_Code";                 //店舗番号
        const string B2_Honbu_Yakkyoku_Code_key = @"HonbuYakkyoku_Code";      //本部店舗番号（識別）
        #endregion

        #region ローカル変数

        //---------------------------------------------------------------------------------
        //▼ 共通情報
        //---------------------------------------------------------------------------------

        //---------------------------------------------------------------------------------
        //▼DB接続情報格納領域
        //---------------------------------------------------------------------------------
        private string B2_Server;                          　//サーバー名
        private string B2_Port;                          　  //ポート番号
        private string B2_Database;                          //データベース名
        private string B2_UserName;                          //ユーザ名
        private string B2_Password;                          //パスワード
        private string B2_Schema;                            //スキーマー
        private string B2_Honbu_UserName;                    //本部スキーマ用ユーザ名
        private string B2_Honbu_Password;                    //本部スキーマ用パスワード
        private string B2_Yakkyoku_Code;                        //店舗識別コード
        private string B2_Honbu_Yakkyoku_Code;                  //本部用識別コード

        //---------------------------------------------------------------------------------
        //▼GENGO.INI
        //---------------------------------------------------------------------------------
        //[元号]
        private string GENGO_GengoString;                       //元号情報
        private string Reki_System;                             //システム歴
        private string Reki_Unyo;                               //運用歴
        private struct GengoStruct
        {
            public string FullName;                             //元号名
            public string AlphabetName;                         //略称アルファベット１文字
            public string OmissionName;                         //略称漢字一文字
            public int FromDate;                                //開始日付
            public int ToDate;                                  //終了日付
            public int CountYear;                               //年数
        }
        private GengoStruct[] GengoInfo = new GengoStruct[11];

        //---------------------------------------------------------------------------------
        //▼和暦変換関係
        //---------------------------------------------------------------------------------
        private string[] abbreviatedEnglishEraNames;
        private CultureInfo culture;

        //---------------------------------------------------------------------------------
        //▼店舗情報
        //---------------------------------------------------------------------------------
 //       private string TenpoCD;                              //店舗CD     (現在選択店舗)
 //       private string TenpoNM;                              //店舗名称   (現在選択店舗)

        //---------------------------------------------------------------------------------
        //▼ローカル情報
        //---------------------------------------------------------------------------------
        private string PH_PRGID;                                // プログラムID
        private string mstrMachinNm;                            // マシン名
        private string ProgPram;                                // プログラム固有引数(第５引数）
        private List<string> mlstPram = new List<string>();     // コマンドライン引数（全て）

        //---------------------------------------------------------------------------------
        //▼カラー設定情報
        //---------------------------------------------------------------------------------
        private FROM_COLOR_MODE mFromColorMode;                 // フォームカラーモード

        //---------------------------------------------------------------------------------
        //フォームのバックアカラー設定情報
        //---------------------------------------------------------------------------------
        private int backColor_alpha;                            // アルファ
        private int backColor_red;                              // レッド
        private int backColor_green;                            // グリーン
        private int backColor_blue;                             // ブルー

        //---------------------------------------------------------------------------------
        // ログファイル　拡張コード
        //---------------------------------------------------------------------------------
        /// <summary>起動</summary>
        public const string EXCD_START = "01";


        /// <summary>終了</summary>
        public const string EXCD_EXIT = "02";

        /// <summary>ログイン</summary>
        public const string EXCD_LOGIN = "03";

        /// <summary>ログアウト</summary>
        public const string EXCD_LOGOUT = "04";

        /// <summary>認証失敗</summary>
        public const string EXCD_FAILED = "05";

        /// <summary>別EXE起動</summary>
        public const string EXCD_EXEC = "06";

        /// <summary>更新</summary>
        public const string EXCD_UPDATE = "07";

        #endregion

        #region // コンストラクタ
        ///
        /// <summary> 機能　　　: コンストラクタ                            </summary>
        /// <remark>  機能説明　: コンストラクタ                            </remark>
        //
        //*************************************************************************************
        public clsB2Com()
        {
            // 変数クリア
            msubInitDat();

            //システムによる和暦制御の前処理
            culture = new CultureInfo("ja-JP", true);
            culture.DateTimeFormat.Calendar = new JapaneseCalendar();

            JapaneseCalendar japaneseCalendar = new JapaneseCalendar();

            // DateTimeFormatInfo の Type を取得
            Type dateTimeFormatInfoType = typeof(DateTimeFormatInfo);
            DateTimeFormatInfo dateTimeFormatInfo = culture.DateTimeFormat;
            dateTimeFormatInfo.Calendar = japaneseCalendar;

            //和暦英語略称の内部プロパティの取得
            PropertyInfo abbreviatedEnglishEraNamesPropertyInfo = dateTimeFormatInfoType.GetProperty("AbbreviatedEnglishEraNames", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
            abbreviatedEnglishEraNames = (string[])abbreviatedEnglishEraNamesPropertyInfo.GetValue(dateTimeFormatInfo, null);

        }
        #endregion

        #region // デストラクタ(IDispose)
        /// <summary> 機能　　　: デストラクタ(IDispose)                    </summary>
        /// <remark>  機能説明　: デストラクタ(IDispose)                    </remark>
        //*************************************************************************************
        ~clsB2Com()
        {
            Dispose();
        }
        #endregion

        #region // 解放処理
        ///
        /// <summary> 機能　　　: 解放処理</summary>
        /// 
        /// <remark>  機能説明　: メモリ等の解放処理</remark>
        //
        //*************************************************************************************
        public void Dispose()
        {
            //------------------------------------
            // ＤＢ終了処理
            //------------------------------------
             PostLib.Dispose();

            GC.SuppressFinalize(this);
        }
        #endregion

        #region // プロパティ(ReadOnly)

        /// <summary> [DB]サーバー名 </summary>
        public string DB_Server
        {
            get { return B2_Server; }
            set { B2_Server = value; }
        }

        /// <summary> [DB]ポート番号 </summary>
        public string DB_Port
        {
            get { return B2_Port; }
            set { B2_Port = value; }
        }

        /// <summary> [DB]データベース名 </summary>
        public string DB_Database
        {
            get { return B2_Database; }
            set { B2_Database = value; }
        }

        /// <summary> [DB]ユーザ名 </summary>
        public string DB_User
        {
            get { return B2_UserName; }
            set { B2_UserName = value; }
        }

        /// <summary> [DB]パスワード </summary>
        public string DB_Password
        {
            get { return B2_Password; }
            set { B2_Password = value; }
        }

        /// <summary> [DB]スキーマー </summary>
        public string DB_Schema
        {
            get { return B2_Schema; }
            set { B2_Schema = value; }
        }

        /// <summary> [DB]本部ユーザ名 </summary>
        public string DB_HonbuUser
        {
            get { return B2_Honbu_UserName; }
            set { B2_Honbu_UserName = value; }
        }

        /// <summary> [DB]本部パスワード </summary>
        public string DB_HonbuPassword
        {
            get { return B2_Honbu_Password; }
            set { B2_Honbu_Password = value; }
        }

        /// <summary> [XX]店舗番号 </summary>
        public string SS_Tenpo
        {
            get { return B2_Yakkyoku_Code; }
            set { B2_Yakkyoku_Code = value; }
        }

        /// <summary> [XX]本部店舗番号 </summary>
        public string SS_HonbuTenpo
        {
            get { return B2_Honbu_Yakkyoku_Code; }
            set { B2_Honbu_Yakkyoku_Code = value; }
        }

        /// <summary> プログラムID </summary>
        public string PRGID
        {
            get { return PH_PRGID; }
            set { PH_PRGID = value; }
        }
        
        public string ProgArgument
        {
            get { return ProgPram; }
            set { ProgPram = value; }
        }
 
        /// <summary> プログラム引数　(該当ｲﾝﾃﾞｯｸｽの情報を取得：Index　0～）        </summary>
        public string CommandParm(int lintIndex)
        {
            if(mlstPram.Count == 0)
            {
                // 引数が存在しない場合、空文字列
                return "";
            }
            if(lintIndex < 0 ||
                lintIndex > (mlstPram.Count - 1))
            {
                // 範囲外の場合、空文字列
                return "";
            }
            // 該当引数を戻す
            return mlstPram[lintIndex];
        }

        /// <summary> フォームカラーモード (FROM_COLOR_MODEより設定取得) </summary>
        public FROM_COLOR_MODE FormColorMode
        {
            get { return mFromColorMode; }
            set { mFromColorMode = value; }  
        }

        /// <summary> マシン名 </summary>
        public string MachinNm
        {
            get { return mstrMachinNm; }
            set { mstrMachinNm = value; }
        }

        #endregion

        #region // 内部変数 クリア処理
        /// <summary> 機能　　　: 内部変数　クリア処理                          </summary>
        /// <remark>  機能説明　: 変数クリアを行ないます                        </remark>
        private void msubInitDat()
        {
            //-----------------------------------------------------------------------------
            // string型でnullエラーにならない為に初期化を行ないます
            //-----------------------------------------------------------------------------

            //-----------------------------------------------------------------------------
            //DB接続情報
            //-----------------------------------------------------------------------------
            B2_Server = "";                  // サーバー名
            B2_Port = "";                    // ポート番号
            B2_Database = "";                // データベース名
            B2_UserName = "";                // ユーザ名
            B2_Password = "";                // パスワード
            B2_Schema = "";                  // スキーマ名

            //-----------------------------------------------------------------------------
            //▼ローカル情報
            //-----------------------------------------------------------------------------
            ProgPram = "";                      // プログラム固有引数

            // プログラムID
            PH_PRGID = System.IO.Path.GetFileNameWithoutExtension(Environment.GetCommandLineArgs()[0]);

            // マシン名
            mstrMachinNm = Environment.MachineName;     // マシン名称

            //-----------------------------------------------------------------------------
            //▼カラー設定情報
            //-----------------------------------------------------------------------------
            mFromColorMode = FROM_COLOR_MODE.NORMAL;        // フォームカラーモード


        }
        #endregion

        #region // コマンドライン情報取得処理
        /// <summary> 機能　　　: コマンドライン情報取得処理                        </summary>
        /// <returns> 戻値      : bool                                              </returns>
        /// <remark>  機能説明　: コマンドライン情報を取得します                    </remark>
        public bool gfncGetCommandLine()
        {
            //---------------------------------------------------------------------------------
            // ■コマンドライン引数取得
            //---------------------------------------------------------------------------------
            // コマンドラインを配列で取得する
            string[] lstrCmdLines = Environment.GetCommandLineArgs();
            if(lstrCmdLines.Length < 2)            // 引数にユーザID等がないときはエラー [0:EXE名、1:引数内容 2～：その他]
            {
                return false;
            }

            // パラメータ(カンマ区切)分割
            string[] lstrCmdPara = lstrCmdLines[1].Split(',');
            if(lstrCmdPara.Length < 5)             // 引数の数が不一致の場合エラー [引数は５以上]
            {
                return false;
            }

            // コマンドライン引数全て保存
            mlstPram.Clear();
            for(int lintIndex = 0; lintIndex < lstrCmdPara.Length; lintIndex++)
            {
                mlstPram.Add(lstrCmdPara[lintIndex].Trim());          // リストへ保存
            }

            return true;

        }
        #endregion

        #region // 初期処理
        /// <summary> 機能　　　: 初期処理                              </summary>
        /// <remark>  機能説明　: 初期処理                              </remark>
        public bool gfncInitialize(bool showErrorDialog)
        {
            //ＤＢ接続情報の取得
            if(GetDbConectInfo() == false)
            {
                if(showErrorDialog == true)
                {
                    MessageBox.Show("DB接続情報の取得に失敗しました。" + Environment.NewLine + "プログラムを終了します。",
                                    "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return false;
            }

            //カラー情報の取得
            GetColorIni();

            return true;
        }
        #endregion

        #region // フォームのバックカラー設定処理
        /// <summary> 機能　　　: フォームのバックカラー設定処理                </summary>
        /// <remark>  機能説明　: フォームのバックカラー設定処理　　　　        </remark>
        //
        //*************************************************************************************
        public void gfncSetBackColor(Form fm)
        {
            fm.BackColor = System.Drawing.Color.FromArgb(backColor_red,
                                                         backColor_green,
                                                         backColor_blue);
            
            //コントロールのバックカラー、文字色、ボーダースタイルの設定
            gfncSetAllControls(fm);

            return;
        }
        #endregion

        #region // 全コントロールの設定処理
        /// <summary> 機能　　　: 全コントロールの設定処理           </summary>
        /// <param name="pctrl">
        ///           引数      : 親コントロール                     </param>
        /// <returns> 戻値      : コントロールリスト                 </returns>
        /// <remark>  機能説明　: 全コントロールの設定処理           </remark>
        private List<Control> gfncSetAllControls(Control pctrl)
        {
            Color lobjDefaultBackColor = System.Drawing.Color.FromArgb(backColor_red, backColor_green, backColor_blue);
            Color lobjDefaultForeColor = Color.DimGray;

            //-----------------------------------------------------------------------------
            // ■ 子コントロール分LOOP
            //-----------------------------------------------------------------------------
            foreach (Control c in pctrl.Controls)
            {
                //-------------------------------------------------------------------------
                // ■ コントロール名が設定されている場合
                //-------------------------------------------------------------------------
                if (c.Name != "")
                {
                    //---------------------------------------------------------------------
                    // ■ 色情報初期化
                    //---------------------------------------------------------------------
                    // ┌──┐
                    // │メモ│
                    // └──┘
                    // 背景色"BackColor"が設定されているように見えても、親クラスの値の可能性がある為再設定必要
                    //---------------------------------------------------------------------
                    //--------------------------------------
                    // 背景色初期化
                    //--------------------------------------
                    c.BackColor = c.BackColor;  // →必要
                    //--------------------------------------
                    // 文字色初期化
                    //--------------------------------------
                    c.ForeColor = lobjDefaultForeColor;
                    //---------------------------------------------------------------------
                    // ■ 設定
                    //---------------------------------------------------------------------
                    if (c is TextBox)
                    {
                        //======================================
                        // テキストボックス
                        //======================================
                        ((TextBox)c).BorderStyle = BorderStyle.FixedSingle;
                    }
                    else if (c is RichTextBox)
                    {
                        //======================================
                        // リッチテキストボックス
                        //======================================
                        ((RichTextBox)c).BorderStyle = BorderStyle.FixedSingle;
                    }
                    else if (c is ListBox)
                    {
                        //======================================
                        // リストボックス
                        //======================================
                        ((ListBox)c).BorderStyle = BorderStyle.FixedSingle;
                    }
                    else if (c is ComboBox)
                    {
                        //======================================
                        // コンボボックス
                        //======================================
                        ((ComboBox)c).FlatStyle = FlatStyle.Flat;
                    }
                    else if (c is Label)
                    {
                        //======================================
                        // ラベル
                        //======================================
                        //------------------
                        // 背景色
                        //------------------
                        if (0 < c.Name.ToUpper().IndexOf("GAID"))
                        {
                            //--------------------------------------
                            // ガイダンス
                            //--------------------------------------
                            c.BackColor = System.Drawing.SystemColors.ButtonFace;
                        }
                        else if (0 < c.Name.ToUpper().IndexOf("TIME"))
                        {
                            //--------------------------------------
                            // 時計
                            //--------------------------------------
                            c.BackColor = System.Drawing.SystemColors.ButtonFace;
                        }
                        else if (c.BackColor == System.Drawing.SystemColors.Control)
                        {
                            c.BackColor = lobjDefaultBackColor;
                        }
                        //------------------
                        // 境界線
                        //------------------
                        switch (((Label)c).BorderStyle)
                        {
                            case BorderStyle.None:
                                //------------------
                                // 境界線なし
                                //------------------
                                ((Label)c).BorderStyle = BorderStyle.None;
                                break;
                            default:
                                //------------------
                                // 境界線あり
                                //------------------
                                ((Label)c).BorderStyle = BorderStyle.FixedSingle;
                                //--------------------------------------
                                // テキストの縦位置：上詰め→中央揃え
                                //--------------------------------------
                                switch (((Label)c).TextAlign)
                                {
                                    case ContentAlignment.TopCenter:
                                        ((Label)c).TextAlign = ContentAlignment.MiddleCenter;
                                        break;
                                    case ContentAlignment.TopLeft:
                                        ((Label)c).TextAlign = ContentAlignment.MiddleLeft;
                                        break;
                                    case ContentAlignment.TopRight:
                                        ((Label)c).TextAlign = ContentAlignment.MiddleRight;
                                        break;
                                }
                                break;
                        }
                    }
                    else if (c is Button)
                    {
                        //======================================
                        // ボタン
                        //======================================
                        //------------------
                        // 背景色
                        //------------------
                        c.BackColor = System.Drawing.SystemColors.ButtonFace;
                        //------------------
                        // 境界線
                        //------------------
                        ((Button)c).FlatStyle = FlatStyle.Flat;
                    }
                    else
                    {
                        //======================================
                        // その他コントロール
                        //======================================
                        if (c.BackColor == System.Drawing.SystemColors.Control)
                        {
                            c.BackColor = lobjDefaultBackColor;
                        }
                    }

                    //---------------------------------------------------------------------
                    // ■ 再帰設定
                    //---------------------------------------------------------------------
                    gfncSetAllControls(c);                                  // 再帰
                }
            }

            return new List<Control>();
        }

        
        #endregion

        #region // DB接続処理
        /// <summary> 機能　　　: DB接続処理                                </summary>
        /// <remark>  機能説明　: DB接続処理                                </remark>
        public bool gfncInitDb(bool showErrorDialog)
        {
            //---------------------------------------------------------------------------------
            // ■ DB接続
            //---------------------------------------------------------------------------------
            if(ConnectDB() == false)
            {
                if(showErrorDialog == true)
                {
                    MessageBox.Show("DBサーバーへの接続に失敗しました。" + Environment.NewLine + "プログラムを終了します。",
                                    "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return false;
            }

            return true;
        }

        public void gfncCloseDb()
        {
            PostLib.DisConnect();
        }
        #endregion

        #region // DB接続情報の取得
        /// <summary> 機能　　　: DB接続情報の取得              </summary>
        /// <remark>  機能説明　: レジストリから取得            </remark>
          private bool GetDbConectInfo()
        {

            try
            {
                //取得出来なかった時はEmptyがセットされます。
                B2_Server = clsRegistry.GetRegistry(B2_regkey, B2_Server_key);                  // サーバー名
                B2_Port = clsRegistry.GetRegistry(B2_regkey, B2_Port_key);                    　// ポート番号
                B2_Database = clsRegistry.GetRegistry(B2_regkey, B2_Database_key);              // データベース名
                B2_UserName = clsRegistry.GetRegistry(B2_regkey, B2_UserName_key);              // ユーザ名
                B2_Password = clsRegistry.GetRegistry(B2_regkey, B2_Password_key);              // パスワード
                B2_Schema = clsRegistry.GetRegistry(B2_regkey, B2_Schema_key);                  // スキーマー
                B2_Honbu_UserName = clsRegistry.GetRegistry(B2_regkey, B2_Honbu_UserName_key);  // 本部ユーザ名
                B2_Honbu_Password = clsRegistry.GetRegistry(B2_regkey, B2_Honbu_Password_key);  // 本部パスワード
                B2_Yakkyoku_Code = clsRegistry.GetRegistry(B2_regkey, B2_Yakkyoku_Code_key);              // 店舗番号
                B2_Honbu_Yakkyoku_Code = clsRegistry.GetRegistry(B2_regkey, B2_Honbu_Yakkyoku_Code_key);  // 本部店舗識別

                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion


        #region // COLOR情報の取得
        /// <summary> 機能　　　: COLOR情報の取得                            </summary>
        private bool GetColorIni()
        {

            try
            {
                //カラー情報を取得
                string strcolor = GetINIData("B2COM", "FORM", "COLOR", "&HFFEEF1ED");
                if (strcolor == null)
                {
                    // デフォルトカラーをセット
                    backColor_alpha = int.Parse("000000FF", System.Globalization.NumberStyles.HexNumber);  // アルファ
                    backColor_red = int.Parse("000000EE", System.Globalization.NumberStyles.HexNumber);    // レッド
                    backColor_green = int.Parse("000000F1", System.Globalization.NumberStyles.HexNumber);  // グリーン
                    backColor_blue = int.Parse("000000ED", System.Globalization.NumberStyles.HexNumber);   // ブルー　
                }
                else
                {
                    // 取得したカラーをセット
                    string bk_alpha = string.Empty;
                    string bk_red = string.Empty;
                    string bk_green = string.Empty;
                    string bk_blue = string.Empty;
                    switch (strcolor.Length)
                    {
                        case 8:
                            if (strcolor.Substring(0, 2) == "&H")
                            {
                                bk_alpha = "FF";                      // アルファ
                                bk_red = strcolor.Substring(2, 2);    // レッド
                                bk_green = strcolor.Substring(4, 2);  // グリーン
                                bk_blue = strcolor.Substring(6, 2);   // ブルー　
                            }
                            break;
                        case 10:
                            if (strcolor.Substring(0, 2) == "&H")
                            {
                                bk_alpha = strcolor.Substring(2, 2);  // アルファ
                                if (bk_alpha == "00") bk_alpha = "FF";
                                bk_red = strcolor.Substring(4, 2);    // レッド
                                bk_green = strcolor.Substring(6, 2);  // グリーン
                                bk_blue = strcolor.Substring(8, 2);   // ブルー　
                            }
                            break;
                        default:
                            // デフォルトカラーをセット
                            bk_alpha = "FF";  // アルファ
                            bk_red = "EE";    // レッド
                            bk_green = "F1";  // グリーン
                            bk_blue = "ED";   // ブルー　
                            break;
                    }

                    backColor_alpha = int.Parse(bk_alpha, System.Globalization.NumberStyles.HexNumber);  // アルファ
                    backColor_red = int.Parse(bk_red, System.Globalization.NumberStyles.HexNumber);    // レッド
                    backColor_green = int.Parse(bk_green, System.Globalization.NumberStyles.HexNumber);  // グリーン
                    backColor_blue = int.Parse(bk_blue, System.Globalization.NumberStyles.HexNumber);   // ブルー　
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region // DB接続
        /// <summary> 機能　　　: PHARMA DB接続                          </summary>
        /// <remark>  機能説明　: PHARMA DB接続                      </remark>
        private bool ConnectDB()
        {
            try
            {
                return PostLib.Connect(B2_Server, B2_Port, B2_UserName, B2_Password, B2_Database,B2_Schema);
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region // エラーメッセージ表示処理
        //
        /// <summary> 機能　　　: エラーメッセージ表示処理                          </summary>
        /// 
        /// <param name="pexpErr">
        ///           引数　　　: (I) エラー内容                                    </param> 
        /// <returns> 戻値      : bool                                              </returns>
        /// 
        /// <remark>  機能説明　: エラーメッセージを表示します                      </remark>
        /// 
        //*********************************************************************************
        public void ShowErrMsg(Exception pexpErr)
        {
            // メッセージの編集
            StringBuilder lstrMsg = new StringBuilder();

            // メッセージの組み立て
            lstrMsg.Remove(0, lstrMsg.Length);            // クリア
            lstrMsg.Append("エラーが発生しました。\n");
            lstrMsg.Append("\n[エラータイプ]\n");
            lstrMsg.Append(pexpErr.GetType().ToString());
            lstrMsg.Append("\n[メッセージ]\n");
            lstrMsg.Append(pexpErr.Message);
            lstrMsg.Append("\n[StackTrace]\n");
            lstrMsg.Append(pexpErr.StackTrace);
            MessageBox.Show(lstrMsg.ToString(),
                             PH_PRGID,
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Error);

        }
        #endregion //

        /// <summary>
        /// 端数処理
        /// </summary>
        /// <param name="value">端数処理する値</param>
        /// <param name="div">端数処理区分(0：四捨五入 1：切捨て 2：切上げ)</param>
        /// <returns>端数処理済の値</returns>
        public  decimal ExecFraction(decimal value, int div)
        {
            decimal data;

            switch (div)
            {
                case 1:
                    // 切捨
                    if (0m <= value)
                        data = Math.Floor(value);
                    else
                        data = Math.Ceiling(value);
                    break;

                case 2:
                    // 切上
                    if (0m <= value)
                        data = Math.Ceiling(value);
                    else
                        data = Math.Floor(value);
                    break;

                default:
                    // 四捨五入
                    data = Math.Round(value, MidpointRounding.AwayFromZero);
                    break;
            }

            return data;
        }

        /// <summary>
        /// 端数処理
        /// </summary>
        /// <param name="value">端数処理する値</param>
        /// <param name="div">端数処理区分(0：四捨五入 1：切捨て 2：切上げ)</param>
        /// <returns>端数処理済の値</returns>
        public  double ExecFractionDb(double value, int div)
        {
            double data;

            switch (div)
            {
                case 1:
                    // 切捨
                    if (0d <= value)
                        data = Math.Floor(value);
                    else
                        data = Math.Ceiling(value);
                    break;

                case 2:
                    // 切上
                    if (0d <= value)
                        data = Math.Ceiling(value);
                    else
                        data = Math.Floor(value);
                    break;

                default:
                    // 四捨五入
                    if (0d <= value)
                        data = System.Math.Floor(value + 0.5d);
                    else
                        data = System.Math.Ceiling(value - 0.5d);
                    break;
            }

            return data;
        }

        #region // ログ　出力
        /// <summary> 
        /// ログ　出力
        /// </summary>
        /// <param name="bunruiCode">分類コード</param>
        /// <param name="loginCode">ログインID</param> 
        /// <param name="bikou">備考</param>
        /// <returns>成功したらTrue　エラーでFalse</returns>
        /// <remark>システムログ　出力</remark>
        public bool WriteSysLog(string bunruiCode, string loginCode,  string bikou)
        {
            bool retflg = false;

            try
            {
                /*
                yakkyoku_code, logno, logdate, program_code, bunrui, client, 
                    login_code, key_code, bikou, filename, param, enable */
                PostLib.SQLClear();
                PostLib.SQL.Append("insert into log_data");
                PostLib.SQL.Append(" (yakkyoku_code, logdate, program_code, bunrui, client, ");
                PostLib.SQL.Append("  login_code,  bikou) ");
                PostLib.SQL.Append(" VALUES(");
                PostLib.SQL.Append("'" + B2_Yakkyoku_Code + "',");
                PostLib.SQL.Append("current_timestamp,");
                PostLib.SQL.Append("'" + PH_PRGID + "',");
                PostLib.SQL.Append("'" + bunruiCode + "',");
                PostLib.SQL.Append("'" + mstrMachinNm + "',");
                PostLib.SQL.Append("'" + loginCode.Substring(loginCode.Length-8, 8) + "',");
                PostLib.SQL.Append("'" + bikou + "')");
                if (PostLib.ExecuteSQLNoErr(PostLib.SQL.ToString()) != -1)
                {
                    retflg = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return retflg;
        }
        #endregion

        #region INIテーブルアクセス
        /// <summary>
        /// INI情報取得
        /// </summary>
        /// <param name="pgName">プログラム名</param>
        /// <param name="section">セクション名</param>
        /// <param name="key">キー名</param>
        /// <param name="def">デフォルト値</param>
        /// <returns>INIデータ</returns>
        public string GetINIData(string pgName, string section, string key, string def)
        {
            StringBuilder lstrSQL = new StringBuilder();
            string data = def;

            /*yakkyoku_code, program, section, keycode, data, biko, 
                start_use_date, end_use_date */
            lstrSQL.Append("select ");
            lstrSQL.Append("  data");
            lstrSQL.Append(" from  ini_master");
            lstrSQL.Append(" WHERE yakkyoku_code  = '" + B2_Yakkyoku_Code + "'");
            lstrSQL.Append("   AND program  = '" + pgName + "'");
            lstrSQL.Append("   AND section = '" + section + "'");
            lstrSQL.Append("   AND keycode    = '" + key + "'");
              
            NpgsqlDataReader reader = PostLib.SelectSQL_NoCache(lstrSQL.ToString());
            if (reader != null)
            {
                if (reader.Read())
                {
                    if (DBNull.Value.Equals(reader["data"]))
                        return def;
                    data = reader["data"].ToString();
                }
                reader.Close();
                reader.Dispose();
                reader = null;
            }

            return data;
        }
        #endregion
   


    }
}
