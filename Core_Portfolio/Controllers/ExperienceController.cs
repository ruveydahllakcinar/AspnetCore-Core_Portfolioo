using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_Portfolio.Controllers
{
    [Authorize(Roles ="Admin")]
    public class ExperienceController : Controller
    {
        ExperienceManager experienceManager = new ExperienceManager(new EfExperienceDal());
        public IActionResult Index()
        {
           
            var values = experienceManager.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddExperience()
        {
         
          
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
