using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;


namespace B2.Com
{
    class clsOracle
    /// <summary>
    /// ORACLE操作用クラス
    /// </summary>
    public class clsORALib : IDisposable
    {
        #region 変数宣言
        /// <summary>破棄状況(true：破棄済み false：破棄されていない)</summary>
        private bool disposed;

        /// <summary>接続情報</summary>
        private OracleConnection ORA_Session = new OracleConnection();
        /// <summary>実行コマンド情報</summary>
        private OracleCommand ORA_Command = new OracleCommand();
        /// <summary>トランザクション情報</summary>
        private OracleTransaction ORA_Trans;

        /// <summary>接続ユーザ名</summary>
        private string ORA_UserName;
        /// <summary>接続パスワード</summary>
        private string ORA_Password;
        /// <summary>接続先データベース</summary>
        private string ORA_Database;
        /// <summary>プーリング区分(true：接続のプーリングをする false：しない)</summary>
        private bool ORA_Pooling;

        /// <summary>SQL文字列</summary>
        private StringBuilder ORA_SQL = new StringBuilder();

        /// <summary>接続状況(true：接続中 false：未接続)</summary>
        private bool ORA_IsConnection;
        /// <summary>トランザクション状況(true：トランザクション中 false：それ以外)</summary>
        private bool ORA_IsBeginTrans;

        /// <summary>Oracleエラーコード</summary>
        private int ORA_LastErrorCode;
        /// <summary>Oracleエラーメッセージ</summary>
        private string ORA_LastError;

        /// <summary>リトライ回数</summary>
        private int retryCount;
        #endregion

        /// <summary>
        /// ★コンストラクタ
        /// </summary>
        public clsORALib()
        {
            ORA_UserName = "";
            ORA_Password = "";
            ORA_Database = "";
            ORA_Pooling = false;

            SQLClear();
            ORA_LastErrorCode = 0;
            ORA_LastError = "";

            ORA_IsConnection = false;
            ORA_IsBeginTrans = false;

            disposed = false;
          

            retryCount = 5;
        }

        /// <summary>
        /// ★デストラクタ
        /// </summary>
        ~clsORALib()
        {
            Dispose();
        }

        /// <summary>
        /// 解放処理
        /// </summary>
        public void Dispose()
        {
            //まだDisposeが行われていないなら処理
            if(!this.disposed)
            {
                //以降、解放処理
                DisConnect();

                if(ORA_Trans != null)
                {
                    ORA_Trans.Dispose();
                }

                if(ORA_Command != null)
                {
                    ORA_Command.Dispose();
                }

                if(ORA_Session != null)
                {
                    ORA_Session.Dispose();
                }
            }

            disposed = true;

            GC.SuppressFinalize(this);
        }

        #region プロパティ
        //▼プロパティ(R/W)
        /// <summary>★接続ユーザ名</summary>
        public string UserName
        {
            get { return ORA_UserName; }
            set { ORA_UserName = value; }
        }

        /// <summary>★接続パスワード</summary>
        public string Password
        {
            get { return ORA_Password; }
            set { ORA_Password = value; }
        }

        /// <summary>★接続先データベース</summary>
        public string Database
        {
            get { return ORA_Database; }
            set { ORA_Database = value; }
        }

        /// <summary>★接続先データベース</summary>
        public bool Pooling
        {
            get { return ORA_Pooling; }
            set { ORA_Pooling = value; }
        }

        /// <summary>★SQL文字列</summary>
        public StringBuilder SQL
        {
            get { return ORA_SQL; }
            set { ORA_SQL = value; }
        }

        /// <summary>リトライ回数</summary>
        public int RetryCount
        {
            set
            {
                if(0 < value)
                    retryCount = value;
                else
                    retryCount = 1;
            }
            get { return retryCount; }
        }

        //▼プロパティ(R)
        /// <summary>★接続状況表示</summary>
        public bool IsConnect
        {
            get { return ORA_IsConnection; }
        }

        /// <summary>★最後に起きたエラーコード</summary>
        public int LastErrorCode
        {
            get { return ORA_LastErrorCode; }
        }

