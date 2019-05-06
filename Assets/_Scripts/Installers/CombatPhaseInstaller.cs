using Zenject;
using _Scripts.Unit;
using _Scripts.UnitPools;

namespace _Scripts.Installers
{
    public class CombatPhaseInstaller : Installer<CombatPhaseInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindFactory<int, UnitAlliance, IUnitMovementStrategy, IUnitHealthStrategy, CombatUnitModel, CombatUnitModel.Factory>();

            Container.BindInterfacesTo<CombatBoardUnitPool>().AsSingle();
        }
    }
}