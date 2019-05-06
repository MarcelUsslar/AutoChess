using System.Collections.Generic;
using _Scripts.Unit;

namespace _Scripts.UnitPools
{
    public interface IPreparationUnitPool
    {
        IList<IPreparationUnitModel> Units { get; }

        void AddUnit(IPreparationUnitModel unit);
        void RemoveUnit(IPreparationUnitModel unit);
    }
}