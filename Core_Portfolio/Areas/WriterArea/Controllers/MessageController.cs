using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_Portfolio.Areas.WriterArea.Controllers
{
    [Area("WriterArea")]
    [Route("WriterArea/[controller]/[action]")]
    public class MessageController : Controller
    {
        private readonly UserManager<WriterUser> _userManager;
        WriterMessageManager writerMessageManager = new WriterMessageManager(new EfWriterMessageDal());

        public MessageController(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult>ReceiverMessage(string p) //Alıcı mesaj
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            p = values.Email;
            var messageList = writerMessageManager.GetListReceiverMessage(p);

            return View(messageList);
        }

        public async Task<IActionResult> SenderMessage(string p) //Gönderici mesaj
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            p = values.Email;
            var messageList = writerMessageManager.GetListSenderMessage(p);

            return View(messageList);
        }

        public IActionResult MessageDetails(int id)
        {
            WriterMessage writerMessage = writerMessageManager.TGetByID(id);
            return View(writerMessage);
        }
      
        public IActionResult ReceiverMessageDetails(int id)
        {
            WriterMessage writerMessage = writerMessageManager.TGetByID(id);
            return View(writerMessage);
        }
        [HttpGet]
        public IActionResult SendMessage()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SendMessage(WriterMessage writerMessage)
        {
            var values = _userManager.FindByNameAsync(User.Identity.Name).Result;
            string mail = values.Email;
            string name = values.Name + " " + values.Surname;
            writerMessage.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            writerMessage.Sender = mail;
            writerMessage.SenderName = name;
            Context context = new Context();
            var usernamesurname = context.Users.Where(x => x.Email == writerMessage.Receiver).Select(y => y.Name + " " + y.Surname).FirstOrDefault();
            writerMessage.ReceiverName = usernamesurname;
            writerMessageManager.TAdd(writerMessage);
            return RedirectToAction("SenderMessage");
        }
    }
}
