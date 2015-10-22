using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WAFF.WebUI.Models
{
    public class Event
    {
        public int Event_ID { get; set; }
        public DateTime Event_StartDate { get; set; }
        public DateTime Event_EndDate { get; set; }
        public string Event_Location { get; set; }
    }//end class
}//end namespace