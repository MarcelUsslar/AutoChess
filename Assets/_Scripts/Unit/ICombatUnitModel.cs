using UniRx;
using UnityEngine;

namespace _Scripts.Unit
{
    public interface ICombatUnitModel
    {
        int Id { get; }
        UnitAlliance Alliance { get; }
        IReadOnlyReactiveProperty<Vector2Int> Position { get; }
        IReadOnlyReactiveProperty<int> Health { get; }
    }
}