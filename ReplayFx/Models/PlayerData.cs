//public class PlayerStats
//{
//    public BoostStats boostStats { get; set; }
//    public Distance distanceStats { get; set; }
//    public Posession posessionStats { get; set; }
//    public Position positionStats { get; set; }
//    public RelativePosition relativePositionStats { get; set; }
//    public Averages averagesStats { get; set; }
//    public HitCount hitCountStats { get; set; }
//    public Speed speedStats { get; set; }
//    public PerPosession perPosessionStats { get; set; }
//    public BallCarry ballCarryStats { get; set; }
//    public Kickoff kickoffStats { get; set; }

using System;

namespace ReplayFx.Models
{
    public class PlayerData
    {
        public int Id { get; set; }
        public int TeamID { get; set; }
        public Guid MatchGuid { get; set; }
        public string playerId { get; set; }
        public string name { get; set; }
        public string titleId { get; set; }
        public string score { get; set; }
        public string goals { get; set; }
        public string assists { get; set; }
        public string shots { get; set; }
        public string saves { get; set; }
        public string isOrange { get; set; }
        public string timeInGame { get; set; }
        public string carId { get; set; }
        public string boostUsage { get; set; }
        public string numSmallBoost { get; set; }
        public string numLargeBoost { get; set; }
        public string totalWastedBoost { get; set; }
        public string timeFullBoost { get; set; }
        public string timeLowBoost { get; set; }
        public string timeNoBoost { get; set; }
        public string numStolenBoost { get; set; }
        public string averageBoostLevel { get; set; }
        public string totalWastedBigBoost { get; set; }
        public string totalWastedSmallBoost { get; set; }
        public string distanceBallHitForward { get; set; }
        public string distanceBallHitBackward { get; set; }
        public string timeClosestToBall { get; set; }
        public string timeFurthestFromBall { get; set; }
        public string timeCloseToBall { get; set; }
        public string totalPossessionTime { get; set; }
        public string turnovers { get; set; }
        public string turnoversOnMyHalf { get; set; }
        public string turnoversOnTheirHalf { get; set; }
        public string wonTurnovers { get; set; }
        public string timeOnGround { get; set; }
        public string timeLowInAir { get; set; }
        public string timeHighInAir { get; set; }
        public string timeInDefendingHalf { get; set; }
        public string timeInAttackingHalf { get; set; }
        public string timeInDefendingThird { get; set; }
        public string timeInAttackingThird { get; set; }
        public string timeInNeutralThird { get; set; }
        public string timeBehindBall { get; set; }
        public string timeInFrontBall { get; set; }
        public string timeNearWall { get; set; }
        public string timeInCorner { get; set; }
        public string timeOnWall { get; set; }
        public string timeInFrontOfCenterOfMass { get; set; }
        public string timeBehindCenterOfMass { get; set; }
        public string timeMostForwardPlayer { get; set; }
        public string timeMostBackPlayer { get; set; }
        public string timeBetweenPlayers { get; set; }
        public string averageSpeed { get; set; }
        public string averageHitDistance { get; set; }
        public string averageDistanceFromCenter { get; set; }
        public string totalHits { get; set; }
        public string totalPasses { get; set; }
        public string totalSaves { get; set; }
        public string totalDribbles { get; set; }
        public string totalDribbleContinuations { get; set; }
        public string totalAerials { get; set; }
        public string totalClears { get; set; }
        public string timeAtSlowSpeed { get; set; }
        public string timeAtSuperSonic { get; set; }
        public string timeAtBoostSpeed { get; set; }
        public string ppAverageDuration { get; set; }
        public string ppAverageHits { get; set; }
        public string ppTotalCount { get; set; }
        public string ppAveragePass { get; set; }
        public string ppAveragePassed { get; set; }
        public string ppAverageDribble { get; set; }
        public string ppAverageDribbleContinuation { get; set; }
        public string ppAverageShot { get; set; }
        public string ppAverageGoal { get; set; }
        public string ppAverageAssist { get; set; }
        public string ppAverageAssisted { get; set; }
        public string ppAverageSave { get; set; }
        public string ppAverageAerial { get; set; }
        public string totalCarries { get; set; }
        public string longestCarry { get; set; }
        public string furthestCarry { get; set; }
        public string totalCarryTime { get; set; }
        public string averageCarryTime { get; set; }
        public string fastestCarrySpeed { get; set; }
        public string totalCarryDistance { get; set; }
        public string averageCarrySpeed { get; set; }
        public string distanceAlongPath { get; set; }
        public string totalKickoffs { get; set; }
        public string numTimeCheat { get; set; }
        public string numTimeGoToBall { get; set; }
        public string numTimeFirstTouch { get; set; }
        public string averageBoostUsed { get; set; }


        public MetaData MetaData { get; set; }
        public TeamData TeamData { get; set; }
    }
}