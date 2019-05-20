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
            return _preparationUnitModelFactory.Create(shopUnit.Id);
        }
    }
}