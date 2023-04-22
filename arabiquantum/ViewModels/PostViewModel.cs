using arabiquantum.Models;

namespace arabiquantum.ViewModels
{
    public class PostViewModel
    {
        public IEnumerable<Post> posts { get; set; }

        public Post Post { get; set; }
    }
}
