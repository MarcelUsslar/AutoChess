using System;
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
            var disposer = Disposer.Create();
            Container.Rebind<IDisposer>().FromInstance(disposer);
            Container.Bind<IDisposable>().FromInstance(disposer);

            var shopPool = Container.Resolve<IUnitPool<IShopUnitModel>>();
            shopPool.Clear();

            var shopConfig = Container.Resolve<IShopConfig>();
            var shopFactory = Container.Resolve<IShopFactory>();
            var randomUnitGenerator = Container.Resolve<IRandomUnitGenerator>();

            var shopPanel = Container.Resolve<IShopPanelView>();
            AddShopUnits(shopConfig.ShopEntryAmount, shopPanel, shopPool, shopFactory, randomUnitGenerator, disposer);
            
            // TODO create board controller and visuals
        }

        private static void AddShopUnits(int amount, IShopPanelView shopPanel,
            IUnitPool<IShopUnitModel> unitPool, IShopFactory shopFactory,
            IRandomUnitGenerator unitGenerator, IDisposer disposer)
        {
            amount.Times(() => unitPool.AddUnit(shopFactory.Create(unitGenerator.GetRandomUnitId(), shopPanel.UnitParent, disposer)));
            // create unit controller with preparation unit factory
        }
    }
}