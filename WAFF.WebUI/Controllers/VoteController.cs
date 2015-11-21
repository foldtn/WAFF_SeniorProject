using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WAFF.DataAccess.Entity;

namespace WAFF.WebUI.Controllers
{
    public class VoteController : Controller
    {
 
        // GET: Vote
        [HttpGet]
        public ActionResult Vote(int VoterID)
        {
            return View();
        }
        [HttpPost]
        public ActionResult Vote(Vote vote )
        {
            return View();
        }
    }
}