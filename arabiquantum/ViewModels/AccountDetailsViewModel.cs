using arabiquantum.Models;

namespace arabiquantum.ViewModels
{
    public class AccountDetailsViewModel
    {

        public IList<Post> Posts { get; set; }

        public string  UserId { get; set; }

        public string UserName { get; set; }

        public string UserEmail { get; set; }

        public string UserPassword { get; set; }

    }
}
