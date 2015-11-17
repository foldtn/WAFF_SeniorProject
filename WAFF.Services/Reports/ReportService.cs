using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WAFF.DataAccess.Contexts;
using WAFF.DataAccess.Entity;

namespace WAFF.Services.Reports
{
    public class ReportService
    {
        private EFDbContext db = new EFDbContext();

        public IEnumerable<Film> test()
        {
            IEnumerable<Film> Films = db.Films;

            return Films;
        }

        public IEnumerable<position> calcWinners()
        {
            

            return null;
        }

    }

    public class position
    {
        public int Position { get; set; }
        public Film Film { get; set; }
        public int votePercentage { get; set; }
    }
}
