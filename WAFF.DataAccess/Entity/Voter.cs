using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WAFF.DataAccess.Entity
{
    public class Voter
    {
        public int VoterID { get; set; } 

        public int VoterAge { get; set; }

        public string VoterEthnicity { get; set; }

        public string VoterEducation { get; set; }

        public decimal VoterIncome { get; set; }

    }
}