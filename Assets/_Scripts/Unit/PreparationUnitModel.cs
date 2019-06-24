using UniRx;
using UnityEngine;
using Zenject;
using _Scripts.PlayAreas;
using _Scripts.UnitPools;
using _Scripts.Utility;

namespace _Scripts.Unit
{
    public class PreparationUnitModel : IPreparationUnitModel
    {
        public class Factory : PlaceholderFactory<int, PreparationUnitModel>
        { }

        private readonly IPlayArea _benchModel;
        private readonly IPlayArea _boardModel;
        private readonly IUnitPool<IPreparationUnitModel> _boardPool;
        private readonly IUnitPool<IPreparationUnitModel> _benchPool;

        public int Id { get; private set; }
        private readonly IReactiveProperty<Vector2Int> _position;


        public IReadOnlyReactiveProperty<Vector2Int> Position
        {
            get { return _position; }
        }

        public PreparationUnitModel(int id,
            [Inject(Id = PlayArea.Bench)] BenchModel benchModel, [Inject(Id = PlayArea.Board)] BoardModel boardModel,
            IBoardPreparationUnitPool boardPool, IBenchPreparationUnitPool benchPool)
        {
            Id = id;
            _benchModel = benchModel;
            _boardModel = boardModel;
            _boardPool = boardPool;
            _benchPool = benchPool;

            _position = new ReactiveProperty<Vector2Int>();
        }

        public void MoveTo(bool isOnBoard)
        {
            MoveToPool(isOnBoard);
            SetPosition(isOnBoard ? _boardModel.GetFirstFreePosition() : _benchModel.GetFirstFreePosition());
        }

        public void MoveTo(bool isOnBoard, Vector2Int position)
        {
            MoveToPool(isOnBoard);
            SetPosition(position);
        }

        private void MoveToPool(bool isOnBoard)
        {
            if (isOnBoard)
            {
                _benchPool.RemoveUnit(this);
                _boardPool.AddUnit(this);
            }
            else
            {
                _benchPool.RemoveUnit(this);
                _boardPool.AddUnit(this);
            }
        }

        public void SetPosition(Vector2Int position)
        {
            _position.Value = position;
        }
    }
}