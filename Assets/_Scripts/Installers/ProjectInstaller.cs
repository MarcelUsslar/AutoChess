using System;
using UniRx;
using Zenject;
using _Scripts.Utility;

namespace _Scripts.Installers
{
    public class ProjectInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            var disposer = Disposer.Create();
            ((IDisposable) disposer).AddTo(gameObject);

            Container.Bind<IDisposer>().FromInstance(disposer);

            ServiceInstaller.Install(Container);
            BoardInstaller.Install(Container);
        }
    }
}