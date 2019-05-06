using System.Collections.Generic;
using _Scripts.Unit;

namespace _Scripts.UnitPools
{
    public interface ICombatBoardUnitPool
    {
        IList<ICombatUnitModel> Units { get; }
        IList<ICombatUnitModel> AlliedUnits { get; }
        IList<ICombatUnitModel> EnemyUnits { get; }

        void AddUnit(ICombatUnitModel unit);
        void Clear();

        ICombatUnitModel GetUnit(int unitId);
    }
}