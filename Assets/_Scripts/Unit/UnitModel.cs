using UniRx;
using Zenject;
using _Scripts.Services;
using _Scripts.Utility;

namespace _Scripts.Unit
{
    public class UnitModel
    {
        public class Factory : PlaceholderFactory<UnitAlliance, UnitModel>
        {}

        private readonly ITickService _tickService;

        public int ActOrder { get; set; }
        public UnitAlliance Alliance { get; private set; }

        public UnitModel(UnitAlliance alliance, ITickService tickService, IDisposer disposer)
        {
            ActOrder = 0;
            Alliance = alliance;

            _tickService = tickService;

            tickService.CurrentTick
                .Where(_ => IsActingUnit).AsUnitObservable()
                .CombineLatest(tickService.SubTick.Where(_ => IsActingUnit).AsUnitObservable(), (_, __) => _)
                .Subscribe(_ => Act())
                .AddTo(disposer);
        }

        private void Act()
        {
        
        }

        private bool IsActingUnit
        {
            get { return _tickService.SubTick.Value == ActOrder; }
        }
    }
}
