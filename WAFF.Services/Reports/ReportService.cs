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
        private EFDbContext _db = new EFDbContext();

        public List<LeaderBoardEntry> LeaderBoards()
        {
            var list =  _db.Database.SqlQuery<LeaderBoardEntry>("GetLeaderBoards").ToList();

            return list;
        }

        public List<blockVD> getBlocks()
        {
            var list = _db.Database.SqlQuery<blockVD>("getBlocks").ToList();

            return list;
        }

    }
}
