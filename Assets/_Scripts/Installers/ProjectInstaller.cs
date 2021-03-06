using System;
using Zenject;
using _Scripts.Utility;

namespace _Scripts.Installers
{
    public class ProjectInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            var disposer = Disposer.Create();
            Container.Bind<IDisposable>().FromInstance(disposer);
            Container.Bind<IDisposer>().FromInstance(disposer);

            Container.BindInterfacesTo<UniRxEventBus>().AsSingle();
            
            ServiceInstaller.Install(Container);

            PlayAreaInstaller.Install(Container);

            FactoryInstaller.Install(Container);

            PlayerInstaller.Install(Container);

            PreparationPhaseInstaller.Install(Container);
            CombatPhaseInstaller.Install(Container);

            HudInstaller.Install(Container);

            ShopInstaller.Install(Container);

            RoundInstaller.Install(Container);
        }
    }
}