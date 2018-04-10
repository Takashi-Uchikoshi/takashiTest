using System.Runtime.Serialization;

namespace B2.BestFunction.Models
{
    /// <summary>
    /// ボタンを押したときに実行する内容
    /// </summary>
    [DataContract]
    public class Command
    {
        public Command()
        {
            this.Enable = false;
            this.FileName = string.Empty;
            this.FormName = string.Empty;
            this.MenuLevel = string.Empty;
            this.MenuShowMode = BestFunction.MenuShowMode.Ichiran;
        }

        /// <summary>
        /// 有効
        /// </summary>
        [DataMember(Name = "Enable")]
        public bool Enable { get; set; }

        /// <summary>
        /// 機能フォームを含む実行ファイル名
        /// </summary>
        [DataMember(Name = "FileName")]
        public string FileName { get; set; }

        /// <summary>
        /// 機能フォームのクラス名
        /// </summary>
        [DataMember(Name = "FormName")]
        public string FormName { get; set; }

        /// <summary>
        /// 機能フォームの上に表示するパスのようなタイトル
        /// </summary>
        [DataMember(Name = "MenuLevel")]
        public string MenuLevel { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "MenuShowMode")]
        public MenuShowMode MenuShowMode { get; set; }

        ///// <summary>
        ///// 機能フォーム呼び出しにおける設定値
        ///// </summary>
        //[DataMember(Name = "Parameter")]
        //public string Parameter { get; set; }

        ///// <summary>
        ///// 別ウインドウとして表示する
        ///// </summary>
        //public bool BetsuWindow { get; set; }

        ///// <summary>
        ///// モーダルモードで表示する
        ///// </summary>
        //public bool ModalMode { get; set; }
    }
}
