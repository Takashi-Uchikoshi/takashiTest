using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using Npgsql;
using GrapeCity.Win.Editors;


namespace B2.Com
{
    /// <summary>
    /// åå¼å?ã³ã³ãã?ã?¯ã¹ã³ã³ãã­ã¼ã«
    /// </summary>
    public partial class ctlComboBoxGc : GcComboBox
    {
        /// <summary>éé¸ææã³ã¼ã?</summary>
        private const string CODE_NONE = "00";

        /// <summary>B2ã³ã¢ã³ãªãã¸ã§ã¯ã?</summary>
        private B2Com b2Com;
        /// <summary>ã??ãã«å?</summary>
        private string tableMei = string.Empty;
        /// <summary>ã³ã¼ãé??®å?</summary>
        private string codeKomokumei = string.Empty;
        /// <summary>åç§°é ?®å?</summary>
        private string meishoKomokumei = string.Empty;
        
        /// <summary>ã³ã³ãã?ã?¯ã¹ç¨ã??ã¿ã»ã?</summary>
        private DataSet comboboxDataSet = new DataSet();

        /// <summary>
        /// ã³ã³ã¹ãã©ã¯ã¿
        /// </summary>
        public ctlComboBoxGc()
        {
            InitializeComponent();
        }

        /// <summary>
        /// ã³ã³ã¹ãã©ã¯ã¿
        /// </summary>
        /// <param name="container">ã³ã³ã?ã¼</param>
        public ctlComboBoxGc(IContainer container)
            : base(container)
        {
            InitializeComponent();
        }

        /// <summary>
        /// åæåå?ç?
        /// </summary>
        /// <param name="Pb2Com">B2ã³ã¢ã³ãªãã¸ã§ã¯ã?</param>
        /// <param name="table_nm">ã??ãã«å?</param>
        /// <param name="key_cd">ã³ã¼ãé??®å?</param>
        /// <param name="key_nm">åç§°é ?®å?</param>
        public void Init(B2Com Pb2Com, string table_nm, string key_cd, string key_nm)
        {
            this.b2Com = Pb2Com;
            this.tableMei = table_nm;
            this.codeKomokumei = key_cd;
            this.meishoKomokumei = key_nm;

            this.SetComboBoxDataSet();
        }

        /// <summary>
        /// åæåå?ç?
        /// </summary>
        /// <param name="Pb2Com">B2ã³ã¢ã³ãªãã¸ã§ã¯ã?</param>
        /// <param name="table_nm">ã??ãã«å?</param>
        /// <param name="field_nm">ã­ã¼é ?®å?</param>
        /// <param name="field_key">ã­ã¼å¤</param>
        /// <param name="key_cd">ã³ã¼ãé??®å?</param>
        /// <param name="key_nm">åç§°é ?®å?</param>
        public void Init(B2Com Pb2Com, string table_nm, string field_nm, string field_key, string key_cd, string key_nm)
        {
            this.b2Com = Pb2Com;
            this.tableMei = table_nm;
            this.codeKomokumei = key_cd;
            this.meishoKomokumei = key_nm;

            SetComboBoxDataSet(field_nm, field_key);
        }

        /// <summary>
        /// ã³ã¼ãåå¾?
        /// </summary>
        /// <returns>ã³ã¼ã?</returns>
        public string GetCode()
        {
            try
            {
                return this.GetCode(this.SelectedIndex);
            }
            catch (Exception ex)
            {
                this.b2Com.ShowErrMsg(ex);
                return "";
            }
        }

        /// <summary>
        /// ã³ã¼ãåå¾?
        /// </summary>
        /// <param name="pintINDEX">ã¤ã³ã?ã¯ã¹å¤</param>
        /// <returns>ã³ã¼ã?</returns>
        public string GetCode(int pintINDEX)
        {
            try
            {
                string lstrR = "";

                if (pintINDEX < 0)
                {
                    return "";
                }

                lstrR = this.comboboxDataSet.Tables[this.tableMei].Rows[pintINDEX]["CODE"].ToString();
                if (lstrR == CODE_NONE)
                {
                    lstrR = "";
                }

                return lstrR;
            }
            catch (Exception ex)
            {
                this.b2Com.ShowErrMsg(ex);
                return "";
            }
        }

