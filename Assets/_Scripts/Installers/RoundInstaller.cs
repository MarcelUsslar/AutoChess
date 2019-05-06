using Zenject;
using _Scripts.Factories;
using _Scripts.UnitPools;
using _Scripts.Utility;

namespace _Scripts.Installers
{
    public class RoundInstaller : Installer<RoundInstaller>
    {
        private const int K_randomShopUnit = 0;

        public override void InstallBindings()
        {
            var shopPool = Container.Resolve<IShopUnitPool>();
            var shopFactory = Container.Resolve<IShopFactory>();

            // add x amount of units to shop pool (needs config)
            shopPool.Clear();
            AddShopUnits(0, shopPool, shopFactory);

            // TODO create board controller and visuals
        }

        private static void AddShopUnits(int amount, IShopUnitPool unitPool, IShopFactory shopFactory)
        {
            amount.Times(() => unitPool.AddUnit(shopFactory.CreateShopUnit(K_randomShopUnit)));
        }
    }
}