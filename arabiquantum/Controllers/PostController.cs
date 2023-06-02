using arabiquantum.InterfacesRepository;
using arabiquantum.Models;
using arabiquantum.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace arabiquantum.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostRepository _post;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserRepository _user;
        private readonly IVoteRepository _vote;

        public PostController(IPostRepository post, IHttpContextAccessor httpContextAccessor, IUserRepository user, IVoteRepository voteRepository)
        {
            this._post = post;
            this._httpContextAccessor = httpContextAccessor;
            this._user = user;
            this._vote = voteRepository;
        }

        public async Task<IActionResult> Index(string SearchText)
        {
            PostViewModel viewModel = new PostViewModel();

            List<ListPostsViewModel> result = new();

            viewModel.listPostsView = result;

            if (string.IsNullOrEmpty(SearchText))
            {
                var allposts = await _post.GetAll();

                foreach (var post in allposts)
                {
                    ListPostsViewModel postsViewModel = new ListPostsViewModel()
                    {
                        PostDateTime = post.DateTime,
                        PostId = post.Id,
                        PostText = post.text,
                        PostUsername = _user.GetUserNameById(post.UserId),
                        Votes = await _vote.GetVoteCountByPost(post.Id)//query every load 

                    };
                    result.Add(postsViewModel);
                }
                return View(viewModel);
            }
            var someposts = await _post.search(SearchText);

            foreach (var post in someposts)
            {
                ListPostsViewModel postsViewModel = new ListPostsViewModel()
                {
                    PostDateTime = post.DateTime,
                    PostId = post.Id,
                    PostText = post.text,
                    PostUsername = _user.GetUserNameById(post.UserId)
                };
                result.Add(postsViewModel);
            }

            return View(viewModel);
        }

 


    }
}
