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

        public async Task<IEnumerable<Post>> GetAllUserPosts()
        {
            var CurrentUser = _httpContextAccessor.HttpContext?.User;
            var posts = _context.Posts.Where(p=>p.user.Id == CurrentUser.ToString());
            return posts;
        }

        public Task<User> GetUserDetails()
        {
            throw new NotImplementedException();
        }
    }
}
