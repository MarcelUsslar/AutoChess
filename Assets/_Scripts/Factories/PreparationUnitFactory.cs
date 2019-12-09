using System.Collections.Generic;
using Zenject;
using _Scripts.Config;
using _Scripts.Installers;
using _Scripts.PlayAreas;
using _Scripts.Unit;

namespace _Scripts.Factories
{
    public class PreparationUnitFactory : IPreparationUnitFactory
    {
        private readonly PreparationUnitController.Factory _preparationUnitControllerFactory;
        private readonly PreparationUnitModel.Factory _preparationUnitModelFactory;
        private readonly IUnitConfig _unitConfig;
        private readonly IPlayArea _benchModel;

        private readonly Dictionary<UnitType, IViewFactory<PreparationUnitView>> _unitViewFactories;

        public PreparationUnitFactory(PreparationUnitController.Factory preparationUnitControllerFactory,
            PreparationUnitModel.Factory preparationUnitModelFactory, IUnitConfig unitConfig,
            [Inject(Id = UnitType.Cube)] IViewFactory<PreparationUnitView> cubePreparationUnitViewFactory,
            [Inject(Id = UnitType.Sphere)] IViewFactory<PreparationUnitView> spherePreparationUnitViewFactory,
            [Inject(Id = UnitType.Cylinder)] IViewFactory<PreparationUnitView> cylinderPreparationUnitViewFactory,
            [Inject(Id = PlayArea.Bench)] IPlayArea benchModel)
        {
            _preparationUnitControllerFactory = preparationUnitControllerFactory;
            _preparationUnitModelFactory = preparationUnitModelFactory;
            _unitConfig = unitConfig;
            _benchModel = benchModel;

            _unitViewFactories = new Dictionary<UnitType, IViewFactory<PreparationUnitView>>
            {
                {UnitType.Cube, cubePreparationUnitViewFactory},
                {UnitType.Cylinder, cylinderPreparationUnitViewFactory},
                {UnitType.Sphere, spherePreparationUnitViewFactory}
            };
        }

        public IPreparationUnitModel Create(IShopUnitModel shopUnit)
        {
            var model = _preparationUnitModelFactory.Create(shopUnit.Id.Value);
            model.MoveTo(false, _benchModel.GetFirstFreePosition());

            var unitType = _unitConfig.GetPreviewType(shopUnit.Id.Value);
            var view = _unitViewFactories[unitType].Instantiate();

            _preparationUnitControllerFactory.Create(model, view);

            return model;
        }
    }
}