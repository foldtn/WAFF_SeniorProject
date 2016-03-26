using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WAFF.DataAccess.Contexts;
using System.Web.Mvc;

namespace WAFF.Services.Mobile
{
    class MobileService
    {

        private readonly EFDbContext _dbContext = new EFDbContext();

        public JsonResult GetAllFilmsByEventId(int id)
        {
        
        
        }

    }
}
