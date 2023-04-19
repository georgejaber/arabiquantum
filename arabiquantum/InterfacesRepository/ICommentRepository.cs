using arabiquantum.Models;

namespace arabiquantum.InterfacesRepository
{
    public interface ICommentRepository
    {
        Task<Comment> GetById(int id);
        Task<IEnumerable<Comment>> GetAll();
        Task Add(Comment entity);
        void Delete(Comment entity);
        void Update(Comment entity);
    }
}
