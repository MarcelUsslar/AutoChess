using Zenject;
using _Scripts.Unit;

namespace _Scripts.Installers
{
    public class RoundInstaller : Installer<RoundInstaller>
    {
        public override void InstallBindings()
        {
            Container.Instantiate<UnitManualMovementController>();
            // TODO create board controller and visuals
        }
    }
}