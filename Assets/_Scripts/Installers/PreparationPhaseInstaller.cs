using Zenject;
using _Scripts.Config;
using _Scripts.Unit;
using _Scripts.UnitPools;

namespace _Scripts.Installers
{
    public class PreparationPhaseInstaller : Installer<PreparationPhaseInstaller>
    {
        private readonly IBoardConfig _boardConfig;

        public PreparationPhaseInstaller(IBoardConfig boardConfig)
        {
            _boardConfig = boardConfig;
        }

        public override void InstallBindings()
        {
            Container.BindFactory<int, PreparationUnitModel, PreparationUnitModel.Factory>();
            Container.BindFactory<IPreparationUnitModel, PreparationUnitView, PreparationUnitController, PreparationUnitController.Factory>();

            Container.BindInterfacesTo<BenchPreparationUnitPool>().AsSingle().WithArguments(_boardConfig.UnitInventorySize.x * _boardConfig.UnitInventorySize.y);
            Container.BindInterfacesTo<BoardPreparationUnitPool>().AsSingle().WithArguments(_boardConfig.BoardSize.x * _boardConfig.BoardSize.y);
        }
    }
}