        /// <summary>★最後に起きたエラー</summary>
        public string LastError
        {
            get { return ORA_LastError; }
        }

        /// <summary>ORACLEコネクション</summary>
        public OracleConnection Session
        {
            get { return ORA_Session; }
        }

        /// <summary>ORALCEコマンド</summary>
        public OracleCommand Command
        {
            get { return ORA_Command; }
        }
        #endregion

        #region 接続関連
        /// <summary>
        /// ★Oracle接続
        /// </summary>
        /// <param name="userName">ユーザ名</param>
        /// <param name="password">パスワード</param>
        /// <param name="database">データベース</param>
        /// <param name="pooling">接続プーリング区分(true：接続プーリングする false：しない)</param>
        /// <returns>true：正常終了 false：エラー</returns>
        public bool Connect(string userName, string password, string database, bool pooling)
        {
            StringBuilder wkConnect = new StringBuilder();

            for(int count = 1; count <= retryCount; count++)
            {
                try
                {
                    //◆接続済みの場合、事前にClose
                    if(ORA_IsConnection)
                    {
                        DisConnect();
                    }

                    //■接続
                    wkConnect.Remove(0, wkConnect.Length);
                    wkConnect.Append("User ID=");
                    wkConnect.Append(userName);
                    wkConnect.Append(";Password=");
                    wkConnect.Append(password);
                    wkConnect.Append(";Data Source=");
                    wkConnect.Append(database);
                    wkConnect.Append(";Pooling=");
                    wkConnect.Append(pooling.ToString());

                    ORA_Session.ConnectionString = wkConnect.ToString();
                    ORA_Session.Open();

                    ORA_Command.Connection = ORA_Session;

                    //プロパティの更新
                    ORA_UserName = userName;
                    ORA_Password = password;
                    ORA_Database = database;
                    ORA_Pooling = pooling;

                    SQLClear();

                    ORA_IsConnection = true;

                    return true;
                }
                catch(OracleException ex)
                {
                    ORA_LastErrorCode = ex.Number;
                    ORA_LastError = ex.ToString();
                    // 接続エラーのときだけリトライする
                    if(IsConnectError())
                    {
                        // リトライ回数が終わったときだけメッセージを表示
                        if(count == retryCount)
                            ShowOraErrMsg(ex);
                    }
                    else
                    {
                        // 接続エラー以外はリトライしない
                        ShowOraErrMsg(ex);
                        break;
                    }
                }
                catch(Exception ex)
                {
                    // 接続エラー以外はリトライしない
                    ORA_LastErrorCode = -1;
                    ORA_LastError = ex.ToString();
                    ShowOraErrMsg(ex);
                    break;
                }
            }

            return false;
        }

        //接続文字列を返す　2017-05-01
        public string strConnect()
        {
            StringBuilder wkConnect = new StringBuilder();

            //■接続 文字列の作成
            wkConnect.Remove(0, wkConnect.Length);
            wkConnect.Append("User ID=");
            wkConnect.Append(ORA_UserName);
            wkConnect.Append(";Password=");
            wkConnect.Append(ORA_Password);
            wkConnect.Append(";Data Source=");
            wkConnect.Append(ORA_Database);
            wkConnect.Append(";Pooling=");
            wkConnect.Append(ORA_Pooling.ToString());

            return wkConnect.ToString();
        }

        /// <summary>
        /// ★Oracle接続
        /// ユーザ名などはINIファイルを参照
        /// </summary>
        /// <returns>true：正常終了 false：エラー</returns>
        public bool Connect()
        {
            return Connect(ORA_UserName, ORA_Password, ORA_Database, ORA_Pooling);
        }

        /// <summary>
        /// ★Oracke接続
        /// 接続プーリングを使用して接続する
        /// </summary>
        /// <param name="userName">ユーザ名</param>
        /// <param name="password">パスワード</param>
        /// <param name="database">データベース</param>
        /// <returns>true：正常終了 false：エラー</returns>
        public bool Connect(string userName, string password, string database)
        {
            return Connect(userName, password, database, true);
        }

