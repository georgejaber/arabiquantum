using arabiquantum.Data;
using arabiquantum.InterfacesRepository;
using arabiquantum.Models;
using arabiquantum.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Xml.Linq;

namespace arabiquantum.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostRepository _post;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public PostController(IPostRepository post,IHttpContextAccessor httpContextAccessor)
        {
            this._post = post;
            this._httpContextAccessor = httpContextAccessor;
        }
 
        public async Task<IActionResult> Index(string SearchText)
        {
            PostViewModel viewModel = new PostViewModel();
            EditPostViewModel editPostViewModel = new EditPostViewModel();
      

            Post post = await _post.GetByText(SearchText);
            viewModel.Post = post;
            viewModel.EditPostViewModel = editPostViewModel;


            if (string.IsNullOrEmpty(SearchText))
            {
              viewModel.EditPostViewModel.posts =   await _post.GetAll();

              return View(viewModel);
            }

            viewModel.EditPostViewModel.posts = await _post.search(SearchText);

            return View(viewModel);
        }

        public async Task<IActionResult> delete(int postid)
        {
            Post post = await _post.GetById(postid);

             _post.Delete(post);

            return View(); 
         
        }

        public IActionResult create() 
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> create(Post post) 
        {
            var UserId = _httpContextAccessor.HttpContext.User.GetUserId();
           

            Post post1 = new Post();

            post1.text = post.text;
            post1.DateTime = DateTime.Now;
            post1.commentcount = 0;
            post1.vote = 0;
            post1.UserId = UserId;
           
            if (!ModelState.IsValid)
            {
                return RedirectToAction("index");
            }
            _post.Add(post1);
            return RedirectToAction("index");
        }

        [HttpPost]
        public async Task<IActionResult> edit(string PostText, long PostId, string PostRequestRoutedFrom)
        {
            
            Post OldPost = await _post.GetpostByPostIdNoTracking(PostId);

            var UserId = _httpContextAccessor.HttpContext.User.GetUserId();

            if (OldPost == null)
            {
                return View("Error");
            }

            Post NewPost = new Post
            {
                Id = PostId,
                text = PostText,
                DateTime = DateTime.Now,
                commentcount = OldPost.commentcount,
                vote = OldPost.vote,
                UserId = UserId              
            };

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit Post");
                return RedirectToAction("index");
            }

            if (PostText == OldPost.text)
            {
                return RedirectToAction("index");
            }
            await _post.Update(NewPost);
            if (PostRequestRoutedFrom.Equals("Account")) 
            {
                return RedirectToAction("AccountDetails","Account");
            }
            return RedirectToAction("index");

        }

    }
}
