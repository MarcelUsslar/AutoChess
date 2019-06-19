using UniRx;
using _Scripts.Unit;

namespace _Scripts.UnitPools
{
    public interface IBenchPreparationUnitPool : IUnitPool<IPreparationUnitModel>
    {
        IReadOnlyReactiveProperty<bool> IsBenchFull { get; }
    }
}