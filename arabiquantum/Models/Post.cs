using System.ComponentModel.DataAnnotations;

namespace arabiquantum.Models
{
    public class Post
    {
        [Key]
        public long Id { get; set; }
        public string text { get; set; }
        public DateTime Data { get; set; }= DateTime.Now;


    }
}
