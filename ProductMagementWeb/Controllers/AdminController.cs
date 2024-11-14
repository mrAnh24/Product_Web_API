using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProductMagementWeb.Models;

namespace ProductMagementWeb.Controllers
{
    public class AdminController : Controller
    {
        private readonly UserManager<AppUser> userManager;

        public AdminController(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }

        public IActionResult UserManagement()
        {
            return View();
        }

    }
}
