using System.ComponentModel.DataAnnotations;

namespace arabiquantum.Models
{
    public class User
    {
        [Key]
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }

        [DataType(DataType.Date)]
        public DateTime  BirthData { get; set; }
        public string?  Role { get; set; }
        
    }
}
