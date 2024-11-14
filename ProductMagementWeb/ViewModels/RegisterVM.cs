using System.ComponentModel.DataAnnotations;

namespace ProductMagementWeb.ViewModels
{
    public class RegisterVM
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
        [Required]
        public string? Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        [Compare("Password", ErrorMessage ="Passwords don't match.")]
        [Display(Name = "Confirmed Password")]
        [DataType(DataType.Password)]
        public string? ConfirmedPassword { get; set; }

        public string? Role { get; set; }
        
        public string? Gender { get; set; }
    }
}
