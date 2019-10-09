using Zenject;
using _Scripts.Unit;

namespace _Scripts.Installers
{
    public class PlayerInstaller : Installer<PlayerInstaller>
    {
        private const int K_playerCash = int.MaxValue;

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<CashModel>().AsSingle().WithArguments(K_playerCash);
        }
    }
}