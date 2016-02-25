using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace WAFF.DataAccess.Entity
{
    public class Film
    {
        [HiddenInput(DisplayValue = false)]
        public int FilmID { get; set; }
        [DisplayName("Film Name")]        
        public string FilmName { get; set; }
        [DisplayName("Genre")]
        public string FilmGenre { get; set; }
        [DisplayName("Description")]
        [DataType(DataType.MultilineText)]
        public string FilmDesc { get; set; }
        [DisplayName("Length (minutes)")]
        public int FilmLength { get; set; }
    }
}