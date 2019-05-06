using UniRx;
using UnityEngine;
using Zenject;
using _Scripts.Board;
using _Scripts.Utility;

namespace _Scripts.Unit
{
    public class PreparationUnitModel : IPreparationUnitModel
    {
        public class Factory : PlaceholderFactory<int, PreparationUnitModel>
        { }

        private readonly IBoardConfig _config;

        public int Id { get; private set; }
        private readonly IReactiveProperty<Vector2Int> _position;
        public IReadOnlyReactiveProperty<bool> IsPlacedOnBoard { get; private set; }


        public IReadOnlyReactiveProperty<Vector2Int> Position
        {
            get { return _position; }
        }
        
        public PreparationUnitModel(int id, IBoardConfig config, IDisposer disposer)
        {
            Id = id;
            _config = config;
            _position = new ReactiveProperty<Vector2Int>();
            IsPlacedOnBoard = _position.Select(IsOnBoard).ToReadOnlyReactiveProperty().AddTo(disposer);
        }

        public void SetPosition(Vector2Int position)
        {
            _position.Value = position;
        }

        private bool IsOnBoard(Vector2Int currentPosition)
        {
            return currentPosition.x < _config.BoardSize.x;
        }
    }
}