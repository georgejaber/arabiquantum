using Microsoft.AspNetCore.Mvc;

namespace arabiquantum.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
