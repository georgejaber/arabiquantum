using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace arabiquantum.Models
{
    public class Vote
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public int vote { get; set; }

        [ForeignKey("Id")]
        public string UserId { get; set; }
        public User User { get; set; }

        [ForeignKey("Id")]
        public long? PostId { get; set; }
        public  Post Post { get; set; }

        [ForeignKey("CommentId")]
        public long? CommentId { get; set; }
        public Comment Comment { get; set; }

    }
}
