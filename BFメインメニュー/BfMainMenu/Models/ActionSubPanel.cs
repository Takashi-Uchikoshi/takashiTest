using System.Collections.Generic;
using System.Runtime.Serialization;

namespace B2.BestFunction.Models
{
    /// <summary>
    /// アクションパネルに表示する在庫一覧、出庫、入庫、などのパネル
    /// </summary>
    [DataContract]
    public class ActionSubPanel
    {
        public ActionSubPanel()
        {
            this.ActionButtons = new List<ActionButton>();
        }

        [DataMember(Name = "Title")]
        public string Title { get; set; }

        [DataMember(Name = "Note")]
        public string Note { get; set; }

        [DataMember(Name = "ActionButtons")]
        public List<ActionButton> ActionButtons { get; set; }
    }
}
