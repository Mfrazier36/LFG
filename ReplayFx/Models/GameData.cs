using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace ReplayFx.Models
{
    public class GameData : DbContext
    {
        [Key]
        public string id;
        public DbSet<MetaData> metaData;
        public DbSet<FrameData> frameData;
        public DbSet<PlayerData> playerData;
        public DbSet<TeamData> teamData;
    }
}
