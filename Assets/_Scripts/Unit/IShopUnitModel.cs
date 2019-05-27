using UniRx;

namespace _Scripts.Unit
{
    public interface IShopUnitModel
    {
        int Id { get; }
        int Cost { get; }
        IReadOnlyReactiveProperty<bool> CanBeBought { get; }

        void Buy();
    }
}