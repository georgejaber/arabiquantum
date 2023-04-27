using arabiquantum.Models;

namespace arabiquantum.ViewModels
{
    public class CreateCommentViewModel
    {
        public Comment Comment { get; set; }

        public long? PostId { get; set; }

        public string? PostText { get; set; }

        public string? PostUsername { get; set; }

        public DateTime? PostDateTime { get; set; }

    }
}
