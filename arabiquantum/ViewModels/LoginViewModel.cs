using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace arabiquantum.ViewModels
{
    public class LoginViewModel 
    {
        [Required]
        [Display(Name ="Email Address")]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }

}
 