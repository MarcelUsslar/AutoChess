using System.Collections.Generic;

namespace _Scripts.Config
{
    public interface IShopConfig
    {
        int ShopEntryAmount { get; }
        IDictionary<int, int> AllShopUnits { get; }
        int GetCost(int id);
    }
}