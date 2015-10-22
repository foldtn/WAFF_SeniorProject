using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WAFF.WebUI.Models
{
    public class Film
    {
        public int Film_Id { get; set; }
        public string Film_Name { get; set; }
        public string Film_Genre { get; set; }
        public string Film_Desc { get; set; }
        public int Film_Votes { get; set; }
        public TimeSpan Film_Length { get; set; }
        public string Block_Id { get; set; }
    }
}