using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace ReplayFx.Models.Data
{
    class Ball
    {
        public double timeOnGround { get; set; }
        public double timeLowInAir { get; set; }
        public double timeHighInAir { get; set; }
        public double timeInDefendingHalf { get; set; }
        public double timeInAttackingHalf { get; set; }
        public double timeInNeutralThird { get; set; }
        public double timeInAttackingThird { get; set; }
        public double timeInDefendingThird { get; set; }
        public double timeNearWall { get; set; }
        public double timeInCorner { get; set; }
        public double timeOnWall { get; set; }
        public double averageSpeed { get; set; }
        public double neutralPosessionTime { get; set; }
    }
}
