using System.Linq;
using UnityEngine;
using _Scripts.UnitPools;

namespace _Scripts.PlayAreas
{
    public class BenchModel : IPlayArea
    {
        private readonly IBenchPreparationUnitPool _benchUnitPool;

        private int MaxUnits
        {
            get { return _benchUnitPool.MaxUnits; }
        }

        public BenchModel(IBenchPreparationUnitPool benchUnitPool)
        {
            _benchUnitPool = benchUnitPool;
        }

        public Vector2Int GetFirstFreePosition()
        {
            for (var i = 0; i < MaxUnits; i++)
            {
                if (_benchUnitPool.Units.Any(model => model.Position.Value.x == i))
                    continue;
                
                return new Vector2Int(i, 0);
            }

            return Vector2Int.one * -1;
        }
    }
}
