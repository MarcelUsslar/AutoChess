using UniRx;
using UnityEngine;

namespace _Scripts.Unit
{
    public interface IUnitMovementStrategy
    {
        IReadOnlyReactiveProperty<Vector2Int> Position { get; }

        void Move();
    }
}