using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using Npgsql;

namespace B2.Com
{
    /// <summary>
    /// PostgreSQL 操作用クラス
    /// </summary>
   public  class clsPostgre : IDisposable
    {
            #region 変数宣言
            /// <summary>破棄状況(true：破棄済み false：破棄されていない)</summary>
            private bool disposed;

            /// <summary>接続情報</summary>
            private NpgsqlConnection PG_Session = new NpgsqlConnection();

            /// <summary>実行コマンド情報</summary>
            private NpgsqlCommand PG_Command = new NpgsqlCommand();

            /// <summary>トランザクション情報</summary>
            private NpgsqlTransaction PG_Trans;

            /// <summary>接続ユーザ名:ROLE NAME</summary>
            private string PG_UserName;

            /// <summary>接続パスワード</summary>
            private string PG_Password;

            /// <summary>接続先データベース</summary>
            private string PG_Database;

            /// <summary>接続先サーバー名</summary>
            private string PG_Server;

            /// <summary>接続先サポート番号</summary>
            private string PG_Port = "5432";

            /// <summary>接続先スキーマ</summary>
            private string PG_Schema = "public";

            /// <summary>プーリング区分(true：接続のプーリングをする false：しない)</summary>
            private bool PG_Pooling;

            /// <summary>SQL文字列</summary>
            private StringBuilder PG_SQL = new StringBuilder();

            /// <summary>接続状況(true：接続中 false：未接続)</summary>
            private bool PG_IsConnection;

            /// <summary>トランザクション状況(true：トランザクション中 false：それ以外)</summary>
            private bool PG_IsBeginTrans;

            /// <summary>Oracleエラーコード</summary>
            private int PG_LastErrorCode;

            /// <summary>Oracleエラーメッセージ</summary>
            private string PG_LastError;

            /// <summary>リトライ回数</summary>
            private int retryCount;

            #endregion

            /// <summary>
            /// ★コンストラクタ
            /// </summary>
            public clsPostgre()
            {
                PG_UserName = "";
                PG_Password = "";
                PG_Database = "";
                PG_Server = "";
                PG_Pooling = false;
                PG_Schema = "";

                SQLClear();
                PG_LastErrorCode = 0;
                PG_LastError = "";

                PG_IsConnection = false;
                PG_IsBeginTrans = false;

                disposed = false;


                retryCount = 5;
            }

            /// <summary>
            /// ★デストラクタ
            /// </summary>
            ~clsPostgre()
            {
                Dispose();
            }

