namespace B2.Com
{
    partial class frmSelectData
    {
        /// <summary>
        /// 必要なデザイナ変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナで生成されたコード

        /// <summary>
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディタで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            FarPoint.Win.Spread.TipAppearance tipAppearance1 = new FarPoint.Win.Spread.TipAppearance();
            FarPoint.Win.Spread.TipAppearance tipAppearance2 = new FarPoint.Win.Spread.TipAppearance();
            this.spdList = new FarPoint.Win.Spread.FpSpread();
            this.spdList_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.spdFilter = new FarPoint.Win.Spread.FpSpread();
            this.spdFilter_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.btnReView = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.spdList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdList_Sheet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdFilter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdFilter_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // spdList
            // 
            this.spdList.About = "2.5.2012.2005";
            this.spdList.AccessibleDescription = "spdList, Sheet1, Row 0, Column 0, ";
            this.spdList.BackColor = System.Drawing.SystemColors.Control;
            this.spdList.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdList.Location = new System.Drawing.Point(12, 12);
            this.spdList.Name = "spdList";
            this.spdList.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.spdList.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdList_Sheet1});
            this.spdList.Size = new System.Drawing.Size(658, 342);
            this.spdList.TabIndex = 0;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.spdList.TextTipAppearance = tipAppearance1;
            this.spdList.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdList.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.spdCosList_CellDoubleClick);
            this.spdList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.spdList_KeyDown);
            // 
            // spdList_Sheet1
            // 
            this.spdList_Sheet1.Reset();
            this.spdList_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdList_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.spdList_Sheet1.ColumnCount = 1;
            this.spdList_Sheet1.RowCount = 1;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "-";
            this.spdList_Sheet1.ColumnHeader.Rows.Get(0).Height = 34F;
            this.spdList_Sheet1.Columns.Get(0).Label = "-";
            this.spdList_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(0).Width = 100F;
            this.spdList_Sheet1.DataAutoCellTypes = false;
            this.spdList_Sheet1.DataAutoHeadings = false;
            this.spdList_Sheet1.DataAutoSizeColumns = false;
            this.spdList_Sheet1.HorizontalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, System.Drawing.Color.Black);
            this.spdList_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
            this.spdList_Sheet1.RowHeader.Columns.Default.Resizable = true;
            this.spdList_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this.spdList_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.spdList_Sheet1.VerticalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, System.Drawing.Color.Black);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(566, 455);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(103, 40);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "キャンセル";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(457, 455);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(103, 40);
            this.btnOk.TabIndex = 3;
            this.btnOk.Text = "選択決定";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // spdFilter
            // 
            this.spdFilter.About = "2.5.2012.2005";
            this.spdFilter.AccessibleDescription = "spdFilter, Sheet1, Row 0, Column 0, ";
            this.spdFilter.BackColor = System.Drawing.SystemColors.Control;
            this.spdFilter.EditModePermanent = true;
            this.spdFilter.EditModeReplace = true;
            this.spdFilter.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            this.spdFilter.Location = new System.Drawing.Point(12, 360);
            this.spdFilter.Name = "spdFilter";
            this.spdFilter.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.spdFilter.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdFilter_Sheet1});
            this.spdFilter.Size = new System.Drawing.Size(304, 135);
            this.spdFilter.TabIndex = 1;
            tipAppearance2.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance2.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            tipAppearance2.ForeColor = System.Drawing.SystemColors.InfoText;
            this.spdFilter.TextTipAppearance = tipAppearance2;
            // 
            // spdFilter_Sheet1
            // 
            this.spdFilter_Sheet1.Reset();
            this.spdFilter_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdFilter_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.spdFilter_Sheet1.ColumnCount = 1;
            this.spdFilter_Sheet1.RowCount = 1;
            this.spdFilter_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "フィルタ";
            this.spdFilter_Sheet1.Columns.Get(0).Label = "フィルタ";
            this.spdFilter_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdFilter_Sheet1.Columns.Get(0).Width = 204F;
            this.spdFilter_Sheet1.DataAutoCellTypes = false;
            this.spdFilter_Sheet1.DataAutoHeadings = false;
            this.spdFilter_Sheet1.DataAutoSizeColumns = false;
            this.spdFilter_Sheet1.HorizontalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, System.Drawing.Color.Black);
            this.spdFilter_Sheet1.Protect = false;
            this.spdFilter_Sheet1.RowHeader.Columns.Default.Resizable = true;
            this.spdFilter_Sheet1.VerticalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, System.Drawing.Color.Black);
            // 
            // btnReView
            // 
            this.btnReView.Location = new System.Drawing.Point(322, 455);
            this.btnReView.Name = "btnReView";
            this.btnReView.Size = new System.Drawing.Size(103, 40);
            this.btnReView.TabIndex = 2;
            this.btnReView.Text = "再表示";
            this.btnReView.UseVisualStyleBackColor = true;
            this.btnReView.Click += new System.EventHandler(this.btnReView_Click);
            // 
            // frmSelData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 507);
            this.Controls.Add(this.btnReView);
            this.Controls.Add(this.spdFilter);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.spdList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmSelData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "一覧表示";
            ((System.ComponentModel.ISupportInitialize)(this.spdList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdList_Sheet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdFilter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdFilter_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private FarPoint.Win.Spread.FpSpread spdList;
        private FarPoint.Win.Spread.SheetView spdList_Sheet1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private FarPoint.Win.Spread.FpSpread spdFilter;
        private FarPoint.Win.Spread.SheetView spdFilter_Sheet1;
        private System.Windows.Forms.Button btnReView;
    }

}