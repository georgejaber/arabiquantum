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

        public async Task<IActionResult> Index(Post post)
        {        
           return View(await _comment.GetCommentByPostId(post.Id));
        }     
        
        public IActionResult create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> create(Comment comment)
        {
            Comment comment1 = new Comment();

            comment1.Text = comment.Text;
            comment1.DateTime = DateTime.Now;

            if (!ModelState.IsValid)
            {
                return View(comment);
            }
            _comment.Add(comment1);
            return RedirectToAction("index");
        }
    }
}
