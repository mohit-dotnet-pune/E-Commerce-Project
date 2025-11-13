using System.ComponentModel.DataAnnotations.Schema;

namespace OrderServices.Models
{
    public class OrderItems
    {
        public int OrderItemsId { get; set; }
        public int ProductId {  get; set; }
        public string ProductName { get; set; }
        public int ProductQuantity { get; set; }
        [ForeignKey("Order")]
        public int OrderId { get; set; }
        public Order? order { get; set; }
    }
}