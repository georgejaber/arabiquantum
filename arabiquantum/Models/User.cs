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
        public DateTime  birthData { get; set; }
        public string?  role { get; set; }
        
    }
}