        /// <summary>
        /// ★切断
        /// </summary>
        /// <returns>true：正常終了 false：エラー</returns>
        public bool DisConnect()
        {
            try
            {
                //◆トランザクションが終了していないならCOMMIT
                if(ORA_IsBeginTrans)
                {
                    CommitTransaction();
                }

                //■切断
                if(ORA_IsConnection)
                {
                    ORA_Session.Close();
                    ORA_Command.Connection = null;
                    ORA_IsConnection = false;
                }

                SQLClear();

                return true;
            }
            catch(OracleException ex)
            {
                ORA_LastErrorCode = ex.Number;
                ORA_LastError = ex.ToString();
                ShowOraErrMsg(ex);

                return false;
            }
            catch(Exception ex)
            {
                ORA_LastErrorCode = -1;
                ORA_LastError = ex.ToString();
                ShowOraErrMsg(ex);
                return false;
            }
        }
        #endregion

        /// <summary>
        /// ★Select(接続型)
        /// </summary>
        /// <param name="selectSQL">SQL文字列</param>
        /// <returns>データリーダオブジェクト(エラーのときはnull)</returns>
        public OracleDataReader SelectSQL_NoCache(string selectSQL)
        {
            try
            {
                if(ORA_IsConnection)
                {
                    ORA_Command.CommandText = selectSQL;
                    SQLClear();
                    ORA_SQL.Append(selectSQL);

                    return ORA_Command.ExecuteReader();
                }
            }
            catch(OracleException ex)
            {
                ORA_LastErrorCode = ex.Number;
                ORA_LastError = ex.ToString();
                // 接続エラーのときだけリトライする
                if(IsConnectError())
                {
                    // 2013/03/20 @B2 ADD START --- [回線再接続時のエラー減]
                    //ORA_IsBeginTrans = false;
                    //ORA_Trans.Dispose();            // 2007/11/01 ADD
                    //ORA_Trans = null;               // 2007/11/01 ADD
                    //ORA_IsConnection = false;
                    // 2013/03/20 @B2 ADD END   --- [回線再接続時のエラー減]
                    // 再度接続を試みてからもう一度SQLを実行
                    if(Connect())
                    {
                        try
                        {
                            // 2013/03/20 @B2 ADD START --- [回線再接続時にログ出力]
                            WriteSysLog("50", "", "回線再接続:SelectSQL_NoCache");
                            // 2013/03/20 @B2 ADD END   --- [回線再接続時にログ出力]
                            ORA_Command.CommandText = selectSQL;
                            SQLClear();
                            ORA_SQL.Append(selectSQL);
                            return ORA_Command.ExecuteReader();
                        }
                        catch(Exception e)
                        {
                            // 再接続後のエラーはリトライしない
                            ORA_LastErrorCode = -1;
                            ORA_LastError = e.ToString();
                            ShowOraErrMsg(e);
                        }
                    }
                    ORA_IsConnection = true;
                }
                else
                    ShowOraErrMsg(ex);
            }
            catch(InvalidOperationException ex)
            {
                ORA_LastErrorCode = -1;
                ORA_LastError = ex.ToString();
                // 2013/03/20 @B2 ADD START --- [回線再接続時のエラー減]
                //ORA_IsBeginTrans = false;
                //ORA_Trans.Dispose();            // 2007/11/01 ADD
                //ORA_Trans = null;               // 2007/11/01 ADD
                //ORA_IsConnection = false;
                // 2013/03/20 @B2 ADD END   --- [回線再接続時のエラー減]
                // 接続関連のエラー時のみ再接続してリトライ
                if(IsConnectError(ORA_LastError) && Connect())
                {
                    try
                    {
                        // 2013/03/20 @B2 ADD START --- [回線再接続時にログ出力]
                        WriteSysLog("50", "", "回線再接続:SelectSQL_NoCache");
                        // 2013/03/20 @B2 ADD END   --- [回線再接続時にログ出力]
                        ORA_Command.CommandText = selectSQL;
                        SQLClear();
                        ORA_SQL.Append(selectSQL);
                        return ORA_Command.ExecuteReader();
                    }
                    catch(Exception e)
                    {
                        // 再接続後のエラーはリトライしない
                        ORA_LastErrorCode = -1;
                        ORA_LastError = e.ToString();
                        ShowOraErrMsg(e);
                    }
                }
                else
                    ShowOraErrMsg(ex);
                ORA_IsConnection = true;
            }
            catch(Exception ex)
            {
                ORA_LastErrorCode = -1;
                ORA_LastError = ex.ToString();
                ShowOraErrMsg(ex);
            }

            return null;
        }

