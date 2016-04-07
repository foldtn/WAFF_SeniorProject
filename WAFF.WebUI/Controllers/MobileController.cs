using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using WAFF.Services.Mobile;


namespace WAFF.WebUI.Controllers
{
    
    public class MobileController : Controller
    {

        private MobileService _mobileService = new MobileService();

        public JsonResult GetAllFilmsByEvent()
        {
            //front door

            var result = _mobileService.GetFilmsByBlockByEvent();
            //var result = Call Service passing along eventId



            var json = new JsonResult() { Data = result, JsonRequestBehavior = JsonRequestBehavior.AllowGet};

            return json;
        }

        public JsonResult DummyAPI()
        {
            var json = new JsonResult() { Data = "You have reached the API", JsonRequestBehavior = JsonRequestBehavior.AllowGet };

            return json;
        }

    }//end class

}//end namespace