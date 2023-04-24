using arabiquantum.Data;
using arabiquantum.InterfacesRepository;
using arabiquantum.Models;

namespace arabiquantum.Repository
{
    public class AccountRepo : IAccountRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AccountRepo(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            this._context = context;
            this._httpContextAccessor = httpContextAccessor;
        }

        public async Task<IList<Post>> GetAllUserPosts()
        {
            var CurrentUser = _httpContextAccessor.HttpContext?.User.GetUserId();
            var posts = _context.Posts.Where(p=>p.user.Id == CurrentUser);
            return posts.ToList();
        }

        public Task<User> GetUserDetails()
        {
            throw new NotImplementedException();
        }
    }
}
