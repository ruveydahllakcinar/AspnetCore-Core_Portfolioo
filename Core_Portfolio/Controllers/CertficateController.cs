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
    public class CertficateController : Controller
    {
        CertficateManager certficateManager = new CertficateManager(new EfCertficateDal());
        public IActionResult Index()
        {
            ViewBag.v1 = "Certificate List";
            ViewBag.v2 = "Certificate";
            ViewBag.v3 = "Certificate List";
            ViewBag.v4 = "/Certficate/Index";
            var values = certficateManager.TGetList().OrderByDescending(x => x.CompanyName).ToList(); ;
            return View(values);
        }

        [HttpGet]
        public IActionResult AddCertficate()
        {

            ViewBag.v1 = "Add Certificate";
            ViewBag.v2 = "Certificate";
            ViewBag.v3 = "Add Certificate";
            ViewBag.v4 = "/Certficate/Index";

            return View();
            
        }

        [HttpPost]
        public IActionResult AddCertficate(Certficate certficate)
        {
            CertficateValidator validations = new CertficateValidator();
            ValidationResult results = validations.Validate(certficate);

            if (results.IsValid)
            {
                certficateManager.TAdd(certficate);
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
        public IActionResult DeleteCertficate(int id)
        {
            var values = certficateManager.TGetByID(id);
            certficateManager.TDelete(values);
            return RedirectToAction("Index");
            
        }
        [HttpGet]
        public IActionResult EditCertficate(int id)
        {
            ViewBag.v1 = "Update Certificate";
            ViewBag.v2 = "Certificate";
            ViewBag.v3 = "Update Certificate";
            ViewBag.v4 = "/Certficate/Index";

            var values = certficateManager.TGetByID(id);
            return View(values);

        }

        [HttpPost]
        public IActionResult EditCertficate(Certficate certficate)
        {
            CertficateValidator validations = new CertficateValidator();
            ValidationResult results = validations.Validate(certficate);

            if (results.IsValid)
            {
                certficateManager.TUpdate(certficate);
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
