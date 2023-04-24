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

            EditCommentViewModel editComment = new EditCommentViewModel();
           CommentViewModel commentView = new CommentViewModel(); 

           editComment.comments = await _comment.GetCommentByPostId(Id);

            Post post1 =  await _comment.GetpostByPostId(PostId:Id);

            ViewData["posttext"] = post1.text;
            ViewData["postdate"] = post1.DateTime;
            ViewBag.postid = post1.Id ;

            commentView.EditCommentViewModel = editComment;

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
            comment1.Votes = 0;

            if (!ModelState.IsValid)
            {
                return RedirectToAction("index", "Comment", new { comment1.Post.Id });
            }
            _comment.Add(comment1);
            return RedirectToAction("index", "Comment",new { comment1.Post.Id });
        }


        [HttpPost]
        public async Task<IActionResult> Edit(string CommentText,int CommentId,long postid)
        {
 
            Comment OldComment = await _comment.GetByIdNoTracking(CommentId);
            Post post = await _comment.GetpostByPostIdNoTracking(postid);

            if (OldComment == null||post == null) {
                return View("Error");
            }
  
           Comment Comment =  new Comment {
                CommentId = CommentId,
                Text = CommentText,
                DateTime = DateTime.Now,
                PostId = postid,
                Post = post,
                Votes = OldComment.Votes,
                user = OldComment.user,
                UserId = OldComment.UserId };
            
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit Comment");
                return RedirectToAction("index", "Comment", new { Comment.Post.Id});
            }   
            if(CommentText == OldComment.Text) 
            {
                return RedirectToAction("index", "Comment", new { Comment.Post.Id});
            }

            await _comment.Update(Comment);
            return RedirectToAction("index",new {Comment.Post.Id} );
        }
    }
}
