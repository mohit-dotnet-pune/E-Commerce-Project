using Microsoft.AspNetCore.Mvc;
using MVC_Frontend.Models;
using System.Net.Http.Json;

namespace MVC_Frontend.Service
{
    public class OrderApiService
    {
        private readonly HttpClient _client;

        public OrderApiService(HttpClient client)
        {
            _client = client;
            _client.BaseAddress = new Uri("http://localhost:5183/"); 
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            var products = await _client.GetFromJsonAsync<List<Product>>("product");
            return products ?? new List<Product>();
        }

        public async Task<bool> PlaceOrderAsync(object orderRequest)
        {
            var response = await _client.PostAsJsonAsync("order", orderRequest);
            return response.IsSuccessStatusCode;
        }

        public async Task<List<Order>> GetOrderById(int id)
        {
            var response = await _client.GetFromJsonAsync<List<Order>>($"order/{id}");
            return response;
        }

    }
}
