using System.ComponentModel.DataAnnotations;

namespace arabiquantum.Models
{
    public class Post
    {
        [Key]
        public long PostId { get; set; }
        public string text { get; set; }
        public DateTime Date { get; set; }= DateTime.Now;

    }
}
