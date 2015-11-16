using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WAFF.Services.Reports;
using WAFF.WebUI.Models;


namespace WAFF.WebUI.Controllers
{
    public class ReportsController : Controller
    {
        private ReportService service = new ReportService();
        
        public ActionResult Reports()
        {
            FilmsListViewModel model = new FilmsListViewModel
            {
                Films = service.test()
            };
            
            return View(model);
        }
    }
}