using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace B2.BestFunction
{
//    public abstract partial class BfForm : Form
    public partial class BfForm : Form
    {
        public BfForm()
        {
            InitializeComponent();
        }

        public virtual void kensaku(string keyField, string key)
        {
            return;
        }

        public virtual void kinou_exit()
        {
            return;
        }

        public virtual void kinou_cancel()
        {
            return;
        }

        #region コールバック
        //-----------------------------------
        // メインFormへ伝えるイベントハンドラを定義
        public event MyEventHandler MyProgressEvent;

        // 呼び出し元Formへイベントを伝える関数を定義
        public virtual void UpdateProgress(int commandNumValue, string commandStringValue)
        {
            MyProgressEvent(new MyEventArgs(commandNumValue, commandStringValue));
        }

        //-----------------------------------
        //イベントハンドラのデリゲートを定義
        public delegate void MyEventHandler(MyEventArgs e);

        //-----------------------------------
        // 渡せるイベントデータ引数、EventArgsを継承したクラスを拡張
        public class MyEventArgs : EventArgs
        {
            private readonly int _commandNumValue;
            private readonly string _commandStringValue;

            public MyEventArgs(int commandNumValue, string commandStringValue)
            {
                _commandNumValue = commandNumValue;
                _commandStringValue = commandStringValue;
            }
            public int commandNumValue { get { return _commandNumValue; } }
            public string commandStringValue { get { return _commandStringValue; } }

        }
        #endregion

    }
}
