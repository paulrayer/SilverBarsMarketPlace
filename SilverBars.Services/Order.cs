namespace SilverBars.Services
{
    public class Order
    {
        public string UserId { get; set; }
        public double Quantity { get; set; }
        public double Price { get; set; }
        public string OrderType { get; set; }
    }
}