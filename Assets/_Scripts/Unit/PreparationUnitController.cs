using UniRx;
using UnityEngine;
using Zenject;
using _Scripts.PlayAreas;
using _Scripts.Utility;

namespace _Scripts.Unit
{
    public class PreparationUnitController
    {
        public class Factory : PlaceholderFactory<IPreparationUnitModel, PreparationUnitView, PreparationUnitController>
        { }
        
        private readonly PreparationUnitView _view;

        private readonly IPlayAreaService _boardService;
        private readonly IPlayAreaService _benchService;

        public PreparationUnitController(IPreparationUnitModel model, PreparationUnitView view,
            [Inject(Id = PlayArea.Board)] IPlayAreaService boardService, [Inject(Id = PlayArea.Bench)] IPlayAreaService benchService,
            IDisposer disposer)
        {
            _view = view;
            _boardService = boardService;
            _benchService = benchService;

            model.Position.Subscribe(pos => SetPosition(pos, model.IsOnBoard)).AddToDisposer(disposer);
        }

        private void SetPosition(Vector2Int pos, bool onBoard)
        {
            var field = onBoard ? _boardService.GetField(pos.x, pos.y) : _benchService.GetField(pos.x, pos.y);
            _view.transform.SetParent(field.UnitParent, false);
        }
    }
}