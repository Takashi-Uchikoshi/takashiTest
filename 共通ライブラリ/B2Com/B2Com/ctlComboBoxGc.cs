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
    /// å–å¼•å?ã‚³ãƒ³ãƒœã?ãƒ?‚¯ã‚¹ã‚³ãƒ³ãƒˆãƒ­ãƒ¼ãƒ«
    /// </summary>
    public partial class ctlComboBoxGc : GcComboBox
    {
        /// <summary>éé¸æŠæ™‚ã‚³ãƒ¼ãƒ?</summary>
        private const string CODE_NONE = "00";

        /// <summary>B2ã‚³ãƒ¢ãƒ³ã‚ªãƒ–ã‚¸ã‚§ã‚¯ãƒ?</summary>
        private B2Com b2Com;
        /// <summary>ãƒ??ãƒ–ãƒ«å?</summary>
        private string tableMei = string.Empty;
        /// <summary>ã‚³ãƒ¼ãƒ‰é??›®å?</summary>
        private string codeKomokumei = string.Empty;
        /// <summary>åç§°é ?›®å?</summary>
        private string meishoKomokumei = string.Empty;
        
        /// <summary>ã‚³ãƒ³ãƒœã?ãƒ?‚¯ã‚¹ç”¨ãƒ??ã‚¿ã‚»ãƒ?ƒˆ</summary>
        private DataSet comboboxDataSet = new DataSet();

        /// <summary>
        /// ã‚³ãƒ³ã‚¹ãƒˆãƒ©ã‚¯ã‚¿
        /// </summary>
        public ctlComboBoxGc()
        {
            InitializeComponent();
        }

        /// <summary>
        /// ã‚³ãƒ³ã‚¹ãƒˆãƒ©ã‚¯ã‚¿
        /// </summary>
        /// <param name="container">ã‚³ãƒ³ãƒ?ƒŠãƒ¼</param>
        public ctlComboBoxGc(IContainer container)
            : base(container)
        {
            InitializeComponent();
        }

        /// <summary>
        /// åˆæœŸåŒ–å?ç?
        /// </summary>
        /// <param name="Pb2Com">B2ã‚³ãƒ¢ãƒ³ã‚ªãƒ–ã‚¸ã‚§ã‚¯ãƒ?</param>
        /// <param name="table_nm">ãƒ??ãƒ–ãƒ«å?</param>
        /// <param name="key_cd">ã‚³ãƒ¼ãƒ‰é??›®å?</param>
        /// <param name="key_nm">åç§°é ?›®å?</param>
        public void Init(B2Com Pb2Com, string table_nm, string key_cd, string key_nm)
        {
            this.b2Com = Pb2Com;
            this.tableMei = table_nm;
            this.codeKomokumei = key_cd;
            this.meishoKomokumei = key_nm;

            this.SetComboBoxDataSet();
        }

        /// <summary>
        /// åˆæœŸåŒ–å?ç?
        /// </summary>
        /// <param name="Pb2Com">B2ã‚³ãƒ¢ãƒ³ã‚ªãƒ–ã‚¸ã‚§ã‚¯ãƒ?</param>
        /// <param name="table_nm">ãƒ??ãƒ–ãƒ«å?</param>
        /// <param name="field_nm">ã‚­ãƒ¼é ?›®å?</param>
        /// <param name="field_key">ã‚­ãƒ¼å€¤</param>
        /// <param name="key_cd">ã‚³ãƒ¼ãƒ‰é??›®å?</param>
        /// <param name="key_nm">åç§°é ?›®å?</param>
        public void Init(B2Com Pb2Com, string table_nm, string field_nm, string field_key, string key_cd, string key_nm)
        {
            this.b2Com = Pb2Com;
            this.tableMei = table_nm;
            this.codeKomokumei = key_cd;
            this.meishoKomokumei = key_nm;

            SetComboBoxDataSet(field_nm, field_key);
        }

        /// <summary>
        /// ã‚³ãƒ¼ãƒ‰å–å¾?
        /// </summary>
        /// <returns>ã‚³ãƒ¼ãƒ?</returns>
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
        /// ã‚³ãƒ¼ãƒ‰å–å¾?
        /// </summary>
        /// <param name="pintINDEX">ã‚¤ãƒ³ãƒ?ƒƒã‚¯ã‚¹å€¤</param>
        /// <returns>ã‚³ãƒ¼ãƒ?</returns>
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
        /// ã‚¤ãƒ³ãƒ?ƒƒã‚¯ã‚¹å€¤å–å¾?
        /// </summary>
        /// <param name="pstrCODE">ã‚³ãƒ¼ãƒ?</param>
        /// <returns>ã‚¤ãƒ³ãƒ?ƒƒã‚¯ã‚¹å€¤</returns>
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
        /// ãƒ??ã‚¿å–å¾?
        /// </summary>
        /// <param name="pstrColumnName">é ?›®åç§°</param>
        /// <returns>ãƒ??ã‚¿</returns>
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
        /// ãƒ??ã‚¿å–å¾?
        /// </summary>
        /// <param name="pintINDEX">ã‚¤ãƒ³ãƒ?ƒƒã‚¯ã‚¹å€¤</param>
        /// <param name="pstrColumnName">é ?›®åç§°</param>
        /// <returns>ãƒ??ã‚¿</returns>
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
                MessageBox.Show("ã‚³ãƒ³ãƒœã?ãƒ?‚¯ã‚¹ã«ã¯'" + pstrColumnName + "'ã¨ã?†é ?›®ãŒã‚ã‚Šã¾ã›ã‚“ã€‚å?ç?‚’ç¶™ç¶šã—ã¾ã™ã??", "ç¢ºèª?", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                return null;
            }
        }

        /// <summary>
        /// ã‚³ãƒ³ãƒœã?ãƒ?‚¯ã‚¹DataSetãƒ??ã‚¿è¨­å®?
        /// </summary>
        private void SetComboBoxDataSet()
        {
            try
            {
                // ä½¿ç”¨ãƒ??ã‚¿ã‚»ãƒ?ƒˆ?ˆãƒ†ãƒ¼ãƒ–ãƒ«?‰ã?åˆæœŸåŒ?
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

                // ãƒã‚¹ã‚¿æƒ??±å–å¾—ç”¨SQL
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

                // ã‚³ãƒ³ãƒˆãƒ­ãƒ¼ãƒ«ãƒ‘ãƒ©ãƒ¡ãƒ¼ã‚¿è¨­å®?
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
        /// ã‚³ãƒ³ãƒœã?ãƒ?‚¯ã‚¹DataSetãƒ??ã‚¿è¨­å®?
        /// </summary>
        /// <param name="field_nm">ã‚­ãƒ¼é ?›®å?</param>
        /// <param name="field_key">ã‚­ãƒ¼å€¤</param>
        private void SetComboBoxDataSet(string field_nm, string field_key)
        {
            try
            {
                // ä½¿ç”¨ãƒ??ã‚¿ã‚»ãƒ?ƒˆ?ˆãƒ†ãƒ¼ãƒ–ãƒ«?‰ã?åˆæœŸåŒ?
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

                // ã‚³ãƒ³ãƒœã?ãƒ?‚¯ã‚¹ç”¨æƒ??±å–å¾?
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

                // ã‚³ãƒ³ãƒˆãƒ­ãƒ¼ãƒ«ãƒ‘ãƒ©ãƒ¡ãƒ¼ã‚¿è¨­å®?
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
