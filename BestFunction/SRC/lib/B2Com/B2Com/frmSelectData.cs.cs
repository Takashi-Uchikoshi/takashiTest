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
    public partial class frmSelectData : Form
    {
        #region  ■ グローバル変数 定義
        /// <summary> </summary>
        public string[] gstrRes = new string[1] { "" };

        /// <summary> </summary>
        public int gintRowCount = 0;
        #endregion

        //プロパティ

        /// <summary>
        /// フォームのタイトル
        /// </summary>
        public string Title
        {
            get { return this.Text; }
            set { this.Text = value; }
        }


        #region  ■ ローカル変数 定義
        /// <summary> PHARMAコモンオブジェクト </summary>
        private clsB2Com b2Com;

        /// <summary> フィルターフラグ </summary>
        private bool mblnFilter = false;
        #endregion

        #region  コンストラクタ

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="pPhCom">PHARMAコモンオブジェクト</param>
        public frmSelectData(clsB2Com pb2Com)
        {
            frmSelData_(pb2Com, true);
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="pPhCom">PHARMAコモンオブジェクト</param>
        /// <param name="pblnFilter">フィルターフラグ</param>
        public frmSelectData(clsB2Com pb2Com, bool pblnFilter)
        {
            frmSelData_(pb2Com, pblnFilter);
        }

        /// <summary>
        /// コンストラクタ実処理
        /// </summary>
        /// <param name="pPhCom">PHARMAコモンオブジェクト</param>
        /// <param name="pblnFilter">フィルターフラグ</param>
        private void frmSelData_(clsB2Com pb2Com, bool pblnFilter)
        {
            //---------------------------------------------------------------------------------
            //■ 引数保存
            //---------------------------------------------------------------------------------
            b2Com = pb2Com;
            mblnFilter = pblnFilter;

            //---------------------------------------------------------------------------------
            //■ Windows フォーム デザイナ サポートに必要です。
            //---------------------------------------------------------------------------------
            InitializeComponent();

            //---------------------------------------------------------------------------------
            //■ 初期化処理
            //---------------------------------------------------------------------------------
            mfncInit();
        }
        #endregion

        #region ☆ イベント関数

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
        /// <remarks>選択したコースのコードを取得し画面を終了します</remarks>
        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                int lintI = 0;

                //------------------------------------------------------------------------------
                // ■ 選択行確認
                //------------------------------------------------------------------------------
                if (spdList_Sheet1.RowCount <= 0)
                {
                    return;
                }
                if (spdList_Sheet1.Rows[spdList_Sheet1.ActiveRowIndex].Visible == false)
                {
                    return;
                }

                //------------------------------------------------------------------------------
                // ■ 選択行データ取得
                //------------------------------------------------------------------------------
                gstrRes = new string[spdList_Sheet1.ColumnCount];
                for (lintI = 0; lintI < spdList_Sheet1.ColumnCount; lintI++)
                {
                    gstrRes[lintI] = spdList_Sheet1.Cells[spdList_Sheet1.ActiveRowIndex, lintI].Value.ToString();
                }

                //------------------------------------------------------------------------------
                // ■ 画面終了
                //------------------------------------------------------------------------------
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                b2Com.ShowErrMsg(ex);
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
                b2Com.ShowErrMsg(ex);
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
                b2Com.ShowErrMsg(ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReView_Click(object sender, EventArgs e)
        {
            try
            {
                mfncDispReView();
            }
            catch (Exception ex)
            {
                b2Com.ShowErrMsg(ex);
            }
        }

        #endregion

        #region ☆ ユーザ定義関数

        /// <summary>
        /// 画面クリア処理
        /// </summary>
        /// <returns>成否</returns>
        /// <remarks>画面をクリアします</remarks>
        private bool mfncClearScreen()
        {
            try
            {
                spdList.EditModeReplace = true;
                spdList_Sheet1.RowCount = 0;

                spdFilter.EditModeReplace = true;
                spdFilter_Sheet1.RowCount = 0;
                spdFilter_Sheet1.ColumnCount = 1;
                spdFilter_Sheet1.Columns[0].CellType = new FarPoint.Win.Spread.CellType.TextCellType();

                spdFilter.Visible = mblnFilter;
                btnReView.Visible = mblnFilter;
                if (mblnFilter == false)
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
                b2Com.ShowErrMsg(ex);
                return false;
            }
        }

        /// <summary>
        /// 一覧表示処理
        /// </summary>
        /// <returns>成否</returns>
        /// <remarks>コースの一覧を表示します</remarks>
        private bool mfncDispData()
        {
            try
            {
                int lintI = 0;
                int lintColumnWidth = 0;

                //------------------------------------------------------------------------------
                // ■ データ初期化
                //------------------------------------------------------------------------------
                gintRowCount = 0;
                spdList_Sheet1.RowCount = 0;
                spdList_Sheet1.ColumnCount = 0;

                //------------------------------------------------------------------------------
                // ■ SQL確認
                //------------------------------------------------------------------------------
                if (b2Com.PostLib.SQL.ToString().Length <= 0)
                {
                    return false;
                }

                //------------------------------------------------------------------------------
                // ■ SQL実行
                //------------------------------------------------------------------------------
                using (NpgsqlDataReader lOraDSRead = b2Com.PostLib.SelectSQL_NoCache())
                {
                    if (lOraDSRead == null)
                    {
                        return false;
                    }

                    //--------------------------------------------------------------------------
                    // ◆ 列データ設定
                    //--------------------------------------------------------------------------
                    spdList_Sheet1.ColumnCount = lOraDSRead.FieldCount;
                    for (lintI = 0; lintI < lOraDSRead.FieldCount; lintI++)
                    {
                        spdList_Sheet1.ColumnHeader.Cells.Get(0, lintI).Text = lOraDSRead.GetName(lintI);
                        spdList_Sheet1.Columns[lintI].AllowAutoSort = false;
                    }

                    //--------------------------------------------------------------------------
                    // ◆ DB件数分LOOP
                    //--------------------------------------------------------------------------
                    while (lOraDSRead.Read() == true)
                    {
                        //----------------------------------------------------------------------
                        // ◇ 一覧表示
                        //----------------------------------------------------------------------
                        spdList_Sheet1.RowCount += 1;
                        int lintRow = spdList_Sheet1.RowCount - 1;
                        // データ設定
                        for (lintI = 0; lintI < spdList_Sheet1.ColumnCount; lintI++)
                        {
                            spdList_Sheet1.Cells[lintRow, lintI].Value = lOraDSRead[lintI].ToString().Trim();
                            spdList_Sheet1.Cells[lintRow, lintI].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
                            spdList_Sheet1.Cells[lintRow, lintI].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
                        }
                    }
                    lOraDSRead.Close();

                    //--------------------------------------------------------------------------
                    // ◆列幅を自動調整
                    //--------------------------------------------------------------------------
                    for (lintI = 0; lintI < spdList_Sheet1.ColumnCount; lintI++)
                    {
                        // 列幅取得
                        lintColumnWidth = int.Parse(spdList_Sheet1.GetPreferredColumnWidth(lintI).ToString());
                        // 識別子が半角スペース" "の物は列幅を0とする事で非表示にする
                        if (spdList_Sheet1.ColumnHeader.Cells.Get(0, lintI).Text.Trim().Length <= 0)
                        {
                            lintColumnWidth = 0;
                        }
                        //列幅設定
                        spdList_Sheet1.SetColumnWidth(lintI, lintColumnWidth);
                    }
                }

                //------------------------------------------------------------------------------
                // ■ 行数保管
                //------------------------------------------------------------------------------
                gintRowCount = spdList_Sheet1.RowCount;

                //------------------------------------------------------------------------------
                // ■ フィルタ一覧表示
                //------------------------------------------------------------------------------
                if (mfncDispFilter() == false)
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
                b2Com.ShowErrMsg(ex);
                return false;
            }
        }

        /// <summary>
        /// 画面初期化処理
        /// </summary>
        /// <returns>成否</returns>
        /// <remarks>画面を初期化します</remarks>
        private bool mfncInit()
        {
            try
            {
                //------------------------------------------------------------------------------
                // ■ 一覧初期化
                //------------------------------------------------------------------------------
                spdList.FocusRenderer = new FarPoint.Win.Spread.SolidFocusIndicatorRenderer(Color.Blue, 2);
                //------------------------------------------------------------------------------
                // ■ 画面クリア
                //------------------------------------------------------------------------------
                if (mfncClearScreen() == false)
                {
                    return false;
                }
                //------------------------------------------------------------------------------
                // ■ 一覧表示
                //------------------------------------------------------------------------------
                if (mfncDispData() == false)
                {
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
               b2Com.ShowErrMsg(ex);
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private bool mfncDispFilter()
        {
            try
            {
                int lintI = 0;
                int lintColumnWidth = 0;
                string lstrTmp = "";

                //------------------------------------------------------------------------------
                // ■ データ初期化
                //------------------------------------------------------------------------------
                spdFilter_Sheet1.RowCount = 0;

                //------------------------------------------------------------------------------
                // ■ フィルター行設定
                //------------------------------------------------------------------------------
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

                //------------------------------------------------------------------------------
                // ■ フィルター行タイトル列幅自動調整
                //------------------------------------------------------------------------------
                //行ヘッダ 列幅設定
                lintColumnWidth = int.Parse(spdFilter_Sheet1.RowHeader.Columns[0].GetPreferredWidth().ToString());
                spdFilter_Sheet1.RowHeader.Columns[0].Width = lintColumnWidth;
                //フィルタ 列幅設定
                lintColumnWidth = spdFilter.Width - lintColumnWidth - 21;
                if (lintColumnWidth < 100) { lintColumnWidth = 100; }
                spdFilter_Sheet1.Columns[0].Width = lintColumnWidth;
                return true;
            }
            catch (Exception ex)
            {
                b2Com.ShowErrMsg(ex);
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private bool mfncDispReView()
        {
            try
            {
                int lintI = 0;
                int lintJ = 0;
                int lintCount = 0;
                string lstrTmp = "";
                bool[] lblnVisible;

                //------------------------------------------------------------------------------
                // ■ フィルター初期化確認
                //------------------------------------------------------------------------------
                if (spdFilter_Sheet1.RowCount != spdList_Sheet1.ColumnCount)
                {
                    return false;
                }

                //------------------------------------------------------------------------------
                // ■ データ初期化
                //------------------------------------------------------------------------------
                lintCount = spdFilter_Sheet1.RowCount;
                lblnVisible = new bool[spdList_Sheet1.RowCount];
                for (lintI = 0; lintI < spdList_Sheet1.RowCount; lintI++)
                {
                    lblnVisible[lintI] = true;
                }

                //------------------------------------------------------------------------------
                // ■ フィルタ確認
                //------------------------------------------------------------------------------
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

                //------------------------------------------------------------------------------
                // ■ 表示有無設定
                //------------------------------------------------------------------------------
                for (lintI = 0; lintI < spdList_Sheet1.RowCount; lintI++)
                {
                    spdList_Sheet1.Rows[lintI].Visible = lblnVisible[lintI];
                }

                return true;
            }
            catch (Exception ex)
            {
                b2Com.ShowErrMsg(ex);
                return false;
            }
        }

        #endregion

    }
}
