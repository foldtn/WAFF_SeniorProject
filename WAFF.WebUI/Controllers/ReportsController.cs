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
            var events = _service.GetEvents();

            return View(events);
        }

        public PartialViewResult EventSelect()
        {
            var events = _service.GetEvents();

            return PartialView(events);
        }

        public PartialViewResult EventLB()
        {
            var events = _service.GetEvents();

            return PartialView(events);
        }

        public PartialViewResult Blocks(int eventID)
        {
            var blocks = _service.GetBlocks(eventID);

            return PartialView(blocks);
        }

        public PartialViewResult Genres(int eventID)
        {
            var genre = _service.GetGenres(eventID);

            return PartialView(genre);
        }

        public PartialViewResult FilmsB(int id)
        {
            string genre = null;
            int eventID = 0;
            var films = _service.GetFilms(id, genre, eventID);

            return PartialView(films);
        }

        public PartialViewResult FilmsG(string genre, int eventID)
        {
            int id = -1;
            var films = _service.GetFilms(id, genre, eventID);

            return PartialView(films);
        }

        public PartialViewResult GraphB(int id, int eventID)
        {
            string genre = null;
            var films = _service.GetGraph(id, genre, eventID);

            return PartialView(films);
        }

        public PartialViewResult GraphG(string genre, int eventID)
        {
            int id = -1;
            var films = _service.GetGraph(id, genre, eventID);

            return PartialView(films);
        }

        public PartialViewResult FilmInfo(int filmID)
        {
            var filmInfo = _service.GetFilmInfo(filmID);

            return PartialView(filmInfo);
        }


        public ActionResult LeaderBoards()
        {

            return View();
        }

        public PartialViewResult Update(int EventID)
        {
            var LeaderBoardInfo = _service.LeaderBoards(EventID);

            return PartialView(LeaderBoardInfo);
        }

        public ActionResult Demographics()
        {
            var events = _service.GetEvents();

            return View(events);
        }

        public PartialViewResult getIncome(int eventID)
        {
            var income = _service.GetIncomeChart(eventID);

            return PartialView(income);
        }

        public PartialViewResult getAge(int eventID)
        {
            var age = _service.GetAgeChart(eventID);

            return PartialView(age);
        }

        public PartialViewResult getEducation(int eventID)
        {
            var education = _service.GetEducationChart(eventID);

            return PartialView(education);
        }

        public PartialViewResult getEthnicity(int eventID)
        {
            var ethnicity = _service.GetEthnicityChart(eventID);

            return PartialView(ethnicity);
        }
    }
}