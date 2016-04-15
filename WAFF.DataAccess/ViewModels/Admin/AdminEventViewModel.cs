using System;
using System.Collections.Generic;
using System.Data.Entity;
using WAFF.DataAccess.Entity;

namespace WAFF.DataAccess.ViewModels.Admin
{
    public class AdminEventViewModel
    {
        public int EventId { get; set; }

        public DateTime EventStart { get; set; }

        public DateTime EventEnd { get; set; }

        public string EventStartString{get{ return EventStart.ToShortDateString() + " - " + EventStart.DayOfWeek;}}

        public string EventEndString { get { return EventEnd.ToShortDateString() + " - " + EventEnd.DayOfWeek; } }

        public IEnumerable<AdminBlockViewModel> AdminBlockViewModels { get; set; }

        public IEnumerable<Film> Films { get; set; }

        public static AdminEventViewModel Create(Event waffEvent,
            IEnumerable<AdminBlockViewModel> blocks,
            IEnumerable<Film> films)
        {
            var adminViewModel = new AdminEventViewModel();

            if (waffEvent != null)
            {
                adminViewModel.EventId      = waffEvent.EventID;
                adminViewModel.EventStart   = waffEvent.EventStartDate;
                adminViewModel.EventEnd     = waffEvent.EventEndDate;
            }

            adminViewModel.AdminBlockViewModels = blocks;
            adminViewModel.Films = films;

            return adminViewModel;
        } 
    }
}