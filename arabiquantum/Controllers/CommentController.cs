using arabiquantum.Data;
using arabiquantum.InterfacesRepository;
using arabiquantum.Models;
using Microsoft.AspNetCore.Mvc;

namespace arabiquantum.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentRepository _comment;

        public CommentController(ICommentRepository comment)
        {
            this._comment = comment;
        }

        public IActionResult Index()
        {
      
            return View();
        }
    }
}
