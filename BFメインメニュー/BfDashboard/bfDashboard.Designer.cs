namespace B2.BestFunction
{
    partial class BfDashboardForm
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
            this.components = new System.ComponentModel.Container();
            this.split1 = new System.Windows.Forms.SplitContainer();
            this.menuLevelLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.userAccountBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.split1)).BeginInit();
            this.split1.Panel1.SuspendLayout();
            this.split1.Panel2.SuspendLayout();
            this.split1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userAccountBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // split1
            // 
            this.split1.BackColor = System.Drawing.Color.White;
            this.split1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.split1.IsSplitterFixed = true;
            this.split1.Location = new System.Drawing.Point(0, 0);
            this.split1.Name = "split1";
            this.split1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // split1.Panel1
            // 
            this.split1.Panel1.BackColor = System.Drawing.Color.White;
            this.split1.Panel1.Controls.Add(this.menuLevelLabel);
            // 
            // split1.Panel2
            // 
            this.split1.Panel2.BackColor = System.Drawing.Color.White;
            this.split1.Panel2.Controls.Add(this.label1);
            this.split1.Size = new System.Drawing.Size(995, 657);
            this.split1.SplitterDistance = 129;
            this.split1.TabIndex = 0;
            // 
            // menuLevelLabel
            // 
            this.menuLevelLabel.AutoSize = true;
            this.menuLevelLabel.Font = new System.Drawing.Font("メイリオ", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.menuLevelLabel.ForeColor = System.Drawing.Color.Gray;
            this.menuLevelLabel.Location = new System.Drawing.Point(27, 27);
            this.menuLevelLabel.Name = "menuLevelLabel";
            this.menuLevelLabel.Size = new System.Drawing.Size(115, 31);
            this.menuLevelLabel.TabIndex = 0;
            this.menuLevelLabel.Text = "Dashboad";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("メイリオ", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(385, 185);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(199, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Dashboad　開発中";
            // 
            // userAccountBindingSource
            // 
            this.userAccountBindingSource.DataSource = typeof(B2.BestFunction.Entities.UserAccount);
            // 
            // BfDashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(995, 657);
            this.Controls.Add(this.split1);
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "BfDashboardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ユーザーアカウント情報保守";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BfDashboardForm_FormClosing);
            this.Load += new System.EventHandler(this.BfDashboardForm_Load);
            this.Shown += new System.EventHandler(this.BfDashboardForm_Shown);
            this.split1.Panel1.ResumeLayout(false);
            this.split1.Panel1.PerformLayout();
            this.split1.Panel2.ResumeLayout(false);
            this.split1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.split1)).EndInit();
            this.split1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.userAccountBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer split1;
        private System.Windows.Forms.BindingSource userAccountBindingSource;
        private System.Windows.Forms.Label menuLevelLabel;
        private System.Windows.Forms.Label label1;

    }
}