        /// <summary>
        /// ★Select(接続型)
        /// SQLに設定されたSQL文字列を実行
        /// </summary>
        /// <returns>データリーダオブジェクト(エラーのときはnull)</returns>
        public OracleDataReader SelectSQL_NoCache()
        {
            return SelectSQL_NoCache(ORA_SQL.ToString());
        }

        /// <summary>
        /// ★Select(非接続型)
        /// </summary>
        /// <param name="selectSQL">SQL文字列</param>
        /// <returns>データアダプタオブジェクト(エラーのときはnull)</returns>
        public OracleDataAdapter SelectSQL(string selectSQL)
        {
            try
            {
                if(ORA_IsConnection)
                {
                    ORA_Command.CommandText = selectSQL;
                    SQLClear();
                    ORA_SQL.Append(selectSQL);

                    return new OracleDataAdapter(ORA_Command);
                }
            }
            catch(OracleException ex)
            {
                ORA_LastErrorCode = ex.Number;
                ORA_LastError = ex.ToString();
                // 接続エラーのときだけリトライする
                if(IsConnectError())
                {
                    // 2013/03/20 @B2 ADD START --- [回線再接続時のエラー減]
                    //ORA_IsBeginTrans = false;
                    //ORA_Trans.Dispose();            // 2007/11/01 ADD
                    //ORA_Trans = null;               // 2007/11/01 ADD
                    //ORA_IsConnection = false;
                    // 2013/03/20 @B2 ADD END   --- [回線再接続時のエラー減]
                    // 再度接続を試みてからもう一度SQLを実行
                    if(Connect())
                    {
                        try
                        {
                            // 2013/03/20 @B2 ADD START --- [回線再接続時にログ出力]
                            WriteSysLog("50", "", "回線再接続:SelectSQL");
                            // 2013/03/20 @B2 ADD END   --- [回線再接続時にログ出力]
                            ORA_Command.CommandText = selectSQL;
                            SQLClear();
                            ORA_SQL.Append(selectSQL);
                            return new OracleDataAdapter(ORA_Command);
                        }
                        catch(Exception e)
                        {
                            // 再接続後のエラーはリトライしない
                            ORA_LastErrorCode = -1;
                            ORA_LastError = e.ToString();
                            ShowOraErrMsg(e);
                        }
                    }
                    ORA_IsConnection = true;
                }
                else
                    ShowOraErrMsg(ex);
            }
            catch(InvalidOperationException ex)
            {
                ORA_LastErrorCode = -1;
                ORA_LastError = ex.ToString();
                // 2013/03/20 @B2 ADD START --- [回線再接続時のエラー減]
                //ORA_IsBeginTrans = false;
                //ORA_Trans.Dispose();            // 2007/11/01 ADD
                //ORA_Trans = null;               // 2007/11/01 ADD
                //ORA_IsConnection = false;
                // 2013/03/20 @B2 ADD END   --- [回線再接続時のエラー減]
                // 接続関連のエラー時のみ再接続してリトライ
                if(IsConnectError(ORA_LastError) && Connect())
                {
                    try
                    {
                        // 2013/03/20 @B2 ADD START --- [回線再接続時にログ出力]
                        WriteSysLog("50", "", "回線再接続:SelectSQL");
                        // 2013/03/20 @B2 ADD END   --- [回線再接続時にログ出力]
                        ORA_Command.CommandText = selectSQL;
                        SQLClear();
                        ORA_SQL.Append(selectSQL);
                        return new OracleDataAdapter(ORA_Command);
                    }
                    catch(Exception e)
                    {
                        // 再接続後のエラーはリトライしない
                        ORA_LastErrorCode = -1;
                        ORA_LastError = e.ToString();
                        ShowOraErrMsg(e);
                    }
                }
                else
                    ShowOraErrMsg(ex);
                ORA_IsConnection = true;
            }
            catch(Exception ex)
            {
                ORA_LastErrorCode = -1;
                ORA_LastError = ex.ToString();
                ShowOraErrMsg(ex);
            }

            return null;
        }

