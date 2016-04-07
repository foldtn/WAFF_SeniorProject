﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WAFF.DataAccess.Contexts;
using System.Web.Mvc;
using WAFF.Services.Votes;
using System.Data.SqlClient;

namespace WAFF.Services.Mobile
{
    public class MobileService
    {

        private readonly EFDbContext _dbContext = new EFDbContext();

        public IEnumerable<EventBlocksFilmsViewModel> GetFilmsByBlockByEvent()
        {

            var currentTime = new DateTime();
            currentTime = DateTime.Now;

            SqlParameter mCurrentDate = new SqlParameter("@currentDate", currentTime);

            var results = _dbContext.Database.SqlQuery<EventBlocksFilmsViewModel>("GetFilmsByBlockByEvent", mCurrentDate);

            

            //return list of objects
            return results.ToList();
        }

    }//end class

    //public class MobileEventBlocksFilmViewModel//FilmsByBlocksByEvent
    //{
        
    //    public int FilmId { get; set; }

    //    public int BlockId {get; set;}

    //    public int EventId { get; set; }

    //    public string FilmName { get; set; }

    //    public string FilmDescription { get; set; }

    //    public string FilmGenre { get; set; }

    //    public int FilmLength { get; set; } 
        
    //    public string BlockType { get; set; }

    //    public DateTime BlockStart { get; set; }

    //    public DateTime BlockEnd { get; set; }

    //    public string BlockLocation { get; set; }
        
    //}

}//end namespace