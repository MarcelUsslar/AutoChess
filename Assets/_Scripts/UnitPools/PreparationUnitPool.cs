using System.Collections.Generic;
using _Scripts.Unit;

namespace _Scripts.UnitPools
{
    public class PreparationUnitPool : IUnitPool<IPreparationUnitModel>
    {
        private readonly IList<IPreparationUnitModel> _units = new List<IPreparationUnitModel>();

        public IList<IPreparationUnitModel> Units
        {
            get { return _units; }
        }

        public void AddUnit(IPreparationUnitModel unit)
        {
            _units.Add(unit);
        }

        public void RemoveUnit(IPreparationUnitModel unit)
        {
            _units.Remove(unit);
        }

        public void Clear()
        {
            _units.Clear();
        }
    }
}