using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WAFF.DataAccess.Entity
{
    public class Vote
    {
        public int VoterID { get; set; }
        public int FilmID { get; set; }
        public int BlockID { get; set; }
        public string VoteComment { get; set; }
   
    }
}
