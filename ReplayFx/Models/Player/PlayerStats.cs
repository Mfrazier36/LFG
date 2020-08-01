using Newtonsoft.Json.Linq;
using ReplayFx.Models.Frame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;

namespace ReplayFx.Models.Data
{
    public class PlayerStats : JObject
    {
        public PlayerStats(JObject rawData)
        {

        }
        public class BasicStats
        {
            public string score { get; set; }
            public string goals { get; set; }
            public string assists { get; set; }
            public string shots { get; set; }
            public string saves { get; set; }
            public string isOrange { get; set; }
            public string timeInGame { get; set; }
            public string carId { get; set; }
            public BasicStats(JObject rawData)
            {
                Console.WriteLine("Model: [Player.BasicStats]");
                score = rawData["score"].ToString();
                goals = rawData["goals"].ToString();
                assists = rawData["assists"].ToString();
                shots = rawData["shots"].ToString();
                isOrange = rawData["isOrange"].ToString();
                timeInGame = rawData["timeInGame"].ToString();
                carId = rawData["loadout.carId"].ToString();
            }
        }
        public class Boost
        {
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
            public Boost (JObject rawData)
            {
                Console.WriteLine("Model: [PlayerBoost]");
                boostUsage = rawData["boostUsage"].ToString();
                numSmallBoost = rawData["numSmallBoost"].ToString();
                numLargeBoost = rawData["numLargeBoost"].ToString();
                totalWastedBoost = rawData["wastedCollection"].ToString();
                timeFullBoost = rawData["timeFullBoost"].ToString();
                timeLowBoost = rawData["timeLowBoost"].ToString();
                timeNoBoost = rawData["timeNoBoost"].ToString();
                numStolenBoost = rawData["numStolenBoost"].ToString();
                averageBoostLevel = rawData["averageBoostLevel"].ToString();
                totalWastedBigBoost = rawData["wastedBig"].ToString();
                totalWastedSmallBoost = rawData["wastedSmall"].ToString();
            }
        }

        public class Distance
        {
            public string distanceBallHitForward { get; set; }
            public string distanceBallHitBackward { get; set; }
            public string timeClosestToBall { get; set; }
            public string timeFurthestFromBall { get; set; }
            public string timeCloseToBall { get; set; }
            public Distance (JObject rawData)
            {
                Console.WriteLine("Model: [PlayerDistance]");
                distanceBallHitBackward = rawData["ballHitBackward"].ToString();
                distanceBallHitForward = rawData["ballHitForward"].ToString();
                timeClosestToBall = rawData["timeClosestToBall"].ToString();
                timeFurthestFromBall = rawData["timeFurthestFromBall"].ToString();
                timeCloseToBall = rawData["timeCloseToBall"].ToString();
            }
        }

        public class Posession
        {
            public string totalPossessionTime { get; set; }
            public string turnovers { get; set; }
            public string turnoversOnMyHalf { get; set; }
            public string turnoversOnTheirHalf { get; set; }
            public string wonTurnovers { get; set; }
            public Posession(JObject rawData)
            {
                Console.WriteLine("Model: [PlayerPosession]");
                totalPossessionTime = rawData["possessionTime"].ToString();
                turnovers = rawData["turnovers"].ToString();
                turnoversOnMyHalf = rawData["turnoversOnMyHalf"].ToString();
                turnoversOnTheirHalf = rawData["turnoversOnTheirHalf"].ToString();
                wonTurnovers = rawData["wonTurnovers"].ToString();
            }
        }

        public class Position
        {
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
            public Position (JObject rawData)
            {
                Console.WriteLine("Model: [PlayerPosition]");
                timeOnGround = rawData["timeOnGround"].ToString();
                timeLowInAir = rawData["timeLowInAir"].ToString();
                timeHighInAir = rawData["timeHighInAir"].ToString();
                timeInDefendingHalf = rawData["timeInDefendingHalf"].ToString();
                timeInAttackingHalf = rawData["timeInAttackingHalf"].ToString();
                timeInDefendingThird = rawData["timeInDefendingThird"].ToString();
                timeInAttackingThird = rawData["timeInAttackingThird"].ToString();
                timeInNeutralThird = rawData["timeInNeutralThird"].ToString();
                timeBehindBall = rawData["timeBehindBall"].ToString();
                timeInFrontBall = rawData["timeInFrontBall"].ToString();
                timeNearWall = rawData["timeNearWall"].ToString();
                timeInCorner = rawData["timeInCorner"].ToString();
                timeOnWall = rawData["timeOnWall"].ToString();
            }
        }

        public class RelativePosition
        {
            public string timeInFrontOfCenterOfMass { get; set; }
            public string timeBehindCenterOfMass { get; set; }
            public string timeMostForwardPlayer { get; set; }
            public string timeMostBackPlayer { get; set; }
            public string timeBetweenPlayers { get; set; }
            public RelativePosition(JObject rawData)
            {
                Console.WriteLine("Model: [PlayerRelativePosition]");
                timeInFrontOfCenterOfMass = rawData["timeInFrontOfCenterOfMass"].ToString();
                timeBehindCenterOfMass = rawData["timeBehindCenterOfMass"].ToString();
                timeMostForwardPlayer = rawData["timeMostForwardPlayer"].ToString();
                timeMostBackPlayer = rawData["timeMostBackPlayer"].ToString();
                timeBetweenPlayers = rawData["timeBetweenPlayers"].ToString();
            }
        }

