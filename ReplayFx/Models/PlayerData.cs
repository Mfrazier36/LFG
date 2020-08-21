//public class PlayerStats
//{
//    public BoostStats boostStats { get; set; }
//    public Distance distanceStats { get; set; }
//    public Posession posessionStats { get; set; }
//    public Position positionStats { get; set; }
//    public RelativePosition relativePositionStats { get; set; }
//    public Avgs averagesStats { get; set; }
//    public HitCount hitCountStats { get; set; }
//    public Speed speedStats { get; set; }
//    public PerPosession perPosessionStats { get; set; }
//    public BallCarry ballCarryStats { get; set; }
//    public Kickoff kickoffStats { get; set; }

using System;

namespace ReplayFx.Models
{
    public class PlayerData : DbEntry
    {
        public int Id { get; set; }
        public int TeamID { get; set; }
        public Guid MatchGuid { get; set; }
        public string PlayerId { get; set; }
        public string Name { get; set; }
        public string TitleId { get; set; }
        public string Score { get; set; }
        public string Goals { get; set; }
        public string Assists { get; set; }
        public string Shots { get; set; }
        public string Saves { get; set; }
        public string IsOrange { get; set; }
        public string TimeInGame { get; set; }
        public string CarId { get; set; }
        public string BoostUsage { get; set; }
        public string NumSmallBoost { get; set; }
        public string NumLargeBoost { get; set; }
        public string TotWastedBoost { get; set; }
        public string TimeFullBoost { get; set; }
        public string TimeLowBoost { get; set; }
        public string TimeNoBoost { get; set; }
        public string NumStolenBoost { get; set; }
        public string AvgBoostLevel { get; set; }
        public string TotWastedBigBoost { get; set; }
        public string TotWastedSmallBoost { get; set; }
        public string DistanceBallHitForward { get; set; }
        public string DistanceBallHitBackward { get; set; }
        public string TimeClosestToBall { get; set; }
        public string TimeFurthestFromBall { get; set; }
        public string TimeCloseToBall { get; set; }
        public string TotPossessionTime { get; set; }
        public string Turnovers { get; set; }
        public string TurnoversOnMyHalf { get; set; }
        public string TurnoversOnTheirHalf { get; set; }
        public string WonTurnovers { get; set; }
        public string TimeOnGround { get; set; }
        public string TimeLowInAir { get; set; }
        public string TimeHighInAir { get; set; }
        public string TimeInDefendingHalf { get; set; }
        public string TimeInAttackingHalf { get; set; }
        public string TimeInDefendingThird { get; set; }
        public string TimeInAttackingThird { get; set; }
        public string TimeInNeutralThird { get; set; }
        public string TimeBehindBall { get; set; }
        public string TimeInFrontBall { get; set; }
        public string TimeNearWall { get; set; }
        public string TimeInCorner { get; set; }
        public string TimeOnWall { get; set; }
        public string TimeInFrontOfCenterOfMass { get; set; }
        public string TimeBehindCenterOfMass { get; set; }
        public string TimeMostForwardPlayer { get; set; }
        public string TimeMostBackPlayer { get; set; }
        public string TimeBetweenPlayers { get; set; }
        public string AvgSpeed { get; set; }
        public string AvgHitDistance { get; set; }
        public string AvgDistanceFromCenter { get; set; }
        public string TotHits { get; set; }
        public string TotPasses { get; set; }
        public string TotSaves { get; set; }
        public string TotDribbles { get; set; }
        public string TotDribbleContinuations { get; set; }
        public string TotAerials { get; set; }
        public string TotClears { get; set; }
        public string TimeAtSlowSpeed { get; set; }
        public string TimeAtSuperSonic { get; set; }
        public string TimeAtBoostSpeed { get; set; }
        public string PpAvgDuration { get; set; }
        public string PpAvgHits { get; set; }
        public string PpTotCount { get; set; }
        public string PpAvgPass { get; set; }
        public string PpAvgPassed { get; set; }
        public string PpAvgDribble { get; set; }
        public string PpAvgDribbleContinuation { get; set; }
        public string PpAvgShot { get; set; }
        public string PpAvgGoal { get; set; }
        public string PpAvgAssist { get; set; }
        public string PpAvgAssisted { get; set; }
        public string PpAvgSave { get; set; }
        public string PpAvgAerial { get; set; }
        public string TotCarries { get; set; }
        public string LongestCarry { get; set; }
        public string FurthestCarry { get; set; }
        public string TotCarryTime { get; set; }
        public string AvgCarryTime { get; set; }
        public string FastestCarrySpeed { get; set; }
        public string TotCarryDistance { get; set; }
        public string AvgCarrySpeed { get; set; }
        public string DistanceAlongPath { get; set; }
        public string TotKickoffs { get; set; }
        public string NumTimeCheat { get; set; }
        public string NumTimeGoToBall { get; set; }
        public string NumTimeFirstTouch { get; set; }
        public string AvgBoostUsed { get; set; }


        public MatchData MatchData { get; set; }
        public TeamData TeamData { get; set; }
    }
}