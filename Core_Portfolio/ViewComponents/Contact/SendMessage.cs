using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_Portfolio.ViewComponents.Contact
{
    public class SendMessage:ViewComponent
    {

        MessageManager messageManager = new MessageManager(new EfMessageDal());

        [HttpGet]
        public IViewComponentResult Invoke()
        {

            return View();
        }
        //[HttpPost]
        //public IViewComponentResult Invoke(Message m)
        //{
        //    m.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
        //    m.Status = true;
        //    messageManager.TAdd(m);
        //    return View();
        //}
    }
}
