using arabiquantum.Models;

namespace arabiquantum.InterfacesRepository
{
    public interface IUserRepository
    {
        Task<User> GetById(int id);
        Task<IEnumerable<User>> GetAll();
        Task Add(User entity);
        void Delete(User entity);
        void Update(User entity);

    }


}
