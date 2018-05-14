using B2.BestFunction.Entities;
using B2.Com;
using Npgsql;
using System;
using System.Text;
using System.Windows.Forms;


namespace B2.BestFunction
{
    /// <summary>
    /// BestFunction共通処理クラス
    /// </summary>
    public class BfCom
    {
        #region メニューテーブルアクセス
        /// <summary>
        /// プログラム名称取得
        /// </summary>
        /// <param name="b2com">共通パラメータ</param>
        /// <returns>日本語プログラム名称</returns>
        public string getProgramName(B2Com b2com)
        {
            StringBuilder lstrSQL = new StringBuilder();
            string data = b2com.ProgramId;

            lstrSQL.Append("select ");
            lstrSQL.Append("  program_name as data");
            lstrSQL.Append(" from  menu_data");
            lstrSQL.Append(" WHERE filename like '%" + b2com.ProgramId + "%'");

            NpgsqlDataReader reader = b2com.PgLib.SelectSql_NoCache(lstrSQL.ToString());
            if (reader != null)
            {
                if (reader.Read())
                {
                    if (DBNull.Value.Equals(reader["data"]))
                        return data;
                    data = reader["data"].ToString();
                }
                reader.Close();
                reader.Dispose();
                reader = null;
            }

            return data;
        }
        #endregion

        //**********************************************************************
        /// <summary>
        /// DBテーブル使用開始日・使用終了日 設定
        /// </summary>
        /// <remarks>
        /// ┌──┐
        /// │メモ│使用開始日を元に使用終了日を設定します。
        /// └──┘
        /// 以下の場合SQLエラーとなります
        /// ※ 同一主キー内にて使用開始日が重複していた場合NG
        /// ※ 使用開始日に0以外で日付変換不可の数値が入っていた場合NG
        /// </remarks>
        /// <param name="b2Com">共通パラメータ</param>
        /// <param name="pTableName">テーブル名称</param>
        /// <param name="pPrimaryKeys">主キー項目名称(使用開始日・使用終了日除く)</param>
        /// <param name="pStartUseDate">使用開始日項目名称</param>
        /// <param name="pEndUseDate">使用終了日項目名称</param>
        /// <returns>true:正常 false:異常</returns>
        //**********************************************************************
        public bool TorokuUseDate(B2Com b2Com, string pTableName, string[] pPrimaryKeys, string pStartUseDate, string pEndUseDate)
        {
            try
            {
                //--------------------------------------
                // 主キー項目名称を","区切りの文字列に変換
                //--------------------------------------
                string lPrimaryKeys = "";
                foreach (string lPrimaryKey in pPrimaryKeys)
                {
                    lPrimaryKeys += "," + lPrimaryKey;
                }
                if (lPrimaryKeys != "")
                {
                    lPrimaryKeys = lPrimaryKeys.Substring(1);
                }

                using (var context = new BfDbContext(b2Com))
                {
                    using (var transaction = b2Com.PgLib.Connection.BeginTransaction())
                    {
                        StringBuilder[] lSqls = new StringBuilder[2];

                        //--------------------------------------
                        // 同一主キー内にて使用開始日でソートした際の先頭の使用開始日をゼロにするSQL作成
                        //--------------------------------------
                        lSqls[0] = new StringBuilder();
                        lSqls[0].Clear();
                        lSqls[0].Append("\r\n UPDATE " + pTableName + " SET ");
                        lSqls[0].Append("\r\n        " + pStartUseDate + " = 0 ");
                        lSqls[0].Append("\r\n  WHERE ( ");
                        lSqls[0].Append("\r\n            " + lPrimaryKeys + " ");
                        lSqls[0].Append("\r\n          , " + pStartUseDate + " ");
                        lSqls[0].Append("\r\n        ) IN ( ");
                        lSqls[0].Append("\r\n                 SELECT " + lPrimaryKeys + " ");
                        lSqls[0].Append("\r\n                      , MIN (" + pStartUseDate + ") AS " + pStartUseDate + " ");
                        lSqls[0].Append("\r\n                   FROM " + pTableName + " ");
                        lSqls[0].Append("\r\n                  GROUP BY ");
                        lSqls[0].Append("\r\n                        " + lPrimaryKeys + " ");
                        lSqls[0].Append("\r\n             ) ");

                        //--------------------------------------
                        // 使用終了日を設定するSQL作成
                        //--------------------------------------
                        lSqls[1] = new StringBuilder();
                        lSqls[1].Clear();
                        lSqls[1].Append("\r\n UPDATE " + pTableName + " T1 SET ");
                        lSqls[1].Append("\r\n        " + pEndUseDate + " = COALESCE( ");
                        lSqls[1].Append("\r\n                                          ( ");
                        lSqls[1].Append("\r\n                                              SELECT TO_NUMBER(TO_CHAR((TO_DATE(TO_CHAR(MIN(T2." + pStartUseDate + "),'FM99999999'),'YYYYMMDD')-1),'YYYYMMDD'),'FM99999999') AS " + pEndUseDate + " ");
                        lSqls[1].Append("\r\n                                                FROM " + pTableName + " T2 ");
                        lSqls[1].Append("\r\n                                               WHERE T2." + pStartUseDate + " > T1." + pStartUseDate + " ");
                        foreach (string lPrimaryKey in pPrimaryKeys)
                        {
                            lSqls[1].Append("\r\n                                             AND T2." + lPrimaryKey + "   = T1." + lPrimaryKey + " ");
                        }
                        lSqls[1].Append("\r\n                                          ) ");
                        lSqls[1].Append("\r\n                                          , 99999999 ");
                        lSqls[1].Append("\r\n                                      ) ");


                        //------------------
                        // SQL実行
                        //------------------
                        foreach (StringBuilder lSql in lSqls)
                        {
                            var command = new NpgsqlCommand(lSql.ToString(), b2Com.PgLib.Connection);
                            try
                            {
                                command.ExecuteNonQuery();
                            }
                            catch (NpgsqlException)
                            {
                                transaction.Rollback();
                                MessageBox.Show("SQL:" + lSql.ToString(), "DBエラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;
                            }
                        }

                        //------------------
                        // コミット
                        //------------------
                        transaction.Commit();
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
