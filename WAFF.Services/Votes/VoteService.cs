using System;
using System.Collections.Generic;
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
    }

    
}
