using UnityEngine;
using _Scripts.Config;
using _Scripts.Installers;
using _Scripts.Unit;
using _Scripts.Utility;

namespace _Scripts.Factories
{
    public class ShopFactory : IShopFactory
    {
        private readonly IShopConfig _shopConfig;

        private readonly ShopUnitModel.Factory _shopUnitModelFactory;
        private readonly ShopUnitController.Factory _shopUnitControllerFactory;
        private readonly IViewFactory<ShopUnitView> _shopViewFactory;

        public ShopFactory(IShopConfig shopConfig, ShopUnitModel.Factory shopUnitModelFactory,
            ShopUnitController.Factory shopUnitControllerFactory, IViewFactory<ShopUnitView> shopViewFactory)
        {
            _shopConfig = shopConfig;
            _shopUnitModelFactory = shopUnitModelFactory;
            _shopUnitControllerFactory = shopUnitControllerFactory;
            _shopViewFactory = shopViewFactory;
        }

        public IShopUnitModel Create(int id, Transform shopUnitParent, IDisposer disposer)
        {
            var unitModel = _shopUnitModelFactory.Create(id, _shopConfig.GetCost(id));

            var view = _shopViewFactory.Instantiate(shopUnitParent);

            _shopUnitControllerFactory.Create(unitModel, view, disposer);

            return unitModel;
        }
    }
}
