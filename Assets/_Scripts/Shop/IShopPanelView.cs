using UnityEngine;
using UnityEngine.UI;
using _Scripts.Utility;

namespace _Scripts.Shop
{
    public interface IShopPanelView : IPanelView
    {
        Transform UnitParent { get; }
        Button CloseButton { get; }
        Button BackgroundButton { get; }
        int CurrentCash { set; }
    }
}