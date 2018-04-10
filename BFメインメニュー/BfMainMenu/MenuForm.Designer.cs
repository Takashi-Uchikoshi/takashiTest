using B2.BestFunction.UserControls;

namespace B2.BestFunction
{
    partial class MenuForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
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

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.dateAndYakkyokuMeiLabel = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.logoutButtonTextBox = new GrapeCity.Win.Editors.GcTextBox();
            this.userNameLabel = new System.Windows.Forms.Label();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.gcShortcut1 = new GrapeCity.Win.Editors.GcShortcut();
            this.zerostockPictureBox = new System.Windows.Forms.PictureBox();
            this.kinoButtonControl1 = new B2.BestFunction.UserControls.KinoButtonControl();
            this.kinoButtonControl2 = new B2.BestFunction.UserControls.KinoButtonControl();
            this.searchButton = new B2.BestFunction.UserControls.ButtonLabel();
            this.searchComboBox = new B2.Com.ctlComboBoxGc();
            this.searchDropDownButton = new GrapeCity.Win.Editors.DropDownButton();
            this.kinoPanel1 = new B2.BestFunction.UserControls.KinoPanel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoutButtonTextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zerostockPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchComboBox)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.zerostockPictureBox);
            this.splitContainer1.Panel1.Controls.Add(this.flowLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1194, 720);
            this.splitContainer1.SplitterDistance = 205;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.dateAndYakkyokuMeiLabel);
            this.flowLayoutPanel1.Controls.Add(this.kinoButtonControl1);
            this.flowLayoutPanel1.Controls.Add(this.kinoButtonControl2);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 65);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(205, 655);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // dateAndYakkyokuMeiLabel
            // 
            this.dateAndYakkyokuMeiLabel.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.dateAndYakkyokuMeiLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dateAndYakkyokuMeiLabel.Location = new System.Drawing.Point(3, 0);
            this.dateAndYakkyokuMeiLabel.Name = "dateAndYakkyokuMeiLabel";
            this.dateAndYakkyokuMeiLabel.Size = new System.Drawing.Size(197, 52);
            this.dateAndYakkyokuMeiLabel.TabIndex = 0;
            this.dateAndYakkyokuMeiLabel.Text = "2018/01/05\r\nアサイクル薬局";
            this.dateAndYakkyokuMeiLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // splitContainer2
            // 
            this.splitContainer2.BackColor = System.Drawing.Color.White;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(200)))), ((int)(((byte)(250)))));
            this.splitContainer2.Panel1.Controls.Add(this.searchButton);
            this.splitContainer2.Panel1.Controls.Add(this.logoutButtonTextBox);
            this.splitContainer2.Panel1.Controls.Add(this.searchComboBox);
            this.splitContainer2.Panel1.Controls.Add(this.userNameLabel);
            this.splitContainer2.Panel1.Controls.Add(this.searchTextBox);
            this.splitContainer2.Panel1MinSize = 5;
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer2.Panel2.Controls.Add(this.kinoPanel1);
            this.splitContainer2.Size = new System.Drawing.Size(988, 720);
            this.splitContainer2.SplitterDistance = 59;
            this.splitContainer2.SplitterWidth = 1;
            this.splitContainer2.TabIndex = 0;
            // 
            // logoutButtonTextBox
            // 
            this.logoutButtonTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(200)))), ((int)(((byte)(250)))));
            this.logoutButtonTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.logoutButtonTextBox.ContentAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.logoutButtonTextBox.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.logoutButtonTextBox.ForeColor = System.Drawing.Color.White;
            this.logoutButtonTextBox.GridLine = new GrapeCity.Win.Editors.Line(GrapeCity.Win.Editors.LineStyle.None, System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(200)))), ((int)(((byte)(250))))));
            this.logoutButtonTextBox.Location = new System.Drawing.Point(877, 14);
            this.logoutButtonTextBox.Name = "logoutButtonTextBox";
            this.logoutButtonTextBox.ReadOnly = true;
            this.gcShortcut1.SetShortcuts(this.logoutButtonTextBox, new GrapeCity.Win.Editors.ShortcutCollection(new System.Windows.Forms.Keys[] {
                System.Windows.Forms.Keys.F2}, new object[] {
                ((object)(this.logoutButtonTextBox))}, new string[] {
                "ShortcutClear"}));
            this.logoutButtonTextBox.SingleBorderColor = System.Drawing.Color.White;
            this.logoutButtonTextBox.Size = new System.Drawing.Size(91, 30);
            this.logoutButtonTextBox.TabIndex = 5;
            this.logoutButtonTextBox.Text = "ログアウト";
            this.logoutButtonTextBox.Click += new System.EventHandler(this.logoutButtonTextBox_Click);
            // 
            // userNameLabel
            // 
            this.userNameLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(200)))), ((int)(((byte)(250)))));
            this.userNameLabel.Font = new System.Drawing.Font("メイリオ", 12F);
            this.userNameLabel.ForeColor = System.Drawing.Color.White;
            this.userNameLabel.Location = new System.Drawing.Point(747, 17);
            this.userNameLabel.Name = "userNameLabel";
            this.userNameLabel.Size = new System.Drawing.Size(123, 23);
            this.userNameLabel.TabIndex = 3;
            this.userNameLabel.Text = "浅井　太郎";
            this.userNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // searchTextBox
            // 
            this.searchTextBox.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.searchTextBox.Location = new System.Drawing.Point(157, 16);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(244, 27);
            this.searchTextBox.TabIndex = 1;
            // 
            // zerostockPictureBox
            // 
            this.zerostockPictureBox.Image = global::B2.BestFunction.Properties.Resources.zerostock;
            this.zerostockPictureBox.InitialImage = ((System.Drawing.Image)(resources.GetObject("zerostockPictureBox.InitialImage")));
            this.zerostockPictureBox.Location = new System.Drawing.Point(0, 0);
            this.zerostockPictureBox.Name = "zerostockPictureBox";
            this.zerostockPictureBox.Size = new System.Drawing.Size(205, 59);
            this.zerostockPictureBox.TabIndex = 0;
            this.zerostockPictureBox.TabStop = false;
            // 
            // kinoButtonControl1
            // 
            this.kinoButtonControl1.Location = new System.Drawing.Point(3, 55);
            this.kinoButtonControl1.Name = "kinoButtonControl1";
            this.kinoButtonControl1.Size = new System.Drawing.Size(205, 55);
            this.kinoButtonControl1.TabIndex = 1;
            // 
            // kinoButtonControl2
            // 
            this.kinoButtonControl2.Location = new System.Drawing.Point(3, 116);
            this.kinoButtonControl2.Name = "kinoButtonControl2";
            this.kinoButtonControl2.Size = new System.Drawing.Size(205, 55);
            this.kinoButtonControl2.TabIndex = 2;
            // 
            // searchButton
            // 
            this.searchButton.BackColor = System.Drawing.Color.White;
            this.searchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.searchButton.ForeColor = System.Drawing.Color.Transparent;
            this.searchButton.Image = global::B2.BestFunction.Properties.Resources.kensaku;
            this.searchButton.Location = new System.Drawing.Point(368, 19);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(27, 23);
            this.searchButton.TabIndex = 6;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // searchComboBox
            // 
            this.searchComboBox.AutoComplete.MatchingMode = GrapeCity.Win.Editors.AutoCompleteMatchingMode.MatchAll;
            this.searchComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.searchComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.searchComboBox.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.searchComboBox.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.searchComboBox.ListHeaderPane.Height = 27;
            this.searchComboBox.Location = new System.Drawing.Point(56, 16);
            this.searchComboBox.Name = "searchComboBox";
            this.gcShortcut1.SetShortcuts(this.searchComboBox, new GrapeCity.Win.Editors.ShortcutCollection(new System.Windows.Forms.Keys[] {
                System.Windows.Forms.Keys.F2,
                ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Return)))}, new object[] {
                ((object)(this.searchComboBox)),
                ((object)(this.searchComboBox))}, new string[] {
                "ShortcutClear",
                "ApplyRecommendedValue"}));
            this.searchComboBox.SideButtons.AddRange(new GrapeCity.Win.Editors.SideButtonBase[] {
            this.searchDropDownButton});
            this.searchComboBox.Size = new System.Drawing.Size(100, 27);
            this.searchComboBox.TabIndex = 4;
            // 
            // searchDropDownButton
            // 
            this.searchDropDownButton.Name = "searchDropDownButton";
            // 
            // kinoPanel1
            // 
            this.kinoPanel1.BackColor = System.Drawing.Color.White;
            this.kinoPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kinoPanel1.Location = new System.Drawing.Point(0, 0);
            this.kinoPanel1.Name = "kinoPanel1";
            this.kinoPanel1.Size = new System.Drawing.Size(988, 660);
            this.kinoPanel1.TabIndex = 0;
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1194, 720);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MenuForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BestFunction";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MenuForm_FormClosing);
            this.Load += new System.EventHandler(this.MenuForm_Load);
            this.Shown += new System.EventHandler(this.MenuForm_Shown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.logoutButtonTextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zerostockPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchComboBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.PictureBox zerostockPictureBox;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Label userNameLabel;
        private B2.Com.ctlComboBoxGc searchComboBox;
        private GrapeCity.Win.Editors.DropDownButton searchDropDownButton;
        private GrapeCity.Win.Editors.GcTextBox logoutButtonTextBox;
        private System.Windows.Forms.Label dateAndYakkyokuMeiLabel;
        private ButtonLabel searchButton;
        private GrapeCity.Win.Editors.GcShortcut gcShortcut1;
        private KinoButtonControl kinoButtonControl1;
        private KinoButtonControl kinoButtonControl2;
        private KinoPanel kinoPanel1;
    }
}

