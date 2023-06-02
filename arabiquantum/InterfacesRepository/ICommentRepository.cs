using arabiquantum.Models;

namespace arabiquantum.InterfacesRepository
{
    public interface ICommentRepository
    {
        Task<Comment> GetById(long id);
        Task<Comment> GetByIdNoTracking(long id);
        Task<IEnumerable<Comment>> GetCommentByPostId(long PostId);
        Task<Post> GetpostByPostId(long? PostId);
        Task<Post> GetpostByPostIdNoTracking(long? PostId);

        bool Save();
    }
}
