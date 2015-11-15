using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WAFF.DataAccess.Entity
{
    
    public class Event
    {
        public int EventID { get; set; }
        public DateTime EventStartDate { get; set; }
        public DateTime EventEndDate { get; set; }
        public string EventLocation { get; set; }
    }//end Event class

}//end namespace