using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WAFF.WebUI.Models
{
    public class LeaderBoardEntry
    {
        public string FilmName { get; set; }
        public string FilmGenre { get; set; }
        public int BlockID { get; set; }
        public int Votes { get; set; }
    }
}