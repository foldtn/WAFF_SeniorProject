﻿using System;
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

        public ActionResult LeaderBoards()
        {
            var service = new ReportService();

            var list = service.CalculateWinners();

            return View(list);
        }

        public ActionResult Demographics()
        {
            return View();
        }

        public PartialViewResult Menu(int selected)
        {
            ViewBag.Selected = selected;

            return PartialView(selected);
        }
    }
}