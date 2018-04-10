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
    /// <summary>
    /// テキスト入力フォームクラス
    /// </summary>
    public partial class InputBoxForm : Form
    {
        /// <summary>OK選択情報(TRUE:OK選択)</summary>
        private bool okSelectFlag;
        /// <summary>OK選択フラグ(true:OK選択 false:キャンセル)</summary>
        public bool OkSelectFlag
        {
            get { return okSelectFlag; }
            set { okSelectFlag = value; }
        }

        /// <summary> ラベル情報 </summary>
        private string labelText;
        /// <summary>ラベル表示テキスト</summary>
        public string LabelText
        {
            set { labelText = value; }
        }

        /// <summary>入力テキスト</summary>
        private string inputText;
        /// <summary>入力テキスト</summary>
        public string InPutText
        {
            get { return inputText; }
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public InputBoxForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// フォームロードイベント
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void InputBox_Load(object sender, EventArgs e)
        {
            this.label1.Text = this.labelText;
        }

        /// <summary>
        /// OKボタンクリックイベント
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void button1_Click(object sender, EventArgs e)
        {
            this.okSelectFlag = true;
            this.inputText = this.textBox1.Text;
            this.Close();
        }

        /// <summary>
        /// キャンセルボタンクリックイベント
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void button2_Click(object sender, EventArgs e)
        {
            this.okSelectFlag = false;
            this.Close();
        }
    }
}
