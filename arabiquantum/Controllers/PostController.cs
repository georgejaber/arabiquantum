using arabiquantum.Data;
using arabiquantum.InterfacesRepository;
using arabiquantum.Models;
using arabiquantum.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace arabiquantum.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostRepository _post;

        public PostController(IPostRepository post)
        {
            this._post = post;
        }
 
        public async Task<IActionResult> Index(string SearchText)
        {
            PostViewModel viewModel = new PostViewModel();

            Post post = await _post.GetByText(SearchText);
            viewModel.Post = post;

            if (string.IsNullOrEmpty(SearchText))
            {
              viewModel.posts =   await _post.GetAll();
              return View(viewModel);
            }
              viewModel.posts = await _post.search(SearchText);
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
            Post post1 = new Post();

            post1.text = post.text;
            post1.DateTime = DateTime.Now;
           
            if (!ModelState.IsValid)
            {
                return RedirectToAction("index");
            }
            _post.Add(post1);
            return RedirectToAction("index");
        }

        [HttpPost]
        public async Task<IActionResult> edit(Post post)
        {
            Post post1 = new Post();

            post1.text = post.text;
            post1.DateTime = DateTime.Now;

            if (!ModelState.IsValid)
            {
                return RedirectToAction("index");
            }
            _post.Update(post1);
            return RedirectToAction("index");
        }




    }
}
