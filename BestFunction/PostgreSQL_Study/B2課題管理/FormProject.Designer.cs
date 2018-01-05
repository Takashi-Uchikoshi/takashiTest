namespace B2
{
    partial class FormProject
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
            this.txt_orderno = new System.Windows.Forms.TextBox();
            this.lbl_orderno = new System.Windows.Forms.Label();
            this.lbl_user_name = new System.Windows.Forms.Label();
            this.lbl_pname = new System.Windows.Forms.Label();
            this.lbl_pno = new System.Windows.Forms.Label();
            this.txt_pno = new System.Windows.Forms.TextBox();
            this.txt_pname = new System.Windows.Forms.TextBox();
            this.txt_user_name = new System.Windows.Forms.TextBox();
            this.txt_maker = new System.Windows.Forms.TextBox();
            this.lbl_maker = new System.Windows.Forms.Label();
            this.lbl_parson = new System.Windows.Forms.Label();
            this.txt_parson = new System.Windows.Forms.TextBox();
            this.btn_Ok = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.txt_bikou = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txt_orderno
            // 
            this.txt_orderno.BackColor = System.Drawing.Color.White;
            this.txt_orderno.Location = new System.Drawing.Point(129, 88);
            this.txt_orderno.MaxLength = 9;
            this.txt_orderno.Name = "txt_orderno";
            this.txt_orderno.Size = new System.Drawing.Size(72, 19);
            this.txt_orderno.TabIndex = 3;
            this.txt_orderno.Text = "A9999-999";
            this.txt_orderno.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_orderno_KeyDown);
            // 
            // lbl_orderno
            // 
            this.lbl_orderno.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lbl_orderno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_orderno.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbl_orderno.Location = new System.Drawing.Point(22, 84);
            this.lbl_orderno.Name = "lbl_orderno";
            this.lbl_orderno.Size = new System.Drawing.Size(100, 23);
            this.lbl_orderno.TabIndex = 57;
            this.lbl_orderno.Text = "受注管理番号";
            this.lbl_orderno.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_user_name
            // 
            this.lbl_user_name.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lbl_user_name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_user_name.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbl_user_name.Location = new System.Drawing.Point(22, 60);
            this.lbl_user_name.Name = "lbl_user_name";
            this.lbl_user_name.Size = new System.Drawing.Size(100, 23);
            this.lbl_user_name.TabIndex = 58;
            this.lbl_user_name.Text = "顧客名";
            this.lbl_user_name.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_pname
            // 
            this.lbl_pname.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lbl_pname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_pname.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbl_pname.Location = new System.Drawing.Point(22, 35);
            this.lbl_pname.Name = "lbl_pname";
            this.lbl_pname.Size = new System.Drawing.Size(100, 23);
            this.lbl_pname.TabIndex = 59;
            this.lbl_pname.Text = "プロジェクト名";
            this.lbl_pname.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_pno
            // 
            this.lbl_pno.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lbl_pno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_pno.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbl_pno.Location = new System.Drawing.Point(22, 9);
            this.lbl_pno.Name = "lbl_pno";
            this.lbl_pno.Size = new System.Drawing.Size(100, 23);
            this.lbl_pno.TabIndex = 60;
            this.lbl_pno.Text = "プロジェクト№";
            this.lbl_pno.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txt_pno
            // 
            this.txt_pno.BackColor = System.Drawing.Color.White;
            this.txt_pno.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txt_pno.Location = new System.Drawing.Point(129, 11);
            this.txt_pno.MaxLength = 6;
            this.txt_pno.Name = "txt_pno";
            this.txt_pno.Size = new System.Drawing.Size(56, 20);
            this.txt_pno.TabIndex = 0;
            this.txt_pno.Text = "123456";
            this.txt_pno.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_pno_KeyDown);
            // 
            // txt_pname
            // 
            this.txt_pname.BackColor = System.Drawing.Color.White;
            this.txt_pname.Location = new System.Drawing.Point(129, 36);
            this.txt_pname.MaxLength = 50;
            this.txt_pname.Name = "txt_pname";
            this.txt_pname.Size = new System.Drawing.Size(410, 19);
            this.txt_pname.TabIndex = 1;
            this.txt_pname.Text = "１２３４５６７８９０１２３４５６７８９０１２３４５６７８９０１２３４５６７８９０１２３４５６７８９０";
            this.txt_pname.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_pname_KeyDown);
            // 
            // txt_user_name
            // 
            this.txt_user_name.BackColor = System.Drawing.Color.White;
            this.txt_user_name.Location = new System.Drawing.Point(129, 61);
            this.txt_user_name.MaxLength = 50;
            this.txt_user_name.Name = "txt_user_name";
            this.txt_user_name.Size = new System.Drawing.Size(410, 19);
            this.txt_user_name.TabIndex = 2;
            this.txt_user_name.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_user_name_KeyDown);
            // 
            // txt_maker
            // 
            this.txt_maker.BackColor = System.Drawing.Color.White;
            this.txt_maker.Location = new System.Drawing.Point(129, 109);
            this.txt_maker.MaxLength = 50;
            this.txt_maker.Name = "txt_maker";
            this.txt_maker.Size = new System.Drawing.Size(410, 19);
            this.txt_maker.TabIndex = 4;
            this.txt_maker.Text = "日本事務器　札幌支社";
            this.txt_maker.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_maker_KeyDown);
            // 
            // lbl_maker
            // 
            this.lbl_maker.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lbl_maker.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_maker.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbl_maker.Location = new System.Drawing.Point(22, 109);
            this.lbl_maker.Name = "lbl_maker";
            this.lbl_maker.Size = new System.Drawing.Size(100, 23);
            this.lbl_maker.TabIndex = 67;
            this.lbl_maker.Text = "発注元名";
            this.lbl_maker.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_parson
            // 
            this.lbl_parson.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lbl_parson.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_parson.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbl_parson.Location = new System.Drawing.Point(22, 134);
            this.lbl_parson.Name = "lbl_parson";
            this.lbl_parson.Size = new System.Drawing.Size(100, 23);
            this.lbl_parson.TabIndex = 69;
            this.lbl_parson.Text = "発注担当者名";
            this.lbl_parson.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txt_parson
            // 
            this.txt_parson.BackColor = System.Drawing.Color.White;
            this.txt_parson.Location = new System.Drawing.Point(129, 135);
            this.txt_parson.MaxLength = 10;
            this.txt_parson.Name = "txt_parson";
            this.txt_parson.Size = new System.Drawing.Size(125, 19);
            this.txt_parson.TabIndex = 5;
            this.txt_parson.Text = "日本事務器　太郎花子";
            this.txt_parson.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_parson_KeyDown);
            // 
            // btn_Ok
            // 
            this.btn_Ok.Location = new System.Drawing.Point(367, 219);
            this.btn_Ok.Name = "btn_Ok";
            this.btn_Ok.Size = new System.Drawing.Size(75, 30);
            this.btn_Ok.TabIndex = 7;
            this.btn_Ok.Text = "実行";
            this.btn_Ok.UseVisualStyleBackColor = true;
            this.btn_Ok.Click += new System.EventHandler(this.btn_Ok_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(463, 219);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 30);
            this.btn_Cancel.TabIndex = 8;
            this.btn_Cancel.Text = "取消";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // txt_bikou
            // 
            this.txt_bikou.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txt_bikou.Location = new System.Drawing.Point(129, 162);
            this.txt_bikou.MaxLength = 100;
            this.txt_bikou.Multiline = true;
            this.txt_bikou.Name = "txt_bikou";
            this.txt_bikou.Size = new System.Drawing.Size(409, 35);
            this.txt_bikou.TabIndex = 6;
            this.txt_bikou.Text = "１２３４５６７８９０１２３４５６７８９０１２３４５６７８９０１２３４５６７８９０１２３４５６７８９０１２３４５６７８９０１２３４５６７８９０１２３４５６７８９０１" +
    "２３４５６７８９０１２３４５６７８９０";
            this.txt_bikou.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_bikou_KeyDown);
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label7.Location = new System.Drawing.Point(21, 159);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 23);
            this.label7.TabIndex = 76;
            this.label7.Text = "備考";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FormProject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 261);
            this.Controls.Add(this.txt_bikou);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_Ok);
            this.Controls.Add(this.txt_maker);
            this.Controls.Add(this.lbl_maker);
            this.Controls.Add(this.lbl_parson);
            this.Controls.Add(this.txt_parson);
            this.Controls.Add(this.txt_user_name);
            this.Controls.Add(this.txt_pname);
            this.Controls.Add(this.txt_pno);
            this.Controls.Add(this.txt_orderno);
            this.Controls.Add(this.lbl_orderno);
            this.Controls.Add(this.lbl_user_name);
            this.Controls.Add(this.lbl_pname);
            this.Controls.Add(this.lbl_pno);
            this.Name = "FormProject";
            this.Text = "プロジェクト情報の登録";
            this.Load += new System.EventHandler(this.FormProject_Load);
            this.Shown += new System.EventHandler(this.FormProject_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_orderno;
        private System.Windows.Forms.Label lbl_orderno;
        private System.Windows.Forms.Label lbl_user_name;
        private System.Windows.Forms.Label lbl_pname;
        private System.Windows.Forms.Label lbl_pno;
        private System.Windows.Forms.TextBox txt_pno;
        private System.Windows.Forms.TextBox txt_pname;
        private System.Windows.Forms.TextBox txt_user_name;
        private System.Windows.Forms.TextBox txt_maker;
        private System.Windows.Forms.Label lbl_maker;
        private System.Windows.Forms.Label lbl_parson;
        private System.Windows.Forms.TextBox txt_parson;
        private System.Windows.Forms.Button btn_Ok;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.TextBox txt_bikou;
        private System.Windows.Forms.Label label7;
    }
}