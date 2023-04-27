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

        public bool add(User user)
        {
            throw new NotImplementedException();
        }

        public bool delete(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
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
            throw new NotImplementedException();
        }

        public bool update(User user)
        {
            throw new NotImplementedException();
        }
    }
}
