using System;
using UniRx;
using Zenject;
using _Scripts.Factories;
using _Scripts.UnitPools;
using _Scripts.Utility;

namespace _Scripts.Unit
{
    public class ShopUnitModel : IShopUnitModel
    {
        public class Factory : PlaceholderFactory<int, int, ShopUnitModel>
        { }

        private readonly ICashModel _cashModel;
        private readonly IPreparationUnitFactory _preparationUnitFactory;

        public int Id { get; }
        public int Cost { get; }
        public IReadOnlyReactiveProperty<bool> CanBeBought { get; }

        public ShopUnitModel(int id, int cost, ICashModel cashModel,
            [Inject(Id = false)] IPreparationUnitPool preparationUnitPool,
            IPreparationUnitFactory preparationUnitFactory,
            IDisposer disposer)
        {
            Id = id;
            Cost = cost;

            _cashModel = cashModel;
            _preparationUnitFactory = preparationUnitFactory;

            CanBeBought = preparationUnitPool.IsBenchFull
                .CombineLatest(cashModel.CurrentCash, (benchFull, cash) => !benchFull && cash >= cost)
                .ToReadOnlyReactiveProperty()
                .AddToDisposer(disposer);
        }

        public void Buy()
        {
            if (!CanBeBought.Value)
                throw new InvalidOperationException("Can not buy unit when not enough cash");

            _cashModel.Buy(Cost);
            _preparationUnitFactory.Create(this);
        }
    }
}