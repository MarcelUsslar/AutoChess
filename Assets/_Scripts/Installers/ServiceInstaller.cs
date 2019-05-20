using UniRx;
using Zenject;
using _Scripts.Services;
using _Scripts.Unit;

namespace _Scripts.Installers
{
    public class ServiceInstaller : Installer<ServiceInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<IScheduler>().FromInstance(Scheduler.DefaultSchedulers.TimeBasedOperations);
            
            Container.BindInterfacesTo<ActionTimerService>().AsSingle();
            Container.BindInterfacesTo<RandomUnitGenerator>().AsSingle();

            Container.BindInterfacesTo<GenericUnitMovementStrategy>().AsTransient();
            Container.BindInterfacesTo<GenericUnitHealthStrategy>().AsTransient();
        }
    }
}