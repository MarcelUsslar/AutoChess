using System.Collections.Generic;
using _Scripts.Config;

namespace _Scripts.PlayAreas
{
    public class BenchService : IPlayAreaService
    {
        private readonly Dictionary<int, Dictionary<int, IFieldView>> _fields;

        public BenchService(BenchView benchView, IFieldFactory fieldFactory, IBoardConfig boardConfig)
        {
            _fields = fieldFactory.Create(benchView.BenchParent, boardConfig.UnitInventorySize);
        }
        
        public IFieldView GetField(int x, int y)
        {
            return _fields[x][y];
        }
    }
}