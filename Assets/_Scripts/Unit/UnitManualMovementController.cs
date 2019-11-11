using System.Linq;
using UniRx;
using UnityEngine;
using Zenject;
using _Scripts.Config;
using _Scripts.PlayAreas;
using _Scripts.UnitPools;
using _Scripts.Utility;

namespace _Scripts.Unit
{
    public class UnitManualMovementController
    {
        private readonly IUnitPool<IPreparationUnitModel> _boardPool;
        private readonly IUnitPool<IPreparationUnitModel> _benchPool;
        private readonly IPlayAreaService _boardService;
        private readonly IPlayAreaService _benchService;
        private readonly IDisposer _disposer;

        private readonly IReactiveProperty<IPreparationUnitModel> _selectedUnit;

        public UnitManualMovementController(IBoardPreparationUnitPool boardPool, IBenchPreparationUnitPool benchPool,
            [Inject(Id = PlayArea.Board)] IPlayAreaService boardService,
            [Inject(Id = PlayArea.Bench)] IPlayAreaService benchService,
            IBoardConfig boardConfig, IDisposer disposer)
        {
            _boardPool = boardPool;
            _benchPool = benchPool;
            _boardService = boardService;
            _benchService = benchService;
            _disposer = disposer;

            _selectedUnit = new ReactiveProperty<IPreparationUnitModel>(null).AddToDisposer(disposer);

            SetupPlayAreaSubscriptions(boardConfig.BoardSize.x, boardConfig.BoardSize.y, true);
            SetupPlayAreaSubscriptions(boardConfig.UnitInventorySize.x, boardConfig.UnitInventorySize.y, false);
        }

        private void SetupPlayAreaSubscriptions(int width, int height, bool isBoard)
        {
            var playAreaService = isBoard ? _boardService : _benchService;

            for (var i = 0; i < width; i++)
            {
                for (var h = 0; h < height; h++)
                {
                    var x = i;
                    var y = h;
                    var view = playAreaService.GetField(x, y);
                    view.OnPointerClickAsObservable.Subscribe(() => OnPlayAreaClicked(x, y, isBoard)).AddToDisposer(_disposer);
                }
            }
        }

        private void OnPlayAreaClicked(int x, int y, bool isBoard)
        {
            var pool = isBoard ? _boardPool : _benchPool;
            var unitOnClickedArea = pool.Units.FirstOrDefault(model => model.Position.Value == new Vector2Int(x, y));

            if (_selectedUnit.Value == null)
            {
                _selectedUnit.Value = unitOnClickedArea;
            }
            else
            {
                if (unitOnClickedArea != null)
                {
                    unitOnClickedArea.MoveTo(_selectedUnit.Value.IsOnBoard.Value, _selectedUnit.Value.Position.Value);
                }

                _selectedUnit.Value.MoveTo(isBoard, new Vector2Int(x, y));
                _selectedUnit.Value = null;
            }
        }
    }
}