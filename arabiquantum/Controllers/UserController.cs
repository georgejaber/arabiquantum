using arabiquantum.Data;
using arabiquantum.Models;
using Microsoft.AspNetCore.Mvc;

namespace arabiquantum.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;
        public UserController(ApplicationDbContext _context)
        {
            this._context = _context;
        }

        public IActionResult Index()
        {
            List<User> users = _context.Users.ToList();
            return View();
        }
        
        public string name() {

            return "hasan";
        }


    }
}
