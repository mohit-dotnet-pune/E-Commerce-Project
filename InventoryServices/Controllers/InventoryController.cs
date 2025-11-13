using InventoryServices.Models;
using InventoryServices.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InventoryServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryRepository _repo;
        public InventoryController(IInventoryRepository repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public async Task<ActionResult<Inventory>> AddInventory([FromBody] Inventory inventory)
        {
            var invent = await _repo.AddInventory(inventory);
            if (invent == null)
            {
                return BadRequest();
            }
            return Ok(invent);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Inventory>> GetInventoryById(int id)
        {
            var invent = await _repo.GetInventoryById(id);
            if (invent == null)
            {
                return BadRequest();
            }
            return Ok(invent);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Inventory>>> GetAllInventories()
        {
            var invent = await _repo.GetAllInventories();
            if (invent == null)
            {
                return BadRequest();
            }
            return Ok(invent);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Inventory>> UpdateInventory(Inventory inventory)
        {
            var invent = await _repo.UpdateInventory(inventory);
            if (invent == null)
            {
                return BadRequest();
            }
            return Ok(invent);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteInventory(int id)
        {
            var invent = await _repo.DeleteInventory(id);
            if (invent == null)
            {
                return BadRequest();
            }
            return Ok(invent);
        }

        [HttpPut("{productId}/reduce")]
        public async Task<IActionResult> ReduceStock(int productId, [FromBody] int quantity)
        {
            var invent = await _repo.ReduceStock(productId, quantity);
            if (invent == null)
            {
                return BadRequest();
            }
            return Ok(invent);
        }
    }
}
