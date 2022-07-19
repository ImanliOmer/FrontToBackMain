using FrontToBack.Models;
using FrontToBack.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontToBack.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]

    public class UserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _rolemanager;

        public UserController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> rolemanager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _rolemanager = rolemanager;
        }

        public IActionResult Index(string search)
        {
            var users=search==null?
                _userManager.Users.ToList():_userManager.Users.
                Where(user=>user.FullName.ToLower().Contains(search.ToLower())).ToList();
  

            return View(users);
        }
        public async Task<IActionResult> Update(string id)
            
        {
            if (id == null) return NotFound();
            AppUser user = await _userManager.FindByIdAsync(id);
            var userRoles = await _userManager.GetRolesAsync(user);
            var roles=  _rolemanager.Roles.ToList();
            RoleVM roleVM = new RoleVM
            {
                FullName = user.FullName,
                Roles= roles,
                UserRoles=userRoles,
                UserId=user.Id
                

            };
            return View(roleVM);
        
        }
        [HttpPost]
        public async Task<IActionResult> Update(List<string>roles,string id)

        {
            AppUser user = await _userManager.FindByIdAsync(id);
                var userRoles=await _userManager.GetRolesAsync(user);
            await _userManager.RemoveFromRolesAsync(user, userRoles);
            await _userManager.AddToRolesAsync(user,roles);


            return RedirectToAction("index");
        }

    }
}
