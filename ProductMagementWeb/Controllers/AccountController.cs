using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProductMagementWeb.Models;
using ProductMagementWeb.ViewModels;
using System.Windows;

namespace ProductMagementWeb.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<AppUser> signInManager;
        private readonly UserManager<AppUser> userManager;

        public AccountController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM model)
        {
            if(ModelState.IsValid)
            {
                
                AppUser user = new()
                {
                    Name = model.Username,
                    Email = model.Email,
                    UserName = model.Username,
                    Role = "lv1",
                    Gender = "Unknown",
                };

                if(model.Username == "admin")
                {
                    ModelState.AddModelError("", "Can't use admin as Username!");
                }
                else
                {
                    var result = await userManager.CreateAsync(user, model.Password!);

                    if (result.Succeeded)
                    {
                        //await signInManager.SignInAsync(user, false);
                        return RedirectToAction("Login", "Account");
                    }
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(model);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {
            if(ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe, false);

                if (result.Succeeded)
                {
                    if (model.Username == "admin")
                    {
                        return RedirectToAction("UserManagement", "Admin");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }

                ModelState.AddModelError("", "Invalid information");
                return View(model);
            }
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
