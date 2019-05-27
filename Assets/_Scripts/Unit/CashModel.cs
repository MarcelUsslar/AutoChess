using UniRx;

namespace _Scripts.Unit
{
    public class CashModel : ICashModel
    {
        private readonly IReactiveProperty<int> _currentCash;

        public IReadOnlyReactiveProperty<int> CurrentCash => _currentCash;

        public CashModel(int currentCash)
        {
            _currentCash = new ReactiveProperty<int>(currentCash);
        }

        public void Buy(int cost)
        {
            _currentCash.Value -= cost;
        }
    }
}