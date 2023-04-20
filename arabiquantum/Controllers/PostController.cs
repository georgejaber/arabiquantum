using arabiquantum.Data;
using arabiquantum.InterfacesRepository;
using arabiquantum.Models;
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
 
        public async Task<IActionResult> Index(Post post)
        {
            if (post.text == null) 
            {
              IEnumerable<Post> posts =  await _post.GetAll();
              return View(posts);
            }
            IEnumerable<Post> Posts = await _post.search(post);
            return View(Posts);
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
                return View(post1);
            }
            _post.Add(post1);
            return RedirectToAction("index");
        }

    }
}
