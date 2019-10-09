using UnityEngine;
using UnityEngine.UI;
using _Scripts.Utility;

namespace _Scripts.Shop
{
    public class ShopPanelView : PanelView, IShopPanelView
    {
        [SerializeField] private Transform _unitParent;
        [SerializeField] private Button _closeButton;
        [SerializeField] private Button _backgroundButton;

        public Transform UnitParent
        {
            get { return _unitParent; }
        }

        public Button CloseButton
        {
            get { return _closeButton; }
        }

        public Button BackgroundButton
        {
            get { return _backgroundButton; }
        }
    }
}