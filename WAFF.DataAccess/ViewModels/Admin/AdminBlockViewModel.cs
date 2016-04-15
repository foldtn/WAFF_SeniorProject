using System;

namespace WAFF.DataAccess.ViewModels.Admin
{
    public class AdminBlockViewModel
    {
        public int BlockId { get; set; }

        public int EventId { get; set; }

        public DateTime BlockStart { get; set; }

        public DateTime BlockEnd { get; set; }

        public string BlockStartString{get{ return BlockStart.DayOfWeek + " - " + BlockStart.ToShortTimeString();}}

        public string BlockEndString{get{ return BlockEnd.DayOfWeek + " - " + BlockEnd.ToShortTimeString();}}

        public int Duration { get { var duration = BlockEnd - BlockStart;
        return (int) duration.TotalMinutes; }}

        public string BlockLocation { get; set; }

        public string BlockType { get; set; }

        public string BlockDescription { get; set; }
    }
}