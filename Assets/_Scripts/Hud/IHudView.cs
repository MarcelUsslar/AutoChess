using UnityEngine.UI;
using _Scripts.Utility;

namespace _Scripts.Hud
{
    public interface IHudView : IPanelView
    {
        Button ShopButton { get; }
    }
}