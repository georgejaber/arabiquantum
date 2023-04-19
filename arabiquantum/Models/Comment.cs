using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace arabiquantum.Models
{
    public class Comment
    {
        [Key]
        public long CommentId { get; set; }

        [ForeignKey("PostId")]
        public int PostId { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public int Like { get; set; }
        public int Dislike { get; set; }
    }
}
