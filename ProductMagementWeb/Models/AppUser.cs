using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ProductMagementWeb.Models
{
    public class AppUser:IdentityUser
    {
        [StringLength(100)]
        [MaxLength(100)]
        [Required]
        public string Name { get; set; }
        public string Role { get; set; }
        public string Gender { get; set; }
    }
}
