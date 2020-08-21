using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace ReplayFx.Models
{

    public class MatchData : DbEntry
    {
        [Key]
        public int Id { get; set; }
        public int GameDataID { get; set; }
        public Guid MatchGuid { get; set; }
        public string ReplayId { get; set; }
        public string ReplayName { get; set; }
        public string ReplayVersion { get; set; }
        public string MapName { get; set; }
        public string TotGameTime { get; set; }
        public string TotFrames { get; set; }
        public string TeamAlphaScore { get; set; } // Team 0 & ( isOrange: false )
        public string TeamBravoScore { get; set; }
        public string PrimaryPlayerId { get; set; }
        public string FileLength { get; set; }
        public string GameServerId { get; set; }
        public string GameServerName { get; set; }
        public string TeamSize { get; set; }
        public string GameMode { get; set; }


        public GameData GameData { get; set; }
    }
}
