using Microsoft.AspNetCore.Mvc;

namespace MVC_Frontend.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}