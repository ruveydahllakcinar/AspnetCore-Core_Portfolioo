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

    public class ProfileController : Controller
    {
        private readonly UserManager<WriterUser> _userManager;

        public ProfileController(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditViewModel model = new UserEditViewModel();
            model.Name = values.Name;
            model.Surname = values.Surname;
            model.PictureURL = values.ImageUrl;
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserEditViewModel userEditViewModel)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (userEditViewModel.Picture != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(userEditViewModel.Picture.FileName);
                var imagename = Guid.NewGuid() + extension;
                var savelocation = resource + "/wwwroot/UserImage/" + imagename;
                var stream = new FileStream(savelocation, FileMode.Create);
                await userEditViewModel.Picture.CopyToAsync(stream);
                user.ImageUrl = imagename;

            }
           
            user.Name = userEditViewModel.Name;
            user.Surname = userEditViewModel.Surname;
            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Profile");
            }
            return View();
        }

        //[HttpGet]
        //public async Task<IActionResult> ChangePassword()
        //{
        //    var values = await _userManager.FindByNameAsync(User.Identity.Name);
        //    UserEditViewModel model = new UserEditViewModel();
        //    model.Password = values.PasswordHash;
        //    model.PasswordConfirm = values.PasswordHash;
        //    return View(model);
        //}


        //[HttpPost]
        //public async Task<IActionResult> ChangePassword(UserEditViewModel userEditViewModel)
        //{
        //    //var values = await _userManager.FindByNameAsync(User.Identity.Name);
        //    //UserEditViewModel model = new UserEditViewModel();
        //    //model.Password = values.PasswordHash;
        //    //model.Surname = values.Surname;
        //    //model.PictureURL = values.ImageUrl;
        //    return View();
        //}
    }
}
