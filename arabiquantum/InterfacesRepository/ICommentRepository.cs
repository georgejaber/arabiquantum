using arabiquantum.Models;

namespace arabiquantum.InterfacesRepository
{
    public interface ICommentRepository
    {
        Task<Comment> GetById(int id);
        Task<IEnumerable<Comment>> GetAll();
        Task Add(Comment entity);
        void Delete(int id);
        void Update(int id ,Comment entity);
    }
}
