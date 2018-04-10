using System;
using System.Text;
using System.Windows.Forms;
using Npgsql;
using System.IO;

namespace B2.Com
{
    /// <summary>
    /// PostgreSql 操作用クラス
    /// </summary>
    public class PgLib : IDisposable
    {
        #region 変数宣言

        /// <summary>接続ユーザ名</summary>
        private string userName;

        /// <summary>接続パスワード</summary>
        private string password;

        /// <summary>接続先データベース</summary>
        private string database;

        /// <summary>接続先サーバ</summary>
        private string server;

        /// <summary>接続先ポート番号</summary>
        private string port;

        /// <summary>接続プーリング区分(true：接続プーリングする false：しない)</summary>
        private bool Pooling;

        /// <summary>接続先スキーマ</summary>
        private string schema;

        /// <summary>破棄状況(true：破棄済み false：破棄されていない)</summary>
        private bool disposed;

        /// <summary>接続情報</summary>
        private NpgsqlConnection connection = new NpgsqlConnection();

        /// <summary>実行コマンド情報</summary>
        private NpgsqlCommand command = new NpgsqlCommand();

        /// <summary>トランザクション情報</summary>
        private NpgsqlTransaction transaction;

        /// <summary>接続状況(true：接続中 false：未接続)</summary>
        private bool isConnected;

        /// <summary>トランザクション状況(true：トランザクション中 false：それ以外)</summary>
        private bool isBeginTransaction;

        /// <summary>PostgreSqlエラーコード</summary>
        private int lastErrorCode;

        /// <summary>PostgreSqlエラーメッセージ</summary>
        private string lastError;

        /// <summary>リトライ回数</summary>
        private int retryCount;

        #endregion

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public PgLib()
        {
            this.userName = string.Empty;
            this.password = string.Empty;
            this.database = string.Empty;
            this.server = string.Empty;
            this.Pooling = false;
            this.schema = string.Empty;
            this.Sql = new StringBuilder();
            this.lastErrorCode = 0;
            this.lastError = string.Empty;
            this.isConnected = false;
            this.isBeginTransaction = false;
            this.disposed = false;
            this.retryCount = 5;
        }

        /// <summary>
        /// デストラクタ
        /// </summary>
        ~PgLib()
        {
            Dispose();
        }

        /// <summary>
        /// 解放処理
        /// </summary>
        public void Dispose()
        {
            // まだDisposeが行われていないなら処理
            if (!this.disposed)
            {
                // 接続済みの場合
                if (this.isConnected)
                {
                    DisConnect();
                }

                // 以降、解放処理
                if (this.transaction != null)
                {
                    this.transaction.Dispose();
                }

                if (this.command != null)
                {
                    this.command.Dispose();
                }

                if (this.connection != null)
                {
                    //this.connection.Dispose();
                }
            }

            this.disposed = true;

            GC.SuppressFinalize(this);
        }

        #region プロパティ
        //▼プロパティ(R/W)
        /// <summary>this.Sql文字列</summary>
        public StringBuilder Sql { get; set; }

        /// <summary>リトライ回数</summary>
        public int RetryCount
        {
            set
            {
                if (0 < value)
                    this.retryCount = value;
                else
                    this.retryCount = 1;
            }
            get { return this.retryCount; }
        }

        //▼プロパティ(R)
        /// <summary>接続状況表示</summary>
        public bool IsConnected
        {
            get { return this.isConnected; }
        }

        /// <summary>最後に起きたエラーコード</summary>
        public int LastErrorCode
        {
            get { return this.lastErrorCode; }
        }

        /// <summary>最後に起きたエラー</summary>
        public string LastError
        {
            get { return this.lastError; }
        }

        /// <summary>コネクション</summary>
        public NpgsqlConnection Connection
        {
            get { return this.connection; }
        }

        /// <summary>コマンド</summary>
        public NpgsqlCommand Command
        {
            get { return this.command; }
        }

        /// <summary>
        /// 接続文字列
        /// </summary>
        private string ConnectionString
        {
            get
            {
                var connectionString = new StringBuilder();

                connectionString.Append("Server=");
                connectionString.Append(this.server);

                connectionString.Append(";Port=");
                connectionString.Append(this.port);

                connectionString.Append(";User ID=");
                connectionString.Append(this.userName);

                connectionString.Append(";Database=");
                connectionString.Append(this.database);

                connectionString.Append(";Password=");
                connectionString.Append(this.password);

                //connectionString.Append(";Schema=");
                //connectionString.Append(this.schema);

                //connectionString.Append(";Pooling=");
                //connectionString.Append(pooling.ToString());

                return connectionString.ToString();
            }
        }

