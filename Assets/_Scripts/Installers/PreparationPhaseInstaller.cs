using Zenject;
using _Scripts.Config;
using _Scripts.Unit;
using _Scripts.UnitPools;
using _Scripts.Utility;

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
            Container.BindFactory<int, int, ShopUnitModel, ShopUnitModel.Factory>();
            Container.BindFactory<IShopUnitModel, IShopUnitView, IDisposer, ShopUnitController, ShopUnitController.Factory>();

            Container.BindInterfacesTo<ShopUnitPool>().AsSingle();
            Container.BindInterfacesTo<PreparationUnitPool>().AsTransient().WithConcreteId(true).WithArguments(_boardConfig.BoardSize.x * _boardConfig.BoardSize.y);
            Container.BindInterfacesTo<PreparationUnitPool>().AsTransient().WithConcreteId(false).WithArguments(_boardConfig.UnitInventorySize.x * _boardConfig.UnitInventorySize.y);
        }
    }
}