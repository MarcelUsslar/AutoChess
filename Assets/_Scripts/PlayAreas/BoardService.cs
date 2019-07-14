using System.Collections.Generic;
using UnityEngine;
using _Scripts.Config;
using _Scripts.Installers;

namespace _Scripts.PlayAreas
{
    public class BoardService : IPlayAreaService
    {
        private readonly BoardView _boardView;
        private readonly IViewFactory<FieldView> _fieldViewFactory;
        
        private readonly Dictionary<int, Dictionary<int, FieldView>> _fields;

        public BoardService(BoardView boardView, IViewFactory<FieldView> fieldViewFactory, IBoardConfig boardConfig)
        {
            _boardView = boardView;
            _fieldViewFactory = fieldViewFactory;

            _fields = new Dictionary<int, Dictionary<int, FieldView>>(boardConfig.BoardSize.x);

            CreateBoard(boardConfig.BoardSize);
        }

        // TODO move this into creation helper class
        private void CreateBoard(Vector2Int boardSize)
        {
            for (var i = 0; i < boardSize.x; i++)
            {
                _fields.Add(i, new Dictionary<int, FieldView>(boardSize.y));

                for (var j = 0; j < boardSize.y; j++)
                {
                    var view = _fieldViewFactory.Instantiate(_boardView.BoardParent);
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