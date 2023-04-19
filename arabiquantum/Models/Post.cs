using Google.Protobuf.WellKnownTypes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace arabiquantum.Models
{
    public class Post
    {
        [Key]
        public long PostId { get; set; }
        public string text { get; set; }
        public DateTime DateTime { get; set; }

        [ForeignKey("UserId")]
        public long UserId { get; set; }
        // Navigation property
        public User user { get; set; }

    }
}
