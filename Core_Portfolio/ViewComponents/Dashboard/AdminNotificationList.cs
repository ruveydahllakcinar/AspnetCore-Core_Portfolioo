﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_Portfolio.ViewComponents.Dashboard
{
    public class AdminNotificationList:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
