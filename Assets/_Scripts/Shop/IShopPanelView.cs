using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.Unit
{
    public interface IShopPanelView
    {
        Transform UnitParent { get; }
        Button CloseButton { get; }
        Button BackgroundButton { get; }

        void OpenPanel();
        void ClosePanel();
    }
}