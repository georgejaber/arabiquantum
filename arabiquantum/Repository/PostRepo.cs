﻿using arabiquantum.InterfacesRepository;
using arabiquantum.Models;

namespace arabiquantum.Repository
{
    public class PostRepo : IPostRepository
    {
        public Task Add(Post entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Post>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Post> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, Post entity)
        {
            throw new NotImplementedException();
        }
    }
}
