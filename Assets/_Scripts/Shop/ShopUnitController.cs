﻿using UniRx;
using Zenject;
using _Scripts.Unit;
using _Scripts.Utility;

namespace _Scripts.Shop
{
    public class ShopUnitController
    {
        public class Factory : PlaceholderFactory<IShopUnitModel, IShopUnitView, ShopUnitController>
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