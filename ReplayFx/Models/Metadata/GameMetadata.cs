using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ReplayFx.Models
{
    public class GameMetadata : Entry
    {
        public int PrimaryPlayerId { get; set; }
        [Required] public int TeamBravoId { get; set; }
        [Required] public int TeamAlphaId { get; set; }
        public string ServerId { get; set; }
        public string SaveId { get; set; }

        public int TeamAlphaScore { get; set; } // Team0Score && isOrange: false
        public int TeamBravoScore { get; set; } // Team1Score && isOrange: true
        public string TeamSize { get; set; }

        public string ServerName { get; set; }
        public string SaveName { get; set; }
        public string SaveVersion { get; set; }
        public string MapName { get; set; }
        public string GameMode { get; set; }

        public string TotGameTime { get; set; }
        public string TotFrames { get; set; }
        public string FileLength { get; set; }

        public Ball BallStats { get; set; }
        public Team TeamAlpha { get; set; }
        public Team TeamBravo { get; set; }
    }
}
