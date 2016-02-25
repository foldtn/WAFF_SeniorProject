using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace WAFF.DataAccess.Entity
{
    
    public class Event
    {
        [HiddenInput(DisplayValue = false)]
        public int EventID { get; set; }
        [DisplayName("Event Start Date")]
        public DateTime EventStartDate { get; set; }
        [DisplayName("End Date")]
        public DateTime EventEndDate { get; set; }
        [DisplayName("Event Location")]
        public string EventLocation { get; set; }
    }//end Event class

}//end namespace