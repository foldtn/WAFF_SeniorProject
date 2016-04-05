using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WAFF.DataAccess.ViewModels.Leader_Boards
{
    public class VotesLB
    {
        public int FilmID { get; set; }
        public int BlockID { get; set; }
        public int Votes { get; set; }
        public int VotesPerBlock { get; set; }
    }
}
