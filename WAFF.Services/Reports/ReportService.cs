using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WAFF.DataAccess.Contexts;
using WAFF.DataAccess.ViewModels;

namespace WAFF.Services.Reports
{
    public class ReportService
    {
        private EFDbContext db = new EFDbContext();

        public IEnumerable<LeaderBoardEntry> CalculateWinners()
        {
            var list =  db.Database.SqlQuery<LeaderBoardEntry>("GetLeaderBoardEntries").ToList();

            return list;
        }

    }
}
