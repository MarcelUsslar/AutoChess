using UniRx;

namespace _Scripts.Unit
{
    public interface IShopUnitModel
    {
        IReadOnlyReactiveProperty<int> Id { get; }
        IReadOnlyReactiveProperty<int> Cost { get; }
        IReadOnlyReactiveProperty<bool> CanBeBought { get; }

        void Buy();
        void Reset(int unitId);
    }
}