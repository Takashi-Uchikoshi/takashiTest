using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace B2.Com
{
    public partial class frmShowMessage : Form
    {
        /// <summary>タイトル</summary>
        public string msgTitle;
        /// <summary>メッセージ</summary>
        public string msgString;
        /// <summary>アイコン</summary>
        public MessageBoxIcon msgIcon;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="title">タイトル</param>
        /// <param name="message">メッセージ</param>
        /// <param name="icon">アイコン</param>
        public frmShowMessage(string title, string message, MessageBoxIcon icon)
        {
            InitializeComponent();

            msgTitle = title;
            msgString = message;
            msgIcon = icon;
        }

        /// <summary>
        /// フォームロード
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowMessage_Load(object sender, EventArgs e)
        {
            Bitmap img = GetIconImage();
            if(img != null)
                this.picIcon.Size = img.Size;
            this.picIcon.Image = img;

            this.Text = msgTitle;
            this.lblMessage.Text = msgString;
        }

        /// <summary>
        /// ＯＫボタンクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// アイコンイメージ取得
        /// </summary>
        /// <returns>アイコンイメージ</returns>
        private Bitmap GetIconImage()
        {
            switch(msgIcon)
            {
                //case MessageBoxIcon.Asterisk:
                //    return SystemIcons.Asterisk.ToBitmap();
                case MessageBoxIcon.Error:
                    return SystemIcons.Error.ToBitmap();
                case MessageBoxIcon.Exclamation:
                    return SystemIcons.Exclamation.ToBitmap();
                //case MessageBoxIcon.Hand:
                //    return SystemIcons.Hand.ToBitmap();
                case MessageBoxIcon.Information:
                    return SystemIcons.Information.ToBitmap();
                case MessageBoxIcon.None:
                    return null;
                case MessageBoxIcon.Question:
                    return SystemIcons.Question.ToBitmap();
                //case MessageBoxIcon.Stop:
                //    return SystemIcons.Error.ToBitmap();
                //case MessageBoxIcon.Warning:
                //    return SystemIcons.Warning.ToBitmap();
            }
            return SystemIcons.WinLogo.ToBitmap();
        }
    }
}
