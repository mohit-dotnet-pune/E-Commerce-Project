using Microsoft.AspNetCore.Mvc;
using MVC_Frontend.Models;
using MVC_Frontend.Service;

namespace MVC_Frontend.Controllers
{
    public class OrderController : Controller
    {
        OrderApiService _orderApi;   
        public OrderController(OrderApiService orderApi)
        {
            _orderApi = orderApi;
        }

        public async Task<IActionResult> Products()
        {
            var products = await _orderApi.GetAllProductsAsync();
            return View(products);
        }

        [HttpPost]
        public IActionResult ReviewOrder(List<OrderItem> SelectedProducts)
        {
            var selected = SelectedProducts
                .Where(x => x.IsSelected && x.ProductQuantity > 0)
                .ToList();

            return View(selected);
        }




        [HttpPost]
        public async Task<IActionResult> PlaceOrder(int CustomerId, List<OrderItem> Items)
        {
            if (Items == null || !Items.Any())
                return BadRequest("No products selected");

            var order = new
            {
                CustomerId = CustomerId,
                orderItems = Items.Select(x => new
                {
                    ProductId = x.ProductId,
                    ProductName = x.ProductName,
                    ProductQuantity = x.ProductQuantity
                }).ToList()
            };

            var ok = await _orderApi.PlaceOrderAsync(order);

            if (ok)
                return RedirectToAction("Orders", new { id = CustomerId });

            return View("ReviewOrder", Items);
        }

        [HttpGet]
        public async Task<IActionResult> Orders(int id)
        {
            var orders = await _orderApi.GetOrderById(id);
            return View(orders);
        }

    }
}