        /// <summary>
        /// ã¤ã³ã?ã¯ã¹å¤åå¾?
        /// </summary>
        /// <param name="pstrCODE">ã³ã¼ã?</param>
        /// <returns>ã¤ã³ã?ã¯ã¹å¤</returns>
        public int GetIndex(string pstrCODE)
        {
            try
            {
                int lintR = 0;
                DataRow[] lRows = this.comboboxDataSet.Tables[this.tableMei].Select("CODE='" + pstrCODE.ToString() + "'");
                foreach (DataRow lRow in lRows)
                {
                    lintR = (int)lRow["INDEX"];
                }
                return lintR;
            }
            catch (Exception ex)
            {
                this.b2Com.ShowErrMsg(ex);
                return -1;
            }
        }

        /// <summary>
        /// ã??ã¿åå¾?
        /// </summary>
        /// <param name="pstrColumnName">é ?®åç§°</param>
        /// <returns>ã??ã¿</returns>
        public object GetData(string pstrColumnName)
        {
            try
            {
                return this.GetData(this.SelectedIndex, pstrColumnName);
            }
            catch (Exception ex)
            {
                this.b2Com.ShowErrMsg(ex);
                return "";
            }
        }

        /// <summary>
        /// ã??ã¿åå¾?
        /// </summary>
        /// <param name="pintINDEX">ã¤ã³ã?ã¯ã¹å¤</param>
        /// <param name="pstrColumnName">é ?®åç§°</param>
        /// <returns>ã??ã¿</returns>
        public object GetData(int pintINDEX, string pstrColumnName)
        {
            try
            {
                if (pintINDEX < 0)
                {
                    return CnvStr.TypeConv("", this.comboboxDataSet.Tables[this.tableMei].Columns[pstrColumnName].DataType);
                }

                return this.comboboxDataSet.Tables[this.tableMei].Rows[pintINDEX][pstrColumnName];
            }
            catch
            {
                MessageBox.Show("ã³ã³ãã?ã?¯ã¹ã«ã¯'" + pstrColumnName + "'ã¨ã?é ?®ãããã¾ãããå?ç?ç¶ç¶ãã¾ãã??", "ç¢ºèª?", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                return null;
            }
        }

        /// <summary>
        /// ã³ã³ãã?ã?¯ã¹DataSetã??ã¿è¨­å®?
        /// </summary>
        private void SetComboBoxDataSet()
        {
            try
            {
                // ä½¿ç¨ã??ã¿ã»ã??ãã¼ãã«?ã?åæå?
                if (this.comboboxDataSet.Tables.Count > 0)
                {
                    int i;
                    i = this.comboboxDataSet.Tables.Count;
                    for (int j = 0; j < i; j++)
                    {
                        if (this.comboboxDataSet.Tables[j].TableName == this.tableMei)
                        {
                            this.comboboxDataSet.Tables.Remove(this.tableMei);
                            break;
                        }
                    }
                }

                // ãã¹ã¿æ??±åå¾ç¨SQL
                this.b2Com.PgLib.Sql.Clear();
                this.b2Com.PgLib.Sql.Append("\r\n SELECT '0'  AS CODE  ");
                this.b2Com.PgLib.Sql.Append("\r\n      , '' AS NAME  ");
                this.b2Com.PgLib.Sql.Append("\r\n      , 0  AS INDEX  ");
                this.b2Com.PgLib.Sql.Append("\r\n UNION ALL  ");
                this.b2Com.PgLib.Sql.Append("\r\n SELECT " + this.codeKomokumei + "  AS CODE ");
                this.b2Com.PgLib.Sql.Append("\r\n      , " + this.meishoKomokumei + "  AS NAME ");
                this.b2Com.PgLib.Sql.Append("\r\n      , (ROW_NUMBER() OVER (ORDER BY " + this.codeKomokumei + ")) AS \"INDEX\" ");
                this.b2Com.PgLib.Sql.Append("\r\n   FROM " + this.tableMei + " ");
                this.b2Com.PgLib.Sql.Append("\r\n ORDER BY INDEX ");

                NpgsqlDataAdapter oAdp = new NpgsqlDataAdapter(this.b2Com.PgLib.Sql.ToString(), this.b2Com.PgLib.Connection);

                oAdp.Fill(this.comboboxDataSet, this.tableMei);

                // ã³ã³ãã­ã¼ã«ãã©ã¡ã¼ã¿è¨­å®?
                this.DataSource = this.comboboxDataSet.Tables[this.tableMei];
                
                this.ListColumns[0].Width = 28;
                this.ListColumns[1].Width = 240;
                for (int lintCol = 2; lintCol < this.ListColumns.Count; lintCol++)
                {
                    this.ListColumns[lintCol].Visible = false;
                }
                this.ListHeaderPane.Visible = false;
                this.DropDown.AutoWidth = true;
                this.TextSubItemIndex = 1;
                this.AutoComplete.MatchingMode = AutoCompleteMatchingMode.AmbiguousMatchAll;
            }
            catch (Exception ex)
            {
                this.b2Com.ShowErrMsg(ex);
            }
        }

