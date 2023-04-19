using System.ComponentModel.DataAnnotations;

namespace arabiquantum.Models
{
    public class User
    {
        [Key]
        public long UserId { get; set; }
        public string?  Role { get; set; }

    }
}
