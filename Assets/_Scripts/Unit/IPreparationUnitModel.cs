using UniRx;
using UnityEngine;

namespace _Scripts.Unit
{
    public interface IPreparationUnitModel
    {
        int Id { get; }
        bool IsOnBoard { get; }
        IReadOnlyReactiveProperty<Vector2Int> Position { get; }

        void MoveTo(bool isOnBoard);
        void MoveTo(bool isOnBoard, Vector2Int position);
    }
}