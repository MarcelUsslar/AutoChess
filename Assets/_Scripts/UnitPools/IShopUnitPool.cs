using System.Collections.Generic;
using _Scripts.Unit;

namespace _Scripts.UnitPools
{
    public interface IShopUnitPool
    {
        IList<IShopUnitModel> Units { get; }

        void AddUnit(IShopUnitModel unit);
        void RemoveUnit(IShopUnitModel unit);
        void Clear();
    }
}