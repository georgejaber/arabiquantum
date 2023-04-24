using arabiquantum.Models;

namespace arabiquantum.InterfacesRepository
{
    public interface IAccountRepository
    {
        Task<IEnumerable<Post>> GetAllUserPosts();
        Task<User> GetUserDetails();


    }
}