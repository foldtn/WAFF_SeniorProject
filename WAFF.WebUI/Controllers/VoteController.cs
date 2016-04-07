﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Web;
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
                EventId = x.EventId
            }).Where(y => y.BlockId == i).ToList()));

            return View(listOfLists);
        }

        [HttpPost]
        public int SubmitVote(Vote vote)
        {
            return _service.SaveVote(vote);
        }

        public JsonResult GetAllBlockForEvent(DateTime currentDate)
        {
            var results = _service.GetAllBlocksForEventsAsync(currentDate);

            //return Json(results);

            //results is currently flat list of films with filmId, blockID, and eventId
            //let's get an array of block objects that have films inside

            var blockIdArray = results.Select(x => x.BlockId).Distinct().ToList();

            var listOfLists = new List<List<FilmVoteViewModel>>() { };

            listOfLists.AddRange(blockIdArray.Select(i => results.Select(x => new FilmVoteViewModel
            {
                BlockId = x.BlockId,
                FilmLength = x.FilmLength,
                FilmName = x.FilmName,
            }).Where(y => y.BlockId == i).ToList()));

            //foreach (var i in blockIdArray)
            //{
            //    var filmsInblock = results.Select(x => new FilmVoteViewModel
            //    {
            //        BlockId = x.BlockId,
            //        FilmLength = x.FilmLength,
            //        FilmName = x.FilmName,

            //    }).Where(y => y.BlockId == i)
            //    .ToList();

            //    listOfLists.Add(filmsInblock);
            //}
            return Json(listOfLists);
        }
    }
}

        