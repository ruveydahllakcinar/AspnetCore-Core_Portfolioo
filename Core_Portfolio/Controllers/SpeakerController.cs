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
    public class SpeakerController : Controller
    {
        SpeakerManager speakerManager = new SpeakerManager(new EfSpeakerDal());

        public IActionResult Index()
        {
            ViewBag.v1 = "Speaker List";
            ViewBag.v2 = "Speaker";
            ViewBag.v3 = "Speaker List";
            ViewBag.v4 = "/Speaker/Index";
            var values = speakerManager.TGetList();
            return View(values);
        
        }

        [HttpGet]
        public IActionResult AddSpeaker()
        {
            ViewBag.v1 = "Add Speaker";
            ViewBag.v2 = "Speaker";
            ViewBag.v3 = "Add Speaker";
            ViewBag.v4 = "/Speaker/Index";
            return View();

        }

        [HttpPost]
        public IActionResult AddSpeaker(Speaker speaker)
        {
            {
                SpeakerValidator validations = new SpeakerValidator();
                ValidationResult results = validations.Validate(speaker);

                if (results.IsValid)
                {
                    speakerManager.TAdd(speaker);
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
        [HttpGet]
        public IActionResult DeleteSpeaker(int id)
        {

            var values = speakerManager.TGetByID(id);
            speakerManager.TDelete(values);
            return RedirectToAction("Index");

        }


        [HttpGet]
        public IActionResult EditSpeaker(int id)
        {
            ViewBag.v1 = "Update Speaker";
            ViewBag.v2 = "Speaker";
            ViewBag.v3 = "Update Speaker";
            ViewBag.v4 = "/Speaker/Index";

            var values = speakerManager.TGetByID(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult EditSpeaker(Speaker speaker)
        {
            SpeakerValidator validations = new SpeakerValidator();
            ValidationResult results = validations.Validate(speaker);

            if (results.IsValid)
            {
                speakerManager.TUpdate(speaker);
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
