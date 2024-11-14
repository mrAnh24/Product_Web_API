using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProductMagementWeb.Models.Account
{
    [Table("Account")]
    public class Account
    {
        [Key]
        [Column("Email")]
        public string Email { get; set; }
        [Column("Username")]
        public string Username { get; set; }
        [Column("Password")]
        public string Password { get; set; }
        [Column("Role")]
        public string Role { get; set; }
        [Column("PhoneNumbers")]
        public string PhoneNumbers { get; set; }
        [Column("Gender")]
        public string Gender { get; set; }
    }
}
