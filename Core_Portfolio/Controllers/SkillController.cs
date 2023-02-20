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
    [Authorize(Roles = "Admin")]
    public class SkillController : Controller
    {
        
        SkillManager skillManager = new SkillManager(new EfSkillDal());
        public IActionResult Index()
        {    
            var values = skillManager.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddSkill()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddSkill(Skill skill)
        {
            SkillValidator validations = new SkillValidator();
            ValidationResult results = validations.Validate(skill);

            if (results.IsValid)
            {
                skillManager.TAdd(skill);
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

        public IActionResult DeleteSkill(int id)
        {
            var values = skillManager.TGetByID(id);
            skillManager.TDelete(values);
            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult EditSkill(int id)
        {
            var values = skillManager.TGetByID(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult EditSkill(Skill skill)
        {
            SkillValidator validations = new SkillValidator();
            ValidationResult results = validations.Validate(skill);

            if (results.IsValid)
            {
                skillManager.TUpdate(skill);
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
