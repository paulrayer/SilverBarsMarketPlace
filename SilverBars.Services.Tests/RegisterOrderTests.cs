using System.Collections.Generic;
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

        public RegisterOrderTests(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [Test]
        public void RegisterOrderShouldAddAnOrderToTheCollection()
        {
           _orderService.RegisterOrder(new Order());
            Assert.AreEqual(1, _orderService.Orders.Count);
        }

      
    }

    public class OrderService : IOrderService
    {
        public List<Order> Orders { get; set; }
        
        public void RegisterOrder(Order order)
        {
            throw new System.NotImplementedException();
        }
    }

    public class Order
    {
    }

    public interface IOrderService
    {
        List<Order> Orders { get; set; }
        void RegisterOrder(Order order);
    }
}
