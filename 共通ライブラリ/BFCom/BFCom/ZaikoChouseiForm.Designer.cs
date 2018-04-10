namespace B2.BestFunction
{
    partial class ZaikoChouseiForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType1 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType1 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType2 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType3 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType3 = new FarPoint.Win.Spread.CellType.TextCellType();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.fpS_Chousei = new FarPoint.Win.Spread.FpSpread();
            this.fpS_Chousei_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.btn_ok = new System.Windows.Forms.Button();
            this.btn_exit = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txt_yakuhinmei = new System.Windows.Forms.TextBox();
            this.gcTxt_gtin_code = new GrapeCity.Win.Editors.GcTextBox(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpS_Chousei)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpS_Chousei_Sheet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTxt_gtin_code)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.btn_ok);
            this.panel1.Controls.Add(this.btn_exit);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.txt_yakuhinmei);
            this.panel1.Controls.Add(this.gcTxt_gtin_code);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1020, 620);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.fpS_Chousei);
            this.panel3.Location = new System.Drawing.Point(34, 115);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(956, 420);
            this.panel3.TabIndex = 11;
            // 
            // fpS_Chousei
            // 
            this.fpS_Chousei.AccessibleDescription = "fpS_Chousei, Sheet1, Row 0, Column 0, True";
            this.fpS_Chousei.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fpS_Chousei.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            this.fpS_Chousei.Location = new System.Drawing.Point(0, 0);
            this.fpS_Chousei.Name = "fpS_Chousei";
            this.fpS_Chousei.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.fpS_Chousei_Sheet1});
            this.fpS_Chousei.Size = new System.Drawing.Size(956, 420);
            this.fpS_Chousei.TabIndex = 0;
            this.fpS_Chousei.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            // 
            // fpS_Chousei_Sheet1
            // 
            this.fpS_Chousei_Sheet1.Reset();
            this.fpS_Chousei_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fpS_Chousei_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fpS_Chousei_Sheet1.ColumnCount = 7;
            this.fpS_Chousei_Sheet1.RowCount = 10;
            this.fpS_Chousei_Sheet1.ActiveSkin = FarPoint.Win.Spread.DefaultSkins.Simple1;
            this.fpS_Chousei_Sheet1.Cells.Get(0, 0).Value = 1;
            this.fpS_Chousei_Sheet1.Cells.Get(0, 1).Value = "L1234567890123456789";
            this.fpS_Chousei_Sheet1.Cells.Get(0, 2).Value = "2019年3月30日";
            this.fpS_Chousei_Sheet1.Cells.Get(0, 3).CellPadding.Right = 2;
            this.fpS_Chousei_Sheet1.Cells.Get(0, 3).Value = 9999999999.9999D;
            this.fpS_Chousei_Sheet1.Cells.Get(0, 4).CellPadding.Right = 2;
            this.fpS_Chousei_Sheet1.Cells.Get(0, 4).Value = 9999999999.9999D;
            this.fpS_Chousei_Sheet1.Cells.Get(0, 5).CellPadding.Right = 2;
            this.fpS_Chousei_Sheet1.Cells.Get(0, 5).Formula = "SUM(RC[-2],RC[-1])";
            this.fpS_Chousei_Sheet1.Cells.Get(0, 5).Value = 19999999999.9998D;
            this.fpS_Chousei_Sheet1.Cells.Get(0, 6).Value = "テストで廃棄";
            this.fpS_Chousei_Sheet1.ColumnFooter.Columns.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpS_Chousei_Sheet1.ColumnFooter.DefaultStyle.BackColor = System.Drawing.Color.Black;
            this.fpS_Chousei_Sheet1.ColumnFooter.DefaultStyle.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.fpS_Chousei_Sheet1.ColumnFooter.DefaultStyle.ForeColor = System.Drawing.Color.White;
            this.fpS_Chousei_Sheet1.ColumnFooter.DefaultStyle.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.fpS_Chousei_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpS_Chousei_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.fpS_Chousei_Sheet1.ColumnFooter.DefaultStyle.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.General;
            this.fpS_Chousei_Sheet1.ColumnFooter.DefaultStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpS_Chousei_Sheet1.ColumnFooter.Rows.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpS_Chousei_Sheet1.ColumnFooterSheetCornerStyle.BackColor = System.Drawing.Color.Black;
            this.fpS_Chousei_Sheet1.ColumnFooterSheetCornerStyle.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.fpS_Chousei_Sheet1.ColumnFooterSheetCornerStyle.ForeColor = System.Drawing.Color.White;
            this.fpS_Chousei_Sheet1.ColumnFooterSheetCornerStyle.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.fpS_Chousei_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpS_Chousei_Sheet1.ColumnFooterSheetCornerStyle.Parent = "HeaderDefault";
            this.fpS_Chousei_Sheet1.ColumnFooterSheetCornerStyle.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.General;
            this.fpS_Chousei_Sheet1.ColumnFooterSheetCornerStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpS_Chousei_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "廃棄";
            this.fpS_Chousei_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "製造番号";
            this.fpS_Chousei_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "使用期限";
            this.fpS_Chousei_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "理論在庫数";
            this.fpS_Chousei_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "調整量";
            this.fpS_Chousei_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "調整後";
            this.fpS_Chousei_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "備考";
            this.fpS_Chousei_Sheet1.ColumnHeader.Columns.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpS_Chousei_Sheet1.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.Black;
            this.fpS_Chousei_Sheet1.ColumnHeader.DefaultStyle.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.fpS_Chousei_Sheet1.ColumnHeader.DefaultStyle.ForeColor = System.Drawing.Color.White;
            this.fpS_Chousei_Sheet1.ColumnHeader.DefaultStyle.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.fpS_Chousei_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpS_Chousei_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.fpS_Chousei_Sheet1.ColumnHeader.DefaultStyle.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.General;
            this.fpS_Chousei_Sheet1.ColumnHeader.DefaultStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpS_Chousei_Sheet1.ColumnHeader.Rows.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpS_Chousei_Sheet1.Columns.Get(0).CellType = checkBoxCellType1;
            this.fpS_Chousei_Sheet1.Columns.Get(0).Font = new System.Drawing.Font("MS UI Gothic", 10F);
            this.fpS_Chousei_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.fpS_Chousei_Sheet1.Columns.Get(0).Label = "廃棄";
            this.fpS_Chousei_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            textCellType1.ReadOnly = true;
            this.fpS_Chousei_Sheet1.Columns.Get(1).CellType = textCellType1;
            this.fpS_Chousei_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.fpS_Chousei_Sheet1.Columns.Get(1).Label = "製造番号";
            this.fpS_Chousei_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.fpS_Chousei_Sheet1.Columns.Get(1).Width = 138F;
            textCellType2.ReadOnly = true;
            this.fpS_Chousei_Sheet1.Columns.Get(2).CellType = textCellType2;
            this.fpS_Chousei_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.fpS_Chousei_Sheet1.Columns.Get(2).Label = "使用期限";
            this.fpS_Chousei_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.fpS_Chousei_Sheet1.Columns.Get(2).Width = 120F;
            this.fpS_Chousei_Sheet1.Columns.Get(3).CellPadding.Right = 2;
            numberCellType1.DecimalPlaces = 4;
            numberCellType1.DecimalSeparator = ".";
            numberCellType1.MaximumValue = 9999999999.9999D;
            numberCellType1.MinimumValue = -99999999999.9999D;
            numberCellType1.NegativeRed = true;
            numberCellType1.ReadOnly = true;
            numberCellType1.Separator = ",";
            numberCellType1.ShowSeparator = true;
            this.fpS_Chousei_Sheet1.Columns.Get(3).CellType = numberCellType1;
            this.fpS_Chousei_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.fpS_Chousei_Sheet1.Columns.Get(3).Label = "理論在庫数";
            this.fpS_Chousei_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.fpS_Chousei_Sheet1.Columns.Get(3).Width = 108F;
            this.fpS_Chousei_Sheet1.Columns.Get(4).CellPadding.Right = 2;
            numberCellType2.DecimalPlaces = 4;
            numberCellType2.DecimalSeparator = ".";
            numberCellType2.MaximumValue = 9999999999.9999D;
            numberCellType2.MinimumValue = -99999999999.9999D;
            numberCellType2.NegativeRed = true;
            numberCellType2.Separator = ",";
            numberCellType2.ShowSeparator = true;
            this.fpS_Chousei_Sheet1.Columns.Get(4).CellType = numberCellType2;
            this.fpS_Chousei_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.fpS_Chousei_Sheet1.Columns.Get(4).Label = "調整量";
            this.fpS_Chousei_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.fpS_Chousei_Sheet1.Columns.Get(4).Width = 108F;
            this.fpS_Chousei_Sheet1.Columns.Get(5).CellPadding.Right = 2;
            numberCellType3.DecimalPlaces = 4;
            numberCellType3.DecimalSeparator = ".";
            numberCellType3.MaximumValue = 9999999999.9999D;
            numberCellType3.MinimumValue = -99999999999.9999D;
            numberCellType3.NegativeRed = true;
            numberCellType3.ReadOnly = true;
            numberCellType3.Separator = ",";
            numberCellType3.ShowSeparator = true;
            this.fpS_Chousei_Sheet1.Columns.Get(5).CellType = numberCellType3;
            this.fpS_Chousei_Sheet1.Columns.Get(5).Formula = "SUM(RC[-2],RC[-1])";
            this.fpS_Chousei_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.fpS_Chousei_Sheet1.Columns.Get(5).Label = "調整後";
            this.fpS_Chousei_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.fpS_Chousei_Sheet1.Columns.Get(5).Width = 108F;
            textCellType3.MaxLength = 40;
            textCellType3.Multiline = true;
            textCellType3.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.fpS_Chousei_Sheet1.Columns.Get(6).CellType = textCellType3;
            this.fpS_Chousei_Sheet1.Columns.Get(6).Label = "備考";
            this.fpS_Chousei_Sheet1.Columns.Get(6).Width = 270F;
            this.fpS_Chousei_Sheet1.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.fpS_Chousei_Sheet1.DefaultStyle.ForeColor = System.Drawing.Color.Black;
            this.fpS_Chousei_Sheet1.DefaultStyle.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.fpS_Chousei_Sheet1.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpS_Chousei_Sheet1.DefaultStyle.Parent = "DataAreaDefault";
            this.fpS_Chousei_Sheet1.DefaultStyle.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.General;
            this.fpS_Chousei_Sheet1.FilterBar.DefaultStyle.BackColor = System.Drawing.Color.Black;
            this.fpS_Chousei_Sheet1.FilterBar.DefaultStyle.ForeColor = System.Drawing.Color.White;
            this.fpS_Chousei_Sheet1.FilterBar.DefaultStyle.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.fpS_Chousei_Sheet1.FilterBar.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpS_Chousei_Sheet1.FilterBar.DefaultStyle.Parent = "FilterBarDefault";
            this.fpS_Chousei_Sheet1.FilterBar.DefaultStyle.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.General;
            this.fpS_Chousei_Sheet1.FilterBar.DefaultStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpS_Chousei_Sheet1.FilterBarHeaderStyle.BackColor = System.Drawing.Color.Black;
            this.fpS_Chousei_Sheet1.FilterBarHeaderStyle.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.fpS_Chousei_Sheet1.FilterBarHeaderStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpS_Chousei_Sheet1.FilterBarHeaderStyle.Parent = "RowHeaderDefault";
            this.fpS_Chousei_Sheet1.FilterBarHeaderStyle.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.General;
            this.fpS_Chousei_Sheet1.FilterBarHeaderStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpS_Chousei_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.fpS_Chousei_Sheet1.RowHeader.Columns.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpS_Chousei_Sheet1.RowHeader.DefaultStyle.BackColor = System.Drawing.Color.Black;
            this.fpS_Chousei_Sheet1.RowHeader.DefaultStyle.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.fpS_Chousei_Sheet1.RowHeader.DefaultStyle.ForeColor = System.Drawing.Color.White;
            this.fpS_Chousei_Sheet1.RowHeader.DefaultStyle.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.fpS_Chousei_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpS_Chousei_Sheet1.RowHeader.DefaultStyle.Parent = "HeaderDefault";
            this.fpS_Chousei_Sheet1.RowHeader.DefaultStyle.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.General;
            this.fpS_Chousei_Sheet1.RowHeader.DefaultStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpS_Chousei_Sheet1.RowHeader.Rows.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpS_Chousei_Sheet1.Rows.Get(0).Height = 33F;
            this.fpS_Chousei_Sheet1.Rows.Get(1).Height = 33F;
            this.fpS_Chousei_Sheet1.Rows.Get(2).Height = 33F;
            this.fpS_Chousei_Sheet1.Rows.Get(3).Height = 33F;
            this.fpS_Chousei_Sheet1.Rows.Get(4).Height = 33F;
            this.fpS_Chousei_Sheet1.Rows.Get(5).Height = 33F;
            this.fpS_Chousei_Sheet1.Rows.Get(6).Height = 33F;
            this.fpS_Chousei_Sheet1.Rows.Get(7).Height = 33F;
            this.fpS_Chousei_Sheet1.Rows.Get(8).Height = 33F;
            this.fpS_Chousei_Sheet1.Rows.Get(9).Height = 33F;
            this.fpS_Chousei_Sheet1.SheetCornerStyle.BackColor = System.Drawing.Color.Black;
            this.fpS_Chousei_Sheet1.SheetCornerStyle.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.fpS_Chousei_Sheet1.SheetCornerStyle.ForeColor = System.Drawing.Color.White;
            this.fpS_Chousei_Sheet1.SheetCornerStyle.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.fpS_Chousei_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpS_Chousei_Sheet1.SheetCornerStyle.Parent = "HeaderDefault";
            this.fpS_Chousei_Sheet1.SheetCornerStyle.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.General;
            this.fpS_Chousei_Sheet1.SheetCornerStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpS_Chousei_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // btn_ok
            // 
            this.btn_ok.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ok.Font = new System.Drawing.Font("メイリオ", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btn_ok.ForeColor = System.Drawing.Color.DodgerBlue;
            this.btn_ok.Location = new System.Drawing.Point(915, 566);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(75, 32);
            this.btn_ok.TabIndex = 9;
            this.btn_ok.Text = "登録";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // btn_exit
            // 
            this.btn_exit.BackColor = System.Drawing.Color.Silver;
            this.btn_exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_exit.Font = new System.Drawing.Font("メイリオ", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btn_exit.Location = new System.Drawing.Point(797, 566);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(75, 32);
            this.btn_exit.TabIndex = 10;
            this.btn_exit.Text = "閉じる";
            this.btn_exit.UseVisualStyleBackColor = false;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Location = new System.Drawing.Point(34, 88);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(956, 2);
            this.panel2.TabIndex = 8;
            // 
            // txt_yakuhinmei
            // 
            this.txt_yakuhinmei.BackColor = System.Drawing.Color.White;
            this.txt_yakuhinmei.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_yakuhinmei.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txt_yakuhinmei.Location = new System.Drawing.Point(280, 61);
            this.txt_yakuhinmei.Multiline = true;
            this.txt_yakuhinmei.Name = "txt_yakuhinmei";
            this.txt_yakuhinmei.ReadOnly = true;
            this.txt_yakuhinmei.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_yakuhinmei.Size = new System.Drawing.Size(636, 23);
            this.txt_yakuhinmei.TabIndex = 7;
            this.txt_yakuhinmei.TabStop = false;
            this.txt_yakuhinmei.Text = "薬品名";
            // 
            // gcTxt_gtin_code
            // 
            this.gcTxt_gtin_code.BackColor = System.Drawing.Color.White;
            this.gcTxt_gtin_code.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gcTxt_gtin_code.ContentAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.gcTxt_gtin_code.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.gcTxt_gtin_code.Format = "9";
            this.gcTxt_gtin_code.GridLine = new GrapeCity.Win.Editors.Line(GrapeCity.Win.Editors.LineStyle.None, System.Drawing.SystemColors.Control);
            this.gcTxt_gtin_code.HighlightText = true;
            this.gcTxt_gtin_code.Location = new System.Drawing.Point(114, 60);
            this.gcTxt_gtin_code.Name = "gcTxt_gtin_code";
            this.gcTxt_gtin_code.ReadOnly = true;
            this.gcTxt_gtin_code.Size = new System.Drawing.Size(137, 23);
            this.gcTxt_gtin_code.TabIndex = 6;
            this.gcTxt_gtin_code.TabStop = false;
            this.gcTxt_gtin_code.Text = "123456789012345";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(34, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "商品コード";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("メイリオ", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(26, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 44);
            this.label1.TabIndex = 0;
            this.label1.Text = "現在庫調整";
            // 
            // frm_Zaiko_Chousei
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1020, 620);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_Zaiko_Chousei";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "現在庫調整";
            this.Load += new System.EventHandler(this.frm_Zaiko_Chousei_Load);
            this.Shown += new System.EventHandler(this.frm_Zaiko_Chousei_Shown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fpS_Chousei)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpS_Chousei_Sheet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTxt_gtin_code)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private GrapeCity.Win.Editors.GcTextBox gcTxt_gtin_code;
        private System.Windows.Forms.TextBox txt_yakuhinmei;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.Panel panel3;
        private FarPoint.Win.Spread.FpSpread fpS_Chousei;
        private FarPoint.Win.Spread.SheetView fpS_Chousei_Sheet1;
    }
}