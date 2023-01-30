using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_Portfolio.Controllers
{
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
    }
}
