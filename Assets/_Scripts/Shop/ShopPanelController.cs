using UniRx;
using _Scripts.Config;
using _Scripts.Factories;
using _Scripts.Services;
using _Scripts.UnitPools;
using _Scripts.Utility;

namespace _Scripts.Unit
{
    public class ShopPanelController
    {
        public ShopPanelController(IShopPanelView view, IShopConfig config, IShopFactory factory,
            IUnitPool<IShopUnitModel> shopPool, IRandomUnitGenerator unitGenerator, IDisposer disposer)
        {
            view.CloseButton.OnClickAsObservable()
                .Merge(view.BackgroundButton.OnClickAsObservable())
                .Subscribe(_ => view.ClosePanel())
                .AddToDisposer(disposer);
            
            // open panel on event

            // only spawn items once shop is first opened
            AddShopUnits(config.ShopEntryAmount, view, shopPool, factory, unitGenerator);
        }
        
        private static void AddShopUnits(int amount, IShopPanelView shopPanel,
            IUnitPool<IShopUnitModel> unitPool, IShopFactory shopFactory,
            IRandomUnitGenerator unitGenerator)
        {
            amount.Times(() => unitPool.AddUnit(shopFactory.Create(unitGenerator.GetRandomUnitId(), shopPanel.UnitParent)));
            // create unit controller with preparation unit factory
        }
    }
}