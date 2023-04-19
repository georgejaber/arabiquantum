using Microsoft.AspNetCore.Mvc;

namespace arabiquantum.Controllers
{
    public class PostController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
