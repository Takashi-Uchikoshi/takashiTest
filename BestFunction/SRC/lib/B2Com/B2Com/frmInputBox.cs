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
    public partial class frmInputBox : Form
  {
        /// <summary> OK選択情報 </summary>
        private bool mblnOkSelect;                              // OK選択フラグ(TRUE:OK選択)
        public bool RETC
        {
            get { return mblnOkSelect; }
            set { mblnOkSelect = value; }
        }

        /// <summary> ラベル情報 </summary>
        private string labeltext;
        public string LABEL
        {
            set { labeltext = value; }
        }

        /// <summary> OK選択情報 </summary>
        private string InText;                              // OK選択フラグ(TRUE:OK選択)
        public string InPutText
        {
            get { return InText; }
        }

        public frmInputBox()
        {
            InitializeComponent();
        }

        private void InputBox_Load(object sender, EventArgs e)
        {
            this.label1.Text = labeltext;
            //this.textBox1.Text = InText;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            mblnOkSelect = true;
            InText = this.textBox1.Text;
            this.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            mblnOkSelect = false;
            this.Close();
        }

    }
}
