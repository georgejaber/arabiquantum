using arabiquantum.Data;
using arabiquantum.InterfacesRepository;
using arabiquantum.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.Design;

namespace arabiquantum.Repository
{
    public class VoteRepo : IVoteRepository
    {
        private readonly ApplicationDbContext _context;

        public VoteRepo(ApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task<bool> AddVote(Vote vote)
        {
            await _context.AddAsync(vote);
            return save();
        }

        public async Task<bool> DeleteVote(Vote vote)
        {
            if(vote != null)
            {
                _context.Remove(vote);
                return save();
            }
            return false;
        }

        public async Task<Vote> GetVoteByID(long id)
        {
            var vote = await _context.Votes.FindAsync(id);

            return vote;          
        }

        public async Task<Vote> DoesPostVoteExist(Vote vote) 
        {
            Vote Vote = await _context.Votes.Where(c => c.UserId == vote.UserId).Where(c=>c.PostId == vote.PostId).FirstOrDefaultAsync();

            return Vote;
        }

        public async Task<Vote> DoesCommentVoteExist(Vote vote)
        {
            Vote Vote = await _context.Votes.Where(c => c.UserId == vote.UserId).Where(c => c.CommentId == vote.CommentId).FirstOrDefaultAsync();

            return Vote;
        }

        public async Task<long> GetVoteCountByComment(long CommentId)
        {
           var CommentSum =  await _context.Votes.Where(c=>c.CommentId == CommentId).SumAsync(c=>c.vote);
           return CommentSum;
        }

        public async Task<long> GetVoteCountByPost(long PostId)
        {
            var CommentSum = await _context.Votes.Where(c => c.PostId == PostId).SumAsync(c => c.vote);
            return CommentSum;
        }

        public bool save()
        {
            return _context.SaveChanges() > 0 ? true : false;
        }

        public async Task<bool> UpdateVote(Vote vote)
        {
            _context.Entry(vote).State = EntityState.Modified;

            return save();
        }
    }
}
