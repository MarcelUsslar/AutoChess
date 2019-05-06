using System.Collections.Generic;
using _Scripts.Unit;

namespace _Scripts.UnitPools
{
    public class ShopUnitPool : IShopUnitPool
    {
        public IList<IShopUnitModel> Units { get; private set; }

        public void AddUnit(IShopUnitModel unit)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveUnit(IShopUnitModel unit)
        {
            throw new System.NotImplementedException();
        }

        public void Clear()
        {
            throw new System.NotImplementedException();
        }
    }
}