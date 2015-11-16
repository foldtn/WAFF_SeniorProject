using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WAFF.DataAccess.Entity;

namespace WAFF.WebUI.Models
{
    public class FilmsListViewModel
    {
        public IEnumerable<Film> Films { get; set; }
    }
}