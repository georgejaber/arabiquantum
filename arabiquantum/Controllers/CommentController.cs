using arabiquantum.Data;
using arabiquantum.InterfacesRepository;
using arabiquantum.Models;
using arabiquantum.ViewModels;
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

        [HttpGet]
        public async Task<IActionResult> Index(long Id)
        {

           CommentViewModel commentView = new CommentViewModel();   


            commentView.comments = await _comment.GetCommentByPostId(Id);

            Post post1 =  await _comment.GetpostByPostId(PostId:Id);

            ViewData["posttext"] = post1.text;
            ViewData["postdate"] = post1.DateTime;
            ViewBag.postid = post1.Id ;

            return View(commentView);           
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
            comment1.PostId = comment.PostId;
            comment1.Post = await _comment.GetpostByPostId(comment1.PostId);

            if (!ModelState.IsValid)
            {
                return RedirectToAction("index", "Comment", new { comment1.Post.Id });
            }
            _comment.Add(comment1);
            return RedirectToAction("index", "Comment",new { comment1.Post.Id });
        }
        [HttpPost]
        public async Task<IActionResult> edit(Comment comment)
        {
            Comment comment1 = new Comment();

            comment1.Text = comment.Text;
            comment1.DateTime = DateTime.Now;
            comment1.PostId = comment.PostId;
            comment1.Post = await _comment.GetpostByPostId(comment1.PostId);
            comment1.Like = comment.Like;
            comment1.Dislike = comment.Dislike;

            if (!ModelState.IsValid)
            {
                return RedirectToAction("index", "Comment", new { comment1.Post.Id });
            }
            _comment.Update(comment1);
            return RedirectToAction("index", "Comment", new { comment1.Post.Id });
        }
    }
}
