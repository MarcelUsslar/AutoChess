using System.Collections.Generic;
using _Scripts.Unit;

namespace _Scripts.UnitPools
{
    public class PreparationBenchUnitPool : IPreparationUnitPool
    {
        public IList<IPreparationUnitModel> Units { get; private set; }

        public void AddUnit(IPreparationUnitModel unit)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveUnit(IPreparationUnitModel unit)
        {
            throw new System.NotImplementedException();
        }
    }
}