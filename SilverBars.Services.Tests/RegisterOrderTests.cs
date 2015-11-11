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

        private Order GetADummyOrder()
        {
            return new Order { UserId = "user1", Quantity = 1, Price = 303, OrderType = "SELL" };
        }

        private void RegisterAnOrder()
        {
            _orderService.RegisterOrder(GetADummyOrder());
        }
    }
}
