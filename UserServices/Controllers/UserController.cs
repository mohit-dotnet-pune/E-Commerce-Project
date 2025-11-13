using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserServices.Models;
using UserServices.Repository;

namespace UserServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _repo;
        public UserController(IUserRepository repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public async Task<ActionResult<User>> AddUser([FromBody] User user)
        {
            var user1 = await _repo.AddUser(user);
            if(user1 == null)
            {
                return BadRequest();
            }
                return Ok(user1);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserId(int id)
        {
            var user1 = await _repo.GetUserById(id);
            if(user1 == null)
            {
                return BadRequest();
            }
            return Ok(user1);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
        {
            var user1 = await _repo.GetAllUsers();
            if(user1 == null)
            {
                return BadRequest();
            }
            return Ok(user1);
        }

        [HttpPatch]
        public async Task<ActionResult<User>> UpdateUser([FromBody] User user)
        {
            var user1 = await _repo.UpdateUser(user);
            if(user1 == null)
            {
                return NotFound();
            }
            return Ok(user1);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var user1 = await _repo.DeleteUser(id);
            if(user1 == false)
            {
                return BadRequest();
            }
            
            return Ok("Deleted successfully");
        }
    }
}
