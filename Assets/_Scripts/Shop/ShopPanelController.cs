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
        private readonly IShopConfig _config;
        private readonly IUnitPool<IShopUnitModel> _shopPool;
        private readonly IPreviewUnitPoolModel _previewUnitPoolModel;
        private readonly IEventBus _eventBus;

        public ShopPanelController(IShopPanelView view, IShopConfig config, IShopFactory factory,
            IUnitPool<IShopUnitModel> shopPool, IRandomUnitGenerator unitGenerator, ICashModel cashModel,
            IPreviewUnitPoolModel previewUnitPoolModel, IEventBus eventBus, IDisposer disposer)
        {
            _config = config;
            _shopPool = shopPool;
            _previewUnitPoolModel = previewUnitPoolModel;
            _eventBus = eventBus;

            view.CloseButton.OnClickAsObservable()
                .Merge(view.BackgroundButton.OnClickAsObservable())
                .SubscribeBlind(() => ClosePanel(view))
                .AddToDisposer(disposer);
            
            eventBus.OnEvent<OpenShopCommand>().SubscribeBlind(() => OpenPanel(view)).AddToDisposer(disposer);

            cashModel.CurrentCash.Subscribe(cash => view.CurrentCash = cash).AddToDisposer(disposer);

            // only spawn items once shop is first opened
            AddShopUnits(config.ShopEntryAmount, view, shopPool, factory, unitGenerator);
        }

        private void OpenPanel(IPanelView view)
        {
            _shopPool.Units.ForEach(model =>
                _previewUnitPoolModel.DisplayPreview(_config.GetPreviewType(model.Id.Value)));

            view.Open();
        }

        private void ClosePanel(IPanelView view)
        {
            _shopPool.Units.ForEach(model =>
                _previewUnitPoolModel.DisablePreview(_config.GetPreviewType(model.Id.Value)));

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