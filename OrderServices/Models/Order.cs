namespace OrderServices.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public decimal? OrderAmount { get; set; }

        public ICollection<OrderItems>? orderItems { get; set; } = new List<OrderItems>();
    }
}