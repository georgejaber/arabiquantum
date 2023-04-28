using arabiquantum.Models;
using Microsoft.AspNetCore.Mvc;

namespace arabiquantum.ViewModels
{
    public class ListCommentsViewModel
    {

        public long CommentId { get; set; }

        public string CommentText { get; set; }

        public DateTime CommentDateTime { get; set; }

        public string CommentUsername { get; set; }

        public long Votes { get; set; }

        public long? PostId { get; set; }

    }
}
