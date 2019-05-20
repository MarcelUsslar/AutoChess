using UniRx;
using UnityEngine;
using Zenject;
using _Scripts.UnitPools;
using _Scripts.Utility;

namespace _Scripts.Unit
{
    public class PreparationUnitModel : IPreparationUnitModel
    {
        public class Factory : PlaceholderFactory<int, PreparationUnitModel>
        { }

        private readonly IUnitPool<IPreparationUnitModel> _boardPool;
        private readonly IUnitPool<IPreparationUnitModel> _benchPool;

        public int Id { get; private set; }
        private readonly IReactiveProperty<Vector2Int> _position;
        public IReadOnlyReactiveProperty<bool> IsPlacedOnBoard { get; private set; }


        public IReadOnlyReactiveProperty<Vector2Int> Position
        {
            get { return _position; }
        }

        public PreparationUnitModel(int id,
            [Inject(Id = true)] IUnitPool<IPreparationUnitModel> boardPool,
            [Inject(Id = true)] IUnitPool<IPreparationUnitModel> benchPool,
            IDisposer disposer)
        {
            Id = id;
            _boardPool = boardPool;
            _benchPool = benchPool;
            _position = new ReactiveProperty<Vector2Int>();
            IsPlacedOnBoard = _position.Select(IsOnBoard).ToReadOnlyReactiveProperty().AddTo(disposer);

            IsPlacedOnBoard.Subscribe(MoveToPool).AddTo(disposer);
        }

        public void MoveToPool(bool onBoard)
        {
            if (onBoard)
            {
                _benchPool.RemoveUnit(this);
                _boardPool.AddUnit(this);
            }
            else
            {
                _benchPool.AddUnit(this);
                _boardPool.RemoveUnit(this);
            }
        }

        public void SetPosition(Vector2Int position)
        {
            _position.Value = position;
        }

        private static bool IsOnBoard(Vector2Int currentPosition)
        {
            return currentPosition.x < 0;
        }
    }
}