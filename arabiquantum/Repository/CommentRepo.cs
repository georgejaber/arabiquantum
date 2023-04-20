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

        public bool Add(Comment entity)
        {
            _Context.Add(entity);
            return Save();
        }

        public bool Delete(Comment entity)
        {
            _Context.Remove(entity);
            return Save();
        }

        public async Task<Comment> GetById(int id)
        {
            return await _Context.Comments.FirstOrDefaultAsync(i => i.CommentId == id);
        }

        public async Task<IEnumerable<Comment>> GetCommentByPostId(int PostId)
        {
            return await _Context.Comments.Where(i => i.Post.Id == PostId).ToListAsync();
        }

        public async Task<IEnumerable<Comment>> GetCommentByUserId(int userId)
        {
            // return await _Context.Comments.Where(i => i.user.UserId == userId).ToListAsync();
            throw new NotImplementedException();
        }

        public bool Save()
        {
            var Save = _Context.SaveChanges();
            return Save > 0 ? true : false;
        }

        public bool Update(Comment entity)
        {
            _Context.Entry(entity).State = EntityState.Modified ;
            return Save();
        }
    }
}
