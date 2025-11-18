namespace MVC_Frontend.Models
{
    public class SelectedProductVM
    {
        public bool IsSelected { get; set; }
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int ProductQuantity { get; set; }
    }
}