        /// <summary>
        /// ã³ã³ãã?ã?¯ã¹DataSetã??ã¿è¨­å®?
        /// </summary>
        /// <param name="field_nm">ã­ã¼é ?®å?</param>
        /// <param name="field_key">ã­ã¼å¤</param>
        private void SetComboBoxDataSet(string field_nm, string field_key)
        {
            try
            {
                // ä½¿ç¨ã??ã¿ã»ã??ãã¼ãã«?ã?åæå?
                if (this.comboboxDataSet.Tables.Count > 0)
                {
                    int i;
                    i = this.comboboxDataSet.Tables.Count;
                    for (int j = 0; j < i; j++)
                    {
                        if (this.comboboxDataSet.Tables[j].TableName == this.tableMei)
                        {
                            this.comboboxDataSet.Tables.Remove(this.tableMei);
                            break;
                        }
                    }
                }

                // ã³ã³ãã?ã?¯ã¹ç¨æ??±åå¾?
                this.b2Com.PgLib.Sql.Clear();
                this.b2Com.PgLib.Sql.Append("\r\n SELECT " + this.codeKomokumei + "  AS CODE ");
                this.b2Com.PgLib.Sql.Append("\r\n      , " + this.meishoKomokumei + "  AS NAME ");
                this.b2Com.PgLib.Sql.Append("\r\n      , (ROW_NUMBER() OVER (ORDER BY " + this.codeKomokumei + ")) AS \"INDEX\" " );
                this.b2Com.PgLib.Sql.Append("\r\n   FROM " + this.tableMei + " ");
                this.b2Com.PgLib.Sql.Append("\r\n  WHERE " + field_nm + " = '" + field_key + "'");
                this.b2Com.PgLib.Sql.Append("\r\n ORDER BY INDEX ");

                NpgsqlDataAdapter oAdp = new NpgsqlDataAdapter(b2Com.PgLib.Sql.ToString(),
                        b2Com.PgLib.Connection);


                oAdp.Fill(this.comboboxDataSet, this.tableMei);

                // ã³ã³ãã­ã¼ã«ãã©ã¡ã¼ã¿è¨­å®?
                this.DataSource = this.comboboxDataSet.Tables[this.tableMei];

                this.ListColumns[0].Width = 28;
                this.ListColumns[1].Width = 240;
                for (int lintCol = 2; lintCol < this.ListColumns.Count; lintCol++)
                {
                    this.ListColumns[lintCol].Visible = false;
                }
                this.ListHeaderPane.Visible = false;
                this.DropDown.AutoWidth = true;
                this.TextSubItemIndex = 1;
                this.AutoComplete.MatchingMode = GrapeCity.Win.Editors.AutoCompleteMatchingMode.AmbiguousMatchAll;

            }
            catch (Exception ex)
            {
                b2Com.ShowErrMsg(ex);
            }
        }
    }
}
