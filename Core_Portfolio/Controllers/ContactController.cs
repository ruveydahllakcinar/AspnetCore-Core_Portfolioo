﻿using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_Portfolio.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ContactController : Controller
    {
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        public IActionResult Index()
        {
            var values = messageManager.TGetList();
            return View(values);
        }

        public IActionResult DeleteMessage(int id)
        {
            var values = messageManager.TGetByID(id);
            messageManager.TDelete(values);
            return RedirectToAction("Index");
        }

        public IActionResult ContactDetails(int id)
        {
            var values = messageManager.TGetByID(id);
            return View(values);
        }
    }
}
