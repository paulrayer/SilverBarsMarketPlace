using System.Collections.Generic;

namespace SilverBars.Services
{
    public interface IOrderService
    {
        List<Order> Orders { get; set; }
        void RegisterOrder(Order order);
    }
}