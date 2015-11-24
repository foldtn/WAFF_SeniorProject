using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace WAFF.DataAccess.Entity
{
    public class Artist
    {
        
        public int ArtistID { get; set; }
        [DisplayName("Artist's First Name")]
        public string ArtistFName { get; set; }
        [DisplayName("Last Name")]
        public string ArtistLName { get; set; }
        [DisplayName("Company")]
        public string ArtistCompany { get; set; }
        [DisplayName("Email")]
        public string ArtistEmail { get; set; }
        [DisplayName("Address")]
        public string ArtistAddress { get; set; }
        [DisplayName("City")]
        public string ArtistCity { get; set; }
        [DisplayName("State")]
        public string ArtistState { get; set; }
        [DisplayName("Zip Code")]
        public int ArtistZip { get; set; }
        [DisplayName("Phone")]
        public string ArtistPhone { get; set; }
    }
}