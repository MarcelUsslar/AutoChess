using Zenject;
using _Scripts.Factories;

namespace _Scripts.Installers
{
    public class FactoryInstaller : Installer<FactoryInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<ShopFactory>().AsSingle();
            Container.BindInterfacesTo<PreparationUnitFactory>().AsSingle();
            Container.BindInterfacesTo<CombatUnitFactory>().AsSingle();
        }
    }
}