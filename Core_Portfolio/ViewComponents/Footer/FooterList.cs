using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_Portfolio.ViewComponents.Footer
{
    public class FooterList:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
