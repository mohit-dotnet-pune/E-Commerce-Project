using Microsoft.EntityFrameworkCore;
using OrderServices.Data;
using OrderServices.DTOs;
using OrderServices.Models;

namespace OrderServices.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _db;
        private readonly HttpClient _httpClient;
        private readonly HttpClient _httpClient1;

        public OrderRepository(AppDbContext db,IHttpClientFactory httpClientFactory)
        {   
            _db = db;
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("http://localhost:5145/");

            _httpClient1 = httpClientFactory.CreateClient();
            _httpClient1.BaseAddress = new Uri("http://localhost:5077/");
        }
        public async Task<Order> AddOrder(Order order)
        {
            decimal amount = 0;
            List<OrderItems> items = order.orderItems.ToList();

            // Step 1: Create a new Order object (without items yet)
            var newOrder = new Order
            {
                CustomerId = order.CustomerId
            };

            _db.orders.Add(newOrder);
            await _db.SaveChangesAsync(); // generates OrderId

            // Step 2: For each item, calculate total and link to newOrder
            foreach (var i in items)
            {
                var product = await _httpClient.GetFromJsonAsync<ProductDto>($"api/product/{i.ProductId}");
                var inventory = await _httpClient1.GetFromJsonAsync<InventoryDto>($"api/inventory/{i.ProductId}");

                if (inventory.StockQuantity < i.ProductQuantity)
                {
                    throw new Exception($"Product {product.ProductName} has lesser quantity");
                }

                amount += (product.ProductPrice * i.ProductQuantity);
                i.ProductName = product.ProductName;
                i.OrderId = newOrder.OrderId; // ✅ link to saved order
                _db.orderItems.Add(i);
            }

            // Step 3: Update total amount
            newOrder.OrderAmount = amount;

            await _db.SaveChangesAsync();

            return newOrder;
        }


        public async Task<IEnumerable<Order>> GetOrderByCustomerId(int customerId)
        {
            return await _db.orders.Where(o => o.CustomerId == customerId).Include(p => p.orderItems).ToListAsync();
        }
    }
}
