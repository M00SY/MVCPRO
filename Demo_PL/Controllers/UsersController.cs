using Demo_Dal.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Demo_PL.Controllers
{
    [Authorize(Roles = "Admin")]

    public class UsersController : Controller
	{

		private readonly UserManager<ApplicationUser> userManager;

		public UsersController( UserManager<ApplicationUser> _userManager)
        {
			userManager = _userManager;
		}
        public async Task<IActionResult> Index(string email)
		{
			List<ApplicationUser> user = new List<ApplicationUser>();
			if (string.IsNullOrEmpty(email))
			{
				user =await userManager.Users.ToListAsync();
			}
			else
			{
				user = await userManager.Users.Where(user => user.Email.Trim().ToLower().Contains(email.Trim().ToLower())).ToListAsync();
			}


			return View(user);
		}

		public async Task<IActionResult> Details(string id, string viewName ="Details")
		{
			if(string.IsNullOrEmpty(id))
				return NotFound();

			var user = await userManager.FindByIdAsync(id);
			if (user == null)
				return NotFound();



			return View(viewName, user);
		}

		public async Task<IActionResult> Update(string id)
		{
			return await Details(id, "Update");
		}

		[HttpPost]
        public async Task<IActionResult> Update(string id, ApplicationUser appUser)
        {
			if (id != appUser.Id)
				return NotFound();

			if(ModelState.IsValid)
			{
				var user = await userManager.FindByIdAsync(id);
				user.UserName = appUser.UserName;
				user.NormalizedUserName = appUser.UserName.ToUpper();

				var result = await userManager.UpdateAsync(user);
				if (result.Succeeded)
				{
					return RedirectToAction("Index");
				}
				foreach (var error in result.Errors)
					ModelState.AddModelError("", error.Description);
			}
			return View(appUser);
        }

		public async Task<IActionResult> Delete(string id, ApplicationUser appUser)
		{
            if (id != appUser.Id)
                return NotFound();
			
            var user = await userManager.FindByIdAsync(id);
            var result = await userManager.DeleteAsync(user);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
			
			foreach (var error in result.Errors)
					ModelState.AddModelError("", error.Description);

            return RedirectToAction("Index");




        }



    }
}
