using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WAFF.Services.Reports;

namespace WAFF.WebUI.Controllers
{
    public class ReportsController : Controller
    {
        
        public ActionResult Reports()
        {
            return View();
        }
    }
}