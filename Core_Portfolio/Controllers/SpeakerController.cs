using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using Core_Portfolio.Models;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Core_Portfolio.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SpeakerController : Controller
    {
       
        SpeakerManager speakerManager = new SpeakerManager(new EfSpeakerDal());

        public IActionResult Index()
        {
            ViewBag.v1 = "Speaker List";
            ViewBag.v2 = "Speaker";
            ViewBag.v3 = "Speaker List";
            ViewBag.v4 = "/Speaker/Index";
            var values = speakerManager.TGetList().OrderByDescending(x => x.Date).ToList();
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
        public IActionResult AddSpeaker(AddSpeakerImage addSpeaker)
        {
            Speaker speaker = new Speaker();
            if (addSpeaker.SpeakerImage != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(addSpeaker.SpeakerImage.FileName);
                var imagename = Guid.NewGuid() + extension;
                var savelocation = resource + "/wwwroot/SpeakerImage/" + imagename;
                var stream = new FileStream(savelocation, FileMode.Create);
                addSpeaker.SpeakerImage.CopyToAsync(stream);
                speaker.SpeakerImage = imagename; 

            }
            speaker.Title = addSpeaker.Title;
            speaker.Subject = addSpeaker.Subject;
            speaker.Date = addSpeaker.Date;
            speakerManager.TAdd(speaker);
            return RedirectToAction("Index");
           
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
        public IActionResult EditSpeaker(AddSpeakerImage addSpeaker)
        {
            var speaker = speakerManager.TGetByID(addSpeaker.SpeakerId);
            if (addSpeaker.SpeakerImage != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(addSpeaker.SpeakerImage.FileName);
                var imagename = Guid.NewGuid() + extension;
                var savelocation = resource + "/wwwroot/SpeakerImage/" + imagename;
                var stream = new FileStream(savelocation, FileMode.Create);
                addSpeaker.SpeakerImage.CopyToAsync(stream);
                speaker.SpeakerImage = imagename;  
            }
            speaker.Title = addSpeaker.Title;
            speaker.Subject = addSpeaker.Subject;
            speaker.Date = addSpeaker.Date;
            speakerManager.TUpdate(speaker);
            return RedirectToAction("Index");
            
        }
    }

}
