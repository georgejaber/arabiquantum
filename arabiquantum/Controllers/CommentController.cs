using arabiquantum.Data;
using arabiquantum.Models;
using Microsoft.AspNetCore.Mvc;

namespace arabiquantum.Controllers
{
    public class CommentController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CommentController(ApplicationDbContext _context)
        {
            this._context = _context;
        }

        public IActionResult Index()
        {
            List<Comment> comments =_context.Comments.ToList();

            return View(comments);
        }
    }
}
