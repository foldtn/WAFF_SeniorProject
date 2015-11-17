﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WAFF.DataAccess.Entity
{
    public class Film
    {
        public int FilmID { get; set; }
        public string FilmName { get; set; }
        public string FilmGenre { get; set; }
        public string FilmDesc { get; set; }
        public int FilmLength { get; set; }
        public int BlockID { get; set; }
    }
}