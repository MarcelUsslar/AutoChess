using _Scripts.Unit;

namespace _Scripts.Factories
{
    public interface ICombatUnitFactory
    {
        ICombatUnitModel CreateCombatUnit(IPreparationUnitModel preparationUnit);
    }
}