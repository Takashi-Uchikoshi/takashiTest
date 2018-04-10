namespace B2.BestFunction.UserControls
{
    partial class ActionSubPanelControl
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.Button1 = new B2.BestFunction.UserControls.ButtonLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Button4 = new B2.BestFunction.UserControls.ButtonLabel();
            this.Button3 = new B2.BestFunction.UserControls.ButtonLabel();
            this.Button2 = new B2.BestFunction.UserControls.ButtonLabel();
            this.Note = new System.Windows.Forms.Label();
            this.Title = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(201)))), ((int)(((byte)(244)))));
            this.panel1.Controls.Add(this.Button1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.Note);
            this.panel1.Controls.Add(this.Title);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(7, 10);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(3);
            this.panel1.Size = new System.Drawing.Size(174, 250);
            this.panel1.TabIndex = 0;
            // 
            // Button1
            // 
            this.Button1.BackColor = System.Drawing.Color.White;
            this.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button1.ForeColor = System.Drawing.Color.Transparent;
            this.Button1.Image = global::B2.BestFunction.Properties.Resources.kensaku;
            this.Button1.Location = new System.Drawing.Point(134, 3);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(37, 31);
            this.Button1.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.Button4);
            this.panel2.Controls.Add(this.Button3);
            this.panel2.Controls.Add(this.Button2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(3, 213);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(168, 34);
            this.panel2.TabIndex = 4;
            // 
            // Button4
            // 
            this.Button4.BackColor = System.Drawing.Color.White;
            this.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button4.ForeColor = System.Drawing.Color.Transparent;
            this.Button4.Image = global::B2.BestFunction.Properties.Resources.shinki;
            this.Button4.Location = new System.Drawing.Point(133, 2);
            this.Button4.Name = "Button4";
            this.Button4.Size = new System.Drawing.Size(35, 32);
            this.Button4.TabIndex = 6;
            // 
            // Button3
            // 
            this.Button3.BackColor = System.Drawing.Color.White;
            this.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button3.ForeColor = System.Drawing.Color.Transparent;
            this.Button3.Image = global::B2.BestFunction.Properties.Resources.ichiran;
            this.Button3.Location = new System.Drawing.Point(66, 1);
            this.Button3.Name = "Button3";
            this.Button3.Size = new System.Drawing.Size(39, 33);
            this.Button3.TabIndex = 6;
            // 
            // Button2
            // 
            this.Button2.BackColor = System.Drawing.Color.White;
            this.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button2.ForeColor = System.Drawing.Color.Transparent;
            this.Button2.Image = global::B2.BestFunction.Properties.Resources.rireki;
            this.Button2.Location = new System.Drawing.Point(0, 1);
            this.Button2.Name = "Button2";
            this.Button2.Size = new System.Drawing.Size(39, 33);
            this.Button2.TabIndex = 6;
            // 
            // Note
            // 
            this.Note.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Note.ForeColor = System.Drawing.Color.White;
            this.Note.Location = new System.Drawing.Point(14, 44);
            this.Note.Name = "Note";
            this.Note.Size = new System.Drawing.Size(145, 166);
            this.Note.TabIndex = 1;
            this.Note.Text = "Note";
            // 
            // Title
            // 
            this.Title.BackColor = System.Drawing.Color.White;
            this.Title.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Title.Location = new System.Drawing.Point(3, 3);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(168, 31);
            this.Title.TabIndex = 0;
            this.Title.Text = "Title";
            this.Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ActionSubPanelControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.panel1);
            this.Name = "ActionSubPanelControl";
            this.Padding = new System.Windows.Forms.Padding(7, 10, 7, 10);
            this.Size = new System.Drawing.Size(188, 270);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Label Note;
        public System.Windows.Forms.Label Title;
        public ButtonLabel Button1;
        public ButtonLabel Button2;
        public ButtonLabel Button3;
        public ButtonLabel Button4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}
