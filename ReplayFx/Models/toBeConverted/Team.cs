using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace ReplayFx.Models.Data
{
    interface Team
    {
        public int id { get; set; }
        public string[] playerIds { get; set; }
        public string leaderId { get; set; }
        public int teamSize { get; set; }
        public int score { get; set; }
        public bool isOrange { get; set; }
        public double totalPosessionTime { get; set; }
        public int turnovers { get; set; }
        public int turnoversOnMyHalf { get; set; }
        public int turnoversOnTheirHalf { get; set; }
        public int wonTurnovers { get; set; }
        public int totalHits { get; set; }
        public int totalPasses { get; set; }
        public int totalSaves { get; set; }
        public int totalShots { get; set; }
        public int totalDribbleContinuations { get; set; }
        public int totalAerials { get; set; }
        public int totalClears { get; set; }
        public double timeOnGround { get; set; }
        public double timeLowInAir { get; set; }
        public double timeHighInAir { get; set; }
        public double timeInDefendingHalf { get; set; }
        public double timeInAttackingHalf { get; set; }
        public double timeInDefendingThird { get; set; }
        public double timeInNeutralThird { get; set; }
        public double timeInAttackingThird { get; set; }
        public double timeBehindBall { get; set; }
        public double timeInFrontBall { get; set; }
        public double timeNearWall { get; set; }
        public double timeInCorner { get; set; }
        public double timeOnWall { get; set; }
        public double averageDistanceFromCenter { get; set; }
        public double averageMaxDistanceFromCenter { get; set; }
        public double timeClumped { get; set; }
        public double timeBoondocks { get; set; }
    }
}
