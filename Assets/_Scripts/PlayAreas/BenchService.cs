using System.Collections.Generic;
using UnityEngine;
using _Scripts.Config;
using _Scripts.Installers;

namespace _Scripts.PlayAreas
{
    public class BenchService : IPlayAreaService
    {
        private readonly BenchView _benchView;
        private readonly IViewFactory<FieldView> _fieldViewFactory;

        private readonly Dictionary<int, Dictionary<int, FieldView>> _fields;

        public BenchService(BenchView benchView, IViewFactory<FieldView> fieldViewFactory, IBoardConfig boardConfig)
        {
            _benchView = benchView;
            _fieldViewFactory = fieldViewFactory;

            _fields = new Dictionary<int, Dictionary<int, FieldView>>(boardConfig.UnitInventorySize.x);

            CreateBench(boardConfig.UnitInventorySize);
        }

        // TODO move this into creation helper class
        private void CreateBench(Vector2Int boardSize)
        {
            for (var i = 0; i < boardSize.x; i++)
            {
                _fields.Add(i, new Dictionary<int, FieldView>(boardSize.y));

                for (var j = 0; j < boardSize.y; j++)
                {
                    var view = _fieldViewFactory.Instantiate(_benchView.BenchParent);
                    view.Position = new Vector3(i - boardSize.x / 2.0f, 0, j);

                    _fields[i].Add(j, view);
                }
            }
        }

        public FieldView GetField(int x, int y)
        {
            return _fields[x][y];
        }
    }
}