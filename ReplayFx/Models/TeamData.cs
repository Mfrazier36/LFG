using System;
using System.ComponentModel.DataAnnotations;

//public class Parties
//{
//    public string leaderId { get; set; }
//    public string[] memberIds { get; set; }

namespace ReplayFx.Models
{
    public class TeamData
    {
        [Key]
        public int Id { get; set; }
        public Guid matchGuid { get; set; }
        public string leaderId { get; set; }
        public string memberId1 { get; set; }
        public string memberId2 { get; set; }
        public string memberId3 { get; set; }
        public string memberId4 { get; set; }
        public string memberId5 { get; set; }
        public string memberId6 { get; set; }
        public string memberId7 { get; set; }
        public string memberId8 { get; set; }
        public string score { get; set; }
        public string isOrange { get; set; }
        public string totalPosessionTime { get; set; }
        public string turnovers { get; set; }
        public string turnoversOnMyHalf { get; set; }
        public string turnoversOnTheirHalf { get; set; }
        public string wonTurnovers { get; set; }
        public string totalHits { get; set; }
        public string totalPasses { get; set; }
        public string totalSaves { get; set; }
        public string totalShots { get; set; }
        public string totalDribbleContinuations { get; set; }
        public string totalAerials { get; set; }
        public string totalClears { get; set; }
        public string timeOnGround { get; set; }
        public string timeLowInAir { get; set; }
        public string timeHighInAir { get; set; }
        public string timeInDefendingHalf { get; set; }
        public string timeInAttackingHalf { get; set; }
        public string timeInDefendingThird { get; set; }
        public string timeInNeutralThird { get; set; }
        public string timeInAttackingThird { get; set; }
        public string timeBehindBall { get; set; }
        public string timeInFrontBall { get; set; }
        public string timeNearWall { get; set; }
        public string timeInCorner { get; set; }
        public string timeOnWall { get; set; }
        public string averageDistanceFromCenter { get; set; }
        public string averageMaxDistanceFromCenter { get; set; }
        public string timeClumped { get; set; }
        public string timeBoondocks { get; set; }
    }
}