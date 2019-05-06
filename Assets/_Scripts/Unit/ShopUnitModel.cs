using Zenject;

namespace _Scripts.Unit
{
    public class ShopUnitModel : IShopUnitModel
    {
        public class Factory : PlaceholderFactory<int, int, ShopUnitModel>
        { }

        public int Id { get; private set; }
        public int Cost { get; private set; }

        public ShopUnitModel(int id, int cost)
        {
            Id = id;
            Cost = cost;
        }
    }
}