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
//
using Npgsql;


namespace B2.Com
{
    //******************************************************************************
    /// <summary>
    /// 取引先コンボボックスコントロール
    /// </summary>
    //******************************************************************************
    public partial class ctlComboBoxGc : GrapeCity.Win.Editors.GcComboBox
    {
        #region ローカル定数定義
        //******************************************************************************
        // ローカル定数定義
        //******************************************************************************
        /// <summary>非選択時コード</summary>
        private const string CODE_NONE = "00";
        #endregion

        #region ローカル変数定義
        //******************************************************************************
        // ローカル変数定義
        //******************************************************************************
        /// <summary>上位からの共通パラメータ</summary>
        private  clsB2Com b2Com;
        private string table_name = string.Empty;
        private string key_code = string.Empty;
        private string key_name = string.Empty;
        
        /// <summary>コンボボックス用データセット</summary>
        private DataSet dS_Combo = new DataSet();

        #endregion

        #region コンストラクタ
        //******************************************************************************
        // コンストラクタ
        //******************************************************************************
        //**********************************************************************
        /// <summary>
        /// コンストラクタ
        /// </summary>
        //**********************************************************************
        public ctlComboBoxGc()
        {
            InitializeComponent();
        }
        //**********************************************************************
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="container">コンテナー</param>
        //**********************************************************************
        public ctlComboBoxGc(IContainer container)
            : base(container)
        {
            InitializeComponent();
        }
        #endregion

        #region グローバル関数定義
        //******************************************************************************
        // グローバル関数定義
        //******************************************************************************
        //**********************************************************************
        /// <summary>
        /// 初期化処理
        /// </summary>
        /// <param name="PHCommon">共通モジュール</param>
        //**********************************************************************
        public void Init(clsB2Com Pb2Com, string table_nm, string key_cd, string key_nm)
        {
            //--------------------------------------
            // 共通パラメータをセット
            //--------------------------------------
            b2Com = Pb2Com;
            table_name = table_nm;
            key_code = key_cd;
            key_name = key_nm;

            //--------------------------------------
            // DBデータ取得
            //--------------------------------------
            mfnc_getComboDs();
        }

        //**********************************************************************
        /// <summary>
        /// コード取得
        /// </summary>
        /// <returns>コード</returns>
        //**********************************************************************
        public string getCode()
        {
            try
            {
                return getCode(this.SelectedIndex);
            }
            catch (Exception ex)
            {
                b2Com.ShowErrMsg(ex);
                return "";
            }
        }

        //**********************************************************************
        /// <summary>
        /// コード取得
        /// </summary>
        /// <param name="pintINDEX">インデックス値</param>
        /// <returns>コード</returns>
        //**********************************************************************
        public string getCode(int pintINDEX)
        {
            try
            {
                string lstrR = "";

                if (pintINDEX < 0)
                {
                    return "";
                }

                lstrR = dS_Combo.Tables[table_name].Rows[pintINDEX]["CODE"].ToString();
                if (lstrR == CODE_NONE)
                {
                    lstrR = "";
                }

                return lstrR;
            }
            catch (Exception ex)
            {
                b2Com.ShowErrMsg(ex);
                return "";
            }
        }

        //**********************************************************************
        /// <summary>
        /// インデックス値取得
        /// </summary>
        /// <param name="pstrCODE">コード</param>
        /// <returns>インデックス値</returns>
        //**********************************************************************
        public int getIndex(string pstrCODE)
        {
            try
            {
                int lintR = 0;
                DataRow[] lRows = dS_Combo.Tables[table_name].Select("CODE='" + pstrCODE.ToString() + "'");
                foreach (DataRow lRow in lRows)
                {
                    lintR = (int)lRow["INDEX"];
                }
                return lintR;
            }
            catch (Exception ex)
            {
                b2Com.ShowErrMsg(ex);
                return -1;
            }
        }

