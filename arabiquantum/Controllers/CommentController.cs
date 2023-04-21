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
           CommentViewModel commentView = new CommentViewModel();   


            commentView.comments = await _comment.GetCommentByPostId(post.Id);

            Post post1 =  await _comment.GetpostByPostId(PostId: post.Id);

            ViewData["posttext"] = post1.text;
            ViewData["postdate"] = post1.DateTime;
            ViewData["postid"] = post1.Id;

            return View(commentView);           
        }     
        

        [HttpPost]
        public async Task<IActionResult> create(Comment comment)
        {
            Comment comment1 = new Comment();

            comment1.Text = comment.Text;
            comment1.DateTime = DateTime.Now;

            if (!ModelState.IsValid)
            {
                return RedirectToAction("index");
            }
            _comment.Add(comment1);
            return RedirectToAction("index");
        }
    }
}
