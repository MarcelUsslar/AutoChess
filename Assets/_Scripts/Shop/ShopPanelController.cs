using System;
using UniRx;
using _Scripts.Config;
using _Scripts.Factories;
using _Scripts.Services;
using _Scripts.Unit;
using _Scripts.UnitPools;
using _Scripts.Utility;

namespace _Scripts.Shop
{
    public class ShopPanelController
    {
        private readonly IEventBus _eventBus;

        public ShopPanelController(IShopPanelView view, IShopConfig config, IShopFactory factory,
            IUnitPool<IShopUnitModel> shopPool, IRandomUnitGenerator unitGenerator, IEventBus eventBus, IDisposer disposer)
        {
            _eventBus = eventBus;
            view.CloseButton.OnClickAsObservable()
                .Merge(view.BackgroundButton.OnClickAsObservable())
                .SubscribeBlind(() => ClosePanel(view))
                .AddToDisposer(disposer);
            
            // open panel on event
            eventBus.OnEvent<OpenShopCommand>().SubscribeBlind(view.Open).AddToDisposer(disposer);

            // only spawn items once shop is first opened
            AddShopUnits(config.ShopEntryAmount, view, shopPool, factory, unitGenerator);
        }

        private void ClosePanel(IShopPanelView view)
        {
            view.Close();
            _eventBus.Publish(new CloseShopEvent());
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