﻿using arabiquantum.Models;

namespace arabiquantum.InterfacesRepository
{
    public interface IPostRepository
    {
        Task<Post> GetById(int id);
        Task<IEnumerable<Post>> GetAll();
        Task<IEnumerable<Post>> GetPostsByUserId(int userId);
        Task<IEnumerable<Post>> search(string search);

        Task<Post> GetByText(string posttext);

        bool Add(Post entity);
        bool Delete(Post entity);
        bool Update(Post entity);
        bool Save();
    }
}
