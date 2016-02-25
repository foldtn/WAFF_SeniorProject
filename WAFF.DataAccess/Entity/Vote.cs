using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WAFF.DataAccess.Entity
{
    public class Vote
    {
        [Key, Column(Order = 0)]
        public int VoterID { get; set; }
        [Key, Column(Order = 1)]
        public int FilmID { get; set; }
        [Key, Column(Order = 2)]
        public int BlockID { get; set; }
        public string VoteComment { get; set; }
   
    }
}
