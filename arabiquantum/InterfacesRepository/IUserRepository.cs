using arabiquantum.Models;

namespace arabiquantum.InterfacesRepository
{
    public interface IUserRepository
    {
        Task<User> GetById(int id);
        Task<IEnumerable<User>> GetAll();
        Task Add(User entity);
        void Delete(int id);
        void Update(int id,User entity);

    }


}
