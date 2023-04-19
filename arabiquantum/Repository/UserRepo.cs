using arabiquantum.Data;
using arabiquantum.InterfacesRepository;
using arabiquantum.Models;

namespace arabiquantum.Repository
{
    public class UserRepo : IUserRepository
    {
        private readonly object _Context;

        public UserRepo(ApplicationDbContext context)
        {
            _Context = context;
        }
        public Task Add(User entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(User entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
