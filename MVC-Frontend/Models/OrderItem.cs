namespace MVC_Frontend.Models
{
    public class OrderItem
    {
        public bool IsSelected { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public int ProductQuantity { get; set; }

        // Use decimal instead of int for price
        public decimal ProductPrice { get; set; }
    }
}
