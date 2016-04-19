using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Web;
using System.Net;
using System.Web.Mvc;
using WAFF.DataAccess.Entity;
using WAFF.DataAccess.ViewModels.Voting;
using WAFF.Services.Votes;

namespace WAFF.WebUI.Controllers
{
    public class VoteController : Controller
    {
        private readonly VoteService _service = new VoteService();
        // GET: Vote
        [HttpGet]
        public ActionResult Vote(int id)
        {
            var isLegitVoter = _service.CheckIfVoterExistsById(id);

            if (!isLegitVoter)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var currentDate = DateTime.Now;
           
            var results = _service.GetAllBlocksForEventsAsync(currentDate);
            var blockIdArray = results.Select(x => x.BlockId).Distinct().ToList();

            var listOfLists = new List<List<FilmVoteViewModel>>() { };

            listOfLists.AddRange(blockIdArray.Select(i => results.Select(x => new FilmVoteViewModel
            {
                BlockId = x.BlockId,
                FilmLength = x.FilmLength,
                FilmName = x.FilmName,
                FilmId = x.FilmId,
                EventId = x.EventId,
                BlockStart = x.BlockStart,
                BlockEnd = x.BlockEnd
            }).Where(y => y.BlockId == i).ToList()));

            return View(listOfLists);
        }

        [HttpPost]
        public int SubmitVote(Vote vote)
        {
            return _service.SaveVote(vote);
        }

       
    }
}

        