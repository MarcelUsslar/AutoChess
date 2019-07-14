using Zenject;
using _Scripts.PlayAreas;

namespace _Scripts.Installers
{
    public class PlayAreaInstaller : Installer<PlayAreaInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<IPlayArea>().WithId(PlayArea.Bench).To<BenchModel>().AsSingle();
            Container.Bind<IPlayArea>().WithId(PlayArea.Board).To<BoardModel>().AsSingle();

            Container.Bind<IPlayAreaService>().WithId(PlayArea.Bench).To<BenchService>().AsSingle().NonLazy();
            Container.Bind<IPlayAreaService>().WithId(PlayArea.Board).To<BoardService>().AsSingle().NonLazy();
        }
    }
}