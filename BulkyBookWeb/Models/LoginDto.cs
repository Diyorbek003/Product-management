using System.ComponentModel.DataAnnotations;

namespace BulkyBookWeb.Models
{
    public class LoginDto
    {

        [Display(Name = "UserName")]
        [Required]
        public string? UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
    }
}
