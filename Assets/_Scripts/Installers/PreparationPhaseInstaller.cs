using Zenject;
using _Scripts.Unit;
using _Scripts.UnitPools;

namespace _Scripts.Installers
{
    public class PreparationPhaseInstaller : Installer<PreparationPhaseInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindFactory<int, PreparationUnitModel, PreparationUnitModel.Factory>();
            Container.BindFactory<int, int, ShopUnitModel, ShopUnitModel.Factory>();

            Container.BindInterfacesTo<ShopUnitPool>().AsSingle();
            Container.BindInterfacesTo<PreparationBoardUnitPool>().AsSingle().WithConcreteId(true);
            Container.BindInterfacesTo<PreparationBenchUnitPool>().AsSingle().WithConcreteId(false);
        }
    }
}