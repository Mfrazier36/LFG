using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReplayFx.Models
{
    public class _Constants
    {
        public static List<string> HeaderKeySet = new List<string> {
                                                                     GameMetadata, gameStats, 
                                                                     Teams, Boost, Parties
                                                                   };
        public static List<string> FrameBoolSet = new List<string> {
                                                                     IsDemo, HasFlick, IsBot
                                                                   };
        public static List<string> MetadataFrameSet = new List<string> { Goals, Demos };
        public static List<string> GameStatsFrameSet = new List<string> { Hits, Bumps, Kickoffs, BallCarries };

        public static List<string> HitFrameSet = new List<string> {
                                                                    CollisionDistance, Distance, DistanceToGoal,
                                                                    NextHitFrameNumber, GoalNumber, IsKickoff
                                                                  };
        public static List<string> KickoffFrameSet = new List<string> {
                                                                        StartFrame, TouchFrame, TouchTime,
                                                                        TouchType, KickoffPosition, TouchPosition,
                                                                        Boost, BallDist,StartLeft
                                                                      };
        public static List<string> KickoffHeadProps = new List<string>
                                                                    {
                                                                        Touch, Players
                                                                    };

        public static List<string> SpeedSet = new List<string> { 
                                                                 TimeAtSlowSpeed, TimeAtSlowSpeed, TimeAtSuperSonic 
                                                               };
        public static List<string> PosessionSet = new List<string> { 
                                                                     PossessionTime, Turnovers, TurnoversOnMyHalf, 
                                                                     TurnoversOnTheirHalf, WonTurnovers
                                                                   };
        public static List<string> PlayerHeaderSet = new List<string> { Name, TitleId, Score, 
                                                                        Goals, Assists, TimeInGame 
                                                                      };
        public static List<string> MetaDataPropSet = new List<string> {
                                                                        Name, Map,
                                                                        Version, Time, Frames,
                                                                        GameServerId, ServerName,
                                                                        MatchGuid, TeamSize, GameMode
                                                                      };
        public static List<string> StatsHeaderSet = new List<string> {
                                                                       Boost, Distance, Possession,
                                                                       Averages, Speed, PerPossession,
                                                                       averageCounts, BallCarries, carryStats,
                                                                       KickoffStats, PositionalTendencies
                                                                     };

        public static List<string> HitCountSet = new List<string> {
                                                                    Hits, TotalHits, Passes,
                                                                    Saves, Shots, TotalShots,
                                                                    Dribbles, Dribble, Aerial,
                                                                    Aerials, Clears
                                                                  };
        public static List<string> BoostSet = new List<string> {
                                                                 BoostUsage, NumSmallBoosts, NumLargeBoosts, WastedCollection,
                                                                 WastedUsage, TimeFullBoost, TimeLowBoost, TimeNoBoost, 
                                                                 NumStolenBoosts, AvgBoostLevel, WastedBig, WastedSmall, AvgBoostUsed
                                                               };
        public static List<string> DistanceSet = new List<string> {
                                                                    BallHitBackward, BallHitForward, TimeClosestToBall,
                                                                    TimeFurthestFromBall, TimeClosestToBall, TimeCloseToBall,
                                                                    TimeFurthestFromTeamCenter
                                                                  };
        public static List<string> TendenciesSet = new List<string> {
                                                                      TimeOnGround, TimeLowInAir, TimeHighInAir,
                                                                      TimeDefendingHalf, TimeAttackingHalf, TimeDefendingThird,
                                                                      TimeNeutralThird, TimeAttackingThird, TimeBehindBall,
                                                                      TimeInFrontBall, TimeNearWall, TimeInCorner, TimeOnWall
                                                                    };
        public static List<string> BallCarrySet = new List<string> {
                                                                     TotalCarries, LongestCarry, FurthestCarry,TotalCarryTime,AvgCarryTime, FastestCarrySpeed, TotalCarryDistance, 
                                                                     CarryStats, AvgCarrySpeed, DistanceAlongPath, AvgZDistance, AvgBallZVelocity, VarianceZDistance, 
                                                                     VarianceBallZVelocity
                                                                   };
        public static List<string> KickoffStatSet = new List<string> {
                                                                       TotalKickoffs, NumTimeCheat,
                                                                       NumTimeGoToBall, NumTimeFirstTouch, AvgBoostUsed
                                                                     };

        public static string GameMetadata = "gameMetadata";
        public static string FrameNumber = "frameNumber";
        public static string TitleId = "titleId";
        public static string PlayerId = "playerId";
        public static string Type = "type";
        public static string Name = "name";
        public static string Id = "id";
        public static string Map = "map";
        public static string Version = "version";
        public static string Time = "time";
        public static string Frames = "frames";
        public static string Score = "score";
        public static string TeamAlphaScore = "team0Score";
        public static string TeamBravoScore = "team1Score";
        public static string Goals = "goals";
        public static string Demos = "demos";
        public static string AttackerId = "attackerId";
        public static string VictimId = "victimId";
        public static string PrimaryPlayer = "primaryPlayer";
        public static string Length = "length";
        public static string GameServerId = "gameServerId";
        public static string ServerName = "serverName";
        public static string MatchGuid = "matchGuid";
        public static string TeamSize = "teamSize";
        public static string GameMode = "playlist";
        public static string Players = "players";
        public static string Assists = "assists";
        public static string Saves = "saves";
        public static string Shots = "shots";
        public static string Loadout = "loadout";
        public static string Car = "car";
        public static string IsOrange = "isOrange";
        public static string Stats = "stats";
        public static string Boost = "boost";
        public static string BoostUsage = "boostUsage";
        public static string NumSmallBoosts = "numSmallBoosts";
        public static string NumLargeBoosts = "numLargeBoosts";
        public static string WastedCollection = "wastedCollection";
        public static string WastedUsage = "wastedUsage";
        public static string TimeFullBoost = "timeFullBoost";
        public static string TimeLowBoost = "timeLowBoost";
        public static string TimeNoBoost = "timeNoBoost";
        public static string NumStolenBoosts = "numStolenBoosts";
        public static string AvgBoostLevel = "averageBoostLevel";
        public static string WastedBig = "wastedBig";
        public static string WastedSmall = "wastedSmall";
        public static string Distance = "distance";
        public static string BallHitForward = "ballHitForward";
        public static string BallHitBackward = "ballHitBackward";
        public static string TimeClosestToBall = "timeClosestToBall";
        public static string TimeFurthestFromBall = "timeFurthestFromBall";
        public static string TimeCloseToBall = "timeCloseToBall";
        public static string TimeClosestToTeamCenter = "timeClosestToTeamCenter";
        public static string TimeFurthestFromTeamCenter = "timeFurthestFromTeamCenter";
        public static string Possession = "possession";
        public static string PossessionTime = "possessionTime";
        public static string Turnovers = "turnovers";
        public static string TurnoversOnMyHalf = "turnoversOnMyHalf";
        public static string TurnoversOnTheirHalf = "turnoversOnTheirHalf";
        public static string WonTurnovers = "wonTurnovers";
        public static string PositionalTendencies = "positionalTendencies";
        public static string TimeInCorner = "timeInCorner";
        public static string TimeOnWall = "timeOnWall";
        public static string Averages = "averages";
        public static string AvgSpeed = "averageSpeed";
        public static string AvgHitDistance = "averageHitDistance";
        public static string AvgDistanceFromCenter = "averageDistanceFromCenter";
        public static string HitCounts = "hitCounts";
        public static string TotalHits = "totalHits";
        public static string Passes = "totalPasses";
        public static string TotalShots = "totalShots";
        public static string Dribbles = "totalDribbles";
        public static string DribbleContuations = "totalDribbleConts";
        public static string Aerials = "totalAerials";
        public static string Clears = "totalClears";
        public static string Controller = "controller";
        public static string Speed = "speed";
        public static string TimeAtSlowSpeed = "timeAtSlowSpeed";
        public static string TimeAtSuperSonic = "timeAtSuperSonic";
        public static string TimeAtBoostSpeed = "timeAtBoostSpeed";
        public static string RelativePositioning = "relativePositioning";
        
        
        public static string TimeInFrontOfCenterOfMass = "timeInFrontOfCenterOfMass";
        public static string TimeBehindCenterOfMass = "timeBehindCenterOfMass";
        public static string TimeMostForwardPlayer = "timeMostForwardPlayer";
        public static string TimeMostBackPlayer = "timeMostBackPlayer";
        public static string TimeBetweenPlayers = "timeBetweenPlayers";
        public static string PerPossession = "perPossessionStats";
       
        
        public static string averageCounts = "averageCounts";
        public static string Pass = "pass";
        public static string Passed = "passed";
        public static string Dribble = "dribble";
        public static string DribbleContinuation = "dribbleContinuation";
        public static string Shot = "shot";
        public static string Goal = "goal";
        public static string Assist = "assist";
        public static string Assisted = "assisted";
        public static string Save = "save";
        public static string Aerial = "aerial";
        public static string AvgDuration = "averageDuration";
        public static string AvgHits = "averageHits";
        public static string Count = "count";
        public static string BallCarries = "ballCarries";


        public static string TotalCarries = "totalCarries";
        public static string LongestCarry = "longestCarry";
        public static string FurthestCarry = "furthestCarry";
        public static string TotalCarryTime = "totalCarryTime";
        public static string AvgCarryTime = "averageCarryTime";
        public static string FastestCarrySpeed = "fastestCarrySpeed";
        public static string TotalCarryDistance = "totalCarryDistance";
        public static string carryStats = "carryStats";
        
        
        public static string AvgZDistance = "averageZDistance";
        public static string AvgXyDistance = "averageXyDistance";
        public static string AvgBallZVelocity = "averageBallZVelocity";
        public static string VarianceXyDistance = "varianceXyDistance";
        public static string VarianceZDistance = "varianceZDistance";
        public static string VarianceBallZVelocity = "varianceBallZVelocity";
        
        
        public static string AvgCarrySpeed = "averageCarrySpeed";
        public static string DistanceAlongPath = "distanceAlongPath";
        public static string KickoffStats = "kickoffStats";
        public static string TotalKickoffs = "totalKickoffs";
        public static string NumTimeCheat = "numTimeCheat";
        public static string NumTimeGoToBall = "numTimeGoToBall";
        public static string NumTimeFirstTouch = "numTimeFirstTouch";
        public static string AvgBoostUsed = "averageBoostUsed";
        public static string PartyLeader = "partyLeader";
        public static string IsBot = "isBot";
        public static string TimeInGame = "timeInGame";
        public static string FirstFrameInGame = "firstFrameInGame";
        public static string Teams = "teams";
        public static string PlayerIds = "playerIds";
        public static string TotalSaves = "totalSaves";
        public static string CenterOfMass = "centerOfMass";


        public static string TimeOnGround = "timeOnGround";
        public static string TimeLowInAir = "timeLowInAir";
        public static string TimeHighInAir = "timeHighInAir";
        public static string TimeDefendingHalf = "timeInDefendingHalf";
        public static string TimeAttackingHalf = "timeInAttackingHalf";
        public static string TimeDefendingThird = "timeInDefendingThird";
        public static string TimeNeutralThird = "timeInNeutralThird";
        public static string TimeAttackingThird = "timeInAttackingThird";
        public static string TimeBehindBall = "timeBehindBall";
        public static string TimeInFrontBall = "timeInFrontBall";
        public static string TimeNearWall = "timeNearWall";
        public static string AvgMaxDistanceFromCenter = "averageMaxDistanceFromCenter";
        public static string TimeClumped = "timeClumped";
        public static string TimeBoondocks = "timeBoondocks";
        public static string gameStats = "gameStats";
        public static string Hits = "hits";
        public static string CollisionDistance = "collisionDistance";
        public static string BallData = "ballData";
        public static string Ball_PosX = "posX";
        public static string Ball_PosY = "posY";
        public static string Ball_PosZ = "posZ";
        public static string Pos_X = "posX";
        public static string Pos_Y = "posY";
        public static string Pos_Z = "posZ";
        public static string Player_PosX = "posX";
        public static string Player_PosY = "posY";
        public static string Player_PosZ = "posZ";
        public static string Kickoff_PosX = "posX";
        public static string Kickoff_PosY = "posY";
        public static string Kickoff_PosZ = "posZ";
        public static string DistanceToGoal = "distanceToGoal";
        public static string NextHitFrameNumber = "nextHitFrameNumber";
        public static string GoalNumber = "goalNumber";
        public static string IsKickoff = "isKickoff";
        public static string neutralPOssessionTime = "neutralPossessionTime";
        public static string Bumps = "bumps";
        public static string StartFrameNumber = "startFrameNumber";
        public static string EndFrameNumber = "endFrameNumber";
        public static string IsDemo = "isDemo";
        public static string BallStats = "ballStats";
        public static string Kickoffs = "kickoffs";
        public static string StartFrame = "startFrame";
        public static string TouchFrame = "touchFrame";
        public static string TouchTime = "touchTime";
        public static string TouchType = "type";
        public static string Touch = "touch";
        public static string Player = "player";
        public static string KickoffPosition = "kickoffPosition";
        public static string TouchPosition = "touchPosition";
        public static string PlayerPosition = "playerPosition";
        public static string BallDist = "ballDist";
        public static string StartLeft = "startLeft";
        public static string StartPosition = "startPosition";
        public static string KickoffGoal = "kickoffGoal";
        public static string FirstTouchPlayer = "firstTouchPlayer";
        public static string HasFlick = "hasFlick";
        public static string CarryTime = "carryTime";
        public static string StraightLineDistance = "straightLineDistance";
        public static string CarryStats = "carryStats";
        public static string Parties = "parties";
        public static string LeaderId = "leaderId";
        public static string Members = "members";

        public static string Alpha = "Alpha";
        public static string Bravo = "Bravo";
    }
}
