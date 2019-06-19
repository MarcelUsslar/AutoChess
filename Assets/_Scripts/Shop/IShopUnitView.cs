using UnityEngine.UI;

namespace _Scripts.Unit
{
    public interface IShopUnitView
    {
        bool Purchasable { set; }
        Button BuyButton { get; }
    }
}