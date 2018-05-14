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
using System.Data;
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
    public class B2Com : IDisposable
    {
        #region  パブリック定数 
        // ---------------------------------------------------------------------------------
        // ▼カラー設定情報
        // ---------------------------------------------------------------------------------
        /// <summary>カラー設定情報</summary>
        public enum FormColorPattern
        {
            /// <summary>通常設定カラー</summary>
            Normal = 0,
            /// <summary>テーマカラー</summary>
            Thema,
        }

        // ---------------------------------------------------------------------------------
        // ログファイル　拡張コード
        // ---------------------------------------------------------------------------------
        /// <summary>ログファイル拡張コード　起動</summary>
        public const string LogfileCodeStart = "01";
        /// <summary>ログファイル拡張コード　終了</summary>
        public const string LogfileCodeExit = "02";
        /// <summary>ログファイル拡張コード　ログイン</summary>
        public const string LogfileCodeLogin = "03";
        /// <summary>ログファイル拡張コード　ログアウト</summary>
        public const string LogfileCodeLogout = "04";
        /// <summary>ログファイル拡張コード　認証失敗</summary>
        public const string LogfileCodeFailed = "05";
        /// <summary>ログファイル拡張コード　別EXE起動</summary>
        public const string LogfileCodeStartProgram = "06";
        /// <summary>ログファイル拡張コード　更新</summary>
        public const string LogfileCodeUpdate = "07";
        #endregion

        #region // ■ パブリック構造体
        #endregion

        #region // ■ パブリック変数
        /// <summary> PgLibQL接続クラスの定義 </summary>
        public PgLib PgLib = new PgLib();
        #endregion

        #region ローカル定数 
        /// <summary>値を取得するレジストリキー名</summary>
        private const string B2Registrykey = @"Software\BestFunction";

        /// <summary>DBサーバー名キー</summary>
        private const string DbServerMeiKey = @"Server";
        /// <summary>DBポート番号キー</summary>
        private const string DbPortBangoKey = @"Port";
        /// <summary>DBデータベース名キー</summary>
        private const string DbDatabaseMeiKey = @"Database";
        /// <summary>店舗DB用ユーザ名キー</summary>
        private const string DbUserMeiKey = @"UserID";
        /// <summary>店舗DB用パスワードキー</summary>
        private const string DbPasswordKey = @"Password";
        /// <summary>DBスキーマー（ユーザー名と同一とする）キー</summary>
        private const string DbSchemaKey = @"Schema";
        /// <summary>本部DB用ユーザ名キー</summary>
        private const string DbHonbuUserMeiKey = @"HonbuUserID";
        /// <summary>本部DB様パスワードキー</summary>
        private const string DbHonbuPasswordKey = @"HonbuPassword";
        /// <summary>薬局コードキー</summary>
        private const string YakkyokuCodeKey = @"Yakkyoku_Code";
        /// <summary>本部薬局コード（識別）キー</summary>
        private const string HonbuYakkyokuCodeKey = @"HonbuYakkyoku_Code";
        #endregion

        #region ローカル変数
        // ---------------------------------------------------------------------------------
        // ▼ 共通情報
        // ---------------------------------------------------------------------------------

        // ---------------------------------------------------------------------------------
        // ▼DB接続情報格納領域
        // ---------------------------------------------------------------------------------
        /// <summary>DBサーバー名</summary>
        private string dbServerMei;
        /// <summary>DBポート番号</summary>
        private string dbPortBango;
        /// <summary>DBデータベース名</summary>
        private string dbDatabaseMei;
        /// <summary>DBユーザ名</summary>
        private string dbUserMei;
        /// <summary>DBパスワード</summary>
        private string dbPassword;
        /// <summary>DBスキーマー</summary>
        private string dbSchema;
        /// <summary>本部DBユーザ名</summary>
        private string honbuDbUserMei;
        /// <summary>本部DBパスワード</summary>
        private string honbuDbPassword;
        /// <summary>薬局コード</summary>
        private string yakkyokuCode;
        /// <summary>本部薬局コード</summary>
        private string honbuYakkyokuCode;

        // ---------------------------------------------------------------------------------
        // ▼和暦変換関係
        // ---------------------------------------------------------------------------------
        /// <summary>和暦元号英字リスト</summary>
        private string[] warekiGengoEijiList;

        // ---------------------------------------------------------------------------------
        // ▼ローカル情報
        // ---------------------------------------------------------------------------------
        /// <summary>プログラムID</summary>
        private string programID;
        /// <summary>マシン名</summary>
        private string machineMei;
        /// <summary>プログラム固有引数(第５引数）</summary>
        private string programArgument;
        /// <summary>コマンドライン引数（全て）</summary>
        private List<string> commandlineArguments = new List<string>();

        // ---------------------------------------------------------------------------------
        // ▼カラー設定情報
        // ---------------------------------------------------------------------------------
        /// <summary>フォームカラーモード</summary>
        private FormColorPattern formColorMode;

        // ---------------------------------------------------------------------------------
        // フォームのバックアカラー設定情報
        // ---------------------------------------------------------------------------------
        /// <summary>フォームのバックアカラー設定情報 アルファ</summary>
        private int backColorAlpha;
        /// <summary>フォームのバックアカラー設定情報 レッド</summary>
        private int backColorRed;
        /// <summary>フォームのバックアカラー設定情報 グリーン</summary>
        private int backColorGreen;
        /// <summary>フォームのバックアカラー設定情報 ブルー</summary>
        private int backColorBlue;
        #endregion

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public B2Com()
        {
            // 変数クリア
            ClearData();

            // システムによる和暦制御の前処理
            CultureInfo culture = new CultureInfo("ja-JP", true);
            culture.DateTimeFormat.Calendar = new JapaneseCalendar();

            JapaneseCalendar japaneseCalendar = new JapaneseCalendar();

            // DateTimeFormatInfo の Type を取得
            Type dateTimeFormatInfoType = typeof(DateTimeFormatInfo);
            DateTimeFormatInfo dateTimeFormatInfo = culture.DateTimeFormat;
            dateTimeFormatInfo.Calendar = japaneseCalendar;

            // 和暦英語略称の内部プロパティの取得
            PropertyInfo abbreviatedEnglishEraNamesPropertyInfo = dateTimeFormatInfoType.GetProperty("AbbreviatedEnglishEraNames", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
            this.warekiGengoEijiList = (string[])abbreviatedEnglishEraNamesPropertyInfo.GetValue(dateTimeFormatInfo, null);
        }

        /// <summary>
        /// デストラクタ
        /// </summary>
        ~B2Com()
        {
            Dispose();
        }

        /// <summary>
        /// メモリ等の解放処理
        /// </summary>
        public void Dispose()
        {
            this.PgLib.Dispose();

            GC.SuppressFinalize(this);
        }

        #region プロパティ
        /// <summary>DBサーバー名</summary>
        public string DbServerMei
        {
            get { return dbServerMei; }
            set { dbServerMei = value; }
        }

        /// <summary>DBポート番号</summary>
        public string DbPortBango
        {
            get { return dbPortBango; }
            set { dbPortBango = value; }
        }

        /// <summary>DBデータベース名</summary>
        public string DbDatabaseMei
        {
            get { return dbDatabaseMei; }
            set { dbDatabaseMei = value; }
        }

        /// <summary>DBユーザ名</summary>
        public string DbUserMei
        {
            get { return dbUserMei; }
            set { dbUserMei = value; }
        }

        /// <summary>DBパスワード</summary>
        public string DbPassword
        {
            get { return dbPassword; }
            set { dbPassword = value; }
        }

        /// <summary>DBスキーマー</summary>
        public string DbSchema
        {
            get { return dbSchema; }
            set { dbSchema = value; }
        }

        /// <summary>本部DBユーザ名</summary>
        public string HonbuDbUserMei
        {
            get { return honbuDbUserMei; }
            set { honbuDbUserMei = value; }
        }

        /// <summary>本部DBパスワード</summary>
        public string HonbuDbPassword
        {
            get { return honbuDbPassword; }
            set { honbuDbPassword = value; }
        }

        /// <summary>薬局コード</summary>
        public string YakkyokuCode
        {
            get { return yakkyokuCode; }
            set { yakkyokuCode = value; }
        }

        /// <summary>本部薬局コード</summary>
        public string HonbuYakkyokuCode
        {
            get { return honbuYakkyokuCode; }
            set { honbuYakkyokuCode = value; }
        }

        /// <summary>プログラムID</summary>
        public string ProgramId
        {
            get { return programID; }
            set { programID = value; }
        }

        /// <summary>プログラム引数</summary>
        public string ProgramHikisu
        {
            get { return programArgument; }
            set { programArgument = value; }
        }
 
        /// <summary>
        /// プログラム引数
        /// </summary>
        /// <param name="lintIndex">引数の順番</param>
        /// <returns>プログラム引数</returns>
        public string GetCommandlineArgument(int lintIndex)
        {
            if(this.commandlineArguments.Count == 0)
            {
                // 引数が存在しない場合、空文字列
                return "";
            }
            if(lintIndex < 0 ||
                lintIndex > (this.commandlineArguments.Count - 1))
            {
                // 範囲外の場合、空文字列
                return "";
            }
            // 該当引数を戻す
            return this.commandlineArguments[lintIndex];
        }

        /// <summary> フォームカラーモード (FromColorPatternより設定取得) </summary>
        public FormColorPattern FormColorMode
        {
            get { return formColorMode; }
            set { formColorMode = value; }  
        }

        /// <summary> マシン名 </summary>
        public string MachineMei
        {
            get { return machineMei; }
            set { machineMei = value; }
        }

        #endregion

        /// <summary>
        /// データクリア処理
        /// </summary>
        private void ClearData()
        {
            // -----------------------------------------------------------------------------
            // string型でnullエラーにならない為に初期化を行ないます
            // -----------------------------------------------------------------------------
            // -----------------------------------------------------------------------------
            // DB接続情報
            // -----------------------------------------------------------------------------
            this.dbServerMei = "";
            this.dbPortBango = "";
            this.dbDatabaseMei = "";
            this.dbUserMei = "";
            this.dbPassword = "";
            this.dbSchema = "";

            // -----------------------------------------------------------------------------
            // ▼ローカル情報
            // -----------------------------------------------------------------------------
            this.programArgument = "";
            this.programID = Path.GetFileNameWithoutExtension(Environment.GetCommandLineArgs()[0]);
            this.machineMei = Environment.MachineName;

            // -----------------------------------------------------------------------------
            // ▼カラー設定情報
            // -----------------------------------------------------------------------------
            this.formColorMode = FormColorPattern.Normal;
        }

        /// <summary>
        /// コマンドライン情報取得処理
        /// </summary>
        /// <returns>true：正常終了 false：エラー</returns>
        public bool GetCommandLine()
        {
            // 引数にユーザID等がないときはエラー [0:EXE名、1:引数内容 2～：その他]
            // 引数の数が不一致の場合エラー [引数は５以上]

            string[] lstrCmdLines = Environment.GetCommandLineArgs();
            if (lstrCmdLines.Length < 2)
            {
                return false;
            }

            string[] lstrCmdPara = lstrCmdLines[1].Split(',');
            if (lstrCmdPara.Length < 5)
            {
                return false;
            }

            this.commandlineArguments.Clear();
            for(int lintIndex = 0; lintIndex < lstrCmdPara.Length; lintIndex++)
            {
                this.commandlineArguments.Add(lstrCmdPara[lintIndex].Trim());
            }

            return true;
        }

        /// <summary>
        /// 初期処理
        /// </summary>
        /// <param name="showErrorDialog">エラーダイアログ表示(true：エラー表示する false：エラー表示しない)</param>
        /// <returns>true：正常終了 false：エラー</returns>
        public bool Initialize(bool showErrorDialog)
        {
            if (GetDbConectInfo() == false)
            {
                if(showErrorDialog == true)
                {
                    MessageBox.Show("DB接続情報の取得に失敗しました。" + Environment.NewLine + "プログラムを終了します。",
                                    "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return false;
            }

            GetColorIni();

            return true;
        }

        /// <summary>
        /// バックカラー設定処理
        /// </summary>
        /// <param name="frm">バックカラーを設定するフォーム</param>
        public void SetBackColor(Form frm)
        {
            frm.BackColor = Color.FromArgb(this.backColorRed, this.backColorGreen, this.backColorBlue);
            SetControlStyle(frm);
        }

        /// <summary>
        /// コントロールスタイル設定処理
        /// </summary>
        /// <param name="pctrl">スタイル設定するコントロール</param>
        private void SetControlStyle(Control pctrl)
        {
            Color lobjDefaultBackColor = Color.FromArgb(this.backColorRed, this.backColorGreen, this.backColorBlue);
            Color lobjDefaultForeColor = Color.DimGray;

            foreach (Control c in pctrl.Controls)
            {
                if (c.Name != "")
                {
                    // 色情報初期化
                    // 背景色"BackColor"が設定されているように見えても、親クラスの値の可能性がある為再設定必要
                    c.BackColor = c.BackColor;
                    c.ForeColor = lobjDefaultForeColor;

                    // スタイル設定
                    if (c is TextBox)
                    {
                        ((TextBox)c).BorderStyle = BorderStyle.FixedSingle;
                    }
                    else if (c is RichTextBox)
                    {
                        ((RichTextBox)c).BorderStyle = BorderStyle.FixedSingle;
                    }
                    else if (c is ListBox)
                    {
                        ((ListBox)c).BorderStyle = BorderStyle.FixedSingle;
                    }
                    else if (c is ComboBox)
                    {
                        ((ComboBox)c).FlatStyle = FlatStyle.Flat;
                    }
                    else if (c is Label)
                    {
                        // 背景色
                        if (0 < c.Name.ToUpper().IndexOf("GAID"))
                        {
                            // ガイダンス
                            c.BackColor = SystemColors.ButtonFace;
                        }
                        else if (0 < c.Name.ToUpper().IndexOf("TIME"))
                        {
                            // 時計
                            c.BackColor = SystemColors.ButtonFace;
                        }
                        else if (c.BackColor == SystemColors.Control)
                        {
                            c.BackColor = lobjDefaultBackColor;
                        }

                        // 境界線
                        switch (((Label)c).BorderStyle)
                        {   
                            case BorderStyle.None:
                                // 境界線なし
                                ((Label)c).BorderStyle = BorderStyle.None;
                                break;
                            default:
                                // 境界線あり
                                ((Label)c).BorderStyle = BorderStyle.FixedSingle;

                                // テキストの縦位置：上詰め→中央揃え
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
                        c.BackColor = SystemColors.ButtonFace;
                        ((Button)c).FlatStyle = FlatStyle.Flat;
                    }
                    else
                    {
                        // その他コントロール
                        if (c.BackColor == SystemColors.Control)
                        {
                            c.BackColor = lobjDefaultBackColor;
                        }
                    }

                    // すべてのコントロールを設定するため再帰呼び出し
                    SetControlStyle(c);
                }
            }
        }

        //**********************************************************************
        /// <summary>
        /// 対象コントロール下の全コントロール取得
        /// </summary>
        /// <param name="pControl">対象コントロール</param>
        /// <returns>全コントロール郡</returns>
        //**********************************************************************
        public List<Control> GetAllControls(Control pControl)
        {
            List<Control> lControlR = new List<Control>();
            foreach (Control lControl in pControl.Controls)
            {
                lControlR.Add(lControl);
                lControlR.AddRange(GetAllControls(lControl));
            }
            return lControlR;
        }

        /// <summary>
        /// DB接続処理
        /// </summary>
        /// <param name="showErrorDialog">エラーダイアログ表示(true：表示する false：表示しない)</param>
        /// <returns>true：正常終了 false：エラー</returns>
        public bool InitDb(bool showErrorDialog)
        {
            if (ConnectDB() == false)
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

        /// <summary>
        /// DB切断処理
        /// </summary>
        public void CloseDb()
        {
            this.PgLib.DisConnect();
        }

        /// <summary>
        /// DB接続情報の取得
        /// </summary>
        /// <returns>true：正常終了 false：エラー</returns>
        private bool GetDbConectInfo()
        {
            try
            {
                // 取得出来なかった時はEmptyがセットされます。
                this.dbServerMei = RegistryControler.GetRegistry(B2Com.B2Registrykey, B2Com.DbServerMeiKey);
                this.dbPortBango = RegistryControler.GetRegistry(B2Com.B2Registrykey, B2Com.DbPortBangoKey);
                this.dbDatabaseMei = RegistryControler.GetRegistry(B2Com.B2Registrykey, B2Com.DbDatabaseMeiKey);
                this.dbUserMei = RegistryControler.GetRegistry(B2Com.B2Registrykey, B2Com.DbUserMeiKey);
                this.dbPassword = RegistryControler.GetRegistry(B2Com.B2Registrykey, B2Com.DbPasswordKey);
                this.dbSchema = RegistryControler.GetRegistry(B2Com.B2Registrykey, B2Com.DbSchemaKey);
                this.honbuDbUserMei = RegistryControler.GetRegistry(B2Com.B2Registrykey, B2Com.DbHonbuUserMeiKey);
                this.honbuDbPassword = RegistryControler.GetRegistry(B2Com.B2Registrykey, B2Com.DbHonbuPasswordKey);
                this.yakkyokuCode = RegistryControler.GetRegistry(B2Com.B2Registrykey, B2Com.YakkyokuCodeKey);
                this.honbuYakkyokuCode = RegistryControler.GetRegistry(B2Com.B2Registrykey, B2Com.HonbuYakkyokuCodeKey);

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// COLOR情報の取得
        /// </summary>
        /// <returns>true：正常終了 false：エラー</returns>
        private bool GetColorIni()
        {
            try
            {
                string strcolor = GetINIData("B2COM", "FORM", "COLOR", "&HFFEEF1ED");
                if (strcolor == null)
                {
                    // INIファイルの設定がないときはデフォルトカラーをセット
                    this.backColorAlpha = int.Parse("000000FF", NumberStyles.HexNumber);
                    this.backColorRed = int.Parse("000000EE", NumberStyles.HexNumber);
                    this.backColorGreen = int.Parse("000000F1", NumberStyles.HexNumber);
                    this.backColorBlue = int.Parse("000000ED", NumberStyles.HexNumber);
                }
                else
                {
                    string bk_alpha = string.Empty;
                    string bk_red = string.Empty;
                    string bk_green = string.Empty;
                    string bk_blue = string.Empty;
                    switch (strcolor.Length)
                    {
                        case 8:
                            if (strcolor.Substring(0, 2) == "&H")
                            {
                                bk_alpha = "FF";
                                bk_red = strcolor.Substring(2, 2);
                                bk_green = strcolor.Substring(4, 2);
                                bk_blue = strcolor.Substring(6, 2);
                            }
                            break;
                        case 10:
                            if (strcolor.Substring(0, 2) == "&H")
                            {
                                bk_alpha = strcolor.Substring(2, 2);
                                if (bk_alpha == "00") bk_alpha = "FF";
                                bk_red = strcolor.Substring(4, 2);
                                bk_green = strcolor.Substring(6, 2);
                                bk_blue = strcolor.Substring(8, 2);
                            }
                            break;
                        default:
                            // デフォルトカラーをセット
                            bk_alpha = "FF";
                            bk_red = "EE";
                            bk_green = "F1";
                            bk_blue = "ED";
                            break;
                    }

                    this.backColorAlpha = int.Parse(bk_alpha, NumberStyles.HexNumber);
                    this.backColorRed = int.Parse(bk_red, NumberStyles.HexNumber);
                    this.backColorGreen = int.Parse(bk_green, NumberStyles.HexNumber);
                    this.backColorBlue = int.Parse(bk_blue, NumberStyles.HexNumber);
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// DB接続
        /// </summary>
        /// <returns>true：正常終了 false：エラー</returns>
        private bool ConnectDB()
        {
            try
            {
                return this.PgLib.Connect(this.dbServerMei, this.dbPortBango, this.dbUserMei, this.dbPassword, this.dbDatabaseMei, this.dbSchema);
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

        /// <summary>
        /// エラーメッセージ表示処理
        /// </summary>
        /// <param name="errorException">エラー内容</param>
        public void ShowErrMsg(Exception errorException)
        {
            StringBuilder lstrMsg = new StringBuilder();

            lstrMsg.Remove(0, lstrMsg.Length);
            lstrMsg.Append("エラーが発生しました。\n");
            lstrMsg.Append("\n[エラータイプ]\n");
            lstrMsg.Append(errorException.GetType().ToString());
            lstrMsg.Append("\n[メッセージ]\n");
            lstrMsg.Append(errorException.Message);
            lstrMsg.Append("\n[StackTrace]\n");
            lstrMsg.Append(errorException.StackTrace);
            MessageBox.Show(lstrMsg.ToString(),
                             this.programID,
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Error);
        }

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

        /// <summary> 
        /// ログ出力
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
                this.PgLib.Sql.Clear();
                this.PgLib.Sql.AppendLine("insert into log_data");
                this.PgLib.Sql.AppendLine(" (yakkyoku_code, logdate, program_code, bunrui, client, ");
                this.PgLib.Sql.AppendLine("  login_code,  bikou) ");
                this.PgLib.Sql.AppendLine(" VALUES(");
                this.PgLib.Sql.AppendLine("'" + this.yakkyokuCode + "',");
                this.PgLib.Sql.AppendLine("current_timestamp,");
                this.PgLib.Sql.AppendLine("'" + this.programID + "',");
                this.PgLib.Sql.AppendLine("'" + bunruiCode + "',");
                this.PgLib.Sql.AppendLine("'" + this.machineMei + "',");
                this.PgLib.Sql.AppendLine("'" + loginCode.Substring(loginCode.Length - 8, 8) + "',");
                this.PgLib.Sql.AppendLine("'" + bikou + "')");
                if (this.PgLib.ExecuteSqlNoErr(this.PgLib.Sql.ToString()) != -1)
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
            lstrSQL.AppendLine("SELECT ");
            lstrSQL.AppendLine("       data");
            lstrSQL.AppendLine("  FROM ini_master");
            lstrSQL.AppendLine(" WHERE yakkyoku_code = '" + this.yakkyokuCode + "'");
            lstrSQL.AppendLine("   AND program = '" + pgName + "'");
            lstrSQL.AppendLine("   AND section = '" + section + "'");
            lstrSQL.AppendLine("   AND keycode = '" + key + "'");

            NpgsqlDataReader reader = this.PgLib.SelectSql_NoCache(lstrSQL.ToString());
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

        //**********************************************************************
        /// <summary>
        /// DBテーブル有無確認
        /// </summary>
        /// <param name="pTableName">テーブル名称</param>
        /// <returns>true:有 false:無</returns>
        //**********************************************************************
        public bool ExistsTable(string pTableName)
        {
            try
            {
                //------------------
                // SQL作成
                //------------------
                this.PgLib.Sql.Clear();
                this.PgLib.Sql.Append("\r\n select count(*) as cnt ");
                this.PgLib.Sql.Append("\r\n   from pg_stat_user_tables ");
                this.PgLib.Sql.Append("\r\n  where lower(schemaname) = lower(session_user) ");
                this.PgLib.Sql.Append("\r\n    and lower(relname)    = lower('" + pTableName.Replace("'", "''") + "') ");
                //------------------
                // SQL実行
                //------------------
                NpgsqlDataAdapter lNpgsqlDataAdapter = new NpgsqlDataAdapter(this.PgLib.Sql.ToString(), this.PgLib.Connection);
                //------------------
                // 結果をDataSetへ
                //------------------
                DataSet lDataSet = new DataSet();
                lNpgsqlDataAdapter.Fill(lDataSet, "ExistsTable");
                //------------------
                // 結果確認
                //------------------
                if (lDataSet.Tables[0].Rows[0].ItemArray[0].ToString() == "0")
                {
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                this.ShowErrMsg(ex);
                return false;
            }
        }
    }
}
