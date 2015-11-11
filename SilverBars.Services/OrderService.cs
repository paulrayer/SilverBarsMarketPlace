using System.Collections.Generic;

namespace SilverBars.Services
{
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
}