using UniRx;

namespace _Scripts.Unit
{
    public interface IUnitHealthStrategy
    {
        IReadOnlyReactiveProperty<int> Health { get; }

        void Damage(int damage);
        void Heal(int heal);
    }
}