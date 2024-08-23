using Demo.Models;
using Demo.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    /// <summary>
    /// 1- Install Package Microsoft.Asp.NetCore.Identity.EntityFrameworkCore
    /// 2- Create Class ApplicationUser: IdentityUser
    /// 3- Update ApplicationDbcontext: IdentityUser<ApplicationUser>
    /// 4- Add Migration
    /// 5- Account Controller
    /// 6- Two Actions For Registeration
    /// 7- ViewMode For Registeration
    /// </summary>
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // Admin
        public IActionResult AddAdmin()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddAdmin(RegisterViewModel user)
        {
            /// Create account
            if (ModelState.IsValid)
            {
                var applicationUser = new ApplicationUser()
                {
                    UserName = user.UserName,

                    Address = user.Address
                };

                IdentityResult result = await _userManager.CreateAsync(applicationUser, user.Password);

                if (result.Succeeded)
                {
                    // Create Cookie

                    // Assign Role
                    await _userManager.AddToRoleAsync(applicationUser, "Admin");

                    await _signInManager.SignInAsync(applicationUser, false);
                    return RedirectToAction("Index", "Department");

                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }

            }
            return View(user);
        }





        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel user)
        {

            /// Create account
            if (ModelState.IsValid)
            {
                var applicationUser = new ApplicationUser()
                {
                    UserName = user.UserName,

                    Address = user.Address
                };

                IdentityResult result = await _userManager.CreateAsync(applicationUser, user.Password);

                if (result.Succeeded)
                {
                    // Create Cookie
                    await _signInManager.SignInAsync(applicationUser, false);
                    return RedirectToAction("Index", "Department");

                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }

            return View(user);
        }


        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Login");
        }



        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {

            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(model.UserName);
                if (user is not null)
                {
                    var isPasswordValid = await _userManager.CheckPasswordAsync(user, model.Password);
                    if (isPasswordValid)
                    {
                        await _signInManager.SignInAsync(user, model.RememberMe);

                        return RedirectToAction("Index", "Department");
                    }
                }

                ModelState.AddModelError("", "Invalid username or password!");
            }
            return View(model);
        }



    }
}
