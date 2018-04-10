using System;
using System.Windows.Forms;
using B2.Com;

namespace B2.BestFunction
{
    public partial class BfDashboardForm : BFBaseForm
    {
        // 共通パラメータ
        private B2Com b2Com;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="b2com">B2共通パラメータ</param>
        public BfDashboardForm(B2Com b2com)
        {
            //共通パラメータのセット
            b2Com = b2com;

            //コントロールの初期化
            InitializeComponent();
        }

        /// <summary>
        /// Loadイベント時の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>     
        private void BfDashboardForm_Load(object sender, EventArgs e)
        {
            //プログラム開始ログの出力
            b2Com.WriteSysLog(B2Com.LogfileCodeStart, b2Com.DbUserMei, "プログラムを開始します。");
        }

        /// <summary>
        /// 表示イベント時の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BfDashboardForm_Shown(object sender, EventArgs e)
        {
            try
            {
                // メニュー階層
                this.menuLevelLabel.Text = this.MenuLevel;
            }
            catch (Exception ex)
            {
                b2Com.ShowErrMsg(ex);
                this.Close();
            }
        }


        /// <summary>
        /// 終了処理
        /// </summary>
        private void BfDashboardForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //プログラム終了ログの出力
            b2Com.WriteSysLog(B2Com.LogfileCodeExit, b2Com.DbUserMei, "プログラムを終了します。");

            // メインメニューへ終了イベントを通知する
            base.CallBFCallbackEvent(BFCallbackEventType.Exit, BFCallbackEventResuslt.Success, "BfDashboardFormを終了します。");
        }

        #region override

        /// <summary>
        /// 検索
        /// </summary>
        /// <param name="key">検索文字列</param>
        public override void SearchItem(string key)
        {
            // keyで検索する処理をここに追加する
        }

        /// <summary>
        /// 終了
        /// 終了可能であれば終了処理をしてtrueを返す
        /// 編集不可のばあいはfalseを返す
        /// </summary>
        public override bool CanClose()
        {
            this.Close();
            return true;
        }

        #endregion // override

        private void gcTxtExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
