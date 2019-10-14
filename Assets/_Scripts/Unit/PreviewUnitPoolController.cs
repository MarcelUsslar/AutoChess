using System;
using Zenject;
using _Scripts.Utility;

namespace _Scripts.Unit
{
    public class PreviewUnitPoolController
    {
        private readonly PreviewUnitView _cubePreviewUnitView;
        private readonly PreviewUnitView _cylinderPreviewUnitView;
        private readonly PreviewUnitView _spherePreviewUnitView;

        public PreviewUnitPoolController([Inject(Id = UnitPreviewType.Cube)] PreviewUnitView cubePreviewUnitView,
            [Inject(Id = UnitPreviewType.Cylinder)] PreviewUnitView cylinderPreviewUnitView,
            [Inject(Id = UnitPreviewType.Sphere)] PreviewUnitView spherePreviewUnitView,
            IPreviewUnitPoolModel previewUnitPoolModel, IDisposer disposer)
        {
            _cubePreviewUnitView = cubePreviewUnitView;
            _cylinderPreviewUnitView = cylinderPreviewUnitView;
            _spherePreviewUnitView = spherePreviewUnitView;

            previewUnitPoolModel.DisplayedUnitPreviewTypes.ObserveCountChanged(true)
                .SubscribeBlind(() =>
                {
                    DisableAllPreviews();
                    previewUnitPoolModel.DisplayedUnitPreviewTypes.ForEach(DisplayPreviewUnit);
                }).AddToDisposer(disposer);
        }

        private void DisableAllPreviews()
        {
            _cubePreviewUnitView.gameObject.SetActive(false);
            _cylinderPreviewUnitView.gameObject.SetActive(false);
            _spherePreviewUnitView.gameObject.SetActive(false);
        }

        private void DisplayPreviewUnit(UnitPreviewType type)
        {
            switch (type)
            {
                case UnitPreviewType.Cube:
                    _cubePreviewUnitView.gameObject.SetActive(true);
                    break;
                case UnitPreviewType.Cylinder:
                    _cylinderPreviewUnitView.gameObject.SetActive(true);
                    break;
                case UnitPreviewType.Sphere:
                    _spherePreviewUnitView.gameObject.SetActive(true);
                    break;
                default:
                    throw new ArgumentOutOfRangeException("type", type, null);
            }
        }
    }
}