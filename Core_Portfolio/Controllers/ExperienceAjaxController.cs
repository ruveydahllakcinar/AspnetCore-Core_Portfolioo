using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Core_Portfolio.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ExperienceAjaxController : Controller
    {
       
        ExperienceManager experienceManager = new ExperienceManager(new EfExperienceDal());

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult ListExperience()
        {
            var values = JsonConvert.SerializeObject(experienceManager.TGetList());
            return Json(values);
        }

        [HttpPost]
        public IActionResult AddExperience(Experience experience)
        {
            experienceManager.TAdd(experience);
            var values = JsonConvert.SerializeObject(experience);
            return Json(values);
        }

        public IActionResult GetById(int ExperienceId)
        {
            var experience = experienceManager.TGetByID(ExperienceId);
            var values = JsonConvert.SerializeObject(experience);
            return Json(values);
        }

        public IActionResult DeleteExperience(int id)
        {
            var values = experienceManager.TGetByID(id);
            experienceManager.TDelete(values);
            return NoContent();
        }
        [HttpPost]
        public IActionResult UpdateExperince(int ExperienceId, string CompanyName, string Title, string Description, string Date)
        {
            var values = experienceManager.TGetByID(ExperienceId);
            if (values != null)
            {
                values.CompanyName = CompanyName;
                values.Title = Title;
                values.Description = Description;
                values.Date = Date;
                experienceManager.TUpdate(values);
                var v = JsonConvert.SerializeObject(values);

                return Json(values);
            }
            else
            {
                return Json(new object());
            }
        }
    }
}
