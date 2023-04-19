using arabiquantum.Models;

namespace arabiquantum.InterfacesRepository
{
    public interface IPostRepository
    {
        Task<Post> GetById(int id);
        Task<IEnumerable<Post>> GetAll();
        Task Add(Post entity);
        void Delete(Post entity);
        void Update(Post entity);
    }
}
