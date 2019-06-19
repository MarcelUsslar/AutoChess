using UnityEngine;
using _Scripts.Unit;

namespace _Scripts.Factories
{
    public class PreparationUnitFactory : IPreparationUnitFactory
    {
        private readonly PreparationUnitModel.Factory _preparationUnitModelFactory;

        public PreparationUnitFactory(PreparationUnitModel.Factory preparationUnitModelFactory)
        {
            _preparationUnitModelFactory = preparationUnitModelFactory;
        }

        public IPreparationUnitModel Create(IShopUnitModel shopUnit)
        {
            var unit = _preparationUnitModelFactory.Create(shopUnit.Id.Value);

            var position = new Vector2Int(0, 0);
            //var position = new Vector2Int(_benchModel.GetFirstFreePosition());

            unit.SetPosition(position);
            
            return unit;
        }
    }
}