using UniRx;
using Zenject;
using _Scripts.Config;
using _Scripts.Unit;
using _Scripts.Utility;

namespace _Scripts.Shop
{
    public class ShopUnitController
    {
        public class Factory : PlaceholderFactory<IShopUnitModel, IShopUnitView, ShopUnitController>
        { }

        private ShopUnitController(IShopUnitView view, IShopUnitModel model, IShopConfig shopConfig, IDisposer disposer)
        {
            view.Preview = shopConfig.GetPreviewTexture(model.Id.Value);

            model.Cost.Subscribe(cost => view.Cost = cost).AddToDisposer(disposer);

            model.CanBeBought
                .Subscribe(purchasable => view.Purchasable = purchasable)
                .AddToDisposer(disposer);

            view.BuyButton.OnClickAsObservable()
                .Where(_ => model.CanBeBought.Value)
                .Subscribe(_ => model.Buy())
                .AddToDisposer(disposer);
        }
    }
}