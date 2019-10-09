using UniRx;

namespace _Scripts.Unit
{
    public class GenericUnitHealthStrategy : IUnitHealthStrategy
    {
        private readonly IReactiveProperty<int> _health;

        public IReadOnlyReactiveProperty<int> Health
        {
            get { return _health; }
        }

        public GenericUnitHealthStrategy()
        {
            _health = new ReactiveProperty<int>();
        }

        public void Damage(int damage)
        {
            throw new System.NotImplementedException();
        }

        public void Heal(int heal)
        {
            throw new System.NotImplementedException();
        }
    }
}