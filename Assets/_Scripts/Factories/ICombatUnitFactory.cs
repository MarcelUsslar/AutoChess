using Zenject;
using _Scripts.Unit;

namespace _Scripts.Factories
{
    public interface ICombatUnitFactory : IFactory<IPreparationUnitModel, UnitAlliance, ICombatUnitModel>
    { }
}