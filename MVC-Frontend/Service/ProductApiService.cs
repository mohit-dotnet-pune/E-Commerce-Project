using MVC_Frontend.Models;

public class ProductApiService
{
    private readonly HttpClient _client;

    public ProductApiService(IHttpClientFactory factory)
    {
        _client = factory.CreateClient("gateway");
    }

    public async Task<List<Product>> GetAll()
    {
        return await _client.GetFromJsonAsync<List<Product>>("product");
    }

    public async Task<Product?> GetById(int id)
    {
        return await _client.GetFromJsonAsync<Product>($"product/{id}");
    }

    public async Task<bool> Create(Product product)
    {
        var response = await _client.PostAsJsonAsync("product", product);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> Update(Product product)
    {
        var response = await _client.PutAsJsonAsync("product", product);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> Delete(int id)
    {
        var response = await _client.DeleteAsync($"product?id={id}");
        return response.IsSuccessStatusCode;
    }
}
