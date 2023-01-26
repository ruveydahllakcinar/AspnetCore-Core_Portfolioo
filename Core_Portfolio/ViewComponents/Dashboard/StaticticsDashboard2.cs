using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_Portfolio.ViewComponents.Dashboard
{
    public class StaticticsDashboard2:ViewComponent
    {
        Context context = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.v1 = context.Speakers.Count();
            ViewBag.v2 = context.Messages.Count();
            ViewBag.v3 = context.Portfolios.Count();
            return View();
        }
    }
}
