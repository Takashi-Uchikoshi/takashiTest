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
    /// 取引�?コンボ�?�?��スコントロール
    /// </summary>
    public partial class ctlComboBoxGc : GcComboBox
    {
        /// <summary>非選択時コー�?</summary>
        private const string CODE_NONE = "00";

        /// <summary>B2コモンオブジェク�?</summary>
        private B2Com b2Com;
        /// <summary>�??ブル�?</summary>
        private string tableMei = string.Empty;
        /// <summary>コード�??���?</summary>
        private string codeKomokumei = string.Empty;
        /// <summary>名称�?���?</summary>
        private string meishoKomokumei = string.Empty;
        
        /// <summary>コンボ�?�?��ス用�??タセ�?��</summary>
        private DataSet comboboxDataSet = new DataSet();

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ctlComboBoxGc()
        {
            InitializeComponent();
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="container">コン�?��ー</param>
        public ctlComboBoxGc(IContainer container)
            : base(container)
        {
            InitializeComponent();
        }

        /// <summary>
        /// 初期化�?�?
        /// </summary>
        /// <param name="Pb2Com">B2コモンオブジェク�?</param>
        /// <param name="table_nm">�??ブル�?</param>
        /// <param name="key_cd">コード�??���?</param>
        /// <param name="key_nm">名称�?���?</param>
        public void Init(B2Com Pb2Com, string table_nm, string key_cd, string key_nm)
        {
            this.b2Com = Pb2Com;
            this.tableMei = table_nm;
            this.codeKomokumei = key_cd;
            this.meishoKomokumei = key_nm;

            this.SetComboBoxDataSet();
        }

        /// <summary>
        /// 初期化�?�?
        /// </summary>
        /// <param name="Pb2Com">B2コモンオブジェク�?</param>
        /// <param name="table_nm">�??ブル�?</param>
        /// <param name="field_nm">キー�?���?</param>
        /// <param name="field_key">キー値</param>
        /// <param name="key_cd">コード�??���?</param>
        /// <param name="key_nm">名称�?���?</param>
        public void Init(B2Com Pb2Com, string table_nm, string field_nm, string field_key, string key_cd, string key_nm)
        {
            this.b2Com = Pb2Com;
            this.tableMei = table_nm;
            this.codeKomokumei = key_cd;
            this.meishoKomokumei = key_nm;

            SetComboBoxDataSet(field_nm, field_key);
        }

        /// <summary>
        /// コード取�?
        /// </summary>
        /// <returns>コー�?</returns>
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
        /// コード取�?
        /// </summary>
        /// <param name="pintINDEX">イン�?��クス値</param>
        /// <returns>コー�?</returns>
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
        /// イン�?��クス値取�?
        /// </summary>
        /// <param name="pstrCODE">コー�?</param>
        /// <returns>イン�?��クス値</returns>
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
        /// �??タ取�?
        /// </summary>
        /// <param name="pstrColumnName">�?��名称</param>
        /// <returns>�??タ</returns>
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
        /// �??タ取�?
        /// </summary>
        /// <param name="pintINDEX">イン�?��クス値</param>
        /// <param name="pstrColumnName">�?��名称</param>
        /// <returns>�??タ</returns>
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
                MessageBox.Show("コンボ�?�?��スには'" + pstrColumnName + "'と�?���?��がありません。�?�?��継続します�??", "確�?", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                return null;
            }
        }

        /// <summary>
        /// コンボ�?�?��スDataSet�??タ設�?
        /// </summary>
        private void SetComboBoxDataSet()
        {
            try
            {
                // 使用�??タセ�?��?�テーブル?��?初期�?
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

                // マスタ�??�取得用SQL
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

                // コントロールパラメータ設�?
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
        /// コンボ�?�?��スDataSet�??タ設�?
        /// </summary>
        /// <param name="field_nm">キー�?���?</param>
        /// <param name="field_key">キー値</param>
        private void SetComboBoxDataSet(string field_nm, string field_key)
        {
            try
            {
                // 使用�??タセ�?��?�テーブル?��?初期�?
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

                // コンボ�?�?��ス用�??�取�?
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

                // コントロールパラメータ設�?
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
