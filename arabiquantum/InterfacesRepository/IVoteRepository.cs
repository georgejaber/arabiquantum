using arabiquantum.Models;

namespace arabiquantum.InterfacesRepository
{
    public interface IVoteRepository
    {
        Task<Vote> GetVoteByID(long id);

        Task<long> GetVoteCountByComment(long CommentId);

        Task<long> GetVoteCountByPost(long PostId);

        Task<Vote> DoesPostVoteExist(Vote vote);

        Task<Vote> DoesCommentVoteExist(Vote vote);

        Task<bool> AddVote(Vote vote);

        Task<bool> UpdateVote(Vote vote);

        Task<bool> DeleteVote(Vote vote);

        bool save();

    }
}
