using System;
using System.Collections.Generic;
using UniRx;
using _Scripts.Unit;

namespace _Scripts.UnitPools
{
    public class BoardPreparationUnitPool : IBoardPreparationUnitPool
    {
        private readonly int _maxUnits;

        private readonly IReactiveProperty<bool> _isBoardFull;

        public IList<IPreparationUnitModel> Units { get; private set; }

        public int MaxUnits
        {
            get { return _maxUnits; }
        }

        public int UnitCount
        {
            get { return Units.Count; }
        }
        
        public IReadOnlyReactiveProperty<bool> IsBoardFull
        {
            get { return _isBoardFull; }
        }

        public BoardPreparationUnitPool(int maxUnits)
        {
            _maxUnits = maxUnits;

            Units = new List<IPreparationUnitModel>();
            _isBoardFull = new ReactiveProperty<bool>();
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
            _isBoardFull.Value = Units.Count < _maxUnits;
        }
    }
}