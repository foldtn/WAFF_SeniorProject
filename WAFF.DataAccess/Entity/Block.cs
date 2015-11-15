using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WAFF.DataAccess.Entity
{
    public class Block
    {
        public int BlockID { get; set; }
        public DateTime BlockStart { get; set; }
        public DateTime BlockEnd { get; set; }
        public string BlockLocation { get; set; }
        public string BlockType { get; set; }
        public int EventID { get; set; }

    }
}