            /// <summary>
            /// 解放処理
            /// </summary>
            public void Dispose()
            {
                //まだDisposeが行われていないなら処理
                if (!this.disposed)
                {
                    //◆接続済みの場合
                    if (PG_IsConnection)
                    {
                        DisConnect();
                    }

                    //以降、解放処理
                    if (PG_Trans != null)
                    {
                        PG_Trans.Dispose();
                    }

                    if (PG_Command != null)
                    {
                        PG_Command.Dispose();
                    }

                    if (PG_Session != null)
                    {
                        PG_Session.Dispose();
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
                get { return PG_UserName; }
                set { PG_UserName = value; }
            }

            /// <summary>★接続パスワード</summary>
            public string Password
            {
                get { return PG_Password; }
                set { PG_Password = value; }
            }

            /// <summary>★接続先データベース</summary>
            public string Database
            {
                get { return PG_Database; }
                set { PG_Database = value; }
            }

            /// <summary>★接続先サーバ</summary>
            public string Server
            {
                get { return PG_Server; }
                set { PG_Server = value; }
            }

            /// <summary>★接続先ポート番号</summary>
            public string Port
            {
                get { return PG_Port; }
                set { PG_Port = value; }
            }

            /// <summary>★接続先データベース</summary>
            public bool Pooling
            {
                get { return PG_Pooling; }
                set { PG_Pooling = value; }
            }

            /// <summary>★接続先スキーマ</summary>
            public string Schema
            {
                get { return PG_Schema; }
                set { PG_Schema = value; }
            }

            /// <summary>★SQL文字列</summary>
            public StringBuilder SQL
            {
                get { return PG_SQL; }
                set { PG_SQL = value; }
            }

            /// <summary>リトライ回数</summary>
            public int RetryCount
            {
                set
                {
                    if (0 < value)
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
                get { return PG_IsConnection; }
            }

            /// <summary>★最後に起きたエラーコード</summary>
            public int LastErrorCode
            {
                get { return PG_LastErrorCode; }
            }

            /// <summary>★最後に起きたエラー</summary>
            public string LastError
            {
                get { return PG_LastError; }
            }

            /// <summary>ORACLEコネクション</summary>
            public NpgsqlConnection Session
            {
                get { return PG_Session; }
            }

            /// <summary>ORALCEコマンド</summary>
            public NpgsqlCommand Command
            {
                get { return PG_Command; }
            }
            #endregion

            #region 接続関連
            /// <summary>
            /// ★PostgreSQL接続
            /// </summary>
            /// <param name="userName">ユーザ名</param>
            /// <param name="password">パスワード</param>
            /// <param name="database">データベース</param>
            /// <param name="schema">スキーマ</param>
            /// <param name="pooling">接続プーリング区分(true：接続プーリングする false：しない)</param>
            /// <returns>true：正常終了 false：エラー</returns>
            public bool Connect(string serverName, string portNo, string userName, string password, string database, string schema, bool pooling)
            {
                StringBuilder wkConnect = new StringBuilder();

                for (int count = 1; count <= retryCount; count++)
                {
                    try
                    {
                        //◆接続済みの場合、事前にClose
                        if (PG_IsConnection)
                        {
                            DisConnect();
                        }

                        //■接続
                        wkConnect.Remove(0, wkConnect.Length);
                        wkConnect.Append("Server=");
                        wkConnect.Append(serverName);

                        wkConnect.Append(";Port=");
                        wkConnect.Append(portNo);

                        wkConnect.Append(";User ID=");
                        wkConnect.Append(userName);

                        wkConnect.Append(";Database=");
                        wkConnect.Append(database);

                        wkConnect.Append(";Password=");
                        wkConnect.Append(password);

     //                   wkConnect.Append(";Schema=");
     //                   wkConnect.Append(schema);

                        //  wkConnect.Append(";Pooling=");
                        //  wkConnect.Append(pooling.ToString());

                        PG_Session.ConnectionString = wkConnect.ToString();
                        PG_Session.Open();

                        PG_Command.Connection = PG_Session;

                        //プロパティの更新
                        PG_UserName = userName;
                        PG_Password = password;
                        PG_Database = database;
                        PG_Server = serverName;
                        PG_Port = portNo;
                        PG_Pooling = pooling;
                        PG_Schema = schema;

                        SQLClear();

                        PG_IsConnection = true;

                        return true;
                    }
                    catch (NpgsqlException ex)
                    {
                        PG_LastErrorCode = ex.ErrorCode;
                        PG_LastError = ex.Message;
                        // 接続エラーのときだけリトライする
                        if (IsConnectError())
                        {
                            // リトライ回数が終わったときだけメッセージを表示
                            if (count == retryCount)
                                ShowPgErrMsg(ex);
                        }
                        else
                        {
                            // 接続エラー以外はリトライしない
                            ShowPgErrMsg(ex);
                            break;
                        }
                    }
                    catch (Exception ex)
                    {
                        // 接続エラー以外はリトライしない
                        PG_LastErrorCode = -1;
                        PG_LastError = ex.ToString();
                        ShowPgErrMsg(ex);
                        break;
                    }
                }

                return false;
            }

            //接続文字列を返す
            public string strConnect()
            {
                StringBuilder wkConnect = new StringBuilder();

                //■接続 文字列の作成
                wkConnect.Remove(0, wkConnect.Length);

                wkConnect.Append("Server=");
                wkConnect.Append(PG_Server);

                wkConnect.Append(";Port=");
                wkConnect.Append(PG_Port);

                wkConnect.Append(";User ID=");
                wkConnect.Append(PG_UserName);

                wkConnect.Append(";Databae=");
                wkConnect.Append(PG_Database);

                wkConnect.Append(";Password=");
                wkConnect.Append(PG_Password);

                wkConnect.Append(";Schema=");
                wkConnect.Append(PG_Schema);

                //wkConnect.Append(";Pooling=");
                //wkConnect.Append(PG_Pooling.ToString());

                return wkConnect.ToString();
            }

            /// <summary>
            /// ★Oracle接続
            /// ユーザ名などはINIファイルを参照
            /// </summary>
            /// <returns>true：正常終了 false：エラー</returns>
            public bool Connect()
            {
                return Connect(PG_Server, PG_Port, PG_UserName, PG_Password, PG_Database, PG_Schema, PG_Pooling);
            }

            /// <summary>
            /// ★Oracke接続
            /// 接続プーリングを使用して接続する
            /// </summary>
            /// <param name="userName">ユーザ名</param>
            /// <param name="password">パスワード</param>
            /// <param name="database">データベース</param>
            /// <param name="schema">スキーマ</param>
            /// <returns>true：正常終了 false：エラー</returns>
            public bool Connect(string serverName, string portNo, string userName, string password, string database, string schema)
            {
                try
                {
                    return Connect(serverName, portNo, userName, password, database, schema, true);
                }
                catch (NpgsqlException ex)
                {
                    PG_LastErrorCode = ex.ErrorCode;
                    PG_LastError = ex.Message;
                    ShowPgErrMsg(ex);

                    return false;
                }
                catch (Exception ex)
                {
                    PG_LastErrorCode = -1;
                    PG_LastError = ex.ToString();
                    ShowPgErrMsg(ex);
                    return false;
                }
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
                    if (PG_IsBeginTrans)
                    {
                        CommitTransaction();
                    }

                    //■切断
                    if (PG_IsConnection)
                    {
                        PG_Session.Close();
                        PG_Command.Connection = null;
                        PG_IsConnection = false;
                    }

                    SQLClear();

                    return true;
                }
                catch (NpgsqlException ex)
                {
                    PG_LastErrorCode = ex.ErrorCode;
                    PG_LastError = ex.Message;
                    ShowPgErrMsg(ex);

                    return false;
                }
                catch (Exception ex)
                {
                    PG_LastErrorCode = -1;
                    PG_LastError = ex.ToString();
                    ShowPgErrMsg(ex);
                    return false;
                }
            }
            #endregion

            /// <summary>
            /// ★Select(接続型)
            /// </summary>
            /// <param name="selectSQL">SQL文字列</param>
            /// <returns>データリーダオブジェクト(エラーのときはnull)</returns>
            public NpgsqlDataReader SelectSQL_NoCache(string selectSQL)
            {
                try
                {
                    if (PG_IsConnection)
                    {
                        PG_Command.CommandText = selectSQL;
                        SQLClear();
                        PG_SQL.Append(selectSQL);

                        return PG_Command.ExecuteReader();
                    }
                }
                catch (NpgsqlException ex)
                {
                    PG_LastErrorCode = ex.ErrorCode;
                    PG_LastError = ex.Message;
                    // 接続エラーのときだけリトライする
                    if (IsConnectError())
                    {
                        // 再度接続を試みてからもう一度SQLを実行
                        if (Connect())
                        {
                            try
                            {
                                WriteSysLog("50", "", "回線再接続:SelectSQL_NoCache");
                                PG_Command.CommandText = selectSQL;
                                SQLClear();
                                PG_SQL.Append(selectSQL);
                                return PG_Command.ExecuteReader();
                            }
                            catch (Exception e)
                            {
                                // 再接続後のエラーはリトライしない
                                PG_LastErrorCode = -1;
                                PG_LastError = e.ToString();
                                ShowPgErrMsg(e);
                            }
                        }
                        PG_IsConnection = true;
                    }
                    else
                        ShowPgErrMsg(ex);
                }
                catch (InvalidOperationException ex)
                {
                    PG_LastErrorCode = -1;
                    PG_LastError = ex.ToString();
                    // 接続関連のエラー時のみ再接続してリトライ
                    if (IsConnectError(PG_LastError) && Connect())
                    {
                        try
                        {
                            WriteSysLog("50", "", "回線再接続:SelectSQL_NoCache");
                            PG_Command.CommandText = selectSQL;
                            SQLClear();
                            PG_SQL.Append(selectSQL);
                            return PG_Command.ExecuteReader();
                        }
                        catch (Exception e)
                        {
                            // 再接続後のエラーはリトライしない
                            PG_LastErrorCode = -1;
                            PG_LastError = e.ToString();
                            ShowPgErrMsg(e);
                        }
                    }
                    else
                        ShowPgErrMsg(ex);
                    PG_IsConnection = true;
                }
                catch (Exception ex)
                {
                    PG_LastErrorCode = -1;
                    PG_LastError = ex.ToString();
                    ShowPgErrMsg(ex);
                }

                return null;
            }

            /// <summary>
            /// ★Select(接続型)
            /// SQLに設定されたSQL文字列を実行
            /// </summary>
            /// <returns>データリーダオブジェクト(エラーのときはnull)</returns>
            public NpgsqlDataReader SelectSQL_NoCache()
            {
                return SelectSQL_NoCache(PG_SQL.ToString());
            }

            /// <summary>
            /// ★Select(非接続型)
            /// </summary>
            /// <param name="selectSQL">SQL文字列</param>
            /// <returns>データアダプタオブジェクト(エラーのときはnull)</returns>
            public NpgsqlDataAdapter SelectSQL(string selectSQL)
            {
                try
                {
                    if (PG_IsConnection)
                    {
                        PG_Command.CommandText = selectSQL;
                        SQLClear();
                        PG_SQL.Append(selectSQL);

                        return new NpgsqlDataAdapter(PG_Command);
                    }
                }
                catch (NpgsqlException ex)
                {
                    PG_LastErrorCode = ex.ErrorCode;
                    PG_LastError = ex.Message;
                    // 接続エラーのときだけリトライする
                    if (IsConnectError())
                    {
                        // 再度接続を試みてからもう一度SQLを実行
                        if (Connect())
                        {
                            try
                            {
                                WriteSysLog("50", "", "回線再接続:SelectSQL");
                                PG_Command.CommandText = selectSQL;
                                SQLClear();
                                PG_SQL.Append(selectSQL);
                                return new NpgsqlDataAdapter(PG_Command);
                            }
                            catch (Exception e)
                            {
                                // 再接続後のエラーはリトライしない
                                PG_LastErrorCode = -1;
                                PG_LastError = e.ToString();
                                ShowPgErrMsg(e);
                            }
                        }
                        PG_IsConnection = true;
                    }
                    else
                        ShowPgErrMsg(ex);
                }
                catch (InvalidOperationException ex)
                {
                    PG_LastErrorCode = -1;
                    PG_LastError = ex.ToString();
                    // 接続関連のエラー時のみ再接続してリトライ
                    if (IsConnectError(PG_LastError) && Connect())
                    {
                        try
                        {
                            WriteSysLog("50", "", "回線再接続:SelectSQL");
                            PG_Command.CommandText = selectSQL;
                            SQLClear();
                            PG_SQL.Append(selectSQL);
                            return new NpgsqlDataAdapter(PG_Command);
                        }
                        catch (Exception e)
                        {
                            // 再接続後のエラーはリトライしない
                            PG_LastErrorCode = -1;
                            PG_LastError = e.ToString();
                            ShowPgErrMsg(e);
                        }
                    }
                    else
                        ShowPgErrMsg(ex);
                    PG_IsConnection = true;
                }
                catch (Exception ex)
                {
                    PG_LastErrorCode = -1;
                    PG_LastError = ex.ToString();
                    ShowPgErrMsg(ex);
                }

                return null;
            }

            /// <summary>
            /// ★Select(非接続型)
            /// SQLに設定されたSQL文字列を実行
            /// </summary>
            /// <returns>データアダプタオブジェクト(エラーのときはnull)</returns>
            public NpgsqlDataAdapter SelectSQL()
            {
                return SelectSQL(PG_SQL.ToString());
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
                    if (PG_IsConnection)
                    {
                        PG_Command.CommandText = execSQL;
                        SQLClear();
                        PG_SQL.Append(execSQL);

                        int rows = PG_Command.ExecuteNonQuery();
                        if (rows < 0)               // 件数を戻さない場合-1になるので補正
                        {
                            rows = 0;
                        }
                        return rows;
                    }
                }
                catch (NpgsqlException ex)
                {
                    PG_LastErrorCode = ex.ErrorCode;
                    PG_LastError = ex.Message;
                    // 接続エラーのときだけリトライする
                    if (IsConnectError())
                    {
                        // 再度接続を試みてからもう一度SQLを実行
                        if (Connect())
                        {
                            try
                            {
                                WriteSysLog("50", "", "回線再接続:ExecuteSQL");
                                PG_Command.CommandText = execSQL;
                                SQLClear();
                                PG_SQL.Append(execSQL);
                                int count = PG_Command.ExecuteNonQuery();
                                // 件数を戻さない場合-1になるので補正
                                if (count < 0)
                                    count = 0;
                                return count;
                            }
                            catch (Exception e)
                            {
                                // 再接続後のエラーはリトライしない
                                PG_LastErrorCode = -1;
                                PG_LastError = e.ToString();
                                ShowPgErrMsg(e);
                            }
                        }
                        PG_IsConnection = true;
                    }
                    else
                        ShowPgErrMsg(ex);
                }
                catch (InvalidOperationException ex)
                {
                    PG_LastErrorCode = -1;
                    PG_LastError = ex.ToString();
                    // 接続関連のエラー時のみ再接続してリトライ
                    if (IsConnectError(PG_LastError) && Connect())
                    {
                        try
                        {
                            WriteSysLog("50", "", "回線再接続:ExecuteSQL");
                            PG_Command.CommandText = execSQL;
                            SQLClear();
                            PG_SQL.Append(execSQL);
                            int count = PG_Command.ExecuteNonQuery();
                            // 件数を戻さない場合-1になるので補正
                            if (count < 0)
                                count = 0;
                            return count;
                        }
                        catch (Exception e)
                        {
                            // 再接続後のエラーはリトライしない
                            PG_LastErrorCode = -1;
                            PG_LastError = e.ToString();
                            ShowPgErrMsg(e);
                        }
                    }
                    else
                        ShowPgErrMsg(ex);
                    PG_IsConnection = true;
                }
                catch (Exception ex)
                {
                    PG_LastErrorCode = -1;
                    PG_LastError = ex.ToString();
                    ShowPgErrMsg(ex);
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
                return ExecuteSQL(PG_SQL.ToString());
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
                    if (PG_IsConnection)
                    {
                        PG_Command.CommandText = execSQL;
                        SQLClear();
                        PG_SQL.Append(execSQL);

                        int rows = PG_Command.ExecuteNonQuery();
                        if (rows < 0)               // 件数を戻さない場合-1になるので補正
                        {
                            rows = 0;
                        }
                        return rows;
                    }
                }
                catch (NpgsqlException ex)
                {
                    PG_LastErrorCode = ex.ErrorCode;
                    PG_LastError = ex.Message;
                    // 接続エラーのときだけリトライする
                    if (IsConnectError())
                    {
                        // 再度接続を試みてからもう一度SQLを実行
                        if (Connect())
                        {
                            try
                            {
                                WriteSysLog("50", "", "回線再接続:ExecuteSQLNoErr");
                                PG_Command.CommandText = execSQL;
                                SQLClear();
                                PG_SQL.Append(execSQL);
                                int count = PG_Command.ExecuteNonQuery();
                                // 件数を戻さない場合-1になるので補正
                                if (count < 0)
                                    count = 0;
                                return count;
                            }
                            catch (Exception e)
                            {
                                // 再接続後のエラーはリトライしない
                                PG_LastErrorCode = -1;
                                PG_LastError = e.ToString();
                                throw e;
                            }
                        }
                        PG_IsConnection = true;
                    }
                    else
                        throw ex;
                }
                catch (InvalidOperationException ex)
                {
                    PG_LastErrorCode = -1;
                    PG_LastError = ex.Message;
                    // 接続関連のエラー時のみ再接続してリトライ
                    if (IsConnectError(PG_LastError) && Connect())
                    {
                        try
                        {
                            WriteSysLog("50", "", "回線再接続:ExecuteSQLNoErr");
                            PG_Command.CommandText = execSQL;
                            SQLClear();
                            PG_SQL.Append(execSQL);
                            int count = PG_Command.ExecuteNonQuery();
                            // 件数を戻さない場合-1になるので補正
                            if (count < 0)
                                count = 0;
                            return count;
                        }
                        catch (Exception e)
                        {
                            // 再接続後のエラーはリトライしない
                            PG_LastErrorCode = -1;
                            PG_LastError = e.ToString();
                            PG_IsConnection = true;
                            throw e;
                        }
                    }
                    else
                    {
                        PG_IsConnection = true;
                        throw ex;
                    }
                }
                catch (Exception ex)
                {
                    PG_LastErrorCode = -1;
                    PG_LastError = ex.ToString();
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
                    if (PG_IsConnection && !PG_IsBeginTrans)
                    {
                        PG_Trans = PG_Session.BeginTransaction();
                        PG_IsBeginTrans = true;
                        return true;
                    }
                }
                catch (NpgsqlException ex)
                {
                    PG_LastErrorCode = ex.ErrorCode;
                    PG_LastError = ex.Message;
                    ShowPgErrMsg(ex);
                }
                catch (Exception ex)
                {
                    PG_LastErrorCode = -1;
                    PG_LastError = ex.ToString();
                    ShowPgErrMsg(ex);
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
                    if (PG_IsConnection && PG_IsBeginTrans && PG_Trans != null)
                    {
                        PG_Trans.Commit();
                        PG_IsBeginTrans = false;
                        PG_Trans.Dispose();
                        PG_Trans = null;
                        return true;
                    }
                }
                catch (NpgsqlException ex)
                {
                    PG_LastErrorCode = ex.ErrorCode;
                    PG_LastError = ex.Message;
                    ShowPgErrMsg(ex);
                }
                catch (Exception ex)
                {
                    PG_LastErrorCode = -1;
                    PG_LastError = ex.ToString();
                    ShowPgErrMsg(ex);
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
                    if (PG_IsConnection && PG_IsBeginTrans && PG_Trans != null)
                    {
                        PG_Trans.Rollback();
                        PG_IsBeginTrans = false;
                        PG_Trans.Dispose();            
                        PG_Trans = null;               
                        return true;
                    }
                }
                catch (NpgsqlException ex)
                {
                    PG_LastErrorCode = ex.ErrorCode;
                    PG_LastError = ex.Message;
                    ShowPgErrMsg(ex);
                }
                catch (Exception ex)
                {
                    PG_LastErrorCode = -1;
                    PG_LastError = ex.ToString();
                    ShowPgErrMsg(ex);
                }

                return false;
            }

            /// <summary>
            /// ★エラーのクリア
            /// </summary>
            public void LastErrorClear()
            {
                PG_LastErrorCode = 0;
                PG_LastError = "";
            }

            /// <summary>
            /// ★SQLのクリア
            /// </summary>
            public void SQLClear()
            {
                PG_SQL.Remove(0, PG_SQL.Length);
            }

            /// <summary>
            /// エラーメッセージ表示処理
            /// </summary>
            /// <param name="pexpErr">エラー内容</param> 
            /// <remark>エラーメッセージを表示します</remark>
            private static void ShowPgErrMsg(Exception pexpErr)
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
                if (PG_LastErrorCode == 3113 || PG_LastErrorCode == 3114
                        || PG_LastErrorCode == 3135 || PG_LastErrorCode == 12545
                        || PG_LastErrorCode == 12571)
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
                if (0 <= errMsg.IndexOf("オブジェクト"))
                    return true;
                return false;
            }

