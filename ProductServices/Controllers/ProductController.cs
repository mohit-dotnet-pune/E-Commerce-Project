using Microsoft.AspNetCore.Mvc;
using ProductServices.Models;
using ProductServices.Repository;

namespace ProductServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _repo;
        public ProductController(IProductRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts()
        {
            var products = await _repo.GetAllProducts();
            if(products == null)
            {
                return BadRequest();
            }
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductsById(int id)
        { 
            var product = await _repo.GetProductById(id);
            if (product == null)
            {
                return BadRequest();
            }
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<Product>> AddProducts([FromBody] Product product)
        {
            var product1 = await _repo.AddProduct(product);
            if (product1 == null)
            {
                return BadRequest();
            }
            return Ok(product1);
        }

        [HttpPut]
        public async Task<ActionResult<Product>> UpdateProduct([FromBody] Product product)
        {
            var product1 = await _repo.UpdateProduct(product);
            if(product1 == null)
            {
                return BadRequest();
            }
            return Ok(product1);
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteProduct(int id)
        {
            bool product = await _repo.DeleteProduct(id);
            if(product)
            {
                return true;
            }
            return false;
        }
    }
}