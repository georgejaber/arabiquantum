using arabiquantum.Data;
using arabiquantum.InterfacesRepository;
using arabiquantum.Models;
using Microsoft.EntityFrameworkCore;

namespace arabiquantum.Repository
{

    public class CommentRepo : ICommentRepository
    {
        private readonly ApplicationDbContext _Context;

        public CommentRepo(ApplicationDbContext context)
        {
            _Context = context;
        }




        public async Task<Comment> GetById(long id)
        {
            return await _Context.Comments.FirstOrDefaultAsync(i => i.CommentId == id);
        }
        public async Task<Comment> GetByIdNoTracking(long id)
        {
            return await _Context.Comments.AsNoTracking().FirstOrDefaultAsync(i => i.CommentId == id);
        }

        public async Task<IEnumerable<Comment>> GetCommentByPostId(long PostId)
        {
            return await _Context.Comments.Include(i=> i.Post).Where(i => i.Post.Id == PostId).ToListAsync();
        }

        public async Task<Post> GetpostByPostId(long? PostId)
        {
            return await _Context.Posts.FirstOrDefaultAsync(i => i.Id == PostId);
        }

        public async Task<Post> GetpostByPostIdNoTracking(long? PostId)
        {
            return await _Context.Posts.AsNoTracking().FirstOrDefaultAsync(i => i.Id == PostId);
        }

        public bool Save()
        {
            var Save = _Context.SaveChanges();
            return Save > 0 ? true : false;
        }

    }
}
