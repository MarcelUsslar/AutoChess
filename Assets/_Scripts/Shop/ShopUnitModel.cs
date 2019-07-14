using System;
using UniRx;
using Zenject;
using _Scripts.Config;
using _Scripts.Factories;
using _Scripts.Unit;
using _Scripts.UnitPools;
using _Scripts.Utility;

namespace _Scripts.Shop
{
    public class ShopUnitModel : IShopUnitModel
    {
        public class Factory : PlaceholderFactory<int, ShopUnitModel>
        { }

        private readonly ICashModel _cashModel;
        private readonly IPreparationUnitFactory _preparationUnitFactory;

        private readonly IReactiveProperty<int> _id;
        private readonly IReactiveProperty<bool> _hasBeenBought;

        public IReadOnlyReactiveProperty<int> Id
        {
            get { return _id; }
        }
        public IReadOnlyReactiveProperty<int> Cost { get; private set; }
        public IReadOnlyReactiveProperty<bool> CanBeBought { get; private set; }

        public ShopUnitModel(int initialId, ICashModel cashModel, IBenchPreparationUnitPool benchPreparationUnitPool,
            IPreparationUnitFactory preparationUnitFactory, IShopConfig shopConfig, IDisposer disposer)
        {
            _id = new ReactiveProperty<int>(initialId);
            _hasBeenBought = new ReactiveProperty<bool>(false);

            Cost = _id.Select(shopConfig.GetCost)
                .ToReadOnlyReactiveProperty()
                .AddToDisposer(disposer);

            _cashModel = cashModel;
            _preparationUnitFactory = preparationUnitFactory;

            CanBeBought = benchPreparationUnitPool.IsBenchFull
                .CombineLatest(cashModel.CurrentCash, Cost, _hasBeenBought,
                    (benchFull, cash, cost, purchased) => !benchFull && cash >= cost && !purchased)
                .ToReadOnlyReactiveProperty()
                .AddToDisposer(disposer);
        }

        public void Buy()
        {
            if (!CanBeBought.Value)
                throw new InvalidOperationException("Can not buy unit when not enough cash");

            _cashModel.Buy(Cost.Value);
            _hasBeenBought.Value = true;
            _preparationUnitFactory.Create(this);
        }

        public void Reset(int unitId)
        {
            _hasBeenBought.Value = false;
            _id.Value = unitId;
        }
    }
}