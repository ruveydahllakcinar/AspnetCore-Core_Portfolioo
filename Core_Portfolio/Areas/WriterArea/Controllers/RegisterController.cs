using Core_Portfolio.Areas.WriterArea.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Core_Portfolio.Areas.WriterArea.Controllers
{
    [Area("WriterArea")]
    [Route("WriterArea/[controller]/[action]")]

    public class RegisterController : Controller
    {
        private readonly UserManager<WriterUser> _userManager;

        public RegisterController(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new UserRegisterViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserRegisterViewModel userRegisterView)
        {
            WriterUser w = new WriterUser()
            {
                Name = userRegisterView.Name,
                Surname = userRegisterView.Surname,
                Email = userRegisterView.Mail,
                UserName = userRegisterView.UserName,
            };

            if (userRegisterView.Password == userRegisterView.ConfirmPassword)
            {
                var result = await _userManager.CreateAsync(w, userRegisterView.Password);

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
            return View(userRegisterView);
        }
    }
}
