using Zenject;
using _Scripts.Config;
using _Scripts.Factories;
using _Scripts.Services;
using _Scripts.Unit;
using _Scripts.UnitPools;
using _Scripts.Utility;

namespace _Scripts.Installers
{
    public class RoundInstaller : Installer<RoundInstaller>
    {
        public override void InstallBindings()
        {
            var shopPool = Container.ResolveId<IUnitPool<IShopUnitModel>>(true);
            shopPool.Clear();

            var shopConfig = Container.Resolve<IShopConfig>();
            var shopFactory = Container.Resolve<IShopFactory>();
            var randomUnitGenerator = Container.Resolve<IRandomUnitGenerator>();
            
            var preparationUnitFactory = Container.Resolve<IPreparationUnitFactory>();
            AddShopUnits(shopConfig.ShopEntryAmount, shopPool, shopFactory, randomUnitGenerator, preparationUnitFactory);
            
            // TODO create board controller and visuals
        }

        private static void AddShopUnits(int amount, IUnitPool<IShopUnitModel> unitPool, IShopFactory shopFactory,
            IRandomUnitGenerator unitGenerator, IPreparationUnitFactory preparationUnitFactory)
        {
            amount.Times(() => unitPool.AddUnit(shopFactory.Create(unitGenerator.GetRandomUnitId())));
            // create unit controller with preparation unit factory
        }
    }
}