        /// <summary>
        /// ★Select(非接続型)
        /// SQLに設定されたSQL文字列を実行
        /// </summary>
        /// <returns>データアダプタオブジェクト(エラーのときはnull)</returns>
        public OracleDataAdapter SelectSQL()
        {
            return SelectSQL(ORA_SQL.ToString());
        }

        /// <summary>
        /// ★SQL実行(接続型)
        /// </summary>
        /// <param name="execSQL">SQL文字列</param>
        /// <returns>処理件数(エラーのときは-1)</returns>
        public int ExecuteSQL(string execSQL)
        {
            try
            {
                if(ORA_IsConnection)
                {
                    ORA_Command.CommandText = execSQL;
                    SQLClear();
                    ORA_SQL.Append(execSQL);

                    int rows = ORA_Command.ExecuteNonQuery();
                    if(rows < 0)               // 件数を戻さない場合-1になるので補正
                    {
                        rows = 0;
                    }
                    return rows;
                }
            }
            catch(OracleException ex)
            {
                ORA_LastErrorCode = ex.Number;
                ORA_LastError = ex.ToString();
                // 接続エラーのときだけリトライする
                if(IsConnectError())
                {
                    // 2013/03/20 @B2 ADD START --- [回線再接続時のエラー減]
                    //ORA_IsBeginTrans = false;
                    //ORA_Trans.Dispose();            // 2007/11/01 ADD
                    //ORA_Trans = null;               // 2007/11/01 ADD
                    //ORA_IsConnection = false;
                    // 2013/03/20 @B2 ADD END   --- [回線再接続時のエラー減]
                    // 再度接続を試みてからもう一度SQLを実行
                    if(Connect())
                    {
                        try
                        {
                            // 2013/03/20 @B2 ADD START --- [回線再接続時にログ出力]
                            WriteSysLog("50", "", "回線再接続:ExecuteSQL");
                            // 2013/03/20 @B2 ADD END   --- [回線再接続時にログ出力]
                            ORA_Command.CommandText = execSQL;
                            SQLClear();
                            ORA_SQL.Append(execSQL);
                            int count = ORA_Command.ExecuteNonQuery();
                            // 件数を戻さない場合-1になるので補正
                            if(count < 0)
                                count = 0;
                            return count;
                        }
                        catch(Exception e)
                        {
                            // 再接続後のエラーはリトライしない
                            ORA_LastErrorCode = -1;
                            ORA_LastError = e.ToString();
                            ShowOraErrMsg(e);
                        }
                    }
                    ORA_IsConnection = true;
                }
                else
                    ShowOraErrMsg(ex);
            }
            catch(InvalidOperationException ex)
            {
                ORA_LastErrorCode = -1;
                ORA_LastError = ex.ToString();
                // 2013/03/20 @B2 ADD START --- [回線再接続時のエラー減]
                //ORA_IsBeginTrans = false;
                //ORA_Trans.Dispose();            // 2007/11/01 ADD
                //ORA_Trans = null;               // 2007/11/01 ADD
                //ORA_IsConnection = false;
                // 2013/03/20 @B2 ADD END   --- [回線再接続時のエラー減]
                // 接続関連のエラー時のみ再接続してリトライ
                if(IsConnectError(ORA_LastError) && Connect())
                {
                    try
                    {
                        // 2013/03/20 @B2 ADD START --- [回線再接続時にログ出力]
                        WriteSysLog("50", "", "回線再接続:ExecuteSQL");
                        // 2013/03/20 @B2 ADD END   --- [回線再接続時にログ出力]
                        ORA_Command.CommandText = execSQL;
                        SQLClear();
                        ORA_SQL.Append(execSQL);
                        int count = ORA_Command.ExecuteNonQuery();
                        // 件数を戻さない場合-1になるので補正
                        if(count < 0)
                            count = 0;
                        return count;
                    }
                    catch(Exception e)
                    {
                        // 再接続後のエラーはリトライしない
                        ORA_LastErrorCode = -1;
                        ORA_LastError = e.ToString();
                        ShowOraErrMsg(e);
                    }
                }
                else
                    ShowOraErrMsg(ex);
                ORA_IsConnection = true;
            }
            catch(Exception ex)
            {
                ORA_LastErrorCode = -1;
                ORA_LastError = ex.ToString();
                ShowOraErrMsg(ex);
            }

            return -1;
        }

