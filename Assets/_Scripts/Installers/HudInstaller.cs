using Zenject;
using _Scripts.Hud;

namespace _Scripts.Installers
{
    public class HudInstaller : Installer<HudInstaller>
    {
        public override void InstallBindings()
        {
            Container.Instantiate<HudController>();
            Container.Instantiate<HudShopController>();
        }
    }
}