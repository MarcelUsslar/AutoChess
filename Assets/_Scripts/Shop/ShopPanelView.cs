using UnityEngine;
using UnityEngine.UI;
using _Scripts.Utility;

namespace _Scripts.Shop
{
    public class ShopPanelView : PanelView, IShopPanelView
    {
        [SerializeField] private Transform _unitParent;
        [SerializeField] private Text _cashText;
        [SerializeField] private Button _closeButton;
        [SerializeField] private Button _backgroundButton;

        public Transform UnitParent
        {
            get { return _unitParent; }
        }

        public int CurrentCash
        {
            set { _cashText.text = string.Format("{0} Cash", value); }
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