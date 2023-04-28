using arabiquantum.Data;
using arabiquantum.InterfacesRepository;
using arabiquantum.Models;
using arabiquantum.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace arabiquantum.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentRepository _comment;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserRepository _user;
        private readonly IVoteRepository _vote;

        public CommentController(ICommentRepository comment, IHttpContextAccessor httpContextAccessor,IUserRepository user, IVoteRepository vote)
        {
            this._comment = comment;
            this._httpContextAccessor = httpContextAccessor;
            this._user = user;
            this._vote = vote;
        }

        [HttpGet]
        public async Task<IActionResult> Index(long PostId,long Id)
        {
            long postId = PostId;

            if(PostId == null) 
            {
                postId = Id;
            }

            List<ListCommentsViewModel> result = new();

            CommentViewModel commentView = new CommentViewModel();
        
            var comments = await _comment.GetCommentByPostId(postId);
            foreach(Comment comment in comments) 
            {
                ListCommentsViewModel listComments = new ListCommentsViewModel() 
                {
                    CommentDateTime = comment.DateTime,
                    CommentId = comment.CommentId,
                    CommentText = comment.Text,
                    CommentUsername = _user.GetUserNameById(comment.UserId),
                    Votes = await _vote.GetVoteCountByComment(CommentId: comment.CommentId),//query every load 
                    PostId = PostId

                };
                result.Add(listComments);
            }

            Post post1 = await _comment.GetpostByPostId(PostId: postId);

            CreateCommentViewModel createCommentViewForPostDetails  = new CreateCommentViewModel()
            { PostText = post1.text,
              PostId   = postId,
              PostDateTime = post1.DateTime,
              PostUsername = _user.GetUserNameById(post1.UserId)
            };


            commentView.listCommentsViewModels = result;
            commentView.CreateCommentViewModel = createCommentViewForPostDetails;

            return View(commentView);
        }

        public IActionResult create()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> create(CreateCommentViewModel createcomment)
        {
            var UserId = _httpContextAccessor.HttpContext.User.GetUserId();

            Comment comment1 = new Comment();

            Post post = await _comment.GetpostByPostId(createcomment.PostId);

            comment1.Text = createcomment.Comment.Text;
            comment1.DateTime = DateTime.Now;
            comment1.PostId = createcomment.PostId;
            comment1.Post = post;
            comment1.Votes = 0;
            comment1.UserId = UserId;

            if (!ModelState.IsValid)
            {
                return RedirectToAction("index", "Comment", new { createcomment.PostId });
            }

            post.commentcount++;
            _comment.Add(comment1);


            return RedirectToAction("index", "Comment", new { createcomment.PostId });
        }


        [HttpPost]
        public async Task<IActionResult> Edit(string CommentText, int CommentId, long postid)
        {

            Comment OldComment = await _comment.GetByIdNoTracking(CommentId);
            Post post = await _comment.GetpostByPostIdNoTracking(postid);

            var UserId = _httpContextAccessor.HttpContext.User.GetUserId();

            if (OldComment == null || post == null)
            {
                return View("Error");
            }

            Comment Comment = new Comment
            {
                CommentId = CommentId,
                Text = CommentText,
                DateTime = DateTime.Now,
                PostId = postid,
                Post = post,
                Votes = OldComment.Votes,
                UserId = OldComment.UserId
            };

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit Comment");
                return RedirectToAction("index", "Comment", new { postid });
            }
            if (CommentText == OldComment.Text)
            {
                return RedirectToAction("index", "Comment", new { postid });
            }

            await _comment.Update(Comment);
            return RedirectToAction("index", new {postid});
        }

        [Route("Comment/Vote/{PostId}/{CommentId}/{type}")]
        public async Task<IActionResult> Vote(long PostId,long CommentId, string type)
        {
            var UserId = _httpContextAccessor.HttpContext.User.GetUserId();

            int VoteValue = 0;

            if (type.Equals("Up"))
            {   
                VoteValue = 1;
            }
            else
            {
                VoteValue = -1;
            }

            var Vote = new Vote()
            {
                vote = VoteValue,
                CommentId= CommentId,
                UserId = UserId,
            };

            if (!ModelState.IsValid)
            {
                return RedirectToAction("index", new { PostId });
            }

            var Existingvote = await _vote.DoesCommentVoteExist(Vote);

            if (Existingvote == null)
            {
                _vote.AddVote(Vote);
                return RedirectToAction("index", new { PostId });
            }

            bool IsEqual = Existingvote.vote.Equals(Vote.vote);

            if (IsEqual)
            {
                return RedirectToAction("index", new { PostId });
            }
            else
            {
                _vote.DeleteVote(Existingvote);
                _vote.AddVote(Vote);

                return RedirectToAction("index", new { PostId });
            }

        }
    }
}
