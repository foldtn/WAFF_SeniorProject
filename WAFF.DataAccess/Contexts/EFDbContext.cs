using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using WAFF.DataAccess.Entity;

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
    }
}