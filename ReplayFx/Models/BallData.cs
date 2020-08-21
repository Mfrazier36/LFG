using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace ReplayFx.Models
{
    public class BallData : DbEntry
    {
        [Key]
        public Guid MatchGuid { get; set; }
        public string TimeOnGround { get; set; }
        public string TimeLowInAir { get; set; }
        public string TimeHighInAir { get; set; }
        public string TimeInDefendingHalf { get; set; }
        public string TimeInAttackingHalf { get; set; }
        public string TimeInNeutralThird { get; set; }
        public string TimeInAttackingThird { get; set; }
        public string TimeInDefendingThird { get; set; }
        public string TimeNearWall { get; set; }
        public string TimeInCorner { get; set; }
        public string TimeOnWall { get; set; }
        public string AvgSpeed { get; set; }
        public string NeutralPosessionTime { get; set; } // GAME STATS

        public MatchData MatchData { get; set; }
    }
}
