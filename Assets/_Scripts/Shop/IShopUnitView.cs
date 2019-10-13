using UnityEngine.UI;

namespace _Scripts.Shop
{
    public interface IShopUnitView
    {
        bool Purchasable { set; }
        Button BuyButton { get; }
        int Cost { set; }
    }
}