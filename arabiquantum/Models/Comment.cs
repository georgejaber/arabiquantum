using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace arabiquantum.Models
{
    public class Comment
    {
        [Key]
        public long Id { get; set; }
        public string Text { get; set; }
        public DateTime Data { get; set; } = DateTime.Now;
        public int Like { get; set; }
        public int Dislike { get; set; }
    }
}
