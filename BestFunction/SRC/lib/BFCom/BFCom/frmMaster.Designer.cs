namespace B2.BestFunction
{
    public partial class frmMaster
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
            this.menuStrip_ms = new System.Windows.Forms.MenuStrip();
            this.File_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Cancel_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Exit_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Edit_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.New_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Modify_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Delete_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Update_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Show_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Select_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Refresh_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Sort_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Output_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Print_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Csv_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Renkei_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Download_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.split_1 = new System.Windows.Forms.SplitContainer();
            this.split_2 = new System.Windows.Forms.SplitContainer();
            this.spd1 = new FarPoint.Win.Spread.FpSpread();
            this.spd1_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.menuStrip_ms.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.split_1)).BeginInit();
            this.split_1.Panel2.SuspendLayout();
            this.split_1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.split_2)).BeginInit();
            this.split_2.Panel1.SuspendLayout();
            this.split_2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spd1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spd1_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip_ms
            // 
            this.menuStrip_ms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.File_ToolStripMenuItem,
            this.Edit_ToolStripMenuItem,
            this.Show_ToolStripMenuItem,
            this.Output_ToolStripMenuItem,
            this.Renkei_ToolStripMenuItem});
            this.menuStrip_ms.Location = new System.Drawing.Point(0, 0);
            this.menuStrip_ms.Name = "menuStrip_ms";
            this.menuStrip_ms.Size = new System.Drawing.Size(1206, 26);
            this.menuStrip_ms.TabIndex = 0;
            this.menuStrip_ms.Text = "menuStrip1";
            // 
            // File_ToolStripMenuItem
            // 
            this.File_ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Cancel_ToolStripMenuItem,
            this.Exit_ToolStripMenuItem});
            this.File_ToolStripMenuItem.Name = "File_ToolStripMenuItem";
            this.File_ToolStripMenuItem.Size = new System.Drawing.Size(68, 22);
            this.File_ToolStripMenuItem.Text = "ファイル";
            // 
            // Cancel_ToolStripMenuItem
            // 
            this.Cancel_ToolStripMenuItem.Name = "Cancel_ToolStripMenuItem";
            this.Cancel_ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.Cancel_ToolStripMenuItem.Text = "取消終了";
            // 
            // Exit_ToolStripMenuItem
            // 
            this.Exit_ToolStripMenuItem.Name = "Exit_ToolStripMenuItem";
            this.Exit_ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.Exit_ToolStripMenuItem.Text = "終了";
            // 
            // Edit_ToolStripMenuItem
            // 
            this.Edit_ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.New_ToolStripMenuItem,
            this.Modify_ToolStripMenuItem,
            this.Delete_ToolStripMenuItem,
            this.Update_ToolStripMenuItem});
            this.Edit_ToolStripMenuItem.Name = "Edit_ToolStripMenuItem";
            this.Edit_ToolStripMenuItem.Size = new System.Drawing.Size(44, 22);
            this.Edit_ToolStripMenuItem.Text = "編集";
            // 
            // New_ToolStripMenuItem
            // 
            this.New_ToolStripMenuItem.Name = "New_ToolStripMenuItem";
            this.New_ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.New_ToolStripMenuItem.Text = "新規";
            // 
            // Modify_ToolStripMenuItem
            // 
            this.Modify_ToolStripMenuItem.Name = "Modify_ToolStripMenuItem";
            this.Modify_ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.Modify_ToolStripMenuItem.Text = "訂正";
            // 
            // Delete_ToolStripMenuItem
            // 
            this.Delete_ToolStripMenuItem.Name = "Delete_ToolStripMenuItem";
            this.Delete_ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.Delete_ToolStripMenuItem.Text = "削除";
            // 
            // Update_ToolStripMenuItem
            // 
            this.Update_ToolStripMenuItem.Name = "Update_ToolStripMenuItem";
            this.Update_ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.Update_ToolStripMenuItem.Text = "更新";
            // 
            // Show_ToolStripMenuItem
            // 
            this.Show_ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Select_ToolStripMenuItem,
            this.Refresh_ToolStripMenuItem,
            this.Sort_ToolStripMenuItem});
            this.Show_ToolStripMenuItem.Name = "Show_ToolStripMenuItem";
            this.Show_ToolStripMenuItem.Size = new System.Drawing.Size(44, 22);
            this.Show_ToolStripMenuItem.Text = "表示";
            // 
            // Select_ToolStripMenuItem
            // 
            this.Select_ToolStripMenuItem.Name = "Select_ToolStripMenuItem";
            this.Select_ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.Select_ToolStripMenuItem.Text = "検索";
            // 
            // Refresh_ToolStripMenuItem
            // 
            this.Refresh_ToolStripMenuItem.Name = "Refresh_ToolStripMenuItem";
            this.Refresh_ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.Refresh_ToolStripMenuItem.Text = "リフレッシュ";
            // 
            // Sort_ToolStripMenuItem
            // 
            this.Sort_ToolStripMenuItem.Name = "Sort_ToolStripMenuItem";
            this.Sort_ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.Sort_ToolStripMenuItem.Text = "ソート";
            // 
            // Output_ToolStripMenuItem
            // 
            this.Output_ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Print_ToolStripMenuItem,
            this.Csv_ToolStripMenuItem});
            this.Output_ToolStripMenuItem.Name = "Output_ToolStripMenuItem";
            this.Output_ToolStripMenuItem.Size = new System.Drawing.Size(44, 22);
            this.Output_ToolStripMenuItem.Text = "出力";
            // 
            // Print_ToolStripMenuItem
            // 
            this.Print_ToolStripMenuItem.Name = "Print_ToolStripMenuItem";
            this.Print_ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.Print_ToolStripMenuItem.Text = "印刷";
            // 
            // Csv_ToolStripMenuItem
            // 
            this.Csv_ToolStripMenuItem.Name = "Csv_ToolStripMenuItem";
            this.Csv_ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.Csv_ToolStripMenuItem.Text = "CSV出力";
            // 
            // Renkei_ToolStripMenuItem
            // 
            this.Renkei_ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Download_ToolStripMenuItem});
            this.Renkei_ToolStripMenuItem.Name = "Renkei_ToolStripMenuItem";
            this.Renkei_ToolStripMenuItem.Size = new System.Drawing.Size(44, 22);
            this.Renkei_ToolStripMenuItem.Text = "連携";
            // 
            // Download_ToolStripMenuItem
            // 
            this.Download_ToolStripMenuItem.Name = "Download_ToolStripMenuItem";
            this.Download_ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.Download_ToolStripMenuItem.Text = "ダウンロード";
            this.Download_ToolStripMenuItem.Click += new System.EventHandler(this.Download_ToolStripMenuItem_Click);
            // 
            // split_1
            // 
            this.split_1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.split_1.Location = new System.Drawing.Point(0, 26);
            this.split_1.Name = "split_1";
            this.split_1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // split_1.Panel2
            // 
            this.split_1.Panel2.Controls.Add(this.split_2);
            this.split_1.Size = new System.Drawing.Size(1206, 666);
            this.split_1.SplitterDistance = 45;
            this.split_1.SplitterWidth = 1;
            this.split_1.TabIndex = 1;
            // 
            // split_2
            // 
            this.split_2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.split_2.Location = new System.Drawing.Point(0, 0);
            this.split_2.Name = "split_2";
            // 
            // split_2.Panel1
            // 
            this.split_2.Panel1.Controls.Add(this.spd1);
            this.split_2.Size = new System.Drawing.Size(1206, 620);
            this.split_2.SplitterDistance = 700;
            this.split_2.SplitterWidth = 1;
            this.split_2.TabIndex = 0;
            // 
            // spd1
            // 
            this.spd1.AccessibleDescription = "";
            this.spd1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spd1.Location = new System.Drawing.Point(0, 0);
            this.spd1.Name = "spd1";
            this.spd1.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spd1_Sheet1});
            this.spd1.Size = new System.Drawing.Size(700, 620);
            this.spd1.TabIndex = 0;
            // 
            // spd1_Sheet1
            // 
            this.spd1_Sheet1.Reset();
            this.spd1_Sheet1.SheetName = "Sheet1";
            // 
            // frmMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1206, 692);
            this.Controls.Add(this.split_1);
            this.Controls.Add(this.menuStrip_ms);
            this.MainMenuStrip = this.menuStrip_ms;
            this.MaximizeBox = false;
            this.Name = "frmMaster";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmMaster";
            this.menuStrip_ms.ResumeLayout(false);
            this.menuStrip_ms.PerformLayout();
            this.split_1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.split_1)).EndInit();
            this.split_1.ResumeLayout(false);
            this.split_2.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.split_2)).EndInit();
            this.split_2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spd1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spd1_Sheet1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip_ms;
        private System.Windows.Forms.ToolStripMenuItem File_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Cancel_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Exit_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Edit_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem New_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Modify_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Delete_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Update_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Show_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Select_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Refresh_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Output_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Print_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Csv_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Renkei_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Download_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Sort_ToolStripMenuItem;
        private System.Windows.Forms.SplitContainer split_1;
        private System.Windows.Forms.SplitContainer split_2;
        private FarPoint.Win.Spread.FpSpread spd1;
        private FarPoint.Win.Spread.SheetView spd1_Sheet1;
    }
}