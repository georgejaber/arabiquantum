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

        public bool Add(Post entity)
        {
            _Context.Add(entity);
            return Save();
        }

        public bool Delete(Post entity)
        {
           _Context.Remove(entity);
            return Save();
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



        public async Task<IEnumerable<Post>> GetPostsByUserId(int userId)
        {
            //return await _Context.Posts.Where(i => i.user.UserId == userId).ToListAsync();

            throw new NotImplementedException();
        }

        public bool Save()
        {
            var saved = _Context.SaveChanges();
            return saved > 0 ? true : false;

        }

        public bool Update(Post entity)
        {
          _Context.Entry(entity).State = EntityState.Modified;
          return Save();
        }

        public async Task<IEnumerable<Post>> search(string searchtext)
        {  
           return await _Context.Posts.Where(s => s.text!.Contains(searchtext)).ToListAsync();
            
        }

      
    }
}
