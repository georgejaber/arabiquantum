using arabiquantum.Data;
using arabiquantum.Models;
using Microsoft.AspNetCore.Mvc;

namespace arabiquantum.Controllers
{
    public class PostController : Controller
    {
        private readonly ApplicationDbContext _context;
        public PostController(ApplicationDbContext _context)
        {
            this._context = _context;
        }
        public IActionResult Index()
        {
            List<Post> Posts = _context.Posts.ToList();
            return View(Posts);
        }
    }
}
