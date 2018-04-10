using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using B2.BestFunction.Entities;
using B2.BestFunction.Models;
using B2.BestFunction.UserControls;
using B2.Com;

namespace B2.BestFunction
{
    public partial class MenuForm : Form
    {
        // メニューボタン情報
        private BfMenu bfMenu;

        // 選択中の機能ボタン。bfFormを閉じたときに、閉じる前のアクションボタンを表示するため。
        private KinoButton kinoButtonSelected;

        // 機能パネルに貼り付けるフォーム
        private BFBaseForm bfForm = null;

        // B2共通パラメータ
        private B2Com b2Com;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="b2Com_">B2共通パラメータ</param>
        public MenuForm(B2Com b2Com)
        {
            this.b2Com = b2Com;

            InitializeComponent();           
            this.SetKinoButtons();
            this.KeyPreview = true;
        }

        // Load
        private void MenuForm_Load(object sender, EventArgs e)
        {
            try
            {
                //プログラム開始ログの出力
                this.b2Com.WriteSysLog(B2Com.LogfileCodeStart, this.b2Com.DbUserMei, "プログラムを開始します。");

                // ■TBD. ログインダイアログを実装したらコメント解除する
                //// ログイン
                //{
                //    var form = new LoginForm();
                //    form.ShowDialog();
                //    if (form.DialogResult != System.Windows.Forms.DialogResult.OK)
                //    {
                //        this.Close();
                //        return;
                //    }
                //}
            }
            catch (Exception ex)
            {
                this.b2Com.ShowErrMsg(ex);
            }
        }

        //初期表示
        private void MenuForm_Shown(object sender, EventArgs e)
        {
            try
            {
                // ■TBD. DBから取得する
                //ログイン名称
                userNameLabel.Text = "浅井　太郎";

                // 日付と薬局名称
                using (var context = new BfDbContext(this.b2Com))
                {
                    var yakkyokuMei = context.TenpoMaster.
                        Where(x => x.YakkyokuCode == this.b2Com.YakkyokuCode).
                        Select(x => x.MiseTenmei).FirstOrDefault();
                    this.dateAndYakkyokuMeiLabel.Text = DateTime.Today.ToString("yyyy/MM/dd") + "\n" + yakkyokuMei;
                }
            }
            catch (Exception ex)
            {
                this.b2Com.ShowErrMsg(ex);
                this.Close();
            }
        }

        //終了
        private void MenuForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                // bfFormを閉じることができないときは終了しない
                if (this.bfForm != null)
                {
                    if (this.bfForm.CanClose() == false)
                    {
                        e.Cancel = true;
                        return;
                    }
                }

                // 終了確認
                //if (MessageBox.Show(this.Text + "を終了します。\r\nよろしいですか？", "確認", MessageBoxButtons.YesNo,
                //    MessageBoxIcon.Question) != DialogResult.Yes)
                //{
                //    e.Cancel = true;
                //    return;
                //}

