using ProductServices.Models;

namespace ProductServices.Repository
{
    public interface IProductRepository
    {
        Task<Product> AddProduct(Product product);
        Task<bool> DeleteProduct(int id);
        Task<Product> GetProductById(int id);
        Task<IEnumerable<Product>> GetAllProducts();
        Task<Product> UpdateProduct(Product product);
    }
}
