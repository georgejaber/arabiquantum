using arabiquantum.InterfacesRepository;
using arabiquantum.Models;

namespace arabiquantum.Repository
{
    public class UserRepo : IUserRepository
    {
        public Task Add(User entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
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

        public void Update(int id, User entity)
        {
            throw new NotImplementedException();
        }
    }
}
