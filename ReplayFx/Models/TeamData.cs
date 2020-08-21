using System;
using System.ComponentModel.DataAnnotations;

//public class Parties
//{
//    public string leaderId { get; set; }
//    public string[] memberIds { get; set; }

namespace ReplayFx.Models
{
    public class TeamData : DbEntry
    {
        [Key]
        public int TeamId { get; set; }
        public Guid MatchGuid { get; set; }
        public string LeaderId { get; set; }
        public string MemberId1 { get; set; }
        public string MemberId2 { get; set; }
        public string MemberId3 { get; set; }
        public string MemberId4 { get; set; }
        public string MemberId5 { get; set; }
        public string MemberId6 { get; set; }
        public string MemberId7 { get; set; }
        public string MemberId8 { get; set; }
        public string Score { get; set; }
        public string IsOrange { get; set; }
        public string TotPosessionTime { get; set; }
        public string Turnovers { get; set; }
        public string TurnoversOnMyHalf { get; set; }
        public string TurnoversOnTheirHalf { get; set; }
        public string WonTurnovers { get; set; }
        public string TotHits { get; set; }
        public string TotPasses { get; set; }
        public string TotSaves { get; set; }
        public string TotShots { get; set; }
        public string TotDribbleContinuations { get; set; }
        public string TotAerials { get; set; }
        public string TotClears { get; set; }
        public string TimeOnGround { get; set; }
        public string TimeLowInAir { get; set; }
        public string TimeHighInAir { get; set; }
        public string TimeInDefendingHalf { get; set; }
        public string TimeInAttackingHalf { get; set; }
        public string TimeInDefendingThird { get; set; }
        public string TimeInNeutralThird { get; set; }
        public string TimeInAttackingThird { get; set; }
        public string TimeBehindBall { get; set; }
        public string TimeInFrontBall { get; set; }
        public string TimeNearWall { get; set; }
        public string TimeInCorner { get; set; }
        public string TimeOnWall { get; set; }
        public string AvgDistanceFromCenter { get; set; }
        public string AvgMaxDistanceFromCenter { get; set; }
        public string TimeClumped { get; set; }
        public string TimeBoondocks { get; set; }
    }
}