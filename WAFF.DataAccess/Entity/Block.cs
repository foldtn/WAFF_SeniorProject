using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace WAFF.DataAccess.Entity
{
    public class Block
    {
        public int BlockID { get; set; }
        [DisplayName("Block Start Time")]
        public DateTime BlockStart { get; set; }
        [DisplayName("End Time")]
        public DateTime BlockEnd { get; set; }
        [DisplayName("Location")]
        public string BlockLocation { get; set; }
        [DisplayName("Type")]
        public string BlockType { get; set; }
        public int EventID { get; set; }

    }
}