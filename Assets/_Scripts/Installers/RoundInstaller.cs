using System;
using Zenject;
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
            
            // TODO create board controller and visuals
        }
    }
}