using UniRx;

namespace _Scripts.Unit
{
    public interface IPreviewUnitPoolModel
    {
        IReactiveCollection<UnitType> DisplayedUnitPreviewTypes { get; }
        void DisplayPreview(UnitType type);
        void DisablePreview(UnitType type);
    }
}