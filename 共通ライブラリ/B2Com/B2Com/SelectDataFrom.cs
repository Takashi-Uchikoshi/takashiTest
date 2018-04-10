using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;


namespace B2.Com
{
    /// <summary>
    /// テーブルデータ一覧表示選択フォームクラス
    /// </summary>
    public partial class SelectDataForm : Form
    {
        /// <summary>選択行データ</summary>
        public string[] SelectRowData = new string[1] { "" };
        /// <summary>明細行数</summary>
        public int MeisaiGyosu = 0;

        /// <summary>
        /// フォームのタイトル
        /// </summary>
        public string Title
        {
            get { return this.Text; }
            set { this.Text = value; }
        }

        /// <summary> B2コモンオブジェクト </summary>
        private B2Com b2Com;
        /// <summary> フィルターフラグ </summary>
        private bool filterFlag = false;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="pb2Com">B2コモンオブジェクト</param>
        public SelectDataForm(B2Com pb2Com)
        {
            // Windows フォーム デザイナ サポートに必要です。
            InitializeComponent();

            this.b2Com = pb2Com;
            this.filterFlag = true;
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="pb2Com">B2コモンオブジェクト</param>
        /// <param name="pblnFilter">フィルターフラグ</param>
        public SelectDataForm(B2Com pb2Com, bool pblnFilter)
        {
            // Windows フォーム デザイナ サポートに必要です。
            InitializeComponent();

            this.b2Com = pb2Com;
            this.filterFlag = pblnFilter;
        }

        /// <summary>
        /// 画面クリア処理
        /// </summary>
        /// <returns>成否</returns>
        /// <remarks>画面をクリアします</remarks>
        private bool ClearScreen()
        {
            try
            {
                spdList.EditModeReplace = true;
                spdList_Sheet1.RowCount = 0;

                spdFilter.EditModeReplace = true;
                spdFilter_Sheet1.RowCount = 0;
                spdFilter_Sheet1.ColumnCount = 1;
                spdFilter_Sheet1.Columns[0].CellType = new FarPoint.Win.Spread.CellType.TextCellType();

                spdFilter.Visible = filterFlag;
                btnReView.Visible = filterFlag;
                if (filterFlag == false)
                {
                    int lintTop = 0;
                    lintTop = spdList.Top + spdList.Height + 6;
                    btnOk.Top = lintTop;
                    btnCancel.Top = lintTop;
                    this.Height = lintTop + btnOk.Height + 46;
                }

                return true;
            }
            catch (Exception ex)
            {
                this.b2Com.ShowErrMsg(ex);
                return false;
            }
        }

        /// <summary>
        /// 一覧表示処理
        /// </summary>
        /// <returns>成否</returns>
        /// <remarks>コースの一覧を表示します</remarks>
        private bool DisplayData()
        {
            try
            {
                int lintI = 0;
                int lintColumnWidth = 0;

                this.MeisaiGyosu = 0;
                spdList_Sheet1.RowCount = 0;
                spdList_Sheet1.ColumnCount = 0;

                if (this.b2Com.PgLib.Sql.ToString().Length <= 0)
                {
                    return false;
                }

                using (NpgsqlDataReader lOraDSRead = this.b2Com.PgLib.SelectSql_NoCache())
                {
                    if (lOraDSRead == null)
                    {
                        return false;
                    }

                    spdList_Sheet1.ColumnCount = lOraDSRead.FieldCount;
                    for (lintI = 0; lintI < lOraDSRead.FieldCount; lintI++)
                    {
                        spdList_Sheet1.ColumnHeader.Cells.Get(0, lintI).Text = lOraDSRead.GetName(lintI);
                        spdList_Sheet1.Columns[lintI].AllowAutoSort = false;
                    }

                    while (lOraDSRead.Read() == true)
                    {
                        spdList_Sheet1.RowCount += 1;
                        int lintRow = spdList_Sheet1.RowCount - 1;
                        for (lintI = 0; lintI < spdList_Sheet1.ColumnCount; lintI++)
                        {
                            spdList_Sheet1.Cells[lintRow, lintI].Value = lOraDSRead[lintI].ToString().Trim();
                            spdList_Sheet1.Cells[lintRow, lintI].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
                            spdList_Sheet1.Cells[lintRow, lintI].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
                        }
                    }
                    lOraDSRead.Close();

                    // 列幅を自動調整します
                    // 識別子が半角スペース" "の物は列幅を0とする事で非表示にします
                    for (lintI = 0; lintI < spdList_Sheet1.ColumnCount; lintI++)
                    {
                        lintColumnWidth = int.Parse(spdList_Sheet1.GetPreferredColumnWidth(lintI).ToString());
                        if (spdList_Sheet1.ColumnHeader.Cells.Get(0, lintI).Text.Trim().Length <= 0)
                        {
                            lintColumnWidth = 0;
                        }
                        spdList_Sheet1.SetColumnWidth(lintI, lintColumnWidth);
                    }
                }

                this.MeisaiGyosu = spdList_Sheet1.RowCount;

                if (DisplayFilter() == false)
                {
                    return false;
                }

                if (spdList_Sheet1.ColumnCount > 4)
                {
                    this.Width = 980;
                    spdList.Width = 950;
                }
                else
                {
                    this.Width = 688;
                    spdList.Width = 658;
                }

                return true;
            }
            catch (Exception ex)
            {
                this.b2Com.ShowErrMsg(ex);
                return false;
            }
        }

        /// <summary>
        /// 画面初期化処理
        /// </summary>
        /// <returns>成否</returns>
        /// <remarks>画面を初期化します</remarks>
        private bool Initialize()
        {
            try
            {
                spdList.FocusRenderer = new FarPoint.Win.Spread.SolidFocusIndicatorRenderer(Color.Blue, 2);

                if (ClearScreen() == false)
                {
                    return false;
                }

                if (DisplayData() == false)
                {
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                this.b2Com.ShowErrMsg(ex);
                return false;
            }
        }

        /// <summary>
        /// フィルタ一覧表示
        /// </summary>
        /// <returns>true:正常終了 false:エラー</returns>
        private bool DisplayFilter()
        {
            try
            {
                int lintI = 0;
                int lintColumnWidth = 0;
                string lstrTmp = "";

                spdFilter_Sheet1.RowCount = 0;

                if (spdList_Sheet1.ColumnCount <= 0)
                {
                    return false;
                }
                spdFilter_Sheet1.RowCount = spdList_Sheet1.ColumnCount;
                for (lintI = 0; lintI < spdFilter_Sheet1.RowCount; lintI++)
                {
                    lstrTmp = spdList_Sheet1.ColumnHeader.Cells.Get(0, lintI).Text;
                    spdFilter_Sheet1.RowHeader.Cells.Get(lintI, 0).Text = lstrTmp;
                    spdFilter_Sheet1.Rows[lintI].Visible = (lstrTmp.Trim() == "") ? false : true;
                    spdFilter_Sheet1.Cells[lintI, 0].Value = "";
                    spdFilter_Sheet1.Cells[lintI, 0].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
                    spdFilter_Sheet1.Cells[lintI, 0].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
                }

                // フィルター行の列、行ヘッダのタイトル列幅を自動調整します
                lintColumnWidth = int.Parse(spdFilter_Sheet1.RowHeader.Columns[0].GetPreferredWidth().ToString());
                spdFilter_Sheet1.RowHeader.Columns[0].Width = lintColumnWidth;
                lintColumnWidth = spdFilter.Width - lintColumnWidth - 21;
                if (lintColumnWidth < 100)
                {
                    lintColumnWidth = 100;
                }
                spdFilter_Sheet1.Columns[0].Width = lintColumnWidth;
                return true;
            }
            catch (Exception ex)
            {
                this.b2Com.ShowErrMsg(ex);
                return false;
            }
        }

        /// <summary>
        /// 再表示
        /// </summary>
        /// <returns>true:正常終了 false:エラー</returns>
        private bool RedisplayData()
        {
            // フィルタ指定に合わせて一覧表を表示します
            try
            {
                int lintI = 0;
                int lintJ = 0;
                int lintCount = 0;
                string lstrTmp = "";
                bool[] lblnVisible;

                if (spdFilter_Sheet1.RowCount != spdList_Sheet1.ColumnCount)
                {
                    return false;
                }

                lintCount = spdFilter_Sheet1.RowCount;
                lblnVisible = new bool[spdList_Sheet1.RowCount];
                for (lintI = 0; lintI < spdList_Sheet1.RowCount; lintI++)
                {
                    lblnVisible[lintI] = true;
                }

                for (lintI = 0; lintI < spdList_Sheet1.RowCount; lintI++)
                {
                    if (lblnVisible[lintI] == false)
                    {
                        continue;
                    }
                    for (lintJ = 0; lintJ < spdFilter_Sheet1.RowCount; lintJ++)
                    {
                        if (spdFilter_Sheet1.Rows[lintJ].Visible == false)
                        {
                            continue;
                        }
                        if (spdFilter_Sheet1.Cells[lintJ, 0].Value == null)
                        {
                            continue;
                        }
                        lstrTmp = spdFilter_Sheet1.Cells[lintJ, 0].Value.ToString().Trim();
                        if (lstrTmp == "")
                        {
                            continue;
                        }
                        if (spdList_Sheet1.Cells[lintI, lintJ].Value.ToString().IndexOf(lstrTmp) < 0)
                        {
                            lblnVisible[lintI] = false;
                        }
                    }
                }

                for (lintI = 0; lintI < spdList_Sheet1.RowCount; lintI++)
                {
                    spdList_Sheet1.Rows[lintI].Visible = lblnVisible[lintI];
                }

                return true;
            }
            catch (Exception ex)
            {
                this.b2Com.ShowErrMsg(ex);
                return false;
            }
        }

        /// <summary>
        /// フォームロード
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectDataForm_Load(object sender, EventArgs e)
        {
            Initialize();
        }

        /// <summary>
        /// キャンセルボタン選択時処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>画面を終了します</remarks>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// 選択決定ボタン選択時処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            // 選択した行データを保存して画面を閉じます
            try
            {
                int lintI = 0;

                if (spdList_Sheet1.RowCount <= 0)
                {
                    return;
                }
                if (spdList_Sheet1.Rows[spdList_Sheet1.ActiveRowIndex].Visible == false)
                {
                    return;
                }

                this.SelectRowData = new string[spdList_Sheet1.ColumnCount];
                for (lintI = 0; lintI < spdList_Sheet1.ColumnCount; lintI++)
                {
                    this.SelectRowData[lintI] = spdList_Sheet1.Cells[spdList_Sheet1.ActiveRowIndex, lintI].Value.ToString();
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                this.b2Com.ShowErrMsg(ex);
            }
        }

        /// <summary>
        /// 一覧ダブルクリック時処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>選択決定ボタンをクリックした時と同等の処理を行います</remarks>
        private void spdCosList_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            try
            {
                btnOk.PerformClick();
            }
            catch (Exception ex)
            {
                this.b2Com.ShowErrMsg(ex);
            }
        }

        /// <summary>
        /// 一覧KeyDown時処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>選択決定ボタンをクリックした時と同等の処理を行います</remarks>
        private void spdList_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                switch (e.KeyCode)
                {
                    case Keys.Enter:
                        btnOk.PerformClick();
                        break;
                }
            }
            catch (Exception ex)
            {
                this.b2Com.ShowErrMsg(ex);
            }
        }

        /// <summary>
        /// 再表示ボタンクリックイベント
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void btnReView_Click(object sender, EventArgs e)
        {
            try
            {
                RedisplayData();
            }
            catch (Exception ex)
            {
                this.b2Com.ShowErrMsg(ex);
            }
        }
    }
}
