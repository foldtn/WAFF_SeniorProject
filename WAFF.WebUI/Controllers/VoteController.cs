using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WAFF.DataAccess.Entity;
using WAFF.Services.Votes;

namespace WAFF.WebUI.Controllers
{
    public class VoteController : Controller
    {
        private VoteService _service = new VoteService();
        // GET: Vote
        [HttpGet]
        public ActionResult Vote(int id)
        {
            var blockId = 1;

            var model = new Vote
            {
                VoterID = id,
                BlockID = blockId,
            };
            return View(model);
        }
        [HttpPost]
        public ActionResult Vote(Vote vote )
        {
            _service.SaveVote(vote);
            return View();
        }
    }
}