                //プログラム終了ログの出力
                this.b2Com.WriteSysLog(B2Com.LogfileCodeExit, this.b2Com.DbUserMei, "プログラムを終了します。");
            }
            catch (Exception ex)
            {
                this.b2Com.ShowErrMsg(ex);
                return;
            }
        }

        //検索
        private void searchButton_Click(object sender, EventArgs e)
        {
            //■TBD. 　gcComboBox1　で検索対象を選択して対象のbfFormに検索textを投げる予定
            // var fielddata = gcComboBox1.SelectedItem.Text;
            // 取り急ぎ、現在のbfFormへ検索textを投げることにする
            this.bfForm.SearchItem(searchTextBox.Text);
        }

        /// <summary>
        /// ログアウト
        /// メイン画面を隠してログイン画面を表示する
        /// </summary>
        private void logoutButtonTextBox_Click(object sender, EventArgs e)
        {
            this.Hide();

            // ログインダイアログ
            {
                var form = new LoginForm();
                form.ShowDialog();
                if (form.DialogResult != System.Windows.Forms.DialogResult.OK)
                {
                    this.Close();
                    return;
                }
            }

            this.Show();
        }

        //---------------------------------------------

        /// <summary>機能ボタンを配置する</summary>
        private void SetKinoButtons()
        {
            try
            {

                // 設定テーブルからメニュー構成データを取得
                var context = new BfDbContext(b2Com);
                var json = context.MenuData.Select(x => x.Data).FirstOrDefault();
                this.bfMenu = BfMenu.Deserialize(json);

                // テスト用
                //this.bfMenu = new BfMenu();
                //var json = BfMenu.Serialize(this.bfMenu);

                // 機能ボタンを配置する
                this.flowLayoutPanel1.Controls.Clear();
                this.flowLayoutPanel1.Controls.Add(this.dateAndYakkyokuMeiLabel);

                foreach (var kinoButton in this.bfMenu.KinoButtons)
                {
                    var control = new KinoButtonControl();
                    control.Button.Tag = kinoButton;
                    control.Button.Text = kinoButton.Text;
                    control.Button.Click += this.kinoButton_Click;
                    control.Button.DoubleClick += this.kinoButton_Click;
                    this.flowLayoutPanel1.Controls.Add(control);
                }

                // kinoButtonSelectedの初期化
                this.kinoButtonSelected = this.bfMenu.KinoButtons[0];
            }
            catch (Exception ex)
            {
                this.b2Com.ShowErrMsg(ex);
            }
        }

        /// <summary>
        /// 機能ボタンのクリックでアクションパネルを表示 or bfFrom を表示
        /// </summary>
        public void kinoButton_Click(object sender, EventArgs e)
        {
            var kinoButton = (KinoButton)(((ButtonLabel)sender).Tag);

            if (kinoButton.Type == KinoButtonType.SetActionButtons)
            {
                this.SetActionButtons(kinoButton);
            }
            else
            {
                this.SetBfForm(kinoButton.Command);
            }
        }

        /// <summary>
        /// アクションボタンを配置する
        /// </summary>
        /// <param name="flowLayoutPanel">機能ボタンを配置するパネル</param>
        /// <param name="button_Click">ボタンクリック時のイベント</param>
        private void SetActionButtons(KinoButton kinoButton)
        {
            // BfFormを閉じることができない場合はアクションボタンの配置をしない
            if (this.bfForm != null)
            {
                if (this.bfForm.CanClose() == false)
                {
                    return;
                }
            }

            // 機能パネルへ貼り付けるコントロールを作成

            // actionPanelControl
            var actionPanelControl = new ActionPanelControl();
            actionPanelControl.flowLayoutPanel1.Controls.Clear();
            actionPanelControl.Title.Text = kinoButton.Text;

            // actionSubPanel 
            foreach (var actionSubPanel in kinoButton.ActionSubPanels)
            {
                var actionSubPanelControl = new ActionSubPanelControl();
                actionSubPanelControl.Title.Text = actionSubPanel.Title;
                actionSubPanelControl.Note.Text = actionSubPanel.Note;

                actionPanelControl.flowLayoutPanel1.Controls.Add(actionSubPanelControl);

                // actionButton
                {
                    // 一旦、非表示に設定
                    var buttons = new List<ButtonLabel>
                    {
                        actionSubPanelControl.Button1,
                        actionSubPanelControl.Button2,
                        actionSubPanelControl.Button3,
                        actionSubPanelControl.Button4,
                    };
                    buttons.ForEach(x => x.Visible = false);

                    // actionButton
                    int i = 0;
                    foreach (var actionButton in actionSubPanel.ActionButtons)
                    {
                        buttons[i].Visible = actionButton.Command.Enable;
                        buttons[i].Tag = actionButton;
                        buttons[i].Click += this.ActionButton_Click;
                        buttons[i].DoubleClick += this.ActionButton_Click;
                        i++;
                    }
                }
            }

            // 機能パネルへ反映
            this.kinoPanel1.Replace(actionPanelControl);

            // bfFormを閉じたときに前に表示していたアクションボタンを表示するために選択されたkinoButtonを覚えておく
            this.kinoButtonSelected = kinoButton;
        }

        /// <summary>
        /// 機能ボタンのクリックで bfForm を表示
        /// </summary>
        private void ActionButton_Click(object sender, EventArgs e)
        {
            var actionButton = (ActionButton)(((ButtonLabel)sender).Tag);
            this.SetBfForm(actionButton.Command);
        }

        //動的にフォームをインスタン化して表示する。
        private void SetBfForm(Command command)
        {
            // BfFormを閉じることができない場合はアクションボタンの配置をしない
            if (this.bfForm != null)
            {
                if (this.bfForm.CanClose() == false)
                {
                    return;
                }
            }

            try
            {
                // exeファイルを読み込む
                var fileFullName = System.Environment.CurrentDirectory + @"\" + command.FileName;
                var asm = System.Reflection.Assembly.LoadFile(fileFullName);

                // FormのTypeを取得する
                var t = asm.GetType(command.FormName);
                if (t == null)
                {
                    MessageBox.Show("Typeの取得で異常です。");
                    return;
                }

                // Formのインスタンスを作成する
                object frm = t.InvokeMember(null,
                    System.Reflection.BindingFlags.CreateInstance,
                    null, null, new object[] { this.b2Com });

                // Baseフォームにキャスト
                this.bfForm = (BFBaseForm)frm;

                // Fromのスタイル
                this.bfForm.Dock = DockStyle.Fill;
                this.bfForm.TopLevel = false;

                // 機能パネルに配置
                this.kinoPanel1.Replace(this.bfForm);

                // イベントハンドラの追加（コールバックイベントの追加）
                this.bfForm.BFCallbackEvent += this.CallBackEventFromBfForm;

                // bfForm 共通パラメータをセット
                this.bfForm.ShowMode = command.MenuShowMode;
                this.bfForm.MenuLevel = command.MenuLevel;

                // フォームを表示する
                this.bfForm.Show();

                // メモ：モーダルダイアログとしては表示出来ない。Exception	{"トップ レベルのフォームでないフォームをモーダル ダイアログ ボックスとして表示できません。showDialog を呼び出す前に、親からフォームを削除してください。"}	System.Exception {System.InvalidOperationException}
                //this.bfForm.ShowDialog();
            }
            catch (Exception ex)
            {
                this.b2Com.ShowErrMsg(ex);
            }
        }

        /// <summary>BfFormからのコールバックイベント</summary>
        /// <param name="e"></param>
        private void CallBackEventFromBfForm(BFCallbackEventArgs e)
        {
            switch (e.EventType)
            {
                case BFCallbackEventType.Exit:
                    this.bfForm = null;

                    // bfFormを表示する以前に機能パネルに表示していたアクションボタンを表示する
                    // （機能ボタンから直接やbfFormを表示することは考慮していない）
                    if (this.kinoButtonSelected != null)
                    {
                        this.SetActionButtons(this.kinoButtonSelected);
                    }
                    break;

                default:
                    MessageBox.Show("何も設定されていません");
                    break;
            }
        }
    }
}
