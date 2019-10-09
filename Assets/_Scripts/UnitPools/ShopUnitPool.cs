using System.Collections.Generic;
using _Scripts.Config;
using _Scripts.Unit;

namespace _Scripts.UnitPools
{
    public class ShopUnitPool : IUnitPool<IShopUnitModel>
    {
        private readonly IShopConfig _config;

        private readonly IList<IShopUnitModel> _units = new List<IShopUnitModel>();

        public IList<IShopUnitModel> Units
        {
            get { return _units; }
        }

        public int MaxUnits
        {
            get { return _config.ShopEntryAmount; }
        }

        public int UnitCount
        {
            get { return _units.Count; }
        }

        public ShopUnitPool(IShopConfig config)
        {
            _config = config;
        }

        public void AddUnit(IShopUnitModel unit)
        {
            _units.Add(unit);
        }

        public void RemoveUnit(IShopUnitModel unit)
        {
            _units.Remove(unit);
        }

        public void Clear()
        {
            _units.Clear();
        }
    }
}