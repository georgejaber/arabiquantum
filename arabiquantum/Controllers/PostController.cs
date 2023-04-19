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
        public async Task<IActionResult> Index()
        {
            IEnumerable<Post> Posts = await _post.GetAll();
            return View(Posts);
        }
    }
}
