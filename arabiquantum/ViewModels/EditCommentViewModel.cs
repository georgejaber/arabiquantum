using arabiquantum.Models;

namespace arabiquantum.ViewModels
{
    public class EditCommentViewModel
    {

        public IEnumerable<Comment> comments { get; set; }

        public Comment comment { get; set; }
    }
}
