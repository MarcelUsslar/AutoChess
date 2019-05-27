using UniRx;
using Zenject;
using _Scripts.Utility;

namespace _Scripts.Unit
{
    public class ShopUnitController
    {
        public class Factory : PlaceholderFactory<IShopUnitModel, IShopUnitView, IDisposer, ShopUnitController>
        { }

        private ShopUnitController(IShopUnitModel unitModel, IShopUnitView unitView, IDisposer disposer)
        {
            unitModel.CanBeBought
                .Subscribe(purchasable => unitView.Purchasable = purchasable)
                .AddToDisposer(disposer);

            unitView.BuyButton.OnClickAsObservable()
                .Where(_ => unitModel.CanBeBought.Value)
                .Subscribe(_ => unitModel.Buy())
                .AddToDisposer(disposer);
        }
    }
}