using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WAFF.DataAccess.Contexts;
using WAFF.DataAccess.Entity;

namespace WAFF.Services.Votes
{
    public class VoteService
    {
        private EFDbContext _db = new EFDbContext();


        public void SaveVote(Vote vote)
        {
            _db.Votes.Add(vote);
             _db.SaveChanges();
        }

        public IEnumerable<EventBlocksFilmsViewModel> GetAllBlocksForEventsAsync(DateTime currentDate)
        {
            var pCurrentDate = new SqlParameter("@currentDate", currentDate);

            var results = _db.Database.SqlQuery<EventBlocksFilmsViewModel>("GetEventBlocksFilmsViewModel", pCurrentDate);

            return results.ToList();
        }
    }

    public class EventBlocksFilmsViewModel
    {
        public int FilmId { get; set; }

        public int BlockId {get; set;}

        public int EventId { get; set; }

        public string FilmName { get; set; }

        public string FilmDescription { get; set; }

        public string FilmGenre { get; set; }

        public int FilmLength { get; set; } 
        
        public string BlockType { get; set; }

        public DateTime BlockStart { get; set; }

        public DateTime BlockEnd { get; set; }

        public string BlockLocation { get; set; }

    }
    
}
