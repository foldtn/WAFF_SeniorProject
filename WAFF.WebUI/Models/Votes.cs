using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WAFF.WebUI.Models
{
    class Votes
    {
        public int voteID { get; set; }
        public string VoteComment { get; set; }
        public DateTime VoteTimeStamp { get; set; }
        public int VoterID { get; set; }
        public int FilmID { get; set; }

        
    }
}
