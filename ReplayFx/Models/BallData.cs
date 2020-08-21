using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace ReplayFx.Models
{
    public class BallData
    {
        [Key]
        public MetaData matchGuid { get; set; }
        public string timeOnGround { get; set; }
        public string timeLowInAir { get; set; }
        public string timeHighInAir { get; set; }
        public string timeInDefendingHalf { get; set; }
        public string timeInAttackingHalf { get; set; }
        public string timeInNeutralThird { get; set; }
        public string timeInAttackingThird { get; set; }
        public string timeInDefendingThird { get; set; }
        public string timeNearWall { get; set; }
        public string timeInCorner { get; set; }
        public string timeOnWall { get; set; }
        public string averageSpeed { get; set; }
        public string neutralPosessionTime { get; set; }
    }
}
