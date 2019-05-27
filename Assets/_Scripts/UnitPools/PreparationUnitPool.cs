using System;
using System.Collections.Generic;
using UniRx;
using _Scripts.Unit;

namespace _Scripts.UnitPools
{
    public class PreparationUnitPool : IPreparationUnitPool
    {
        private readonly int _maxUnits;

        private readonly IReactiveProperty<bool> _isBenchFull;

        public IList<IPreparationUnitModel> Units { get; }

        public IReadOnlyReactiveProperty<bool> IsBenchFull
        {
            get { return _isBenchFull; }
        }

        public PreparationUnitPool(int maxUnits)
        {
            _maxUnits = maxUnits;

            Units = new List<IPreparationUnitModel>();
            _isBenchFull = new ReactiveProperty<bool>();
        }

        public void AddUnit(IPreparationUnitModel unit)
        {
            if (Units.Count >= _maxUnits)
                throw new InvalidOperationException("Unit can not be added to the bench when bench is full");

            Units.Add(unit);
            UpdateBenchCount();
        }

        public void RemoveUnit(IPreparationUnitModel unit)
        {
            if (Units.Count < 0)
                throw new InvalidOperationException("Unit can not be removed when bench is empty");

            Units.Remove(unit);
            UpdateBenchCount();
        }

        public void Clear()
        {
            Units.Clear();
            UpdateBenchCount();
        }

        private void UpdateBenchCount()
        {
            _isBenchFull.Value = Units.Count < _maxUnits;
        }
    }
}