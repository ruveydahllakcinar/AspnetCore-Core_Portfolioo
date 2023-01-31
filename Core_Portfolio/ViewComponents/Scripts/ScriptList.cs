using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_Portfolio.ViewComponents.Scripts
{
    public class ScriptList:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
