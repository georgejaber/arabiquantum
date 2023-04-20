using arabiquantum.Data;
using arabiquantum.InterfacesRepository;
using arabiquantum.Models;
using Microsoft.EntityFrameworkCore;

namespace arabiquantum.Repository
{
    public class UserRepo : IUserRepository
    {
        private readonly ApplicationDbContext _Context;

        public UserRepo(ApplicationDbContext context)
        {

            _Context = context;
        }
        public Task Add(User entity)
        {

            _Context.Add(entity);
        }

        public void Delete(User entity)
        {
            _Context.Remove(entity);
            
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return _Context.Posts.ToListAsync;

        }
        public async Task<User> GetById(int id)
        {
          //  return _Context.Posts.FirstOrDefaultAsync(i => i.UserId == id);
        }

        public void Update(User entity)
        {
            _Context.Update(entity);
           
        }
    }
}
