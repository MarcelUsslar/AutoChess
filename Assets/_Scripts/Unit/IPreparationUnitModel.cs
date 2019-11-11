using UniRx;
using UnityEngine;

namespace _Scripts.Unit
{
    public interface IPreparationUnitModel
    {
        int Id { get; }
        IReadOnlyReactiveProperty<bool> IsOnBoard { get; }
        IReadOnlyReactiveProperty<Vector2Int> Position { get; }

        void MoveTo(bool isOnBoard);
        void MoveTo(bool isOnBoard, Vector2Int position);
    }
}