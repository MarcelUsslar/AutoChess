using System.Collections.Generic;
using System.Linq;
using UniRx;
using _Scripts.Utility;

namespace _Scripts.Unit
{
    public class PreviewUnitPoolModel : IPreviewUnitPoolModel
    {
        private readonly IDisposer _disposer;
        private readonly IReactiveCollection<UnitPreviewType> _displayedUnitPreviewTypes;

        public IReactiveCollection<UnitPreviewType> DisplayedUnitPreviewTypes
        {
            get { return _displayedUnitPreviewTypes; }
        }

        private readonly Dictionary<UnitPreviewType, ReactiveProperty<int>> _unitPreviewRequests;

        public PreviewUnitPoolModel(IDisposer disposer)
        {
            _disposer = disposer;
            _displayedUnitPreviewTypes = new ReactiveCollection<UnitPreviewType>();

            _unitPreviewRequests = EnumHelper<UnitPreviewType>.Iterator
                .ToDictionary(type => type, _ => new ReactiveProperty<int>(0));

            EnumHelper<UnitPreviewType>.Iterator.ForEach(SetupDisplayCondition);
        }

        public void DisplayPreview(UnitPreviewType type)
        {
            _unitPreviewRequests[type].Value++;
        }

        public void DisablePreview(UnitPreviewType type)
        {
            _unitPreviewRequests[type].Value--;
        }

        private void SetupDisplayCondition(UnitPreviewType type)
        {
            var previewRequests = _unitPreviewRequests[type];

            previewRequests.Pairwise((oldValue, newValue) => oldValue == 0 && newValue > 0)
                .IfTrue().SubscribeBlind(() => _displayedUnitPreviewTypes.Add(type))
                .AddToDisposer(_disposer);

            previewRequests.Pairwise((oldValue, newValue) => oldValue > 0 && newValue == 0)
                .IfTrue().SubscribeBlind(() => _displayedUnitPreviewTypes.Remove(type))
                .AddToDisposer(_disposer);
        }
    }
}