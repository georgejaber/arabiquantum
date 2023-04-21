using arabiquantum.Models;

namespace arabiquantum.InterfacesRepository
{
    public interface ICommentRepository
    {
        Task<Comment> GetById(int id);
        Task<IEnumerable<Comment>> GetCommentByUserId(int userId);
        Task<IEnumerable<Comment>> GetCommentByPostId(long PostId);
        Task<Post> GetpostByPostId(long? PostId);

        bool Add(Comment entity);
        bool Delete(Comment entity);
        bool Update(Comment entity);
        bool Save();
    }
}
