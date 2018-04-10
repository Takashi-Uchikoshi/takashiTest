namespace B2.BestFunction
{
    partial class KensakuSyouhinForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KensakuSyouhinForm));
            System.Globalization.CultureInfo cultureInfo = new System.Globalization.CultureInfo("ja-JP", false);
            GrapeCity.Win.Spread.InputMan.CellType.GcTextBoxCellType gcTextBoxCellType8 = new GrapeCity.Win.Spread.InputMan.CellType.GcTextBoxCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType3 = new FarPoint.Win.Spread.CellType.TextCellType();
            GrapeCity.Win.Spread.InputMan.CellType.GcTextBoxCellType gcTextBoxCellType9 = new GrapeCity.Win.Spread.InputMan.CellType.GcTextBoxCellType();
            GrapeCity.Win.Spread.InputMan.CellType.GcTextBoxCellType gcTextBoxCellType10 = new GrapeCity.Win.Spread.InputMan.CellType.GcTextBoxCellType();
            GrapeCity.Win.Spread.InputMan.CellType.GcTextBoxCellType gcTextBoxCellType11 = new GrapeCity.Win.Spread.InputMan.CellType.GcTextBoxCellType();
            GrapeCity.Win.Spread.InputMan.CellType.GcTextBoxCellType gcTextBoxCellType12 = new GrapeCity.Win.Spread.InputMan.CellType.GcTextBoxCellType();
            GrapeCity.Win.Spread.InputMan.CellType.GcTextBoxCellType gcTextBoxCellType13 = new GrapeCity.Win.Spread.InputMan.CellType.GcTextBoxCellType();
            GrapeCity.Win.Spread.InputMan.CellType.GcTextBoxCellType gcTextBoxCellType14 = new GrapeCity.Win.Spread.InputMan.CellType.GcTextBoxCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType4 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType2 = new FarPoint.Win.Spread.CellType.NumberCellType();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btn_select = new System.Windows.Forms.Button();
            this.search_text = new GrapeCity.Win.Editors.GcTextBox(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.fpSMain = new FarPoint.Win.Spread.FpSpread();
            this.fpSMain_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_ok = new System.Windows.Forms.Button();
            this.btn_exit = new System.Windows.Forms.Button();
            this.gcShortcut1 = new GrapeCity.Win.Editors.GcShortcut(this.components);
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.search_text)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpSMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpSMain_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.White;
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btn_select);
            this.splitContainer1.Panel1.Controls.Add(this.search_text);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1020, 620);
            this.splitContainer1.SplitterDistance = 122;
            this.splitContainer1.TabIndex = 0;
            // 
            // btn_select
            // 
            this.btn_select.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_select.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btn_select.ForeColor = System.Drawing.Color.White;
            this.btn_select.Image = ((System.Drawing.Image)(resources.GetObject("btn_select.Image")));
            this.btn_select.Location = new System.Drawing.Point(215, 66);
            this.btn_select.Name = "btn_select";
            this.btn_select.Size = new System.Drawing.Size(36, 32);
            this.btn_select.TabIndex = 2;
            this.btn_select.UseVisualStyleBackColor = true;
            this.btn_select.Click += new System.EventHandler(this.btn_select_Click);
            // 
            // search_text
            // 
            this.search_text.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.search_text.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.search_text.Format = "AH9Ｚ";
            this.search_text.GridLine = new GrapeCity.Win.Editors.Line(GrapeCity.Win.Editors.LineStyle.None, System.Drawing.SystemColors.Control);
            this.search_text.HighlightText = true;
            this.search_text.Location = new System.Drawing.Point(31, 66);
            this.search_text.Name = "search_text";
            this.gcShortcut1.SetShortcuts(this.search_text, new GrapeCity.Win.Editors.ShortcutCollection(new System.Windows.Forms.Keys[] {
                System.Windows.Forms.Keys.F2}, new object[] {
                ((object)(this.search_text))}, new string[] {
                "ShortcutClear"}));
            this.search_text.Size = new System.Drawing.Size(181, 32);
            this.search_text.TabIndex = 1;
            this.search_text.KeyDown += new System.Windows.Forms.KeyEventHandler(this.search_text_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("メイリオ", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(25, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "商品検索";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.fpSMain);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.label3);
            this.splitContainer2.Panel2.Controls.Add(this.label2);
            this.splitContainer2.Panel2.Controls.Add(this.btn_ok);
            this.splitContainer2.Panel2.Controls.Add(this.btn_exit);
            this.splitContainer2.Size = new System.Drawing.Size(1018, 492);
            this.splitContainer2.SplitterDistance = 394;
            this.splitContainer2.TabIndex = 0;
            // 
            // fpSMain
            // 
            this.fpSMain.AccessibleDescription = "fpSMain, Sheet1, Row 0, Column 0, 12345678901234";
            this.fpSMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fpSMain.Location = new System.Drawing.Point(0, 0);
            this.fpSMain.Name = "fpSMain";
            this.fpSMain.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.fpSMain_Sheet1});
            this.fpSMain.Size = new System.Drawing.Size(1018, 394);
            this.fpSMain.TabIndex = 0;
            this.fpSMain.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpSMain_CellDoubleClick);
            this.fpSMain.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fpSMain_KeyDown);
            // 
            // fpSMain_Sheet1
            // 
            this.fpSMain_Sheet1.Reset();
            this.fpSMain_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fpSMain_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fpSMain_Sheet1.ColumnCount = 20;
            this.fpSMain_Sheet1.RowCount = 20;
            this.fpSMain_Sheet1.ActiveSkin = FarPoint.Win.Spread.DefaultSkins.Professional1;
            gcTextBoxCellType8.ClearCollection = true;
            gcTextBoxCellType8.RecommendedValue = null;
            gcTextBoxCellType8.ShortcutKeys.AddRange(new GrapeCity.Win.Spread.InputMan.CellType.ShortcutDictionaryEntry[] {
            new GrapeCity.Win.Spread.InputMan.CellType.ShortcutDictionaryEntry(System.Windows.Forms.Keys.F2, "ShortcutClear")});
            this.fpSMain_Sheet1.Cells.Get(0, 0).CellType = gcTextBoxCellType8;
            this.fpSMain_Sheet1.Cells.Get(0, 0).ParseFormatInfo = ((System.Globalization.NumberFormatInfo)(cultureInfo.NumberFormat.Clone()));
            ((System.Globalization.NumberFormatInfo)(this.fpSMain_Sheet1.Cells.Get(0, 0).ParseFormatInfo)).NumberDecimalDigits = 0;
            this.fpSMain_Sheet1.Cells.Get(0, 0).ParseFormatString = "E";
            this.fpSMain_Sheet1.Cells.Get(0, 0).Value = 12345678901234D;
            this.fpSMain_Sheet1.Cells.Get(0, 1).Value = "02345678901234";
            this.fpSMain_Sheet1.Cells.Get(0, 2).Value = "123456789012";
            this.fpSMain_Sheet1.Cells.Get(0, 3).Value = "1234567890123";
            this.fpSMain_Sheet1.Cells.Get(0, 4).Value = "後発";
            this.fpSMain_Sheet1.Cells.Get(0, 5).Value = "商品名";
            this.fpSMain_Sheet1.Cells.Get(0, 6).Value = "商品名カナ";
            this.fpSMain_Sheet1.Cells.Get(0, 7).Value = "２０ｍｇ　＊　２００";
            this.fpSMain_Sheet1.Cells.Get(0, 8).Value = "内用薬 ";
            this.fpSMain_Sheet1.Cells.Get(0, 9).Value = "ＰＴＰ";
            this.fpSMain_Sheet1.Cells.Get(0, 10).ParseFormatInfo = ((System.Globalization.NumberFormatInfo)(cultureInfo.NumberFormat.Clone()));
            ((System.Globalization.NumberFormatInfo)(this.fpSMain_Sheet1.Cells.Get(0, 10).ParseFormatInfo)).NumberDecimalDigits = 0;
            this.fpSMain_Sheet1.Cells.Get(0, 10).ParseFormatString = "n";
            this.fpSMain_Sheet1.Cells.Get(0, 10).Value = 200;
            this.fpSMain_Sheet1.Cells.Get(0, 11).Value = "錠";
            this.fpSMain_Sheet1.Cells.Get(0, 12).ParseFormatInfo = ((System.Globalization.NumberFormatInfo)(cultureInfo.NumberFormat.Clone()));
            ((System.Globalization.NumberFormatInfo)(this.fpSMain_Sheet1.Cells.Get(0, 12).ParseFormatInfo)).NumberDecimalDigits = 0;
            this.fpSMain_Sheet1.Cells.Get(0, 12).ParseFormatString = "n";
            this.fpSMain_Sheet1.Cells.Get(0, 12).Value = 20;
            this.fpSMain_Sheet1.Cells.Get(0, 13).Value = "錠";
            this.fpSMain_Sheet1.Cells.Get(0, 14).Value = "ああああ製薬会社";
            this.fpSMain_Sheet1.Cells.Get(0, 15).Value = "いいいい販売";
            this.fpSMain_Sheet1.Cells.Get(0, 16).ParseFormatInfo = ((System.Globalization.NumberFormatInfo)(cultureInfo.NumberFormat.Clone()));
            ((System.Globalization.NumberFormatInfo)(this.fpSMain_Sheet1.Cells.Get(0, 16).ParseFormatInfo)).NumberDecimalDigits = 0;
            this.fpSMain_Sheet1.Cells.Get(0, 16).ParseFormatString = "n";
            this.fpSMain_Sheet1.Cells.Get(0, 16).Value = 123456789;
            this.fpSMain_Sheet1.Cells.Get(0, 17).CellType = textCellType3;
            this.fpSMain_Sheet1.Cells.Get(0, 17).ParseFormatInfo = ((System.Globalization.NumberFormatInfo)(cultureInfo.NumberFormat.Clone()));
            ((System.Globalization.NumberFormatInfo)(this.fpSMain_Sheet1.Cells.Get(0, 17).ParseFormatInfo)).NumberDecimalDigits = 0;
            this.fpSMain_Sheet1.Cells.Get(0, 17).ParseFormatString = "E";
            this.fpSMain_Sheet1.Cells.Get(0, 17).Value = 123456789012345D;
            this.fpSMain_Sheet1.Cells.Get(0, 18).Value = 0D;
            this.fpSMain_Sheet1.ColumnFooter.Columns.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpSMain_Sheet1.ColumnFooter.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(132)))));
            this.fpSMain_Sheet1.ColumnFooter.DefaultStyle.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.fpSMain_Sheet1.ColumnFooter.DefaultStyle.ForeColor = System.Drawing.Color.White;
            this.fpSMain_Sheet1.ColumnFooter.DefaultStyle.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.fpSMain_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpSMain_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.fpSMain_Sheet1.ColumnFooter.DefaultStyle.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.General;
            this.fpSMain_Sheet1.ColumnFooter.DefaultStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpSMain_Sheet1.ColumnFooter.Rows.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpSMain_Sheet1.ColumnFooterSheetCornerStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(132)))));
            this.fpSMain_Sheet1.ColumnFooterSheetCornerStyle.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.fpSMain_Sheet1.ColumnFooterSheetCornerStyle.ForeColor = System.Drawing.Color.White;
            this.fpSMain_Sheet1.ColumnFooterSheetCornerStyle.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.fpSMain_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpSMain_Sheet1.ColumnFooterSheetCornerStyle.Parent = "HeaderDefault";
            this.fpSMain_Sheet1.ColumnFooterSheetCornerStyle.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.General;
            this.fpSMain_Sheet1.ColumnFooterSheetCornerStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpSMain_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "GTIN販売";
            this.fpSMain_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "GTIN調剤";
            this.fpSMain_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "YJ";
            this.fpSMain_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "JAN";
            this.fpSMain_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "後発";
            this.fpSMain_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "商品名";
            this.fpSMain_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "商品名カナ";
            this.fpSMain_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "規格・容量";
            this.fpSMain_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "区分";
            this.fpSMain_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "包装形態";
            this.fpSMain_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "入数";
            this.fpSMain_Sheet1.ColumnHeader.Cells.Get(0, 11).Value = "単位";
            this.fpSMain_Sheet1.ColumnHeader.Cells.Get(0, 12).Value = "ヒート";
            this.fpSMain_Sheet1.ColumnHeader.Cells.Get(0, 13).Value = "単位";
            this.fpSMain_Sheet1.ColumnHeader.Cells.Get(0, 14).Value = "製造会社";
            this.fpSMain_Sheet1.ColumnHeader.Cells.Get(0, 15).Value = "販売会社";
            this.fpSMain_Sheet1.ColumnHeader.Cells.Get(0, 16).Value = "薬価";
            this.fpSMain_Sheet1.ColumnHeader.Cells.Get(0, 17).Value = "レセコンコード";
            this.fpSMain_Sheet1.ColumnHeader.Cells.Get(0, 18).Value = "在庫数";
            this.fpSMain_Sheet1.ColumnHeader.Cells.Get(0, 19).Value = "棚";
            this.fpSMain_Sheet1.ColumnHeader.Columns.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpSMain_Sheet1.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(132)))));
            this.fpSMain_Sheet1.ColumnHeader.DefaultStyle.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.fpSMain_Sheet1.ColumnHeader.DefaultStyle.ForeColor = System.Drawing.Color.White;
            this.fpSMain_Sheet1.ColumnHeader.DefaultStyle.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.fpSMain_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpSMain_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.fpSMain_Sheet1.ColumnHeader.DefaultStyle.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.General;
            this.fpSMain_Sheet1.ColumnHeader.DefaultStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpSMain_Sheet1.ColumnHeader.Rows.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpSMain_Sheet1.Columns.Get(0).AllowAutoSort = true;
            gcTextBoxCellType9.ClearCollection = true;
            gcTextBoxCellType9.RecommendedValue = null;
            gcTextBoxCellType9.ShortcutKeys.AddRange(new GrapeCity.Win.Spread.InputMan.CellType.ShortcutDictionaryEntry[] {
            new GrapeCity.Win.Spread.InputMan.CellType.ShortcutDictionaryEntry(System.Windows.Forms.Keys.F2, "ShortcutClear")});
            this.fpSMain_Sheet1.Columns.Get(0).CellType = gcTextBoxCellType9;
            this.fpSMain_Sheet1.Columns.Get(0).Font = new System.Drawing.Font("メイリオ", 10F);
            this.fpSMain_Sheet1.Columns.Get(0).Label = "GTIN販売";
            this.fpSMain_Sheet1.Columns.Get(0).Width = 135F;
            gcTextBoxCellType10.ClearCollection = true;
            gcTextBoxCellType10.RecommendedValue = null;
            gcTextBoxCellType10.ShortcutKeys.AddRange(new GrapeCity.Win.Spread.InputMan.CellType.ShortcutDictionaryEntry[] {
            new GrapeCity.Win.Spread.InputMan.CellType.ShortcutDictionaryEntry(System.Windows.Forms.Keys.F2, "ShortcutClear")});
            this.fpSMain_Sheet1.Columns.Get(1).CellType = gcTextBoxCellType10;
            this.fpSMain_Sheet1.Columns.Get(1).Font = new System.Drawing.Font("メイリオ", 10F);
            this.fpSMain_Sheet1.Columns.Get(1).Label = "GTIN調剤";
            this.fpSMain_Sheet1.Columns.Get(1).Width = 135F;
            this.fpSMain_Sheet1.Columns.Get(2).AllowAutoSort = true;
            gcTextBoxCellType11.ClearCollection = true;
            gcTextBoxCellType11.RecommendedValue = null;
            gcTextBoxCellType11.ShortcutKeys.AddRange(new GrapeCity.Win.Spread.InputMan.CellType.ShortcutDictionaryEntry[] {
            new GrapeCity.Win.Spread.InputMan.CellType.ShortcutDictionaryEntry(System.Windows.Forms.Keys.F2, "ShortcutClear")});
            this.fpSMain_Sheet1.Columns.Get(2).CellType = gcTextBoxCellType11;
            this.fpSMain_Sheet1.Columns.Get(2).Font = new System.Drawing.Font("メイリオ", 10F);
            this.fpSMain_Sheet1.Columns.Get(2).Label = "YJ";
            this.fpSMain_Sheet1.Columns.Get(2).Width = 125F;
            gcTextBoxCellType12.ClearCollection = true;
            gcTextBoxCellType12.RecommendedValue = null;
            gcTextBoxCellType12.ShortcutKeys.AddRange(new GrapeCity.Win.Spread.InputMan.CellType.ShortcutDictionaryEntry[] {
            new GrapeCity.Win.Spread.InputMan.CellType.ShortcutDictionaryEntry(System.Windows.Forms.Keys.F2, "ShortcutClear")});
            this.fpSMain_Sheet1.Columns.Get(3).CellType = gcTextBoxCellType12;
            this.fpSMain_Sheet1.Columns.Get(3).Font = new System.Drawing.Font("メイリオ", 10F);
            this.fpSMain_Sheet1.Columns.Get(3).Label = "JAN";
            this.fpSMain_Sheet1.Columns.Get(3).Width = 125F;
            gcTextBoxCellType13.ClearCollection = true;
            gcTextBoxCellType13.RecommendedValue = null;
            gcTextBoxCellType13.ShortcutKeys.AddRange(new GrapeCity.Win.Spread.InputMan.CellType.ShortcutDictionaryEntry[] {
            new GrapeCity.Win.Spread.InputMan.CellType.ShortcutDictionaryEntry(System.Windows.Forms.Keys.F2, "ShortcutClear")});
            this.fpSMain_Sheet1.Columns.Get(4).CellType = gcTextBoxCellType13;
            this.fpSMain_Sheet1.Columns.Get(4).Font = new System.Drawing.Font("メイリオ", 10F);
            this.fpSMain_Sheet1.Columns.Get(4).Label = "後発";
            this.fpSMain_Sheet1.Columns.Get(5).AllowAutoSort = true;
            gcTextBoxCellType14.ClearCollection = true;
            gcTextBoxCellType14.RecommendedValue = null;
            gcTextBoxCellType14.ShortcutKeys.AddRange(new GrapeCity.Win.Spread.InputMan.CellType.ShortcutDictionaryEntry[] {
            new GrapeCity.Win.Spread.InputMan.CellType.ShortcutDictionaryEntry(System.Windows.Forms.Keys.F2, "ShortcutClear")});
            this.fpSMain_Sheet1.Columns.Get(5).CellType = gcTextBoxCellType14;
            this.fpSMain_Sheet1.Columns.Get(5).Font = new System.Drawing.Font("メイリオ", 10F);
            this.fpSMain_Sheet1.Columns.Get(5).Label = "商品名";
            this.fpSMain_Sheet1.Columns.Get(5).Width = 250F;
            this.fpSMain_Sheet1.Columns.Get(6).Font = new System.Drawing.Font("メイリオ", 10F);
            this.fpSMain_Sheet1.Columns.Get(6).Label = "商品名カナ";
            this.fpSMain_Sheet1.Columns.Get(6).Width = 250F;
            this.fpSMain_Sheet1.Columns.Get(7).Font = new System.Drawing.Font("メイリオ", 10F);
            this.fpSMain_Sheet1.Columns.Get(7).Label = "規格・容量";
            this.fpSMain_Sheet1.Columns.Get(7).Width = 250F;
            this.fpSMain_Sheet1.Columns.Get(9).AllowAutoSort = true;
            this.fpSMain_Sheet1.Columns.Get(9).Font = new System.Drawing.Font("メイリオ", 10F);
            this.fpSMain_Sheet1.Columns.Get(9).Label = "包装形態";
            this.fpSMain_Sheet1.Columns.Get(9).Width = 120F;
            this.fpSMain_Sheet1.Columns.Get(10).Font = new System.Drawing.Font("メイリオ", 10F);
            this.fpSMain_Sheet1.Columns.Get(10).Label = "入数";
            this.fpSMain_Sheet1.Columns.Get(11).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.fpSMain_Sheet1.Columns.Get(11).Label = "単位";
            this.fpSMain_Sheet1.Columns.Get(11).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.fpSMain_Sheet1.Columns.Get(12).Font = new System.Drawing.Font("メイリオ", 10F);
            this.fpSMain_Sheet1.Columns.Get(12).Label = "ヒート";
            this.fpSMain_Sheet1.Columns.Get(13).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.fpSMain_Sheet1.Columns.Get(13).Label = "単位";
            this.fpSMain_Sheet1.Columns.Get(13).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.fpSMain_Sheet1.Columns.Get(14).Font = new System.Drawing.Font("メイリオ", 10F);
            this.fpSMain_Sheet1.Columns.Get(14).Label = "製造会社";
            this.fpSMain_Sheet1.Columns.Get(14).Width = 150F;
            this.fpSMain_Sheet1.Columns.Get(15).Font = new System.Drawing.Font("メイリオ", 10F);
            this.fpSMain_Sheet1.Columns.Get(15).Label = "販売会社";
            this.fpSMain_Sheet1.Columns.Get(15).Width = 150F;
            this.fpSMain_Sheet1.Columns.Get(16).Font = new System.Drawing.Font("メイリオ", 10F);
            this.fpSMain_Sheet1.Columns.Get(16).Label = "薬価";
            this.fpSMain_Sheet1.Columns.Get(16).Width = 100F;
            this.fpSMain_Sheet1.Columns.Get(17).CellType = textCellType4;
            this.fpSMain_Sheet1.Columns.Get(17).Font = new System.Drawing.Font("メイリオ", 10F);
            this.fpSMain_Sheet1.Columns.Get(17).Label = "レセコンコード";
            this.fpSMain_Sheet1.Columns.Get(17).Width = 128F;
            this.fpSMain_Sheet1.Columns.Get(18).CellType = numberCellType2;
            this.fpSMain_Sheet1.Columns.Get(18).Label = "在庫数";
            this.fpSMain_Sheet1.Columns.Get(19).Label = "棚";
            this.fpSMain_Sheet1.Columns.Get(19).Width = 250F;
            this.fpSMain_Sheet1.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.fpSMain_Sheet1.DefaultStyle.ForeColor = System.Drawing.Color.Black;
            this.fpSMain_Sheet1.DefaultStyle.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.fpSMain_Sheet1.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpSMain_Sheet1.DefaultStyle.Parent = "DataAreaDefault";
            this.fpSMain_Sheet1.DefaultStyle.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.General;
            this.fpSMain_Sheet1.FilterBar.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(132)))));
            this.fpSMain_Sheet1.FilterBar.DefaultStyle.ForeColor = System.Drawing.Color.White;
            this.fpSMain_Sheet1.FilterBar.DefaultStyle.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.fpSMain_Sheet1.FilterBar.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpSMain_Sheet1.FilterBar.DefaultStyle.Parent = "FilterBarDefault";
            this.fpSMain_Sheet1.FilterBar.DefaultStyle.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.General;
            this.fpSMain_Sheet1.FilterBar.DefaultStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpSMain_Sheet1.FilterBarHeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(132)))));
            this.fpSMain_Sheet1.FilterBarHeaderStyle.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.fpSMain_Sheet1.FilterBarHeaderStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpSMain_Sheet1.FilterBarHeaderStyle.Parent = "RowHeaderDefault";
            this.fpSMain_Sheet1.FilterBarHeaderStyle.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.General;
            this.fpSMain_Sheet1.FilterBarHeaderStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpSMain_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.fpSMain_Sheet1.RowHeader.Columns.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpSMain_Sheet1.RowHeader.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(132)))));
            this.fpSMain_Sheet1.RowHeader.DefaultStyle.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.fpSMain_Sheet1.RowHeader.DefaultStyle.ForeColor = System.Drawing.Color.White;
            this.fpSMain_Sheet1.RowHeader.DefaultStyle.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.fpSMain_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpSMain_Sheet1.RowHeader.DefaultStyle.Parent = "HeaderDefault";
            this.fpSMain_Sheet1.RowHeader.DefaultStyle.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.General;
            this.fpSMain_Sheet1.RowHeader.DefaultStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpSMain_Sheet1.RowHeader.Rows.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpSMain_Sheet1.SheetCornerStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(132)))));
            this.fpSMain_Sheet1.SheetCornerStyle.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.fpSMain_Sheet1.SheetCornerStyle.ForeColor = System.Drawing.Color.White;
            this.fpSMain_Sheet1.SheetCornerStyle.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.fpSMain_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpSMain_Sheet1.SheetCornerStyle.Parent = "HeaderDefault";
            this.fpSMain_Sheet1.SheetCornerStyle.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.General;
            this.fpSMain_Sheet1.SheetCornerStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpSMain_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(12, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(240, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "最大表示行数は５０００行に制限しています。";
            // 
            // btn_ok
            // 
            this.btn_ok.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ok.Font = new System.Drawing.Font("メイリオ", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btn_ok.ForeColor = System.Drawing.Color.DodgerBlue;
            this.btn_ok.Location = new System.Drawing.Point(921, 27);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(75, 32);
            this.btn_ok.TabIndex = 0;
            this.btn_ok.Text = "選択";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // btn_exit
            // 
            this.btn_exit.BackColor = System.Drawing.Color.Silver;
            this.btn_exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_exit.Font = new System.Drawing.Font("メイリオ", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btn_exit.Location = new System.Drawing.Point(803, 27);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(75, 32);
            this.btn_exit.TabIndex = 0;
            this.btn_exit.Text = "閉じる";
            this.btn_exit.UseVisualStyleBackColor = false;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.Location = new System.Drawing.Point(11, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(193, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "棚情報は5件までに制限しています。";
            // 
            // frm_Kensaku_Syouhin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1020, 620);
            this.ControlBox = false;
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_Kensaku_Syouhin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "商品検索";
            this.Load += new System.EventHandler(this.frm_Kensaku_Syouhin_Load);
            this.Shown += new System.EventHandler(this.frm_Kensaku_Syouhin_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_Kensaku_Syouhin_KeyDown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.search_text)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fpSMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpSMain_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btn_select;
        private GrapeCity.Win.Editors.GcTextBox search_text;
        private GrapeCity.Win.Editors.GcShortcut gcShortcut1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private FarPoint.Win.Spread.FpSpread fpSMain;
        private FarPoint.Win.Spread.SheetView fpSMain_Sheet1;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}