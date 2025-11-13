using CategoryServices.Models;
using CategoryServices.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CategoryServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _repo;
        public CategoryController(ICategoryRepository repo) 
        {
            _repo = repo;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetByCategory(int id)
        {
            var cat = await _repo.GetCategoryById(id);
            if (cat == null)
            {
                return NotFound();
            }
            return Ok(cat);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetAllCategories()
        {
            var cat = await _repo.GetAllCategories();
            if(cat == null)
            {
                return NotFound();
            }
            return Ok(cat);
        }

        [HttpPost]
        public async Task<ActionResult<Category>> AddCategory([FromBody]Category category)
        {
            var cat = await _repo.AddCategory(category);
            if(cat == null)
            {
                return BadRequest();
            }
            return category;
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteCategory(int id)
        {
            bool cat = await _repo.DeleteCategory(id);
            if (cat == true)
            {
                return true;
            }
            return false;
        }

        [HttpPut]
        public async Task<ActionResult<Category>> UpdateCategory( [FromBody]Category category)
        {
            var cat = await _repo.UpdateCategory(category);
            if (cat == null)
            {
                return BadRequest();
            }
            return category;
        }
    }
}
