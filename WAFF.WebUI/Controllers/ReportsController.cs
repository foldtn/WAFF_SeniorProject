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
        
        public ActionResult VotingData()
        {
            
            return View();
        }

        public ActionResult LeaderBoards()
        {
            // Create a ReportsService object to get information for Leaderboards
            var service = new ReportService();

            // Get Votes for each film
            var filmVotes = service.FilmVotes();

            // Get Votes for each block
            /*var blockVotes = service.BlockVotes();

            var final = new List<Winners>();
            var temp = new List<Winners>(filmVotes.Count());
            int count = 0;

            foreach(var f in filmVotes)
            {
                temp[count].FilmName = f.FilmName;
                temp[count].FilmGenre = f.FilmGenre;
                temp[count].BlockID = f.BlockID;
                temp[count].VotePercent = (f.Votes / blockVotes[count].Votes) * 100;
                count++;
            }

            for (int x = 0; x < filmVotes.Count(); x++)
            {
                temp[x].FilmName = filmVotes[x].FilmName;
                temp[x].FilmGenre = filmVotes[x].FilmGenre;
                temp[x].BlockID = filmVotes[x].BlockID;
                temp[x].VotePercent = (filmVotes[x].Votes / blockVotes[x].Votes) * 100;
            }*/


           // ViewBag.Count = filmVotes.Count();

            return View(filmVotes);
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