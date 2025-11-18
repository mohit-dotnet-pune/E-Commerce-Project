namespace MVC_Frontend.Models
{
    public class OrderReviewVM
    {
        public int CustomerId { get; set; }
        public List<OrderItem> Items { get; set; } = new();
    }
}
