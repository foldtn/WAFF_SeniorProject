using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WAFF.WebUI.Models
{
    public class Artist
    {
        public int Artist_Id { get; set; }
        public string Artist_FName { get; set; }
        public string Artist_LName { get; set; }
        public string Artist_Company { get; set; }
        public string Artist_Email { get; set; }
        public string Artist_Address { get; set; }
        public string Artist_City { get; set; }
        public string Artist_State { get; set; }
        public string Artist_Zip { get; set; }
        public string Artist_Phone { get; set; }
    }
}