        /// <summary>
        /// ★SQL実行(接続型)
        /// SQLに設定されたSQL文字列を実行
        /// </summary>
        /// <returns>処理件数(エラーのときは-1)</returns>
        public int ExecuteSQL()
        {
            return ExecuteSQL(ORA_SQL.ToString());
        }

        /// <summary>
        /// ★SQL実行(接続型) エラーメッセージを表示しないでthrowする。
        /// </summary>
        /// <param name="execSQL">SQL文字列</param>
        /// <returns>処理件数(エラーのときは-1)</returns>
        public int ExecuteSQLNoErr(string execSQL)
        {
            try
            {
                if(ORA_IsConnection)
                {
                    ORA_Command.CommandText = execSQL;
                    SQLClear();
                    ORA_SQL.Append(execSQL);

                    int rows = ORA_Command.ExecuteNonQuery();
                    if(rows < 0)               // 件数を戻さない場合-1になるので補正
                    {
                        rows = 0;
                    }
                    return rows;
                }
            }
            catch(OracleException ex)
            {
                ORA_LastErrorCode = ex.Number;
                ORA_LastError = ex.ToString();
                // 接続エラーのときだけリトライする
                if(IsConnectError())
                {
                    // 2013/03/20 @B2 ADD START --- [回線再接続時のエラー減]
                    //ORA_IsBeginTrans = false;
                    //ORA_Trans.Dispose();            // 2007/11/01 ADD
                    //ORA_Trans = null;               // 2007/11/01 ADD
                    //ORA_IsConnection = false;
                    // 2013/03/20 @B2 ADD END   --- [回線再接続時のエラー減]
                    // 再度接続を試みてからもう一度SQLを実行
                    if(Connect())
                    {
                        try
                        {
                            // 2013/03/20 @B2 ADD START --- [回線再接続時にログ出力]
                            WriteSysLog("50", "", "回線再接続:ExecuteSQLNoErr");
                            // 2013/03/20 @B2 ADD END   --- [回線再接続時にログ出力]
                            ORA_Command.CommandText = execSQL;
                            SQLClear();
                            ORA_SQL.Append(execSQL);
                            int count = ORA_Command.ExecuteNonQuery();
                            // 件数を戻さない場合-1になるので補正
                            if(count < 0)
                                count = 0;
                            return count;
                        }
                        catch(Exception e)
                        {
                            // 再接続後のエラーはリトライしない
                            ORA_LastErrorCode = -1;
                            ORA_LastError = e.ToString();
                            throw e;
                        }
                    }
                    ORA_IsConnection = true;
                }
                else
                    throw ex;
            }
            catch(InvalidOperationException ex)
            {
                ORA_LastErrorCode = -1;
                ORA_LastError = ex.ToString();
                // 2013/03/20 @B2 ADD START --- [回線再接続時のエラー減]
                //ORA_IsBeginTrans = false;
                //ORA_Trans.Dispose();            // 2007/11/01 ADD
                //ORA_Trans = null;               // 2007/11/01 ADD
                //ORA_IsConnection = false;
                // 2013/03/20 @B2 ADD END   --- [回線再接続時のエラー減]
                // 接続関連のエラー時のみ再接続してリトライ
                if(IsConnectError(ORA_LastError) && Connect())
                {
                    try
                    {
                        // 2013/03/20 @B2 ADD START --- [回線再接続時にログ出力]
                        WriteSysLog("50", "", "回線再接続:ExecuteSQLNoErr");
                        // 2013/03/20 @B2 ADD END   --- [回線再接続時にログ出力]
                        ORA_Command.CommandText = execSQL;
                        SQLClear();
                        ORA_SQL.Append(execSQL);
                        int count = ORA_Command.ExecuteNonQuery();
                        // 件数を戻さない場合-1になるので補正
                        if(count < 0)
                            count = 0;
                        return count;
                    }
                    catch(Exception e)
                    {
                        // 再接続後のエラーはリトライしない
                        ORA_LastErrorCode = -1;
                        ORA_LastError = e.ToString();
                        ORA_IsConnection = true;
                        throw e;
                    }
                }
                else
                {
                    ORA_IsConnection = true;
                    throw ex;
                }
            }
            catch(Exception ex)
            {
                ORA_LastErrorCode = -1;
                ORA_LastError = ex.ToString();
                throw ex;
            }
            return -1;
        }


