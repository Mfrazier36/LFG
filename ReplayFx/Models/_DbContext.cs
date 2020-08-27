using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ReplayFx.Models
{
    public class _DbContext : DbContext
    {
        public DbSet<List<Frame>> Frames { get; set; }
        public DbSet<GameMetadata> GameMetadata { get; set; }
        public DbSet<List<Player>> Players { get; set; }
        public DbSet<List<Team>> Teams { get; set; }
    }
}
