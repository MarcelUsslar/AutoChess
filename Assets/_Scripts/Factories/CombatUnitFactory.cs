using _Scripts.Unit;

namespace _Scripts.Factories
{
    public class CombatUnitFactory : ICombatUnitFactory
    {
        private readonly CombatUnitModel.Factory _factory;

        public CombatUnitFactory(CombatUnitModel.Factory factory)
        {
            _factory = factory;
        }

        public ICombatUnitModel Create(IPreparationUnitModel preparationUnit, UnitAlliance alliance)
        {
            return _factory.Create(preparationUnit.Id, alliance);
        }
    }
}