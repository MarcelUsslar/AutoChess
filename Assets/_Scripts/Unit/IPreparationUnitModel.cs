using UniRx;
using UnityEngine;

namespace _Scripts.Unit
{
    public interface IPreparationUnitModel
    {
        int Id { get; }
        IReadOnlyReactiveProperty<Vector2Int> Position { get; }
        IReadOnlyReactiveProperty<bool> IsPlacedOnBoard { get; }

        void SetPosition(Vector2Int position);
    }
}