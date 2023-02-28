using Core_Portfolio.Areas.WriterArea.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_Portfolio.Areas.WriterArea.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("WriterArea")]
    [Route("WriterArea/Settings")]
    public class SettingsController : Controller
    {
        private readonly UserManager<WriterUser> _userManager;

        public SettingsController(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }
        
        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(UserChangePasswordViewModel model)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, model.Password);
            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }

    }
}
