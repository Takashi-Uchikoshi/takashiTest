using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace B2.BestFunction
{
    /// <summary>BFアイコンコントロール</summary>
    public partial class BFIconControl : UserControl
    {
        /// <summary>アイコン種類連番</summary>
        public enum IconTypeRenban
        {
            /// <summary>アイコンなし</summary>
            None = 0,
            /// <summary>一覧表示</summary>
            IchiranHyoji,
            /// <summary>検索</summary>
            Kensaku,
            /// <summary>履歴表示</summary>
            RirekiHyoji,
            /// <summary>削除</summary>
            Sakujo,
            /// <summary>修正</summary>
            Shusei,
            /// <summary>追加</summary>
            Tsuika
        }

        /// <summary>アイコン種類</summary>
        public IconTypeRenban IconType
        {
            get { return _IconType; }
            set 
            {
                _IconType = value;
                this.IconPictureBox.Image = mImages[(int)_IconType];
            }
        }
        private IconTypeRenban _IconType = IconTypeRenban.None;

        private Image[] mImages = new Image[]
        {
                null
                ,global::B2.BestFunction.Properties.Resources.IchiranHyojiIcon
                ,global::B2.BestFunction.Properties.Resources.KensakuIcon
                ,global::B2.BestFunction.Properties.Resources.RirekiHyojiIcon
                ,global::B2.BestFunction.Properties.Resources.SakujoIcon
                ,global::B2.BestFunction.Properties.Resources.ShuseiIcon
                ,global::B2.BestFunction.Properties.Resources.TsuikaIcon
        };

        /// <summary>アイコンがクリック及びダブルクリックされたときに発生します。</summary>
        new public event System.EventHandler Click;

        //**********************************************************************
        /// <summary>
        /// BFアイコンコントロールコンストラクタ
        /// </summary>
        //**********************************************************************
        public BFIconControl()
        {
            InitializeComponent();

            if (Enum.GetNames(typeof(IconTypeRenban)).Length != mImages.Length) { MessageBox.Show("コーディング異常"); }
        }

        //**********************************************************************
        /// <summary>
        /// B2.BestFunction.BFIconControl.Click ボタンのイベントを生成します
        /// </summary>
        //**********************************************************************
        public void PerformClick()
        {
            if (this.Click != null)
            {
                this.Click(this, new EventArgs());
            }
        }

        //**********************************************************************
        /// <summary>
        /// クリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //**********************************************************************
        private void This_Click(object sender, EventArgs e)
        {
            if (this.Click != null)
            {
                this.Click(this, e);
            }
        }
    }

}
