
using MVC_Frontend.Models;
using System.Net.Http.Json;

public class InventoryApiService
{
    private readonly HttpClient _client;

    public InventoryApiService(IHttpClientFactory factory)
    {
        _client = factory.CreateClient("gateway");
    }

    // GET ALL
    public async Task<List<Inventory>> GetAll()
    {
        return await _client.GetFromJsonAsync<List<Inventory>>("inventory");
    }

    // GET BY ID
    public async Task<Inventory?> GetById(int id)
    {
        return await _client.GetFromJsonAsync<Inventory>($"inventory/{id}");
    }

    // CREATE
    public async Task<bool> Create(Inventory inventory)
    {
        var response = await _client.PostAsJsonAsync("inventory", inventory);
        return response.IsSuccessStatusCode;
    }

    // UPDATE
    public async Task<bool> Update(Inventory inventory)
    {
        var response = await _client.PutAsJsonAsync($"inventory/{inventory.InventoryId}", inventory);
        return response.IsSuccessStatusCode;
    }

    // DELETE
    public async Task<bool> Delete(int id)
    {
        var response = await _client.DeleteAsync($"inventory/{id}");
        return response.IsSuccessStatusCode;
    }

    // REDUCE STOCK
    public async Task<bool> ReduceStock(int productId, int quantity)
    {
        var response = await _client.PutAsJsonAsync($"inventory/{productId}/reduce", quantity);
        return response.IsSuccessStatusCode;
    }
}