using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WAFF.DataAccess.Entity
{
    public class FilmBlock
    {
        [Key, Column(Order = 0)]
        public int FilmID { get; set; }
        [Key, Column(Order = 1)]
        public int BlockID { get; set; }
    }
}
