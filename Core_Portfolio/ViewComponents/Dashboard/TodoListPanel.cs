
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_Portfolio.ViewComponents.Dashboard
{
    public class TodoListPanel : ViewComponent
    {
       TodoListManager todoListManager = new TodoListManager(new EfTodoListDal());
       public IViewComponentResult Invoke()
        {
            var values = todoListManager.TGetList();
            return View(values);
        }
       
    }
}
