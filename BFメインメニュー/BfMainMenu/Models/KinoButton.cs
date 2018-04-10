using System.Collections.Generic;
using System.Runtime.Serialization;


namespace B2.BestFunction.Models
{

    /// <summary>
    /// メイン画面の左側のボタン。発注、在庫、棚卸など
    /// </summary>
    [DataContract]
    public class KinoButton : ButtonBase
    {
        public KinoButton()
        {
            this.ActionSubPanels = new List<ActionSubPanel>();
            this.Type = KinoButtonType.SetActionButtons;
        }

        [DataMember(Name = "ActionSubPanels")]
        public List<ActionSubPanel> ActionSubPanels { get; set; }

        [DataMember(Name = "Type")]
        public KinoButtonType Type { get; set; }
    }

    public enum KinoButtonType
    {
        SetActionButtons,
        SetBfForm,
    }
}