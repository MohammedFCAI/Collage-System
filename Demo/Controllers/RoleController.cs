using Demo.Models;
using Demo.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    [Authorize]
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        private readonly UserManager<ApplicationUser> _userManager;

        public RoleController(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }


        // Create Role
        [HttpGet]
        public IActionResult AddRole()
        {
            return View();
        }


        // Submit

        [HttpPost]
        public async Task<IActionResult> AddRole(RoleViewModel model)
        {

            if (ModelState.IsValid)
            {
                var role = new IdentityRole() { Name = model.RoleName };
                IdentityResult result = await _roleManager.CreateAsync(role);

                if (result.Succeeded)
                {
                    ViewBag.Msg = "Role Added Successfully";
                    return View(new RoleViewModel());

                }

                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }

            return View(model);
        }



        public IActionResult AssignRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AssignRole(AssignRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(model.UserName);

                if (user != null)
                {
                    var role = await _roleManager.FindByNameAsync(model.RoleName);

                    var roles = await _userManager.GetRolesAsync(user);

                    if (roles.Contains(model.RoleName))
                        ViewBag.RoleExist = "Role Already Added";

                    else if (role != null)
                    {
                        await _userManager.AddToRoleAsync(user, model.RoleName);
                        ViewBag.RoleAdded = "Role Added Successfully";
                    }

                }

                ModelState.AddModelError("", "Invalid username or role!");
            }
            return View(model);
        }
    }
}
