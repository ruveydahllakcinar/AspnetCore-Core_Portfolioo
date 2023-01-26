using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_Portfolio.Controllers
{
    public class FeatureController : Controller
    {
        FeatureManager featureManager = new FeatureManager(new EfFeatureDal());
        [HttpGet]
        public IActionResult Index()
        {

            ViewBag.v1 = "Update Highlights";
            ViewBag.v2 = "Highlights";
            ViewBag.v3 = "Update Highlights";
            ViewBag.v4 = "/Feature/Index";
            var values = featureManager.TGetByID(1);
            return View(values);
        }


        [HttpPost]
        public IActionResult Index(Feature feature)
        {
            featureManager.TUpdate(feature);
            return RedirectToAction("Index","Dashboard");

        }
    }
}
