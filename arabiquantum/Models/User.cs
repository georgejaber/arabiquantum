using System.ComponentModel.DataAnnotations;

namespace arabiquantum.Models
{
    public class User
    {
        [Key]
        public long Id { get; set; }
        public string?  Role { get; set; }

    }
}
