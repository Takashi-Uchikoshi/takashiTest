namespace B2.BestFunction.UserControls
{
    partial class KinoButtonControl
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
            this.labelLine = new System.Windows.Forms.Label();
            this.Button = new B2.BestFunction.UserControls.ButtonLabel();
            this.SuspendLayout();
            // 
            // labelLine
            // 
            this.labelLine.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.labelLine.Dock = System.Windows.Forms.DockStyle.None;
            this.labelLine.Location = new System.Drawing.Point(10, 0);
            this.labelLine.Name = "labelLine";
            this.labelLine.Size = new System.Drawing.Size(205-20, 1);
            this.labelLine.TabIndex = 1;
            // 
            // Button
            // 
            this.Button.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Button.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Button.Location = new System.Drawing.Point(0, 10);
            this.Button.Name = "Button";
            this.Button.Size = new System.Drawing.Size(205, 40);
            this.Button.TabIndex = 2;
            this.Button.Text = "Text";
            this.Button.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // KinoButtonControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelLine);
            this.Controls.Add(this.Button);
            this.Name = "KinoButtonControl";
            this.Size = new System.Drawing.Size(205, 55);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelLine;
        public ButtonLabel Button;
    }
}
