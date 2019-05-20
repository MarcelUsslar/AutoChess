using _Scripts.Config;
using _Scripts.Unit;

namespace _Scripts.Factories
{
    public class ShopFactory : IShopFactory
    {
        private readonly IShopConfig _shopConfig;
        private readonly ShopUnitModel.Factory _shopUnitModelFactory;

        public ShopFactory(IShopConfig shopConfig, ShopUnitModel.Factory shopUnitModelFactory)
        {
            _shopConfig = shopConfig;
            _shopUnitModelFactory = shopUnitModelFactory;
        }

        public IShopUnitModel Create(int id)
        {
            return _shopUnitModelFactory.Create(id, _shopConfig.GetCost(id));
        }
    }
}
