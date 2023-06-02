using arabiquantum.Data;
using arabiquantum.InterfacesRepository;
using arabiquantum.Models;
using Microsoft.EntityFrameworkCore;

namespace arabiquantum.Repository
{
    public class PostRepo : IPostRepository
    {
        private readonly ApplicationDbContext _Context;

        public PostRepo(ApplicationDbContext context)
        {
            _Context = context;
        }

        public async Task<IEnumerable<Post>> GetAll()
        {
            return await _Context.Posts.ToListAsync();
        }

        public async Task<Post> GetById(int id)
        {
            return await _Context.Posts.FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Post> GetByText(string search)
        {
            return await _Context.Posts.FirstOrDefaultAsync(i => i.text.Equals(search));
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
            var saved = _Context.SaveChanges();
            return saved > 0 ? true : false;

        }

        public async Task<IEnumerable<Post>> search(string searchtext)
        {  
           return await _Context.Posts.Where(s => s.text!.Contains(searchtext)).ToListAsync();
            
        }

      
    }
}
