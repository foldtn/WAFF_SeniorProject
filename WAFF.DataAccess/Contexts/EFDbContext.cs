using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.SqlClient;
using WAFF.DataAccess.Entity;
using WAFF.DataAccess.Extensions;
using WAFF.DataAccess.ViewModels.Admin;

namespace WAFF.DataAccess.Contexts
{
    public class EFDbContext : DbContext
    {
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Block> Blocks { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Film> Films { get; set; }
        public DbSet<FilmArtist> FilmArtists { get; set; }
        public DbSet<FilmBlock> FilmBlocks { get; set; }
        public DbSet<Vote> Votes { get; set; }
        public DbSet<Voter> Voters { get; set; }
        public DbSet<User> Users { get; set; }

        //admin stored procs
        public async Task<IEnumerable<BlocksCurrentFilmViewModel>> GetBlocksCurrentFilmsByBlockAndEvent(int blockId, int eventId)
        {
            var pBlockId = new SqlParameter("@blockId", blockId);
            var pEventId = new SqlParameter("@eventId", eventId);

            var currentFilmsInBlock =
                await this.ExecuteStoredProcedureAsync<BlocksCurrentFilmViewModel>(
                    "dbo.GetBlocksCurrentFilmsByBlockAndEvent",
                    pBlockId,
                    pEventId);

            var result = currentFilmsInBlock.ToList();

            return result;
        }

        public async Task<int> GetBlockRemainingDuration(int blockId)
        {
            var pBlockId = new SqlParameter("@blockId", blockId);

            var rawResult =
                await this.ExecuteStoredProcedureAsync<int>(
                    "dbo.GetBlockRemainingDurationByBlockId",
                    pBlockId);

            var result = rawResult.FirstOrDefault();

            return result;
        }
    }
}