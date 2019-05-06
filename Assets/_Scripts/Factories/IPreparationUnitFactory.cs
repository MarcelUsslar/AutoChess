using _Scripts.Unit;

namespace _Scripts.Factories
{
    public interface IPreparationUnitFactory
    {
        IPreparationUnitModel CreatePreparationUnit(IShopUnitModel shopUnit);
    }
}