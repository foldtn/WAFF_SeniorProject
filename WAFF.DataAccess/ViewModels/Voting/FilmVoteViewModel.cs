using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WAFF.DataAccess.ViewModels.Voting
{
    public class FilmVoteViewModel
    {
        public int FilmId { get; set; }
        public int BlockId { get; set; }
        public int EventId { get; set; }
        public string FilmName { get; set; }
        public string FilmDescription { get; set; }
        public string FilmGenre { get; set; }
        public int FilmLength { get; set; }
        public string BlockType { get; set; }
        public DateTime BlockStart { get; set; }
        public DateTime BlockEnd { get; set; }
        public string BlockLocation { get; set; }

        public string BlockDay
        {
            get { return BlockStart.DayOfWeek + " " + BlockStart.ToShortDateString(); }
        }
        public string BlockStartString
        {
            get { return BlockStart.ToShortTimeString();}
        }
        public string BlockEndString
        {
            get { return BlockEnd.ToShortTimeString();}
        }


    }
}
