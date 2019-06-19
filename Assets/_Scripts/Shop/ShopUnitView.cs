using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.Unit
{
    public class ShopUnitView : MonoBehaviour, IShopUnitView
    {
        [SerializeField] private Button _purchaseButton;

        public bool Purchasable
        {
            set { _purchaseButton.interactable = value; }
        }

        public Button BuyButton
        {
            get { return _purchaseButton; }
        }
    }
}