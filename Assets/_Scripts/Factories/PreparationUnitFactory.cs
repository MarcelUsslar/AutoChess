using Zenject;
using _Scripts.PlayAreas;
using _Scripts.Unit;

namespace _Scripts.Factories
{
    public class PreparationUnitFactory : IPreparationUnitFactory
    {
        private readonly PreparationUnitModel.Factory _preparationUnitModelFactory;
        private readonly IPlayArea _benchModel;

        public PreparationUnitFactory(PreparationUnitModel.Factory preparationUnitModelFactory,
            [Inject(Id = PlayArea.Bench)] BenchModel benchModel)
        {
            _preparationUnitModelFactory = preparationUnitModelFactory;
            _benchModel = benchModel;
        }

        public IPreparationUnitModel Create(IShopUnitModel shopUnit)
        {
            var unit = _preparationUnitModelFactory.Create(shopUnit.Id.Value);
            
            unit.SetPosition(_benchModel.GetFirstFreePosition());
            
            return unit;
        }
    }
}