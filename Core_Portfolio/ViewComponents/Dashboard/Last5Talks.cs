using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_Portfolio.ViewComponents.Dashboard
{
    public class Last5Talks : ViewComponent
    {
        Context context = new Context();
        SpeakerManager speakerManager = new SpeakerManager(new EfSpeakerDal());

        public IViewComponentResult Invoke()
        {
            var lastFiveSpeakers = context.Speakers.OrderByDescending(p => p.Date).Take(5).ToList();
            return View(lastFiveSpeakers);
        }
      
    }
}