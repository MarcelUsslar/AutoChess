using UniRx;
using UnityEngine;
using Zenject;

namespace _Scripts.Unit
{
    public class CombatUnitModel : ICombatUnitModel
    {
        public class Factory : PlaceholderFactory<int, UnitAlliance, CombatUnitModel>
        { }

        private readonly IUnitMovementStrategy _movementStrategy;
        private readonly IUnitHealthStrategy _healthStrategy;

        public int Id { get; private set; }
        public UnitAlliance Alliance { get; private set; }
        public IReadOnlyReactiveProperty<Vector2Int> Position
        {
            get { return _movementStrategy.Position; }
        }
        public IReadOnlyReactiveProperty<int> Health
        {
            get { return _healthStrategy.Health; }
        }

        public CombatUnitModel(int id, UnitAlliance unitAlliance, IUnitMovementStrategy movementStrategy,
            IUnitHealthStrategy healthStrategy)
        {
            Id = id;
            Alliance = unitAlliance;

            _movementStrategy = movementStrategy;
            _healthStrategy = healthStrategy;
        }
    }
}