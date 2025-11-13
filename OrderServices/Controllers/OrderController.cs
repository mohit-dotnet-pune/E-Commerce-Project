using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderServices.Models;
using OrderServices.Repository;

namespace OrderServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _db;

        public OrderController(IOrderRepository db)
        {
            _db = db;
        }

        [HttpPost]
        public async Task<IActionResult> AddOrder(Order order)
        {
            var o1 = await _db.AddOrder(order);
            if(o1 == null)
            {
                return BadRequest();
            }
            return Ok(o1);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderByUserId(int id)
        {
            var o = await _db.GetOrderByCustomerId(id);
            if (o == null)
            {
                return BadRequest();
            }
            return Ok(o);
        }
    }
}
