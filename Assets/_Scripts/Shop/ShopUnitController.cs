using UniRx;
using Zenject;
using _Scripts.Unit;
using _Scripts.Utility;

namespace _Scripts.Shop
{
    public class ShopUnitController
    {
        public class Factory : PlaceholderFactory<IShopUnitModel, IShopUnitView, ShopUnitController>
        { }

        private ShopUnitController(IShopUnitModel model, IShopUnitView view, IDisposer disposer)
        {
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