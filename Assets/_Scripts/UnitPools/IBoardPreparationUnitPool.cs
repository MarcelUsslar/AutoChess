using UniRx;
using _Scripts.Unit;

namespace _Scripts.UnitPools
{
    public interface IBoardPreparationUnitPool : IUnitPool<IPreparationUnitModel>
    {
        IReadOnlyReactiveProperty<bool> IsBoardFull { get; }
    }
}