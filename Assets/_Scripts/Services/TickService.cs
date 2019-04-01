using UniRx;

namespace _Scripts.Services
{
    public class TickService : ITickService
    {
        private readonly IReactiveProperty<int> _currentTick;
        private readonly IReactiveProperty<int> _subTick;

        public IReadOnlyReactiveProperty<int> CurrentTick
        {
            get { return _currentTick; }
        }
        public IReadOnlyReactiveProperty<int> SubTick
        {
            get { return _subTick; }
        }

        public TickService()
        {
            _currentTick = new ReactiveProperty<int>();
            _subTick = new ReactiveProperty<int>();
        }

        public void ForwardToNextTick()
        {
            _subTick.Value = 0;
            _currentTick.Value += 1;
        }

        public void EndCharacterAction()
        {
            _subTick.Value += 1;
        }
    }
}
