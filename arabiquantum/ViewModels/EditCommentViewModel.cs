using arabiquantum.Models;
using Microsoft.AspNetCore.Mvc;

namespace arabiquantum.ViewModels
{
    public class EditCommentViewModel
    {

        public IEnumerable<Comment> comments { get; set; }

        public string CommentText { get; set; }

        public int CommentId { get; set; }
        public int PostId { get; set; }


    }
}
