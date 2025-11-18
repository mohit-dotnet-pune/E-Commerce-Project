namespace MVC_Frontend.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public decimal? OrderAmount { get; set; }  // must be decimal to match backend
        public List<OrderItem> orderItems { get; set; } = new List<OrderItem>();
    }
}
