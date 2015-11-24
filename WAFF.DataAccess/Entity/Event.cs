using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace WAFF.DataAccess.Entity
{
    
    public class Event
    {
        public int EventID { get; set; }
        [DisplayName("Event Start Date")]
        public DateTime EventStartDate { get; set; }
        [DisplayName("End Date")]
        public DateTime EventEndDate { get; set; }
        [DisplayName("Event Location")]
        public string EventLocation { get; set; }
    }//end Event class

}//end namespace