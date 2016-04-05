using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WAFF.DataAccess.ViewModels.Leader_Boards
{
    public class LeaderBoardData
    {
        public int FilmID { get; set; }
        public string FilmName { get; set; }
        public string FilmGenre { get; set; }
        public int BlockID { get; set; }
        public string BlockStart { get; set; }
        public string BlockEnd { get; set; }
        public string BlockDayOfWeek { get; set; }
    }
}
