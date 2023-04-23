using Google.Protobuf.WellKnownTypes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace arabiquantum.Models
{
    public class Post
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string text { get; set; }
        public DateTime DateTime { get; set; }
        public int commentcount { get; set; }

        public int vote { get; set; }

        // Navigation property

        [ForeignKey("Id")]
        public string? UserId { get; set; }
        public User? user { get; set; }

    }
}

