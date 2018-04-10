namespace B2.BestFunction.UserControls
{
    partial class ActionPanelControl
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

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.Title = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.actionSubPanelControl1 = new B2.BestFunction.UserControls.ActionSubPanelControl();
            this.actionSubPanelControl2 = new B2.BestFunction.UserControls.ActionSubPanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Panel1.Controls.Add(this.Title);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.flowLayoutPanel1);
            this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.splitContainer1.Size = new System.Drawing.Size(995, 657);
            this.splitContainer1.SplitterDistance = 70;
            this.splitContainer1.TabIndex = 0;
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Font = new System.Drawing.Font("メイリオ", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Title.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Title.Location = new System.Drawing.Point(27, 27);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(57, 31);
            this.Title.TabIndex = 0;
            this.Title.Text = "Title";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanel1.Controls.Add(this.actionSubPanelControl1);
            this.flowLayoutPanel1.Controls.Add(this.actionSubPanelControl2);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(10, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(975, 583);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // actionSubPanelControl1
            // 
            this.actionSubPanelControl1.BackColor = System.Drawing.Color.Transparent;
            this.actionSubPanelControl1.Location = new System.Drawing.Point(3, 3);
            this.actionSubPanelControl1.Name = "actionSubPanelControl1";
            this.actionSubPanelControl1.Padding = new System.Windows.Forms.Padding(7);
            this.actionSubPanelControl1.Size = new System.Drawing.Size(188, 264);
            this.actionSubPanelControl1.TabIndex = 0;
            // 
            // actionSubPanelControl2
            // 
            this.actionSubPanelControl2.BackColor = System.Drawing.Color.Transparent;
            this.actionSubPanelControl2.Location = new System.Drawing.Point(197, 3);
            this.actionSubPanelControl2.Name = "actionSubPanelControl2";
            this.actionSubPanelControl2.Padding = new System.Windows.Forms.Padding(7);
            this.actionSubPanelControl2.Size = new System.Drawing.Size(188, 264);
            this.actionSubPanelControl2.TabIndex = 1;
            // 
            // ActionPanelControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.splitContainer1);
            this.Name = "ActionPanelControl";
            this.Size = new System.Drawing.Size(995, 657);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        public System.Windows.Forms.Label Title;
        public System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private ActionSubPanelControl actionSubPanelControl1;
        private ActionSubPanelControl actionSubPanelControl2;
    }
}