            //  [回線再接続時にログ出力]
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
                        SQL.Append("INSERT INTO log_data ");
                        SQL.Append("(LOGNO,LOGDATE,LOGTIME,PROGRAMID,BUNRUI,CLIENT,OPID,KANJID,BIKOU)");
                        SQL.Append(" VALUES(");

                        SQL.Append("nvl((SELECT MAX(LOGNO) + 1  NEWNO FROM DSECLOG_TBL WHERE LOGDATE = TO_CHAR(SYSDATE, 'YYYYMMDD') GROUP BY LOGDATE),1),");

                        SQL.Append("TO_CHAR(DATE, 'YYYYMMDD'),");
                        SQL.Append("TO_CHAR(DATE, 'HH24MI'),");
                        SQL.Append("'" + System.IO.Path.GetFileNameWithoutExtension(Environment.GetCommandLineArgs()[0]) + "',");
                        SQL.Append("'" + pstrBunruiCD + "',");
                        SQL.Append("'" + Environment.MachineName + "',");
                        SQL.Append("'" + pstrLoginID + "',");
                        SQL.Append("Null");
                        SQL.Append(",");
                        SQL.Append("'" + pstrBIKO + "')");

                        PG_Command.CommandText = SQL.ToString();
                        SQLClear();

                        int rows = PG_Command.ExecuteNonQuery();

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
    
    }
}
