using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WAFF.DataAccess.ViewModels
{
    public class LeaderBoardEntry
    {
        public string FilmName { get; set; }
        public string FilmGenre { get; set; }
        public int BlockID { get; set; }
        public int Votes { get; set; }
    }
}
