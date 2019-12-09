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

        public PreviewUnitPoolController([Inject(Id = UnitType.Cube)] PreviewUnitView cubePreviewUnitView,
            [Inject(Id = UnitType.Cylinder)] PreviewUnitView cylinderPreviewUnitView,
            [Inject(Id = UnitType.Sphere)] PreviewUnitView spherePreviewUnitView,
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

        private void DisplayPreviewUnit(UnitType type)
        {
            switch (type)
            {
                case UnitType.Cube:
                    _cubePreviewUnitView.gameObject.SetActive(true);
                    break;
                case UnitType.Cylinder:
                    _cylinderPreviewUnitView.gameObject.SetActive(true);
                    break;
                case UnitType.Sphere:
                    _spherePreviewUnitView.gameObject.SetActive(true);
                    break;
                default:
                    throw new ArgumentOutOfRangeException("type", type, null);
            }
        }
    }
}