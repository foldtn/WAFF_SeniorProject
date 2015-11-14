using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WAFF.WebUI.Models
{
    class Vote
    {
        public int VoterID { get; set; }
        public int FilmID { get; set; }
        public int BlockID { get; set; }
        public string VoteComment { get; set; }
   
    }
}
