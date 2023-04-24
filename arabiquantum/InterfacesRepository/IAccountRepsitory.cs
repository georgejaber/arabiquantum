using arabiquantum.Models;

namespace arabiquantum.InterfacesRepository
{
    public interface IAccountRepository
    {
        Task<IList<Post>> GetAllUserPosts();
        Task<User> GetUserDetails();


    }
}