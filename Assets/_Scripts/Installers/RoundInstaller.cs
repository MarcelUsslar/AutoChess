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

            // TODO create board controller and visuals
        }
    }
}