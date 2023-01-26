using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_Portfolio.ViewComponents.Dashboard
{
    public class MessageList:ViewComponent
    {
        UserMessageManager userMessageManager = new UserMessageManager(new EfTodoListDal());
        public IViewComponentResult Invoke()
        {
            var values = userMessageManager.GetUserMessagesWithUserService();
            return View(values);
        }
    }
}
