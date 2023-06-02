using arabiquantum.Data;
using arabiquantum.InterfacesRepository;
using arabiquantum.Models;
using Microsoft.EntityFrameworkCore;

namespace arabiquantum.Repository
{
    public class UserRepo : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepo(ApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task<User> GetUserById(string id)
        {
            return await _context.Users.FindAsync(id);
        }

        public string GetUserNameById(string id)
        {
            return GetUserById(id).Result.UserName;
        }

        public bool save()
        {
           var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
