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
    public class SettingsController : Controller
    {
        private readonly UserManager<WriterUser> _userManager;

        public SettingsController(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }
        [AllowAnonymous]
        [Area("WriterArea")]
        [Route("WriterArea/Settings/ChangePassword")]
        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }
       
        [HttpPost]
        public async Task<IActionResult> ChangePassword(UserEditViewModel model)
        {
            WriterUser w = new WriterUser()
            {
                Name = model.Name,
                Surname=model.Surname,
                
            };

            if (model.ConfirmPassword == model.NewPassword)
            {
                var result = await _userManager.CreateAsync(w, model.ConfirmPassword);
                
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Login");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View(model);
        }

    }
}
