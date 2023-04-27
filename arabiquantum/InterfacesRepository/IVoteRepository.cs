using arabiquantum.Models;

namespace arabiquantum.InterfacesRepository
{
    public interface IVoteRepository
    {
        Task<Vote> GetVoteByID(long id);

        Task<long> GetVoteCountByComment(long CommentId);

        Task<long> GetVoteCountByPost(long PostId);

        Task<bool> AddVote(Vote vote);

        Task<bool> UpdateVote(Vote vote);

        Task<bool> DeleteVote(long id);

        bool save();

    }
}
