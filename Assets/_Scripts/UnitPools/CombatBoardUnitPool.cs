using System.Collections.Generic;
using _Scripts.Unit;

namespace _Scripts.UnitPools
{
    public class CombatBoardUnitPool : ICombatBoardUnitPool
    {
        public IList<ICombatUnitModel> Units { get; private set; }
        public IList<ICombatUnitModel> AlliedUnits { get; private set; }
        public IList<ICombatUnitModel> EnemyUnits { get; private set; }

        public void AddUnit(ICombatUnitModel unit)
        {
            throw new System.NotImplementedException();
        }

        public void Clear()
        {
            throw new System.NotImplementedException();
        }

        public ICombatUnitModel GetUnit(int unitId)
        {
            throw new System.NotImplementedException();
        }
    }
}
