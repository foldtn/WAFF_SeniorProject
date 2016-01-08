using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace WAFF.DataAccess.Entity
{
    public class Film
    {
        public int FilmID { get; set; }
        [DisplayName("Film Name")]        
        public string FilmName { get; set; }
        [DisplayName("Genre")]
        public string FilmGenre { get; set; }
        [DisplayName("Description")]
        public string FilmDesc { get; set; }
        [DisplayName("Length (minutes)")]
        public int FilmLength { get; set; }
    }
}