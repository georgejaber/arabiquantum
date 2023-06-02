using arabiquantum.Models;

namespace arabiquantum.InterfacesRepository
{
    public interface IUserRepository
    {
        Task<User> GetUserById(string id);

        string GetUserNameById(string id);

        bool save();
    }
}
