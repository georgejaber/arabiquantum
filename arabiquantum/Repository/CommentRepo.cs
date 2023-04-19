using arabiquantum.InterfacesRepository;
using arabiquantum.Models;

namespace arabiquantum.Repository
{
    public class CommentRepo : ICommentRepository
    {
        public Task Add(Comment entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Comment>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Comment> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, Comment entity)
        {
            throw new NotImplementedException();
        }
    }
}
