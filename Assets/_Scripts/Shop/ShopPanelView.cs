using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.Unit
{
    public class ShopPanelView : MonoBehaviour, IShopPanelView
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

        public void OpenPanel()
        {
            gameObject.SetActive(true);
        }

        public void ClosePanel()
        {
            gameObject.SetActive(false);
        }
    }
}