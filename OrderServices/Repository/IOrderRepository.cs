using OrderServices.Models;

namespace OrderServices.Repository
{
    public interface IOrderRepository
    {
        Task<Order> AddOrder(Order order);
        Task<IEnumerable<Order>> GetOrderByCustomerId (int customerId);
    }
}
