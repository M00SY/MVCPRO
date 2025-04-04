using AutoMapper;
using Demo_BLL.Interfaces;
using Demo_BLL.Repositories;
using Demo_Dal.Entities;
using Demo_PL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Drawing;

namespace Demo_PL.Controllers
{
    [Authorize(Roles = "Admin")]

    public class RolesController : Controller
    {
        private readonly RoleManager<ApplicationRole> roleManager;
        private readonly UserManager<ApplicationUser> userManager;

        public RolesController(RoleManager<ApplicationRole> _roleManager,
                               UserManager<ApplicationUser> _userManager)
        {
            roleManager = _roleManager;
            userManager = _userManager;
        }
        public async Task<IActionResult> Index()
        {
            var roles = await roleManager.Roles.ToListAsync();
            return View(roles);
        }

        public IActionResult Create()
        {

            return View(new ApplicationRole());
        }
        [HttpPost]
        public async Task<IActionResult> Create(ApplicationRole appRole)
        {

            if (ModelState.IsValid)
            {
                 
                var result = await roleManager.CreateAsync(appRole);
                if(result.Succeeded) 
                    return RedirectToAction(nameof(Index));
            }
            
            return View(appRole);
        }


        public async Task<IActionResult> Details(string id, string viewName = "Details")
        {
            if (string.IsNullOrEmpty(id))
                return NotFound();

            var role = await roleManager.FindByIdAsync(id);
            if (role == null)
                return NotFound();



            return View(viewName, role);
        }

        public async Task<IActionResult> Update(string id)
        {
            return await Details(id, "Update");
        }

        [HttpPost]
        public async Task<IActionResult> Update(string id, ApplicationRole approle)
        {
            if (id != approle.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                var role = await roleManager.FindByIdAsync(id);
                role.Name = approle.Name;
                role.NormalizedName = approle.Name.ToUpper();

                var result = await roleManager.UpdateAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                foreach (var error in result.Errors)
                    ModelState.AddModelError("", error.Description);
            }
            return View(approle);
        }

        public async Task<IActionResult> Delete(string id, ApplicationRole appRole)
        {
            if (id != appRole.Id)
                return NotFound();

            var role = await roleManager.FindByIdAsync(id);
            var result = await roleManager.DeleteAsync(role);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }

            foreach (var error in result.Errors)
                ModelState.AddModelError("", error.Description);

            return RedirectToAction("Index");




        }
        public async Task<IActionResult> AddOrRemoveUsers(string roleId)
        {
            var role = await roleManager.FindByIdAsync(roleId);
            if(role == null)
                return NotFound();

            ViewBag.RoleId = role.Id;
            var users = new List<UserInRoleViewModel>();
            foreach (var user in await userManager.Users.ToListAsync())
            {
                var userInRole = new UserInRoleViewModel()
                {
                    UserId = user.Id,
                    UserName = user.UserName,
                    IsSelected = false,
                };
                if(await userManager.IsInRoleAsync(user, role.Name))
                    userInRole.IsSelected = true;

                users.Add(userInRole);
            }
            return View(users);
        }

        [HttpPost]
        public async Task<IActionResult> AddOrRemoveUsers(List<UserInRoleViewModel> users,string roleId)
        {
            var role = await roleManager.FindByIdAsync(roleId);
            if (role == null)
                return NotFound();

            if(ModelState.IsValid)
            {
                foreach (var user in users)
                {
                    var appuser = await userManager.FindByIdAsync(user.UserId);

                    if(appuser == null)
                        return NotFound();

                    if(user.IsSelected && !(await userManager.IsInRoleAsync(appuser, role.Name)) )
                        await userManager.AddToRoleAsync(appuser, role.Name);

                    else if (!user.IsSelected && (await userManager.IsInRoleAsync(appuser, role.Name)))
                        await userManager.RemoveFromRoleAsync(appuser, role.Name);
                }
                return RedirectToAction(nameof(Update), new {id = roleId});
            }
            return View(users);

        }
        

    }
}
