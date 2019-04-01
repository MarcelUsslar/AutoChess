using Zenject;
using _Scripts.Unit;

namespace _Scripts.Installers
{
    public class BoardInstaller : Installer<BoardInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindFactory<UnitAlliance, UnitModel, UnitModel.Factory>();
        }
    }
}