using UniRx;
using _Scripts.Unit;

namespace _Scripts.UnitPools
{
    public interface IPreparationUnitPool : IUnitPool<IPreparationUnitModel>
    {
        IReadOnlyReactiveProperty<bool> IsBenchFull { get; }
    }
}