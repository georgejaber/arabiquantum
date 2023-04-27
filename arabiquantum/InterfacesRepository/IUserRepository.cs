using arabiquantum.Models;

namespace arabiquantum.InterfacesRepository
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsers();
        Task<User> GetUserById(string id);

        string GetUserNameById(string id);

        bool add(User user);
        bool update(User user);    
        bool delete(User user);
        bool save();
    }
}
