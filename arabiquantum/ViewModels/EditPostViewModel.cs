using arabiquantum.Models;
using Microsoft.AspNetCore.Mvc;

namespace arabiquantum.ViewModels
{
    public class EditPostViewModel
    {
        public IEnumerable<Post> posts { get; set; }

        [BindProperty]
        public string PostText { get; set; }

        public long PostId { get; set; }

        public string UserName { get; set; }

    }
}
