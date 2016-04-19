using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WAFF.DataAccess.Entity;

namespace WAFF.DataAccess.ViewModels.Voting
{
    public class EventVoteViewModel
    {
        public List<List<FilmVoteViewModel>> BlockViewModels { get; set; }

        public Voter Voter { get; set; }
    }
}
