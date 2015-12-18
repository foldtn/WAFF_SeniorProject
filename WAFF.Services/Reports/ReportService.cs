using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using WAFF.DataAccess.Contexts;
using WAFF.DataAccess.ViewModels;
using System.Data.SqlClient;
using System.Data.Entity.Infrastructure;

namespace WAFF.Services.Reports
{
    public class ReportService
    {
        private EFDbContext _db = new EFDbContext();

        public List<LeaderBoardEntry> LeaderBoards()
        {
            var list =  _db.Database.SqlQuery<LeaderBoardEntry>("GetLeaderBoards").ToList();

            return list;
        }

        public List<blockVD> GetBlocks()
        {
            var list = _db.Database.SqlQuery<blockVD>("getBlocks").ToList();

            return list;
        }

        public List<genreVD> GetGenres()
        {
            var list = _db.Database.SqlQuery<genreVD>("getGenres").ToList();

            return list;
        }

        public async Task<IEnumerable<filmsVD>> GetFilmsAsync(int block, string genre)
        {
            
            //create connection
            var conn = _db.Database.Connection;

            //create command for connection
            var cmd = conn.CreateCommand();

            //declare command type
            cmd.CommandType = CommandType.StoredProcedure;

            if(block != -1)
            { 
                //stored procedure name goes here
                cmd.CommandText = "getFilmsB";

                //parameters go here
                cmd.Parameters.Add(new SqlParameter("@block", block));
            }
            else
            {
                cmd.CommandText = "getFilmsG";
                cmd.Parameters.Add(new SqlParameter("@genre", genre));
            }

            //black magic stuff
            var objectConext = ((IObjectContextAdapter)_db).ObjectContext;

            var originalState = conn.State;
            
            if (originalState != ConnectionState.Open)
            {
                await conn.OpenAsync();
            }

            try
            {
                //get information in list format
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    return objectConext.Translate<filmsVD>(reader).ToList();
                }
            }
            finally
            {
                if (originalState != ConnectionState.Open)
                {
                    conn.Close();
                }

                if (null != conn)
                {
                    conn.Dispose();
                }
            }
        }
    }
}