        #endregion

        #region 接続関連
        /// <summary>
        /// PostgreSql接続
        /// </summary>
        /// <param name="server">サーバー</param>
        /// <param name="port">ポート</param>
        /// <param name="userName">ユーザ名</param>
        /// <param name="password">パスワード</param>
        /// <param name="database">データベース</param>
        /// <param name="schema">スキーマ</param>
        /// <param name="pooling">接続プーリング区分(true：接続プーリングする false：しない)</param>
        /// <returns>true：正常終了 false：エラー</returns>
        public bool Connect(string server, string port, string userName, string password, string database, string schema, bool pooling = true)
        {
            //プロパティの更新
            this.server = server;
            this.userName = userName;
            this.password = password;
            this.database = database;
            this.port = port;
            this.schema = schema;
            this.Pooling = pooling;

            return Connect();
        }

        /// <summary>
        /// PostgreSql接続
        /// ユーザ名などはINIファイルを参照
        /// </summary>
        /// <returns>true：正常終了 false：エラー</returns>
        public bool Connect()
        {
            for (int count = 1; count <= this.retryCount; count++)
            {
                try
                {
                    // 接続済みの場合、事前にClose
                    if (this.isConnected)
                    {
                        DisConnect();
                    }

                    // 接続
                    this.connection.ConnectionString = this.ConnectionString;
                    this.connection.Open();

                    this.command.Connection = this.connection;

                    this.Sql.Clear();

                    this.isConnected = true;

                    return true;
                }
                catch (NpgsqlException ex)
                {
                    this.lastErrorCode = ex.ErrorCode;
                    this.lastError = ex.Message;

                    // 接続エラーのときだけリトライする
                    if (this.isConnectError())
                    {
                        // リトライ回数が終わったときだけメッセージを表示
                        if (count == this.retryCount)
                        {
                            this.showErrorMessage(ex);
                        }
                    }
                    else
                    {
                        // 接続エラー以外はリトライしない
                        this.showErrorMessage(ex);
                        break;
                    }
                }
                catch (Exception ex)
                {
                    // 接続エラー以外はリトライしない
                    this.lastErrorCode = -1;
                    this.lastError = ex.ToString();
                    this.showErrorMessage(ex);
                    break;
                }
            }

            return false;
        }

        ///// <summary>
        ///// 接続
        ///// 接続プーリングを使用して接続する
        ///// </summary>
        ///// <param name="userName">ユーザ名</param>
        ///// <param name="password">パスワード</param>
        ///// <param name="database">データベース</param>
        ///// <param name="schema">スキーマ</param>
        ///// <returns>true：正常終了 false：エラー</returns>
        //public bool Connect(string serverName, string portNo, string userName, string password, string database, string schema)
        //{
        //    try
        //    {
        //        return Connect(serverName, portNo, userName, password, database, schema, true);
        //    }
        //    catch (NpgsqlException ex)
        //    {
        //        this.lastErrorCode = ex.ErrorCode;
        //        this.lastError = ex.Message;
        //        this.showErrorMessage(ex);

        //        return false;
        //    }
        //    catch (Exception ex)
        //    {
        //        this.lastErrorCode = -1;
        //        this.lastError = ex.ToString();
        //        this.showErrorMessage(ex);
        //        return false;
        //    }
        //}

        /// <summary>
        /// 切断
        /// </summary>
        /// <returns>true：正常終了 false：エラー</returns>
        public bool DisConnect()
        {
            try
            {
                // トランザクションが終了していないならCOMMIT
                if (this.isBeginTransaction)
                {
                    this.CommitTransaction();
                }

                // 切断
                if (this.isConnected)
                {
                    //this.connection.Close();
                    if(this.connection.State == System.Data.ConnectionState.Connecting)
                    {
                        this.connection.Close();
                    }
                    this.command.Connection = null;
                    this.isConnected = false;
                }

                this.Sql.Clear();

                return true;
            }
            catch (NpgsqlException ex)
            {
                this.lastErrorCode = ex.ErrorCode;
                this.lastError = ex.Message;
                this.showErrorMessage(ex);

                return false;
            }
            catch (Exception ex)
            {
                this.lastErrorCode = -1;
                this.lastError = ex.ToString();
                this.showErrorMessage(ex);
                return false;
            }
        }
        #endregion

