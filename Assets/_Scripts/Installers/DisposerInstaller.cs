using System;
using Zenject;
using _Scripts.Utility;

namespace _Scripts.Installers
{
    public class DisposerInstaller : Installer<DisposerInstaller>
    {
        public override void InstallBindings()
        {
            var disposer = Disposer.Create();
            Container.Bind<IDisposable>().FromInstance(disposer);
            Container.Bind<IDisposer>().FromInstance(disposer);
        }
    }
}