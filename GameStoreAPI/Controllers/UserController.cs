using Microsoft.AspNetCore.Mvc;

namespace GameStoreAPI.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
