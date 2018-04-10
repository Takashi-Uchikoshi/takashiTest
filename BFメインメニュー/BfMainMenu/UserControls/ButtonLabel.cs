using System.Windows.Forms;

namespace B2.BestFunction.UserControls
{
    /// <summary>
    /// ボタンとして使用するラベルであることが分かりやすいようにするためのエイリアス
    /// 通常のButtonだとダブルクリックしたときにクリックイベントが２回発生するのに対して
    /// Labelだとダブルクリックしたときにダブルクリックイベントが発生する
    /// シングルクリックとダブルクリックで同じ動作をしたいときはLabelの方がよい
    /// </summary>
    public class ButtonLabel : Label
    {
    }
}
