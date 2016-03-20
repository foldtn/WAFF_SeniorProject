using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using WAFF.DataAccess.Contexts;
using WAFF.DataAccess.Entity;
using WAFF.DataAccess.ViewModels.Voting;

namespace WAFF.Services.Votes
{
    public class VoteService
    {
        private EFDbContext _db = new EFDbContext();


        public int SaveVote(Vote vote)
        {
            _db.Votes.Add(vote);
            try
            {
                _db.SaveChanges();
            }
            catch (Exception e) 
            { 
                //Console.WriteLine(e);
                return 0;
            }
            return vote.BlockID; 
        }

        public IEnumerable<FilmVoteViewModel> GetAllBlocksForEventsAsync(DateTime currentDate)
        {
            //var pCurrentDate = new SqlParameter("@currentDate", currentDate);

            //leaving the stored procedure name the same for now
            //but returns filmvoteviewmodels instead of EventBlocksFilms.
            //var results = _db.Database.SqlQuery<FilmVoteViewModel>("GetEventBlocksFilmsDetail @currentDate",
            //pCurrentDate);

            //return results.ToList();

            var tempResults = from f in _db.Films
                              join fb in _db.FilmBlocks
                                  on f.FilmID equals fb.FilmID
                              join b in _db.Blocks
                                  on fb.BlockID equals b.BlockID
                              join e in _db.Events
                                  on b.EventID equals e.EventID
                              select new FilmVoteViewModel()
                              {
                                  FilmId = f.FilmID,
                                  BlockId = b.BlockID,
                                  EventId = e.EventID,
                                  FilmName = f.FilmName,
                                  FilmDescription = f.FilmDesc,
                                  FilmGenre = f.FilmGenre,
                                  FilmLength = f.FilmLength,
                                  BlockType = b.BlockType,
                                  BlockStart = b.BlockStart,
                                  BlockEnd = b.BlockEnd,
                                  BlockLocation = b.BlockLocation
                              };
            var tempList = tempResults.ToList();

            return tempList;
        }
    }
}