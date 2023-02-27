using MessagePack;
using Microsoft.AspNetCore.Identity;
using Microsoft.Build.Framework;

namespace BulkyBookWeb.Models
{
    public class User : IdentityUser
    {
        public int Id { get; set; }
        [Required]
        public string? UserName { get; set; }
        
        
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }

        public string? IsAdmin { get; set; } 

    }
}