        /// <summary>
        /// Select(接続型)
        /// </summary>
        /// <param name="selectSql">this.Sql文字列</param>
        /// <returns>データリーダオブジェクト(エラーのときはnull)</returns>
        public NpgsqlDataReader SelectSql_NoCache(string selectSql)
        {
            try
            {
                if (this.isConnected)
                {
                    this.command.CommandText = selectSql;
                    this.Sql.Clear();
                    this.Sql.Append(selectSql);

                    try
                    {
                        return command.ExecuteReader();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
            catch (NpgsqlException ex)
            {
                this.lastErrorCode = ex.ErrorCode;
                this.lastError = ex.Message;
                // 接続エラーのときだけリトライする
                if (this.isConnectError())
                {
                    // 再度接続を試みてからもう一度this.Sqlを実行
                    if (this.Connect())
                    {
                        try
                        {
                            this.WriteSystemLog("50", string.Empty, "回線再接続:SelectSql_NoCache");
                            this.command.CommandText = selectSql;
                            this.Sql.Clear();
                            this.Sql.Append(selectSql);
                            return command.ExecuteReader();
                        }
                        catch (Exception e)
                        {
                            // 再接続後のエラーはリトライしない
                            this.lastErrorCode = -1;
                            this.lastError = e.ToString();
                            this.showErrorMessage(e);
                        }
                    }

                    this.isConnected = true;
                }
                else
                {
                    this.showErrorMessage(ex);
                }
            }
            catch (InvalidOperationException ex)
            {
                this.lastErrorCode = -1;
                this.lastError = ex.ToString();
                // 接続関連のエラー時のみ再接続してリトライ
                if (this.isConnectError(this.lastError) && this.Connect())
                {
                    try
                    {
                        this.WriteSystemLog("50", string.Empty, "回線再接続:SelectSql_NoCache");
                        this.command.CommandText = selectSql;
                        this.Sql.Clear();
                        this.Sql.Append(selectSql);
                        return this.command.ExecuteReader();
                    }
                    catch (Exception e)
                    {
                        // 再接続後のエラーはリトライしない
                        this.lastErrorCode = -1;
                        this.lastError = e.ToString();
                        this.showErrorMessage(e);
                    }
                }
                else
                {
                    this.showErrorMessage(ex);
                }

                this.isConnected = true;
            }
            catch (Exception ex)
            {
                this.lastErrorCode = -1;
                this.lastError = ex.ToString();
                this.showErrorMessage(ex);
            }

            return null;
        }

        /// <summary>
        /// Select(接続型)
        /// this.Sqlに設定されたthis.Sql文字列を実行
        /// </summary>
        /// <returns>データリーダオブジェクト(エラーのときはnull)</returns>
        public NpgsqlDataReader SelectSql_NoCache()
        {
            return this.SelectSql_NoCache(this.Sql.ToString());
        }

        /// <summary>
        /// Select(非接続型)
        /// </summary>
        /// <param name="selectSql">this.Sql文字列</param>
        /// <returns>データアダプタオブジェクト(エラーのときはnull)</returns>
        public NpgsqlDataAdapter SelectSql(string selectSql)
        {
            try
            {
                if (this.isConnected)
                {
                    this.command.CommandText = selectSql;
                    this.Sql.Clear();
                    this.Sql.Append(selectSql);

                    return new NpgsqlDataAdapter(this.command);
                }
            }
            catch (NpgsqlException ex)
            {
                this.lastErrorCode = ex.ErrorCode;
                this.lastError = ex.Message;
                // 接続エラーのときだけリトライする
                if (this.isConnectError())
                {
                    // 再度接続を試みてからもう一度this.Sqlを実行
                    if (this.Connect())
                    {
                        try
                        {
                            this.WriteSystemLog("50", string.Empty, "回線再接続:SelectSql");
                            this.command.CommandText = selectSql;
                            this.Sql.Clear();
                            this.Sql.Append(selectSql);
                            return new NpgsqlDataAdapter(this.command);
                        }
                        catch (Exception e)
                        {
                            // 再接続後のエラーはリトライしない
                            this.lastErrorCode = -1;
                            this.lastError = e.ToString();
                            this.showErrorMessage(e);
                        }
                    }
                    this.isConnected = true;
                }
                else
                    this.showErrorMessage(ex);
            }
            catch (InvalidOperationException ex)
            {
                this.lastErrorCode = -1;
                this.lastError = ex.ToString();
                // 接続関連のエラー時のみ再接続してリトライ
                if (this.isConnectError(this.lastError) && Connect())
                {
                    try
                    {
                        this.WriteSystemLog("50", string.Empty, "回線再接続:SelectSql");
                        this.command.CommandText = selectSql;
                        this.Sql.Clear();
                        this.Sql.Append(selectSql);
                        return new NpgsqlDataAdapter(this.command);
                    }
                    catch (Exception e)
                    {
                        // 再接続後のエラーはリトライしない
                        this.lastErrorCode = -1;
                        this.lastError = e.ToString();
                        this.showErrorMessage(e);
                    }
                }
                else
                    this.showErrorMessage(ex);
                this.isConnected = true;
            }
            catch (Exception ex)
            {
                this.lastErrorCode = -1;
                this.lastError = ex.ToString();
                this.showErrorMessage(ex);
            }

            return null;
        }

        /// <summary>
        /// Select(非接続型)
        /// this.Sqlに設定されたthis.Sql文字列を実行
        /// </summary>
        /// <returns>データアダプタオブジェクト(エラーのときはnull)</returns>
        public NpgsqlDataAdapter SelectSql()
        {
            return SelectSql(this.Sql.ToString());
        }

        /// <summary>
        /// this.Sql実行(接続型)
        /// </summary>
        /// <param name="execSql">this.Sql文字列</param>
        /// <returns>処理件数(エラーのときは-1)</returns>
        public int ExecuteSql(string execSql)
        {
            try
            {
                if (this.isConnected)
                {
                    this.command.CommandText = execSql;
                    this.Sql.Clear();
                    this.Sql.Append(execSql);

                    int rows = this.command.ExecuteNonQuery();
                    // 件数を戻さない場合-1になるので補正
                    if (rows < 0)
                    {
                        rows = 0;
                    }
                    return rows;
                }
            }
            catch (NpgsqlException ex)
            {
                this.lastErrorCode = ex.ErrorCode;
                this.lastError = ex.Message;
                // 接続エラーのときだけリトライする
                if (this.isConnectError())
                {
                    // 再度接続を試みてからもう一度this.Sqlを実行
                    if (this.Connect())
                    {
                        try
                        {
                            this.WriteSystemLog("50", string.Empty, "回線再接続:ExecuteSql");
                            this.command.CommandText = execSql;
                            this.Sql.Clear();
                            this.Sql.Append(execSql);
                            int count = this.command.ExecuteNonQuery();
                            // 件数を戻さない場合-1になるので補正
                            if (count < 0)
                                count = 0;
                            return count;
                        }
                        catch (Exception e)
                        {
                            // 再接続後のエラーはリトライしない
                            this.lastErrorCode = -1;
                            this.lastError = e.ToString();
                            this.showErrorMessage(e);
                        }
                    }
                    this.isConnected = true;
                }
                else
                    this.showErrorMessage(ex);
            }
            catch (InvalidOperationException ex)
            {
                this.lastErrorCode = -1;
                this.lastError = ex.ToString();
                // 接続関連のエラー時のみ再接続してリトライ
                if (this.isConnectError(this.lastError) && Connect())
                {
                    try
                    {
                        this.WriteSystemLog("50", string.Empty, "回線再接続:ExecuteSql");
                        this.command.CommandText = execSql;
                        this.Sql.Clear();
                        this.Sql.Append(execSql);
                        int count = this.command.ExecuteNonQuery();
                        // 件数を戻さない場合-1になるので補正
                        if (count < 0)
                            count = 0;
                        return count;
                    }
                    catch (Exception e)
                    {
                        // 再接続後のエラーはリトライしない
                        this.lastErrorCode = -1;
                        this.lastError = e.ToString();
                        this.showErrorMessage(e);
                    }
                }
                else
                {
                    this.showErrorMessage(ex);
                }

                this.isConnected = true;
            }
            catch (Exception ex)
            {
                this.lastErrorCode = -1;
                this.lastError = ex.ToString();
                this.showErrorMessage(ex);
            }

            return -1;
        }

        /// <summary>
        /// this.Sql実行(接続型)
        /// this.Sqlに設定されたthis.Sql文字列を実行
        /// </summary>
        /// <returns>処理件数(エラーのときは-1)</returns>
        public int ExecuteSql()
        {
            return this.ExecuteSql(this.Sql.ToString());
        }

        /// <summary>
        /// this.Sql実行(接続型) エラーメッセージを表示しないでthrowする。
        /// </summary>
        /// <param name="execSql">this.Sql文字列</param>
        /// <returns>処理件数(エラーのときは-1)</returns>
        public int ExecuteSqlNoErr(string execSql)
        {
            try
            {
                if (this.isConnected)
                {
                    this.command.CommandText = execSql;
                    this.Sql.Clear();
                    this.Sql.Append(execSql);

                    int rows = this.command.ExecuteNonQuery();
                    // 件数を戻さない場合-1になるので補正
                    if (rows < 0)
                    {
                        rows = 0;
                    }
                    return rows;
                }
            }
            catch (NpgsqlException ex)
            {
                this.lastErrorCode = ex.ErrorCode;
                this.lastError = ex.Message;
                // 接続エラーのときだけリトライする
                if (this.isConnectError())
                {
                    // 再度接続を試みてからもう一度this.Sqlを実行
                    if (this.Connect())
                    {
                        try
                        {
                            this.WriteSystemLog("50", string.Empty, "回線再接続:ExecuteSqlNoErr");
                            this.command.CommandText = execSql;
                            this.Sql.Clear();
                            this.Sql.Append(execSql);
                            int count = this.command.ExecuteNonQuery();
                            // 件数を戻さない場合-1になるので補正
                            if (count < 0)
                            {
                                count = 0;
                            }

                            return count;
                        }
                        catch (Exception e)
                        {
                            // 再接続後のエラーはリトライしない
                            this.lastErrorCode = -1;
                            this.lastError = e.ToString();
                            throw e;
                        }
                    }
                    this.isConnected = true;
                }
                else
                {
                    throw ex;
                }
            }
            catch (InvalidOperationException ex)
            {
                this.lastErrorCode = -1;
                this.lastError = ex.Message;
                // 接続関連のエラー時のみ再接続してリトライ
                if (this.isConnectError(this.lastError) && Connect())
                {
                    try
                    {
                        this.WriteSystemLog("50", string.Empty, "回線再接続:ExecuteSqlNoErr");
                        this.command.CommandText = execSql;
                        this.Sql.Clear();
                        this.Sql.Append(execSql);
                        int count = this.command.ExecuteNonQuery();
                        // 件数を戻さない場合-1になるので補正
                        if (count < 0)
                        {
                            count = 0;
                        }

                        return count;
                    }
                    catch (Exception e)
                    {
                        // 再接続後のエラーはリトライしない
                        this.lastErrorCode = -1;
                        this.lastError = e.ToString();
                        this.isConnected = true;
                        throw e;
                    }
                }
                else
                {
                    this.isConnected = true;
                    throw ex;
                }
            }
            catch (Exception ex)
            {
                this.lastErrorCode = -1;
                this.lastError = ex.ToString();
                throw ex;
            }
            return -1;
        }


        /// <summary>
        /// トランザクションの開始
        /// </summary>
        /// <returns>true：正常終了 false：エラー</returns>
        public bool BeginTransaction()
        {
            try
            {
                if (this.isConnected && !this.isBeginTransaction)
                {
                    this.transaction = this.connection.BeginTransaction();
                    this.isBeginTransaction = true;
                    return true;
                }
            }
            catch (NpgsqlException ex)
            {
                this.lastErrorCode = ex.ErrorCode;
                this.lastError = ex.Message;
                this.showErrorMessage(ex);
            }
            catch (Exception ex)
            {
                this.lastErrorCode = -1;
                this.lastError = ex.ToString();
                this.showErrorMessage(ex);
            }

            return false;
        }

        /// <summary>
        /// コミット
        /// </summary>
        /// <returns>true：正常終了 false：エラー</returns>
        public bool CommitTransaction()
        {
            try
            {
                if (this.isConnected && this.isBeginTransaction && this.transaction != null)
                {
                    this.transaction.Commit();
                    this.isBeginTransaction = false;
                    this.transaction.Dispose();
                    this.transaction = null;
                    return true;
                }
            }
            catch (NpgsqlException ex)
            {
                this.lastErrorCode = ex.ErrorCode;
                this.lastError = ex.Message;
                this.showErrorMessage(ex);
            }
            catch (Exception ex)
            {
                this.lastErrorCode = -1;
                this.lastError = ex.ToString();
                this.showErrorMessage(ex);
            }

            return false;
        }

        /// <summary>
        /// ロールバック
        /// </summary>
        /// <returns>true：正常終了 false：エラー</returns>
        public bool RollbackTransaction()
        {
            try
            {
                if (this.isConnected && this.isBeginTransaction && this.transaction != null)
                {
                    this.transaction.Rollback();
                    this.isBeginTransaction = false;
                    this.transaction.Dispose();
                    this.transaction = null;
                    return true;
                }
            }
            catch (NpgsqlException ex)
            {
                this.lastErrorCode = ex.ErrorCode;
                this.lastError = ex.Message;
                this.showErrorMessage(ex);
            }
            catch (Exception ex)
            {
                this.lastErrorCode = -1;
                this.lastError = ex.ToString();
                this.showErrorMessage(ex);
            }

            return false;
        }

        /// <summary>
        /// エラーのクリア
        /// </summary>
        public void LastErrorClear()
        {
            this.lastErrorCode = 0;
            this.lastError = string.Empty;
        }


        /// <summary>
        /// エラーメッセージ表示処理
        /// </summary>
        /// <param name="ex">エラー内容</param> 
        /// <remark>エラーメッセージを表示します</remark>
        private void showErrorMessage(Exception ex)
        {
            // メッセージの編集
            var message = new StringBuilder();

            // メッセージの組み立て
            message.Remove(0, message.Length);            // クリア
            message.Append("エラーが発生しました。\n");
            message.Append("\n[エラータイプ]\n");
            message.Append(ex.GetType().ToString());
            message.Append("\n[メッセージ]\n");
            message.Append(ex.Message);
            message.Append("\n[StackTrace]\n");
            message.Append(ex.StackTrace);
            MessageBox.Show(message.ToString(), "ＤＢエラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        /// <summary>
        /// 接続エラー判定
        /// </summary>
        /// <returns>true：接続エラー false：それ以外</returns>
        private bool isConnectError()
        {
             string code = lastError.Substring(0, 5);
             if (code == "08000" || code == "08003"
                    || code == "08006" || code == "08001"
                    || code == "08004" || code == "08007"
                    || code == "08P01")
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 接続エラー判定
        /// </summary>
        /// <param name="errorMessage">エラーメッセージ</param>
        /// <returns>true：接続エラー false：それ以外</returns>
        private bool isConnectError(string errorMessage)
        {
            if (0 <= errorMessage.IndexOf("オブジェクト"))
            {
                return true;
            }
            return false;
        }

        //  [回線再接続時にログ出力]
        #region // システムログ　出力
        /// <summary> 
        /// システムログ　出力
        /// </summary>
        /// <param name="bunruiCd">分類コード</param>
        /// <param name="loginId">ログインID</param> 
        /// <param name="biko">備考</param>
        /// <returns>成功したらTrue　エラーでFalse</returns>
        /// <remark>システムログ　出力</remark>
        public bool WriteSystemLog(string bunruiCd, string loginId, string biko)
        {
            bool retflg = false;
            for (int i = 0; i < 5; i++)
            {
                try
                {
                    //ログの書き込み
                    this.Sql.Clear();
                    this.Sql.Append("INSERT INTO log_data ");
                    this.Sql.Append("(LOGNO,LOGDATE,LOGTIME,PROGRAMID,BUNRUI,CLIENT,OPID,KANJID,BIKOU)");
                    this.Sql.Append(" VALUES(");

                    this.Sql.Append("nvl((SELECT MAX(LOGNO) + 1  NEWNO FROM DSECLOG_TBL WHERE LOGDATE = TO_CHAR(SYSDATE, 'YYYYMMDD') GROUP BY LOGDATE),1),");

                    this.Sql.Append("TO_CHAR(DATE, 'YYYYMMDD'),");
                    this.Sql.Append("TO_CHAR(DATE, 'HH24MI'),");
                    this.Sql.Append("'" + Path.GetFileNameWithoutExtension(Environment.GetCommandLineArgs()[0]) + "',");
                    this.Sql.Append("'" + bunruiCd + "',");
                    this.Sql.Append("'" + Environment.MachineName + "',");
                    this.Sql.Append("'" + loginId + "',");
                    this.Sql.Append("Null");
                    this.Sql.Append(",");
                    this.Sql.Append("'" + biko + "')");

                    this.command.CommandText = this.Sql.ToString();
                    this.Sql.Clear();

                    int rows = this.command.ExecuteNonQuery();

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