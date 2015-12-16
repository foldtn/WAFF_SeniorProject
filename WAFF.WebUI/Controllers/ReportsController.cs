using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public PartialViewResult Blocks()
        {
            var blocks = _service.GetBlocks();

            return PartialView(blocks);
        }

        public PartialViewResult Genres()
        {
            var genre = _service.GetGenres();

            return PartialView();
        }

        public async Task<PartialViewResult> FilmsBAsync(int id)
        {
            var films = await _service.GetFilmsBAsync(id);

            return PartialView(films);
        }

        public PartialViewResult FilmsGasync(string genre)
        {
            var films = _service.GetFilmsGAsync(genre);

            return PartialView(films);
        }

        public PartialViewResult FilmInfo(int filmID)
        {
            return PartialView();
        }


        public ActionResult LeaderBoards()
        {
            // Get Leader Board information from database.
            var LeaderBoardInfo = _service.LeaderBoards();

            return View(LeaderBoardInfo);
        }

        public PartialViewResult Update()
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