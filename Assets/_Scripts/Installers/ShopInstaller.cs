using Zenject;
using _Scripts.Shop;
using _Scripts.Unit;
using _Scripts.UnitPools;

namespace _Scripts.Installers
{
    public class ShopInstaller : Installer<ShopInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindFactory<int, ShopUnitModel, ShopUnitModel.Factory>();
            Container.BindFactory<IShopUnitModel, IShopUnitView, ShopUnitController, ShopUnitController.Factory>();

            Container.BindInterfacesTo<ShopUnitPool>().AsSingle();
            Container.Instantiate<ShopPanelController>();
        }
    }
}