using System.ComponentModel.DataAnnotations;

namespace BulkyBookWeb.Models
{
    public class RegistorDto
    {
        [Required]
        public string? UserName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
        [Required]
        [Compare(nameof(Password), ErrorMessage = "Password doesn't equal to confirm password")]
        public string? ConfirmPassword { get; set; }
        [RegularExpression("Admin|User", ErrorMessage = "Enter Admin or User")] 
        public string? IsAdmin { get; set; }
    }
}
