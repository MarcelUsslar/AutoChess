using _Scripts.Unit;

namespace _Scripts.Services
{
    public interface IOrderService
    {
        void RegisterUnit(UnitModel registeredUnit, bool setOrderDirectly = false);
        void UnRegisterUnit(UnitModel unregisteredUnit, bool collapseActingOrder = false);
        void ShuffleUnitOrder();
    }
}