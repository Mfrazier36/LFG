using Microsoft.EntityFrameworkCore;

namespace ReplayFx.Models
{
    public class _DbContext : DbContext
    {
        public DbSet<Frame> Frames { get; set; }
         public DbSet<MetaDataMode> Metadata { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Rosters { get; set; }
        public DbSet<Team> Teams { get; set; }
    }
}
