using arabiquantum.Models;

namespace arabiquantum.InterfacesRepository
{
    public interface IPostRepository
    {
        Task<Post> GetById(int id);
        Task<IEnumerable<Post>> GetAll();
        Task Add(Post entity);
        void Delete(int id);
        void Update(int id,Post entity);
    }
}
