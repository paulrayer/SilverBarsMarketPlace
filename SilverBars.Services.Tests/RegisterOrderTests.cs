using System.Linq;
using NUnit.Framework;

namespace SilverBars.Services.Tests
{
    [TestFixture]
    public class RegisterOrderTests
    {
        private IOrderService _orderService;

        [SetUp]
        public void SetUp()
        {
            _orderService = new OrderService();
        }

       
        [Test]
        public void RegisterOrderShouldAddAnOrderToTheCollection()
        {
            var order = GetADummyOrder();
           _orderService.RegisterOrder(new Order());
            Assert.AreEqual(1, _orderService.Orders.Count);
        }
        [Test]
        public void CancelARegisteredOrderShouldRemoveAnOrderFromTheCollection()
        {
            RegisterAnOrder();
            var order = GetADummyOrder();
            _orderService.CancelRegistration(order);
            Assert.AreEqual(0, _orderService.Orders.Count);
        }

        [Test]
        public void SummariseOrderShouldMergeOrdersOfTheSamePrice()
        {
            RegisterMultipleOrdersFewWithSamePrice();
            var summarisedOrders = _orderService.SummariseOrders().ToList();
            Assert.AreEqual(5.5d, summarisedOrders.First(s => s.Price.Equals(306d) && s.OrderType == "SELL").Quantity);
        }

        [Test]
        public void SummariseOrderShouldSortSellOrdersInAscendingOrder()
        {
            RegisterMultipleOrdersFewWithSamePrice();
            var summarisedOrders = _orderService.SummariseOrders().ToList();
            Assert.AreEqual(306d, summarisedOrders.First(s => s.OrderType == "SELL").Price);
            Assert.AreEqual(310d, summarisedOrders.Last(s => s.OrderType == "SELL").Price);
        }

        private Order GetADummyOrder()
        {
            return new Order { UserId = "user1", Quantity = 1, Price = 303, OrderType = "SELL" };
        }

        private void RegisterAnOrder()
        {
            _orderService.RegisterOrder(GetADummyOrder());
        }

        private void RegisterMultipleOrdersFewWithSamePrice()
        {
            _orderService.RegisterOrder(new Order { UserId = "user1", Quantity = 3.5, Price = 306, OrderType = "SELL" });
            _orderService.RegisterOrder(new Order { UserId = "user2", Quantity = 1.2, Price = 310, OrderType = "SELL" });
            _orderService.RegisterOrder(new Order { UserId = "user3", Quantity = 1.5, Price = 307, OrderType = "SELL" });
            _orderService.RegisterOrder(new Order { UserId = "user4", Quantity = 2.0, Price = 306, OrderType = "SELL" });
            _orderService.RegisterOrder(new Order { UserId = "user1", Quantity = 1.9, Price = 320, OrderType = "BUY" });
            _orderService.RegisterOrder(new Order { UserId = "user2", Quantity = 3.5, Price = 340, OrderType = "BUY" });
            _orderService.RegisterOrder(new Order { UserId = "user3", Quantity = 4.2, Price = 330, OrderType = "BUY" });
            _orderService.RegisterOrder(new Order { UserId = "user4", Quantity = 2.7, Price = 360, OrderType = "BUY" });
        }

    }
}
