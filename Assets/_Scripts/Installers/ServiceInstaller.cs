using UniRx;
using Zenject;
using _Scripts.Services;

namespace _Scripts.Installers
{
    public class ServiceInstaller : Installer<ServiceInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<IScheduler>().FromInstance(Scheduler.DefaultSchedulers.TimeBasedOperations);
            
            Container.BindInterfacesTo<ActionTimerService>().AsSingle();
        }
    }
}