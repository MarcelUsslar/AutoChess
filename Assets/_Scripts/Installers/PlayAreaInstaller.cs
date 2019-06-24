using Zenject;
using _Scripts.PlayAreas;

namespace _Scripts.Installers
{
    public class PlayAreaInstaller : Installer<PlayAreaInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<BenchModel>().WithId(PlayArea.Bench).AsSingle();
            Container.Bind<BoardModel>().WithId(PlayArea.Board).AsSingle();
            //Container.BindInterfacesTo<BenchModel>().AsSingle().WithConcreteId(PlayArea.Bench);
            //Container.BindInterfacesTo<BoardModel>().AsSingle().WithConcreteId(PlayArea.Board);
        }
    }
}