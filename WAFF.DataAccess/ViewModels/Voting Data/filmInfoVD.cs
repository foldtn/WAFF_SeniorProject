using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WAFF.DataAccess.ViewModels.Voting_Data
{
    public class filmInfoVD
    {
        public String FilmName { get; set; }
        public String FilmGenre { get; set; }
        public String FilmDesc { get; set; }
        public int FilmLength { get; set; }
        public String ArtistFName { get; set; }
        public String ArtistLname { get; set; }
        public String ArtistCompany { get; set; }
        public String ArtistEmail { get; set; }
        public String ArtistPhone { get; set; }
        public String ArtistAddress { get; set; }
        public String ArtistCity { get; set; }
        public String ArtistState { get; set; }
        public int ArtistZip { get; set; }

    }
}
