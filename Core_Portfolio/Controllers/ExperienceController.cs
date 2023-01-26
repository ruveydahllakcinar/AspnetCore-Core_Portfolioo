using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_Portfolio.Controllers
{
    public class ExperienceController : Controller
    {
        ExperienceManager experienceManager = new ExperienceManager(new EfExperienceDal());
        public IActionResult Index()
        {
           
            ViewBag.v1 = "Experience List";
            ViewBag.v2 = "Experience";
            ViewBag.v3 = "Experience List";
            ViewBag.v4 = "/Experience/Index";
            var values = experienceManager.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddExperience()
        {
            ViewBag.v1 = "Add Experience";
            ViewBag.v2 = "Experience";
            ViewBag.v3 = "Add Experience";
            ViewBag.v4 = "/Experience/Index";
          
            return View();
        }
        [HttpPost]
        public IActionResult AddExperience(Experience experience)
        {
            ExperienceValidator validations = new ExperienceValidator();
            ValidationResult results = validations.Validate(experience);
            
            if (results.IsValid)
            {
                experienceManager.TAdd(experience);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var exp in results.Errors)
                {
                    ModelState.AddModelError(exp.PropertyName, exp.ErrorMessage);
                }
            }
            return View();
        }

        [HttpGet]
        public IActionResult DeleteExperience(int id)
        {
            var values = experienceManager.TGetByID(id);
            experienceManager.TDelete(values);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditExperience(int id)
        {
            ViewBag.v1 = "Update Experience";
            ViewBag.v2 = "Experience";
            ViewBag.v3 = "Update Experience";
            ViewBag.v4 = "/Experience/Index";

            var values = experienceManager.TGetByID(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult EditExperience(Experience experience)
        {

            ExperienceValidator validations = new ExperienceValidator();
            ValidationResult results = validations.Validate(experience);

            if (results.IsValid)
            {
                experienceManager.TUpdate(experience);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var exp in results.Errors)
                {
                    ModelState.AddModelError(exp.PropertyName, exp.ErrorMessage);
                }
            }
            return View();

        }

    }
}
