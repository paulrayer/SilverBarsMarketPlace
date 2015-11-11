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

        public OrderService()
        {
            if (Orders == null)
                Orders = new List<Order>();
        }

        public void RegisterOrder(Order order)
        {
            Orders.Add(order);
        }
    }

    public class Order
    {
        public string UserId { get; set; }
        public double Quantity { get; set; }
        public double Price { get; set; }
        public string OrderType { get; set; }
    }

    public interface IOrderService
    {
        List<Order> Orders { get; set; }
        void RegisterOrder(Order order);
    }
}
