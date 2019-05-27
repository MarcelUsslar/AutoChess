using System.Linq;
using UnityEngine;
using _Scripts.Unit;
using _Scripts.UnitPools;

namespace _Scripts.Factories
{
    public class PreparationUnitFactory : IPreparationUnitFactory
    {
        private readonly IPreparationUnitPool _preparationUnitPool;

        private readonly PreparationUnitModel.Factory _preparationUnitModelFactory;

        public PreparationUnitFactory(IPreparationUnitPool preparationUnitPool,
            PreparationUnitModel.Factory preparationUnitModelFactory)
        {
            _preparationUnitPool = preparationUnitPool;
            _preparationUnitModelFactory = preparationUnitModelFactory;
        }

        public IPreparationUnitModel Create(IShopUnitModel shopUnit)
        {
            var unit = _preparationUnitModelFactory.Create(shopUnit.Id);

            unit.SetPosition(new Vector2Int(_preparationUnitPool.Units.Min(model => model.Position.Value.x),
                _preparationUnitPool.Units.Min(model => model.Position.Value.y)));
            
            return unit;
        }
    }
}