using NUnit.Framework;
using _Scripts.UnitPools;
using Moq;
using UniRx;
using _Scripts.Factories;
using _Scripts.Unit;
using _Scripts.Utility;

namespace _Scripts.Editor.UnitTests.Units
{
    [Category("Units")]
    public class ShopUnitModelTests
    {
        private const int K_defaultId = 0;
        private const int K_defaultCost = 0;

        private Disposer _disposer;

        private Mock<ICashModel> _cashModelMock;
        private Mock<IPreparationUnitPool> _preparationUnitPoolMock;
        private Mock<IPreparationUnitFactory> _preparationUnitFactoryMock;

        private IReactiveProperty<int> _mockCurrentCash;
        private IReactiveProperty<bool> _mockIsBenchFull;

        [SetUp]
        public void SetUp()
        {
            _disposer = Disposer.Create();

            _cashModelMock = new Mock<ICashModel>();
            _preparationUnitPoolMock = new Mock<IPreparationUnitPool>();
            _preparationUnitFactoryMock = new Mock<IPreparationUnitFactory>();

            _mockCurrentCash = new ReactiveProperty<int>(0);
            _mockIsBenchFull = new ReactiveProperty<bool>(false);

            _cashModelMock.SetupGet(pool => pool.CurrentCash).Returns(_mockCurrentCash);
            _preparationUnitPoolMock.SetupGet(pool => pool.IsBenchFull).Returns(_mockIsBenchFull);
        }

        [TearDown]
        public void TearDown()
        {
            _disposer.Dispose();
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(5)]
        public void UnitHasId_WhenCreated(int id)
        {
            var model = CreateShopUnitModel(id, K_defaultCost);

            Assert.AreEqual(id, model.Id);
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(5)]
        public void UnitHasCost_WhenCreated(int cost)
        {
            var model = CreateShopUnitModel(K_defaultId, cost);

            Assert.AreEqual(cost, model.Cost);
        }

        [TestCase(1, 0)]
        [TestCase(2, 1)]
        [TestCase(12, 5)]
        public void UnitCanNotBeBought_WhenCostIsHigherThanCash(int cost, int currentCash)
        {
            _mockCurrentCash.Value = currentCash;

            var model = CreateShopUnitModel(K_defaultId, cost);

            Assert.IsFalse(model.CanBeBought.Value);
        }

        [TestCase(0, 0)]
        [TestCase(0, 1)]
        [TestCase(1, 1)]
        [TestCase(2, 5)]
        public void UnitCanBeBought_WhenCostIsLowerOrEqualToCash(int cost, int currentCash)
        {
            _mockCurrentCash.Value = cost - 1;

            var model = CreateShopUnitModel(K_defaultId, cost);

            Assert.IsFalse(model.CanBeBought.Value);

            _mockCurrentCash.Value = currentCash;

            Assert.IsTrue(model.CanBeBought.Value);
        }

        [Test]
        public void UnitCanBeBought_WhenBenchNotFull()
        {
            _mockCurrentCash.Value = K_defaultCost;

            _mockIsBenchFull.Value = false;

            var model = CreateShopUnitModel(K_defaultId, K_defaultCost);

            Assert.IsTrue(model.CanBeBought.Value);
        }

        [Test]
        public void UnitCanNotBeBought_WhenBenchFull()
        {
            _mockCurrentCash.Value = K_defaultCost;

            _mockIsBenchFull.Value = true;

            var model = CreateShopUnitModel(K_defaultId, K_defaultCost);

            Assert.IsFalse(model.CanBeBought.Value);
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(3)]
        public void BuysWithCorrectCost_WhenBuyingUnit(int cost)
        {
            _mockCurrentCash.Value = cost;

            var unitModel = CreateShopUnitModel(K_defaultId, cost);

            _cashModelMock.Verify(model => model.Buy(It.IsAny<int>()), Times.Never());

            unitModel.Buy();

            _cashModelMock.Verify(model => model.Buy(It.Is<int>(i => i == cost)), Times.Once());
        }
        
        [Test]
        public void CreatesPreparationUnit_WhenBuyingUnit()
        {
            _mockCurrentCash.Value = K_defaultCost;

            var unitModel = CreateShopUnitModel(K_defaultId, K_defaultCost);

            _preparationUnitFactoryMock.Verify(factory => factory.Create(It.IsAny<IShopUnitModel>()), Times.Never());

            unitModel.Buy();

            _preparationUnitFactoryMock.Verify(factory => factory.Create(It.Is<IShopUnitModel>(model => model == unitModel)), Times.Once());
        }

        [Test]
        public void ThrowsException_WhenBuyingWhileCanNotBeBought()
        {
            _mockCurrentCash.Value = K_defaultCost - 1;

            var unitModel = CreateShopUnitModel(K_defaultId, K_defaultCost);

            Assert.Catch(unitModel.Buy);
        }

        private ShopUnitModel CreateShopUnitModel(int id, int cost)
        {
            return new ShopUnitModel(id, cost, _cashModelMock.Object, _preparationUnitPoolMock.Object,
                _preparationUnitFactoryMock.Object, _disposer);
        }
    }
}