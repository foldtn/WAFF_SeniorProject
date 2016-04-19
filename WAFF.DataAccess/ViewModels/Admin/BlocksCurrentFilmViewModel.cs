using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WAFF.DataAccess.ViewModels.Admin
{
    public class BlocksCurrentFilmViewModel
    {
        public int FilmId { get; set; }

        public int EventId { get; set; }

        public int BlockId { get; set; }

        public string FilmName { get; set; }

        public int FilmLength { get; set; }
    }
}
