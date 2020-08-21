using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace ReplayFx.Models
{
    public class GameData : DbContext
    {
        [Key]
        public int EntryId { get; set; }
        public DbSet<MatchData> MatchData { get; set; }
        public DbSet<BallData> BallData { get; set; }
        public DbSet<FrameData[]> frameData { get; set; }
        public DbSet<PlayerData[]> PlayerData { get; set; }
        public DbSet<TeamData[]> TeamData { get; set; }
    }
}