        /// <summary>
        /// ★トランザクションの開始
        /// </summary>
        /// <returns>true：正常終了 false：エラー</returns>
        public bool BeginTransaction()
        {
            try
            {
                if(ORA_IsConnection && !ORA_IsBeginTrans)
                {
                    ORA_Trans = ORA_Session.BeginTransaction();
                    ORA_IsBeginTrans = true;
                    return true;
                }
            }
            catch(OracleException ex)
            {
                ORA_LastErrorCode = ex.Number;
                ORA_LastError = ex.ToString();
                ShowOraErrMsg(ex);
            }
            catch(Exception ex)
            {
                ORA_LastErrorCode = -1;
                ORA_LastError = ex.ToString();
                ShowOraErrMsg(ex);
            }

            return false;
        }

        /// <summary>
        /// ★コミット
        /// </summary>
        /// <returns>true：正常終了 false：エラー</returns>
        public bool CommitTransaction()
        {
            try
            {
                if(ORA_IsConnection && ORA_IsBeginTrans && ORA_Trans != null)
                {
                    ORA_Trans.Commit();
                    ORA_IsBeginTrans = false;
                    ORA_Trans.Dispose();            // 2007/11/01 ADD
                    ORA_Trans = null;               // 2007/11/01 ADD
                    return true;
                }
            }
            catch(OracleException ex)
            {
                ORA_LastErrorCode = ex.Number;
                ORA_LastError = ex.ToString();
                ShowOraErrMsg(ex);
            }
            catch(Exception ex)
            {
                ORA_LastErrorCode = -1;
                ORA_LastError = ex.ToString();
                ShowOraErrMsg(ex);
            }

            return false;
        }

        /// <summary>
        /// ★ロールバック
        /// </summary>
        /// <returns>true：正常終了 false：エラー</returns>
        public bool RollbackTransaction()
        {
            try
            {
                if(ORA_IsConnection && ORA_IsBeginTrans && ORA_Trans != null)
                {
                    ORA_Trans.Rollback();
                    ORA_IsBeginTrans = false;
                    ORA_Trans.Dispose();            // 2007/11/01 ADD
                    ORA_Trans = null;               // 2007/11/01 ADD
                    return true;
                }
            }
            catch(OracleException ex)
            {
                ORA_LastErrorCode = ex.Number;
                ORA_LastError = ex.ToString();
                ShowOraErrMsg(ex);
            }
            catch(Exception ex)
            {
                ORA_LastErrorCode = -1;
                ORA_LastError = ex.ToString();
                ShowOraErrMsg(ex);
            }

            return false;
        }

        /// <summary>
        /// ★エラーのクリア
        /// </summary>
        public void LastErrorClear()
        {
            ORA_LastErrorCode = 0;
            ORA_LastError = "";
        }

