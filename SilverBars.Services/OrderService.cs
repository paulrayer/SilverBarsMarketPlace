using System.Collections.Generic;
using System.Linq;

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

        public IEnumerable<Order> SummariseOrders()
        {
            return Orders.GroupBy(o => new { o.OrderType, o.Price })
                .Select(cl => new Order { Quantity = cl.Sum(c => c.Quantity), Price = cl.Key.Price, OrderType = cl.Key.OrderType })
                .OrderBy(o => o.OrderType)
                .ThenBy(o => o.Price);
        }
    }
}