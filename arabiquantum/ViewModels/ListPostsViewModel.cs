using arabiquantum.Models;
using Microsoft.AspNetCore.Mvc;

namespace arabiquantum.ViewModels
{
    public class ListPostsViewModel
    {
        public long PostId { get; set; }
        public string PostText { get; set; }
        public DateTime PostDateTime { get; set; }
        public string PostUsername { get; set; }
    }

}
