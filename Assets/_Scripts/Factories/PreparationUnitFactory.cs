using Zenject;
using _Scripts.Installers;
using _Scripts.PlayAreas;
using _Scripts.Unit;

namespace _Scripts.Factories
{
    public class PreparationUnitFactory : IPreparationUnitFactory
    {
        private readonly PreparationUnitController.Factory _preparationUnitControllerFactory;
        private readonly PreparationUnitModel.Factory _preparationUnitModelFactory;
        private readonly IViewFactory<PreparationUnitView> _preparationUnitViewFactory;
        private readonly IPlayArea _benchModel;

        public PreparationUnitFactory(PreparationUnitController.Factory preparationUnitControllerFactory,
            PreparationUnitModel.Factory preparationUnitModelFactory,
            IViewFactory<PreparationUnitView> preparationUnitViewFactory,
            [Inject(Id = PlayArea.Bench)] IPlayArea benchModel)
        {
            _preparationUnitControllerFactory = preparationUnitControllerFactory;
            _preparationUnitModelFactory = preparationUnitModelFactory;
            _preparationUnitViewFactory = preparationUnitViewFactory;
            _benchModel = benchModel;
        }

        public IPreparationUnitModel Create(IShopUnitModel shopUnit)
        {
            var model = _preparationUnitModelFactory.Create(shopUnit.Id.Value);
            model.MoveTo(false, _benchModel.GetFirstFreePosition());
            
            var view = _preparationUnitViewFactory.Instantiate();
            
            _preparationUnitControllerFactory.Create(model, view);

            return model;
        }
    }
}