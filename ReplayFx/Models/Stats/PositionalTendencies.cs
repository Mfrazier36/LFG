using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace ReplayFx.Models
{
    public class PositionalTendencies : Entry
    {
        public string TimeInCorner { get; set; }
        public string TimeOnWall { get; set; }
        public string TimeNearWall { get; set; }
        public string TimeInFrontBall { get; set; }
        public string TimeBehindBall { get; set; }
        public string TimeAttackingThird { get; set; }
        public string TimeNeutralThird { get; set; }
        public string TimeDefendingThird { get; set; }
        public string TimeAttackingHalf { get; set; }
        public string TimeDefendingHalf { get; set; }
        public string TimeHighInAir { get; set; }
        public string TimeLowInAir { get; set; }
        public string TimeOnGround { get; set; }
        [AllowNull] public string AvgDistFromCenter { get; set; }
        [AllowNull] public string AvgMaxDistFromCenter { get; set; }
        [AllowNull] public string TimeClumped { get; set; }
        [AllowNull] public string TimeBoondocks { get; set; }
    }
}
