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


    }
}
