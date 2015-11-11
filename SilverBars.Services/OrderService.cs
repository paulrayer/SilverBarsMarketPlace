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

        public void CancelRegistration(Order order)
        {
            Orders.RemoveAll(
                r =>
                    r.UserId == order.UserId && r.OrderType == order.OrderType && r.Quantity == order.Quantity &&
                    r.Price == order.Price);
        }
    }
}