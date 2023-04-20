using Google.Protobuf.WellKnownTypes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace arabiquantum.Models
{
    public class Comment
    {
        [Key]
        public long CommentId { get; set; }
        public string Text { get; set; }
        public DateTime DateTime { get; set; }
        public int Like { get; set; }
        public int Dislike { get; set; }

        [ForeignKey("Id")]
        public long? PostId { get; set; }
        // Navigation property
        public Post Post { get; set; }

        [ForeignKey("Id")]
        public string? UserId { get; set; }
        public User user { get; set; }
    }
}
