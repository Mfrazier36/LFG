using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace ReplayFx.Models
{

    public class MetaData
    {
        [Key]
        public int Id { get; set; }
        public int GameDataID { get; set; }
        public Guid matchGuid { get; set; }
        public string replayId { get; set; }
        public string replayName { get; set; }
        public string replayVersion { get; set; }
        public string mapName { get; set; }
        public string totalGameTime { get; set; }
        public string totalFrames { get; set; }
        public string teamAlphaScore { get; set; } // Team 0 & ( isOrange: false )
        public string teamBravoScore { get; set; }
        public string primaryPlayerId { get; set; }
        public string fileLength { get; set; }
        public string gameServerId { get; set; }
        public string gameServerName { get; set; }
        public string teamSize { get; set; }
        public string gameMode { get; set; }


        public GameData GameData { get; set; }
    }
}