        //**********************************************************************
        /// <summary>
        /// データ取得
        /// </summary>
        /// <param name="pstrColumnName">項目名称</param>
        /// <returns>データ</returns>
        //**********************************************************************
        public object getData(string pstrColumnName)
        {
            try
            {
                return getData(this.SelectedIndex, pstrColumnName);
            }
            catch (Exception ex)
            {
                b2Com.ShowErrMsg(ex);
                return "";
            }
        }

        //**********************************************************************
        /// <summary>
        /// データ取得
        /// </summary>
        /// <param name="pintINDEX">インデックス値</param>
        /// <param name="pstrColumnName">項目名称</param>
        /// <returns>データ</returns>
        //**********************************************************************
        public object getData(int pintINDEX, string pstrColumnName)
        {
            try
            {
                if (pintINDEX < 0)
                {
                    return clsCnvStr.TypeConv("", dS_Combo.Tables[table_name].Columns[pstrColumnName].DataType);
                }

                return dS_Combo.Tables[table_name].Rows[pintINDEX][pstrColumnName];
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("コンボボックスには'" + pstrColumnName + "'という項目がありません。処理を継続します。", "確認", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                return null;
            }
        }
        #endregion

        #region ローカル関数定義
        //******************************************************************************
        // ローカル関数定義
        //******************************************************************************
        //**********************************************************************
        /// <summary>
        /// 発注先コンボボックス：DBデータ取得
        /// </summary>
        //**********************************************************************
        private void mfnc_getComboDs()
        {
            try
            {

                //--------------------------------------
                // 使用データセット（テーブル）の初期化
                //--------------------------------------
                if (dS_Combo.Tables.Count > 0)
                {
                    int i;
                    i = dS_Combo.Tables.Count;
                    for (int j = 0; j < i; j++)
                    {
                        if (dS_Combo.Tables[j].TableName == table_name)
                        {
                            dS_Combo.Tables.Remove(table_name);
                            break;
                        }
                    }
                }

                //--------------------------------------
                // マスタ情報取得用SQL
                //--------------------------------------
                b2Com.PostLib.SQLClear();
                b2Com.PostLib.SQL.Append("\r\n SELECT 0  AS CODE  ");
                b2Com.PostLib.SQL.Append("\r\n , ''  AS NAME  ");
                b2Com.PostLib.SQL.Append("\r\n , 0 as INDEX  ");
                b2Com.PostLib.SQL.Append("\r\n union all  ");
                b2Com.PostLib.SQL.Append("\r\n SELECT " + key_code + "  AS CODE ");
                b2Com.PostLib.SQL.Append("\r\n      , " + key_name + "  AS NAME ");
                b2Com.PostLib.SQL.Append("\r\n      , (ROW_NUMBER() OVER (ORDER BY " + key_code + ")) AS \"INDEX\" ");
                //b2Com.PostLib.SQL.Append("\r\n      , * ");
                b2Com.PostLib.SQL.Append("\r\n   FROM " + table_name + " ");
                b2Com.PostLib.SQL.Append("\r\n ORDER BY CODE ");

                NpgsqlDataAdapter oAdp = new NpgsqlDataAdapter(b2Com.PostLib.SQL.ToString(),
                        b2Com.PostLib.Session);

                oAdp.Fill(dS_Combo, table_name);

                ////--------------------------------------
                //// 空白行追加
                ////--------------------------------------
                //{
                //    DataRow lRow;
                //    lRow = dS_Combo.Tables[table_name].NewRow();
                //    clsCnvStr.InitDatarow(ref lRow);
                //    lRow["CODE"] = CODE_NONE;
                //    lRow["NAME"] = "";
                //    lRow["INDEX"] = 0;
                //    dS_Combo.Tables[table_name].Rows.Add(lRow);
                //}

                //--------------------------------------
                // コントロールパラメータ設定
                //--------------------------------------
                this.DataSource = dS_Combo.Tables[table_name];
                
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
        #endregion
    }
}
