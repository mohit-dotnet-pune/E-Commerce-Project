using ProductServices.Data;
using ProductServices.Models;

namespace ProductServices.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _db;
        public ProductRepository(AppDbContext db) 
        {
            _db = db;
        }
        public async Task<Product> AddProduct(Product product)
        {
            await _db.products.AddAsync(product);
            await _db.SaveChangesAsync();
            return product;
        }

        public async Task<bool> DeleteProduct(int id)
        {
            var product = await GetProductById(id);
            if (product == null)
            {
                return false;
            }
             _db.products.Remove(product);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return _db.products.ToList();
        }

        public async Task<Product> GetProductById(int id)
        {
            var product = await _db.products.FindAsync(id);
            if (product == null)
            {
                return null;
            }
            return product;
        }

        public async Task<Product> UpdateProduct(Product product)
        {
            var product1 = await GetProductById(product.ProductId);
            if (product1 == null)
            {
                return null;
            }
            product1.ProductPrice = product.ProductPrice;
            product1.ProductName = product.ProductName;
            product1.ProductDescription = product.ProductDescription;
            product1.CategoryId = product.CategoryId;

            await _db.SaveChangesAsync();
            return product1;
        }
    }
}