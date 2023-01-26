using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_Portfolio.ViewComponents.Certficate
{
    public class CertficateList:ViewComponent
    {
        CertficateManager certficateManager = new CertficateManager(new EfCertficateDal());
        public IViewComponentResult Invoke()
        {
            var values = certficateManager.TGetList();
            return View(values);
        }
    }
}
