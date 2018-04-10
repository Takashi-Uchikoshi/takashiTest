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
            /// <summary>CSV出力</summary>
            Csv,
            /// <summary>一覧表示</summary>
            IchiranHyoji,
            /// <summary>検索</summary>
            Kensaku,
            /// <summary>検索(16×16)</summary>
            KensakuIcon16,
            /// <summary>PFD出力</summary>
            Pdf,
            /// <summary>履歴表示</summary>
            RirekiHyoji,
            /// <summary>削除</summary>
            Sakujo,
            /// <summary>修正</summary>
            Shusei,
            /// <summary>閉じる</summary>
            Tojiru,
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

                switch (_IconType)
                {
                    case IconTypeRenban.None:
                        this.IconPictureBox.Image = null;
                        break;
                    case IconTypeRenban.Csv:
                        this.IconPictureBox.Image = global::B2.BestFunction.Properties.Resources.CsvIcon;
                        break;
                    case IconTypeRenban.IchiranHyoji:
                        this.IconPictureBox.Image = global::B2.BestFunction.Properties.Resources.IchiranHyojiIcon;
                        break;
                    case IconTypeRenban.Kensaku:
                        this.IconPictureBox.Image = global::B2.BestFunction.Properties.Resources.KensakuIcon;
                        break;
                    case IconTypeRenban.KensakuIcon16:
                        this.IconPictureBox.Image = global::B2.BestFunction.Properties.Resources.KensakuIcon16;
                        break;
                    case IconTypeRenban.Pdf:
                        this.IconPictureBox.Image = global::B2.BestFunction.Properties.Resources.PdfIcon;
                        break;
                    case IconTypeRenban.RirekiHyoji:
                        this.IconPictureBox.Image = global::B2.BestFunction.Properties.Resources.RirekiHyojiIcon;
                        break;
                    case IconTypeRenban.Sakujo:
                        this.IconPictureBox.Image = global::B2.BestFunction.Properties.Resources.SakujoIcon;
                        break;
                    case IconTypeRenban.Shusei:
                        this.IconPictureBox.Image = global::B2.BestFunction.Properties.Resources.ShuseiIcon;
                        break;
                    case IconTypeRenban.Tojiru:
                        this.IconPictureBox.Image = global::B2.BestFunction.Properties.Resources.TojiruIcon;
                        break;
                    case IconTypeRenban.Tsuika:
                        this.IconPictureBox.Image = global::B2.BestFunction.Properties.Resources.TsuikaIcon;
                        break;
                    default:
                        break;
                }
            }
        }
        private IconTypeRenban _IconType = IconTypeRenban.None;

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
