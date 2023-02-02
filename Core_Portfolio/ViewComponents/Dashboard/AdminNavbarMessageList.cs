using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_Portfolio.ViewComponents.Dashboard
{
    public class AdminNavbarMessageList:ViewComponent
    {
        WriterMessageManager writerMessageManager = new WriterMessageManager(new EfWriterMessageDal());
        public IViewComponentResult Invoke()
        {
            Context context = new Context();
            string mail = "akcinarruveyda@gmail.com";
            ViewBag.v1 = writerMessageManager.GetListReceiverMessage(mail).OrderByDescending(x => x.WriterMessageId).Count();
            var values = writerMessageManager.GetListReceiverMessage(mail).OrderByDescending(x => x.WriterMessageId).Take(3).ToList();
            return View(values);
        }

    }
}
