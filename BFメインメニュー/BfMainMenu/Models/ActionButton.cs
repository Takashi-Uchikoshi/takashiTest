using System.Runtime.Serialization;

namespace B2.BestFunction.Models
{
    /// <summary>
    /// 出庫などのアクションボタンに配置するアイコンボタン。検索、一覧、新規、履歴など
    /// </summary>
    [DataContract]
    public class ActionButton : ButtonBase
    {
        public ActionButton()
        {
            
        }
    }

    /// <summary>
    /// アイコンボタンの種類
    /// </summary>
    public enum ActionButtonType
    {
        Null,
        Kensaku,
        Rireki,
        Ichiran,
        Shinki,
    }
}
