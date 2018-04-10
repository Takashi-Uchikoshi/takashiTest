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
    /// <summary>
    /// メニュー表示モード
    /// </summary>
    public enum MenuShowMode
    {
        /// <summary>履歴</summary>
        Rireki,
        /// <summary>一覧</summary>
        Ichiran,
        /// <summary>新規</summary>
        Shinki,
        /// <summary>検索</summary>
        Kensaku,
    }

    /// <summary>
    /// コールバックイベントタイプ
    /// </summary>
    public enum BFCallbackEventType
    {
        /// <summary>プログラム終了</summary>
        Exit,
        /// <summary>表示完了</summary>
        CompleteDisplay,
        /// <summary>処理中</summary>
        Processing,
        /// <summary>処理完了</summary>
        CompleteProcess,
        /// <summary>処理キャンセル</summary>
        CancelProcess,
    }

    /// <summary>
    /// コールバックイベント結果
    /// </summary>
    public enum BFCallbackEventResuslt
    {
        /// <summary>成功</summary>
        Success,
        /// <summary>エラー</summary>
        Error,
    }

    /// <summary>
    /// BestFunctionフォーム基本クラス
    /// </summary>
    public partial class BFBaseForm : Form
    {
        /// <summary>メニュー階層文字列</summary>
        public string MenuLevel { get; set; }

        /// <summary>表示モード</summary>
        public MenuShowMode ShowMode { get; set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public BFBaseForm()
        {
            this.BFCallbackEvent = null;
            this.MenuLevel = string.Empty;
            this.ShowMode = MenuShowMode.Ichiran;

            InitializeComponent();
        }

        /// <summary>
        /// 項目検索
        /// </summary>
        /// <param name="key">検索キー</param>
        public virtual void SearchItem(string key)
        {
        }

        /// <summary>
        /// フォーム再表示
        /// </summary>
        public virtual void RedisplayForm()
        {
        }

        /// <summary>
        /// フォーム切替表示問合せ
        /// </summary>
        /// <returns>true:フォーム切替表示可 false:フォーム切替表示不可</returns>
        public virtual bool CanChange()
        {
            return true;
        }

        /// <summary>
        /// フォームクローズ問合せ
        /// </summary>
        /// <returns>true:フォームクローズ可 false:フォームクローズ不可</returns>
        public virtual bool CanClose()
        {
            return true;
        }

        #region コールバック
        /// <summary>
        /// コールバック用イベントハンドラのデリゲート
        /// </summary>
        /// <param name="e">イベントデータ</param>
        public delegate void BFEventHandler(BFCallbackEventArgs e);

        /// <summary>
        /// コールバック用イベントハンドラ
        /// </summary>
        public event BFEventHandler BFCallbackEvent;

        /// <summary>
        /// コールバック処理呼び出し
        /// </summary>
        /// <param name="no">イベントタイプ</param>
        /// <param name="ret">結果</param>
        /// <param name="stringValue">イベント文字列情報</param>
        protected void CallBFCallbackEvent(BFCallbackEventType no, BFCallbackEventResuslt ret, string stringValue)
        {
            if (BFCallbackEvent != null)
                BFCallbackEvent(new BFCallbackEventArgs(no, MenuLevel, ShowMode, ret, stringValue));
        }
        #endregion
    }

    /// <summary>
    /// コールバック用イベント引数クラス
    /// </summary>
    public class BFCallbackEventArgs : EventArgs
    {
        /// <summary>イベントタイプ</summary>
        private BFCallbackEventType eventType;
        /// <summary>メニュー階層</summary>
        private string menuLevel;
        /// <summary>表示モード</summary>
        private MenuShowMode showMode;
        /// <summary>結果</summary>
        private BFCallbackEventResuslt result;
        /// <summary>イベント文字列情報</summary>
        private readonly string eventStringValue;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="type">イベントタイプ</param>
        /// <param name="level">メニュー階層</param>
        /// <param name="mode">表示モード</param>
        /// <param name="result">結果</param>
        /// <param name="stringValue">イベント文字列情報</param>
        public BFCallbackEventArgs(BFCallbackEventType type, string level, MenuShowMode mode, BFCallbackEventResuslt result, string stringValue)
        {
            this.eventType = type;
            this.menuLevel = level;
            this.showMode = mode;
            this.result = result;
            this.eventStringValue = stringValue;
        }
        /// <summary>イベントタイプ</summary>
        public BFCallbackEventType EventType { get { return eventType; } }
        /// <summary>メニュー階層</summary>
        public string MenuLevel { get { return menuLevel; } }
        /// <summary>表示モード</summary>
        public MenuShowMode ShowMode { get { return showMode; } }
        /// <summary>結果</summary>
        public BFCallbackEventResuslt Result { get { return result; } }
        /// <summary>イベント文字列情報</summary>
        public string CommandStringValue { get { return eventStringValue; } }
    }
}
