using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProductMagementWeb.Views.Home;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;

namespace ProductMagementWeb.Views.Admin
{
    public class UserManagementModel : PageModel
    {
        public List<UserAccount> listOfAccount = new List<UserAccount>();
        public void OnGet()
        {
            try
            {
                SqlConnection con = new SqlConnection("Server=.;Database=testAPI;Trusted_Connection=SSPI;MultipleActiveResultSets=true;TrustServerCertificate=true");
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT Id, Name, Role, Gender, Username, Email FROM AspNetUserRoles", con);
                SqlDataReader da = cmd.ExecuteReader();
                while (da.Read())
                {
                    UserAccount userAccount = new UserAccount();
                    userAccount.Id = da.GetString(0);
                    userAccount.Role = da.GetString(1);
                    userAccount.Gender = da.GetString(2);
                    userAccount.Username = da.GetString(3);
                    userAccount.Email = da.GetString(4);

                    listOfAccount.Add(userAccount);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
            }
        }
    }

    public class UserAccount
    {
        public string Id { get; set; }
        public string Role { get; set; }
        public string Gender { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }

    }
}
