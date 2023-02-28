using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_Portfolio.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminMessageController : Controller
    {
        WriterMessageManager writerMessageManager = new WriterMessageManager(new EfWriterMessageDal());
        public IActionResult ReceiverMessageList()
        {
            string mail;
            mail = "akcinarruveyda@gmail.com";
            var values = writerMessageManager.GetListReceiverMessage(mail);
            return View(values);
        }

        public IActionResult SenderMessageList()
        {
            string mail;
            mail = "akcinarruveyda@gmail.com";
            var values = writerMessageManager.GetListSenderMessage(mail);
            return View(values);
        }

        public IActionResult AdminMessageDetails(int id)
        {
            var values = writerMessageManager.TGetByID(id);
            return View(values);
        }

        public IActionResult AdminMessageDelete(int id)
        {
            string mail;
            mail = "akcinarruveyda@gmail.com";
            var values = writerMessageManager.TGetByID(id);
            if (values.Receiver ==mail)
            {
                writerMessageManager.TDelete(values);
                return RedirectToAction("ReceiverMessageList");

            }
            else
            {
                writerMessageManager.TDelete(values);
                return RedirectToAction("SenderMessageList");
            }
        }
        
        
        [HttpGet]
        public IActionResult AdminMessageSend()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AdminMessageSend(WriterMessage wm)
        {
            wm.Sender = "akcinarruveyda@gmail.com";
            wm.SenderName = "Ruveyda Hilal AKÇINAR";
            wm.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            Context c = new Context();
            var usernamesurname = c.Users.Where(x => x.Email == wm.Receiver).Select(y => y.Name + " " + y.Surname).FirstOrDefault();
            wm.ReceiverName = usernamesurname;
            writerMessageManager.TAdd(wm);
            return RedirectToAction("SenderMessageList");
        }
    }
}
