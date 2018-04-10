using System.Runtime.Serialization;

namespace B2.BestFunction.Models
{
    /// <summary>
    /// ボタンの基底クラス
    /// </summary>
    [DataContract]
    public class ButtonBase
    {
        public ButtonBase()
        {
            this.Command = new Command();
        }

        [DataMember(Name = "Text")]
        public string Text { get; set; }

        [DataMember(Name = "Note")]
        public string Note { get; set; }

        [DataMember(Name = "Command")]
        public Command Command { get; set; }
    }
}
