using System;
using System.Collections.Generic;
using System.Linq;
using _Scripts.Unit;
using _Scripts.Utility;

namespace _Scripts.Services
{
    public class OrderService : IOrderService
    {
        private readonly ICollection<UnitModel> _units;

        private readonly Random _random;

        public OrderService()
        {
            _units = new List<UnitModel>();
            _random = new Random();
        }

        public void RegisterUnit(UnitModel registeredUnit, bool setOrderDirectly = false)
        {
            _units.Add(registeredUnit);

            if (setOrderDirectly)
            {
                registeredUnit.ActOrder = _units.Max(model => model.ActOrder) + 1;
            }
        }

        public void UnRegisterUnit(UnitModel unregisteredUnit, bool collapseActingOrder = false)
        {
            _units.Remove(unregisteredUnit);

            if (unregisteredUnit.ActOrder > 0 && collapseActingOrder)
            {
                _units.Where(model => model.ActOrder > unregisteredUnit.ActOrder)
                    .ForEach(model => model.ActOrder -= 1);
            }
        }

        public void ShuffleUnitOrder()
        {
            var orderedUnits = _units.OrderBy(_ => _random.Next()).ToList();

            var actOrder = 1;

            var firstAlly = orderedUnits.First(model => model.Alliance == UnitAlliance.Friendly);
            firstAlly.ActOrder = actOrder;
            actOrder += 1;

            orderedUnits.Remove(firstAlly);

            orderedUnits.ForEach(model =>
            {
                model.ActOrder = actOrder;
                actOrder += 1;
            });
        }
    }
}