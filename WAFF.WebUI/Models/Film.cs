using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WAFF.WebUI.Models
{
    public class Film
    {
        public int FilmId { get; set; }
        public string FilmName { get; set; }
        public string FilmGenre { get; set; }
        public string FilmDesc { get; set; }
        public int FilmVotes { get; set; }
        public TimeSpan FilmLength { get; set; }
        public int BlockId { get; set; }
    }
}