        public class Averages
        {
            public string averageSpeed { get; set; }
            public string averageHitDistance { get; set; }
            public string averageDistanceFromCenter { get; set; }
            public Averages(JObject rawData)
            {
                Console.WriteLine("Model: [PlayerAverages]");
                averageSpeed = rawData["averageSpeed"].ToString();
                averageHitDistance = rawData["averageHitDistance"].ToString();
                averageDistanceFromCenter = rawData["averageDistanceFromCenter"].ToString();
            }
        }

        public class HitCount
        {
            public string totalHits { get; set; }
            public string totalPasses { get; set; }
            public string totalSaves { get; set; }
            public string totalDribbles { get; set; }
            public string totalDribbleContinuations { get; set; }
            public string totalAerials { get; set; }
            public string totalClears { get; set; }
            public HitCount(JObject rawData)
            {
                Console.WriteLine("Model: [PlayerHitCount]");
                totalHits = rawData["totalHits"].ToString();
                totalPasses = rawData["totalPasses"].ToString();
                totalSaves = rawData["totalSaves"].ToString();
                totalDribbles = rawData["totalDribbles"].ToString();
                totalDribbleContinuations = rawData["totalDribbleConts"].ToString();
                totalAerials = rawData["totalAerials"].ToString();
                totalClears = rawData["totalClears"].ToString();
            }
        }

        public class Speed
        {
            public string timeAtSlowSpeed { get; set; }
            public string timeAtSuperSonic { get; set; }
            public string timeAtBoostSpeed { get; set; }
            public Speed(JObject rawData)
            {
                Console.WriteLine("Model: [PlayerSpeed]");
                timeAtSlowSpeed = rawData["timeAtSlowSpeed"].ToString();
                timeAtSuperSonic = rawData["timeAtSuperSonic"].ToString();
                timeAtBoostSpeed = rawData["timeAtBoostSpeed"].ToString();
            }
        }

        public class PerPosession
        {
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
            public PerPosession (JObject rawData)
            {
                Console.WriteLine("Model: [PlayerPerPosession]");
                ppAverageDuration = rawData["averageDuration"].ToString();
                ppAverageHits = rawData["averageHits"].ToString();
                ppTotalCount = rawData["count"].ToString();
                ppAveragePass = rawData["averageCounts.pass"].ToString();
                ppAveragePassed = rawData["averageCounts.passed"].ToString();
                ppAverageDribble = rawData["averageCounts.dribble"].ToString();
                ppAverageDribbleContinuation = rawData["averageCounts.dribbleContinuation"].ToString();
                ppAverageShot = rawData["averageCounts.shot"].ToString();
                ppAverageGoal = rawData["averageCounts.goal"].ToString();
                ppAverageAssist = rawData["averageCounts.assist"].ToString();
                ppAverageAssisted = rawData["averageCounts.assisted"].ToString();
                ppAverageSave = rawData["averageCounts.save"].ToString();
                ppAverageAerial = rawData["averageCounts.aerial"].ToString();
            }
        }

        public class BallCarry
        {
            public string totalCarries { get; set; }
            public string longestCarry { get; set; }
            public string furthestCarry { get; set; }
            public string totalCarryTime { get; set; }
            public string averageCarryTime { get; set; }
            public string fastestCarrySpeed { get; set; }
            public string totalCarryDistance { get; set; }
            public string averageCarrySpeed { get; set; }
            public string distanceAlongPath { get; set; }
            public BallCarry(JObject rawData)
            {
                Console.WriteLine("Model: [PlayerBallCarry]");
                totalCarries = rawData["totalCarries"].ToString();
                longestCarry = rawData["longestCarry"].ToString();
                furthestCarry = rawData["furthestCarry"].ToString();
                totalCarryTime = rawData["totalCarryTime"].ToString();
                averageCarryTime = rawData["averageCarryTime"].ToString();
                fastestCarrySpeed = rawData["fastestCarrySpeed"].ToString();
                totalCarryDistance = rawData["totalCarryDistance"].ToString();
                averageCarrySpeed = rawData["carryStats.averageCarrySpeed"].ToString();
                distanceAlongPath = rawData["carryStats.distanceAlongPath"].ToString();
            }
        }

        public class Kickoff
        {
            public string totalKickoffs { get; set; }
            public string numTimeCheat { get; set; }
            public string numTimeGoToBall { get; set; }
            public string numTimeFirstTouch { get; set; }
            public string averageBoostUsed { get; set; }
            public Kickoff(JObject rawData)
            {
                Console.WriteLine("Model: [PlayerKickoff]");
                totalKickoffs = rawData["totalKickoffs"].ToString();
                numTimeCheat = rawData["numTimeCheat"].ToString();
                numTimeGoToBall = rawData["numTimeGoToBall"].ToString();
                numTimeFirstTouch = rawData["numTimeFirstTouch"].ToString();
                averageBoostUsed = rawData["averageBoostUsed"].ToString();
            }
        }
    }
}
