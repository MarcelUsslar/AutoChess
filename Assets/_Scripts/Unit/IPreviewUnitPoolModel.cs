using UniRx;

namespace _Scripts.Unit
{
    public interface IPreviewUnitPoolModel
    {
        IReactiveCollection<UnitPreviewType> DisplayedUnitPreviewTypes { get; }
        void DisplayPreview(UnitPreviewType type);
        void DisablePreview(UnitPreviewType type);
    }
}