        /// <summary>
        /// ★SQLのクリア
        /// </summary>
        public void SQLClear()
        {
            ORA_SQL.Remove(0, ORA_SQL.Length);
        }

        /// <summary>
        /// エラーメッセージ表示処理
        /// </summary>
        /// <param name="pexpErr">エラー内容</param> 
        /// <remark>エラーメッセージを表示します</remark>
        private static void ShowOraErrMsg(Exception pexpErr)
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
            MessageBox.Show(lstrMsg.ToString(), "ＤＢエラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        /// <summary>
        /// 接続エラー判定
        /// </summary>
        /// <returns>true：接続エラー false：それ以外</returns>
        private bool IsConnectError()
        {
            if(ORA_LastErrorCode == 3113 || ORA_LastErrorCode == 3114
                    || ORA_LastErrorCode == 3135 || ORA_LastErrorCode == 12545
                    || ORA_LastErrorCode == 12571)
                return true;
            return false;
        }

        /// <summary>
        /// 接続エラー判定
        /// </summary>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>true：接続エラー false：それ以外</returns>
        private bool IsConnectError(string errMsg)
        {
            if(0 <= errMsg.IndexOf("オブジェクト"))
                return true;
            return false;
        }

        // 2013/03/20 @B2 ADD START --- [回線再接続時にログ出力]
        #region // システムログ　出力
        /// <summary> 
        /// システムログ　出力
        /// </summary>
        /// <param name="pstrBunruiCD">分類コード</param>
        /// <param name="pstrLoginID">ログインID</param> 
        /// <param name="pstrBIKO">備考</param>
        /// <returns>成功したらTrue　エラーでFalse</returns>
        /// <remark>システムログ　出力</remark>
        public bool WriteSysLog(string pstrBunruiCD, string pstrLoginID, string pstrBIKO)
        {
            bool retflg = false;
            for (int i = 0; i < 5; i++)
            {
                try
                {
                    //ログの書き込み
                    SQLClear();
                    SQL.Append("INSERT INTO DSECLOG_TBL");
                    SQL.Append("(LOGNO,LOGDATE,LOGTIME,PROGRAMID,BUNRUI,CLIENT,OPID,KANJID,BIKOU)");
                    SQL.Append(" VALUES(");

                    // 2011-06-27 MODIFY START
                    //ORALib.SQL.Append("(SELECT MAX(LOGNO) + 1  NEWNO FROM DSECLOG_TBL WHERE LOGDATE = TO_CHAR(SYSDATE, 'YYYYMMDD') GROUP BY LOGDATE),");
                    SQL.Append("nvl((SELECT MAX(LOGNO) + 1  NEWNO FROM DSECLOG_TBL WHERE LOGDATE = TO_CHAR(SYSDATE, 'YYYYMMDD') GROUP BY LOGDATE),1),");
                    // 2011-06-27 MODIFY END

                    SQL.Append("TO_CHAR(SYSDATE, 'YYYYMMDD'),");
                    SQL.Append("TO_CHAR(SYSDATE, 'HH24MI'),");
                    //SQL.Append("'" + PhCom.PRGID + "',");
                    SQL.Append("'" + System.IO.Path.GetFileNameWithoutExtension(Environment.GetCommandLineArgs()[0]) + "',");
                    SQL.Append("'" + pstrBunruiCD + "',");
                    SQL.Append("'" + Environment.MachineName + "',");
                    SQL.Append("'" + pstrLoginID + "',");
                    SQL.Append("Null");
                    SQL.Append(",");
                    SQL.Append("'" + pstrBIKO + "')");

                    ORA_Command.CommandText = SQL.ToString();
                    SQLClear();
                    //ORA_SQL.Append(SQL.ToString());

                    int rows = ORA_Command.ExecuteNonQuery();

                    retflg = true;
                    break;

                }
                catch
                {
                }
            }
            return retflg;
        }
        #endregion
        // 2013/03/20 @B2 ADD START --- [回線再接続時にログ出力]
    }}
