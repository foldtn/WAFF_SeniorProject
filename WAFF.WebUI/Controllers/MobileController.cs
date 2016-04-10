using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using WAFF.Services.Mobile;
using WAFF.Services.Reports;


namespace WAFF.WebUI.Controllers
{
    
    public class MobileController : Controller
    {

        private MobileService _mobileService = new MobileService();
        private ReportService _reportService = new ReportService();

        /// <summary>
        /// Gets All Films By Event.
        /// </summary>
        /// <returns>A Json Result</returns>
        public JsonResult GetAllFilmsByEvent()
        {
            //front door

            JsonResult json;
            
            var result = _mobileService.GetFilmsByBlockByEvent();

            json = new JsonResult() { Data = result, JsonRequestBehavior = JsonRequestBehavior.AllowGet};

            return json;
        }//end GetAllFilmsByEvent()

        public JsonResult GetLeaderBoard()
        {

            JsonResult result;

            //get event id
            int eventId = _mobileService.GetEventId();

            var leaderboardList = _reportService.LeaderBoards(eventId);

            result = new JsonResult() { Data = leaderboardList, JsonRequestBehavior = JsonRequestBehavior.AllowGet};

            return result;
            
        }//end GetLeaderBoard()

        public JsonResult DummyAPI()
        {
            var json = new JsonResult() { Data = "You have reached the API", JsonRequestBehavior = JsonRequestBehavior.AllowGet };

            return json;
        }

    }//end class

}//end namespace