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
        // Create a ReportsService object to get information for Leaderboards
        ReportService _service = new ReportService();
        
        public ActionResult VotingData()
        {
            
            return View();
        }

        public ActionResult LeaderBoards()
        {
            // Get Leader Board information from database.
            var LeaderBoardInfo = _service.LeaderBoards();

            return View(LeaderBoardInfo);
        }

        public PartialViewResult update()
        {
            var LeaderBoardInfo = _service.LeaderBoards();

            return PartialView(LeaderBoardInfo);
        }

        public ActionResult Demographics()
        {
            return View();
        }

        public PartialViewResult Menu()
        {
            return PartialView();
        }
    }
}