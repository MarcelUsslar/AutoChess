using System.Collections.Generic;
using _Scripts.Config;

namespace _Scripts.PlayAreas
{
    public class BoardService : IPlayAreaService
    {
        private readonly Dictionary<int, Dictionary<int, IFieldView>> _fields;

        public BoardService(BoardView boardView, IFieldFactory fieldFactory, IBoardConfig boardConfig)
        {
            _fields = fieldFactory.Create(boardView.BoardParent, boardConfig.BoardSize);
        }
        
        public IFieldView GetField(int x, int y)
        {
            return _fields[x][y];
        }
    }
}