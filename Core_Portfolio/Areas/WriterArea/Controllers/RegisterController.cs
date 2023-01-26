using Core_Portfolio.Areas.WriterArea.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_Portfolio.Areas.WriterArea.Controllers
{
    [Area("WriterArea")]
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
        public async Task<IActionResult> Index(UserRegisterViewModel userRegisterViewModel)
        {
            if (ModelState.IsValid)
            {
                WriterUser writerUser = new WriterUser()
                {
                    Name = userRegisterViewModel.Name,
                    Surname = userRegisterViewModel.Surname,
                    Email = userRegisterViewModel.Mail,
                    UserName = userRegisterViewModel.UserName,
                    ImageUrl = userRegisterViewModel.ImageUrl
                };
                if (userRegisterViewModel.Password == userRegisterViewModel.ConfirmPassword)
                {
                    var result = await _userManager.CreateAsync(writerUser, userRegisterViewModel.Password);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Login");
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                    }

                }
            }

            return View();
        }
    }
}
