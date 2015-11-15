using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WAFF.DataAccess.Entity
{
    public class Artist
    {
        public int ArtistID { get; set; }
        public string ArtistFName { get; set; }
        public string ArtistLName { get; set; }
        public string ArtistCompany { get; set; }
        public string ArtistEmail { get; set; }
        public string ArtistAddress { get; set; }
        public string ArtistCity { get; set; }
        public string ArtistState { get; set; }
        public int ArtistZip { get; set; }
        public string ArtistPhone { get; set; }
    }
}