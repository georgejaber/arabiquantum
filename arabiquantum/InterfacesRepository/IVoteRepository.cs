using arabiquantum.Models;

namespace arabiquantum.InterfacesRepository
{
    public interface IVoteRepository
    {
        Task<Vote> GetVoteByID(long id);

        Task<long> GetVoteCountByComment(long CommentId);

        Task<long> GetVoteCountByPost(long PostId);

        bool save();

    }
}
