using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WAFF.DataAccess.Contexts;
using System.Web.Mvc;
using WAFF.Services.Votes;
using System.Data.SqlClient;

namespace WAFF.Services.Mobile
{
    public class MobileService
    {

        private readonly EFDbContext _dbContext = new EFDbContext();

        public IEnumerable<EventBlocksFilmsViewModel> GetFilmsByBlockByEvent()
        {
            //get current date
            var currentTime = new DateTime();
            currentTime = DateTime.Now;

            //set as sql parameter
            //SqlParameter mCurrentDate = new SqlParameter("@currentDate", currentTime);

            //get query result as EventBlocksFilmsViewModel instance
            var results = _dbContext.Database.SqlQuery<EventBlocksFilmsViewModel>("GetFilmsByBlockByEvent");//, mCurrentDate);

            //return list of objects
            return results.ToList();

        }//end GetFilmsByBlockByEvent()

        public int GetEventId()
        {

            int eventId;

            //get current time
            var now = DateTime.Now;

            //find event
            var resultEvent = _dbContext.Events.FirstOrDefault(x => x.EventStartDate <= now);

            eventId = resultEvent.EventID;

            return eventId;

        }//end GetEventId()

        public JsonResult GetFilmsJson()
        {
            var json = new JsonResult() { Data = "You have reached the API.", JsonRequestBehavior = JsonRequestBehavior.AllowGet };

            return json;
        }

    }//end class

    public class EventBlocksFilmsViewModel//FilmsByBlocksByEvent
    {

        public int FilmId { get; set; }

        public DateTime EventStartDate { get; set; }
        public string EventStartDateString 
        {
            get
            { 
                return EventStartDate.ToShortDateString(); 
            }//end get
        }//end EventStartDateString

        public DateTime EventEndDate { get; set; }
        public string EventEndDateString
        {
            get
            {
                return EventEndDate.ToShortDateString();
            }//end get
        }//end EventEndDateString

        public int BlockId { get; set; }

        public int EventId { get; set; }

        public string FilmName { get; set; }

        public string FilmDescription { get; set; }

        public string FilmGenre { get; set; }

        public int FilmLength { get; set; }

        public string BlockType { get; set; }

        public DateTime BlockStart { get; set; }
        public string BlockStartString
        {
            get
            {
                return BlockStart.ToShortDateString();
            }//end get
        }//end BlockStartString

        public DateTime BlockEnd { get; set; }
        public string BlockEndString
        {
            get
            {
                return BlockEnd.ToShortDateString();
            }//end get
        }//end BlockEndString

        public string BlockLocation { get; set; }

    }

}//end namespace
