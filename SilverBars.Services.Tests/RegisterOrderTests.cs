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
           _orderService.RegisterOrder(new Order());
            Assert.AreEqual(1, _orderService.Orders.Count);
        }

      
    }
}
