using System.Collections.Generic;
using _Scripts.Unit;

namespace _Scripts.UnitPools
{
    public interface IUnitPool<T>
    {
        IList<T> Units { get; }

        void AddUnit(T unit);
        void RemoveUnit(T unit);
        void Clear();
    }
}