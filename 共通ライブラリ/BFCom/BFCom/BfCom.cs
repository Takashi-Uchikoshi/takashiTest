using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using B2.Com;

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

    }
}
