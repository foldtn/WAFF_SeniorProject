﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WAFF.WebUI.Models
{
    public class Voter
    {
        public int VoterId { get; set; } 

        public string Age { get; set; }

        public string Ethnicity { get; set; }

        public string Education { get; set; }

        public decimal Income { get; set; }

    }
}