using UniRx;
using UnityEngine;

namespace _Scripts.Unit
{
    public class GenericUnitMovementStrategy : IUnitMovementStrategy
    {
        private readonly IReactiveProperty<Vector2Int> _position;

        public IReadOnlyReactiveProperty<Vector2Int> Position
        {
            get { return _position; }
        }

        public GenericUnitMovementStrategy()
        {
            _position = new ReactiveProperty<Vector2Int>();
        }

        public void Move()
        {
            throw new System.NotImplementedException();
        }
    }
}