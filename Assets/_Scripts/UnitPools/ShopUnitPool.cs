﻿using System.Collections.Generic;
using _Scripts.Unit;

namespace _Scripts.UnitPools
{
    public class ShopUnitPool : IUnitPool<IShopUnitModel>
    {
        private readonly IList<IShopUnitModel> _units = new List<IShopUnitModel>();

        public IList<IShopUnitModel> Units
        {
            get { return _units; }
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