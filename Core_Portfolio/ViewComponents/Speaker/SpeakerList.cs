using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_Portfolio.ViewComponents.Speaker
{
    public class SpeakerList:ViewComponent
    {
        SpeakerManager speakerManager = new SpeakerManager(new EfSpeakerDal());

        public IViewComponentResult Invoke()
        {
            var values = speakerManager.TGetList().OrderByDescending(x => x.Date).ToList();
            return View(values);
        }
    }
}
