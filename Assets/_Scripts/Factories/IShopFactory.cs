using _Scripts.Unit;

namespace _Scripts.Factories
{
    public interface IShopFactory
    {
        IShopUnitModel CreateShopUnit(int id);
    }
}