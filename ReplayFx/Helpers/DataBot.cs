using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ReplayFx.Models;
using System;
using System.Diagnostics;
using System.IO;

namespace ReplayFx.Helpers
{
    public class DataBot
    {
        public GameData DecompileReplayData(string FilePath)
        {
            var CarballFile = Path.GetFullPath("../wwwroot/lib/carball/init.py");
            var CarballDirectory = Path.GetDirectoryName(CarballFile);
            var CarballFileName = Path.GetFileName(CarballFile);
            var CarballCommand = $"/c carball -i ${FilePath} --json dumpFile.json";

            var settings = new ProcessStartInfo();
            settings.WorkingDirectory = CarballDirectory;
            settings.FileName = CarballFileName;
            settings.Arguments = CarballCommand;
            settings.WindowStyle = ProcessWindowStyle.Hidden;
            settings.RedirectStandardOutput = true;
            settings.Verb = "runas";
            settings.UseShellExecute = true;

            var environment = Process.Start(settings);
            environment.BeginOutputReadLine();
            environment.WaitForExit();

            StreamReader reader = environment.StandardOutput;

            string outputData = reader.ReadToEnd();

            GameData gameData = JsonConvert.DeserializeObject<GameData>(outputData);

            return gameData;
        }
        public MatchData BuildMatchData(JObject jsonData)
        {
            JObject metadataObj = JObject.FromObject(jsonData["gameMetadata"]);

            MatchData metadata = new MatchData();
            metadata.ReplayId = metadataObj["id"].ToString();
            metadata.ReplayName = metadataObj["name"].ToString();
            metadata.MapName = metadataObj["map"].ToString();
            metadata.ReplayVersion = metadataObj["version"].ToString();
            metadata.TotGameTime = metadataObj["time"].ToString();
            metadata.TotFrames = metadataObj["frames"].ToString();
            metadata.TeamAlphaScore = metadataObj["score.team0Score"].ToString();
            metadata.TeamBravoScore = metadataObj["score.team1Score"].ToString();
            metadata.PrimaryPlayerId = metadataObj["primaryPlayer.id"].ToString();
            metadata.FileLength = metadataObj["length"].ToString();
            metadata.GameServerId = metadataObj["gameServerId"].ToString();
            metadata.GameServerName = metadataObj["serverName"].ToString();
            metadata.MatchGuid = metadataObj["matchGuid"].ToObject<Guid>();
            metadata.TeamSize = metadataObj["teamSize"].ToString();
            metadata.GameMode = metadataObj["playlist"].ToString();

            return metadata;
        }

        public PlayerData BuildPlayerData(JObject jsonData)
        {
            JObject playerdataObj = JObject.FromObject(jsonData["players"]);

            PlayerData playerdata = new PlayerData();

            playerdata.PlayerId = (string)playerdataObj["id"];
            playerdata.Name = (string)playerdataObj["name"];
            playerdata.TitleId = (string)playerdataObj["titleId"];
            playerdata.Score = (string)playerdataObj["score"];
            playerdata.Goals = (string)playerdataObj["goals"];
            playerdata.Assists = (string)playerdataObj["assists"];
            playerdata.Shots = (string)playerdataObj["shots"];
            playerdata.IsOrange = (string)playerdataObj["isOrange"];
            playerdata.TimeInGame = (string)playerdataObj["timeInGame"];
            playerdata.CarId = (string)playerdataObj["loadout.carId"];

            JObject StatObj = JObject.FromObject(playerdataObj["stats"]); // PlayerStats

            JObject BoostObj = JObject.FromObject(StatObj["boost"]);    //  Boost
            playerdata.BoostUsage = (string)BoostObj["boostUsage"];
            playerdata.NumSmallBoost = (string)BoostObj["numSmallBoost"];
            playerdata.NumLargeBoost = (string)BoostObj["numLargeBoost"];
            playerdata.TotWastedBoost = (string)BoostObj["totalWastedBoost"];
            playerdata.TimeFullBoost = (string)BoostObj["timeFullBoost"];
            playerdata.TimeLowBoost = (string)BoostObj["timeLowBoost"];
            playerdata.TimeNoBoost = (string)BoostObj["timeNoBoost"];
            playerdata.NumStolenBoost = (string)BoostObj["numStolenBoost"];
            playerdata.AvgBoostLevel = (string)BoostObj["averageBoostLevel"];
            playerdata.TotWastedBigBoost = (string)BoostObj["totalWastedBigBoost"];
            playerdata.TotWastedSmallBoost = (string)BoostObj["totalWastedSmallBoost"];

            JObject DistanceObj = JObject.FromObject(StatObj["distance"]);  //  Distance
            playerdata.DistanceBallHitBackward = (string)DistanceObj["ballHitBackward"];
            playerdata.DistanceBallHitForward = (string)DistanceObj["ballHitForward"];
            playerdata.TimeClosestToBall = (string)DistanceObj["timeClosestToBall"];
            playerdata.TimeFurthestFromBall = (string)DistanceObj["timeFurthestFromBall"];
            playerdata.TimeCloseToBall = (string)DistanceObj["timeCloseToBall"];

            JObject PosessionObj = JObject.FromObject(StatObj["posession"]);    //  Posession
            playerdata.TotPossessionTime = (string)PosessionObj["possessionTime"];
            playerdata.Turnovers = (string)PosessionObj["turnovers"];
            playerdata.TurnoversOnMyHalf = (string)PosessionObj["turnoversOnMyHalf"];
            playerdata.TurnoversOnTheirHalf = (string)PosessionObj["turnoversOnTheirHalf"];
            playerdata.WonTurnovers = (string)PosessionObj["wonTurnovers"];

            JObject PositionObj = JObject.FromObject(StatObj["positionalTendencies"]);  //  Position
            playerdata.TimeOnGround = (string)PositionObj["timeOnGround"];
            playerdata.TimeLowInAir = (string)PositionObj["timeLowInAir"];
            playerdata.TimeHighInAir = (string)PositionObj["timeHighInAir"];
            playerdata.TimeInDefendingHalf = (string)PositionObj["timeInDefendingHalf"];
            playerdata.TimeInAttackingHalf = (string)PositionObj["timeInAttackingHalf"];
            playerdata.TimeInDefendingThird = (string)PositionObj["timeInDefendingThird"];
            playerdata.TimeInAttackingThird = (string)PositionObj["timeInAttackingThird"];
            playerdata.TimeInNeutralThird = (string)PositionObj["timeInNeutralThird"];
            playerdata.TimeBehindBall = (string)PositionObj["timeBehindBall"];
            playerdata.TimeInFrontBall = (string)PositionObj["timeInFrontBall"];
            playerdata.TimeNearWall = (string)PositionObj["timeNearWall"];
            playerdata.TimeInCorner = (string)PositionObj["timeInCorner"];
            playerdata.TimeOnWall = (string)PositionObj["timeOnWall"];

            JObject RelativePosObj = JObject.FromObject(StatObj["relativePositioning"]);    //  RelativePosition
            playerdata.TimeInFrontOfCenterOfMass = (string)RelativePosObj["timeInFrontOfCenterOfMass"];
            playerdata.TimeBehindCenterOfMass = (string)RelativePosObj["timeBehindCenterOfMass"];
            playerdata.TimeMostForwardPlayer = (string)RelativePosObj["timeMostForwardPlayer"];
            playerdata.TimeMostBackPlayer = (string)RelativePosObj["timeMostBackPlayer"];
            playerdata.TimeBetweenPlayers = (string)RelativePosObj["timeBetweenPlayers"];

            JObject AvgsObj = JObject.FromObject(StatObj["averages"]);  //  Avgs
            playerdata.AvgSpeed = (string)AvgsObj["averageSpeed"];
            playerdata.AvgHitDistance = (string)AvgsObj["averageHitDistance"];
            playerdata.AvgDistanceFromCenter = (string)AvgsObj["averageDistanceFromCenter"];

            JObject HitCountObj = JObject.FromObject(StatObj["hitCounts"]); //  HitCounts
            playerdata.TotHits = (string)HitCountObj["totalHits"];
            playerdata.TotPasses = (string)HitCountObj["totalPasses"];
            playerdata.TotSaves = (string)HitCountObj["totalSaves"];
            playerdata.TotDribbles = (string)HitCountObj["totalDribbles"];
            playerdata.TotDribbleContinuations = (string)HitCountObj["totalDribbleConts"];
            playerdata.TotAerials = (string)HitCountObj["totalAerials"];
            playerdata.TotClears = (string)HitCountObj["totalClears"];

            JObject SpeedObj = JObject.FromObject(StatObj["speed"]);    //  Speed
            playerdata.TimeAtSlowSpeed = (string)SpeedObj["timeAtSlowSpeed"];
            playerdata.TimeAtSuperSonic = (string)SpeedObj["timeAtSuperSonic"];
            playerdata.TimeAtBoostSpeed = (string)SpeedObj["timeAtBoostSpeed"];

            JObject PerPosessionObj = JObject.FromObject(StatObj["perPossessionStats"]);    //  PerPosession
            playerdata.PpAvgDuration = (string)PerPosessionObj["averageDuration"];
            playerdata.PpAvgHits = (string)PerPosessionObj["averageHits"];
            playerdata.PpTotCount = (string)PerPosessionObj["count"];
            playerdata.PpAvgPass = (string)PerPosessionObj["averageCounts.pass"];
            playerdata.PpAvgPassed = (string)PerPosessionObj["averageCounts.passed"];
            playerdata.PpAvgDribble = (string)PerPosessionObj["averageCounts.dribble"];
            playerdata.PpAvgDribbleContinuation = (string)PerPosessionObj["averageCounts.dribbleContinuation"];
            playerdata.PpAvgShot = (string)PerPosessionObj["averageCounts.shot"];
            playerdata.PpAvgGoal = (string)PerPosessionObj["averageCounts.goal"];
            playerdata.PpAvgAssist = (string)PerPosessionObj["averageCounts.assist"];
            playerdata.PpAvgAssisted = (string)PerPosessionObj["averageCounts.assisted"];
            playerdata.PpAvgSave = (string)PerPosessionObj["averageCounts.save"];
            playerdata.PpAvgAerial = (string)PerPosessionObj["averageCounts.aerial"];

            JObject BallCarryObj = JObject.FromObject(StatObj["ballCarries"]);  //  BallCarry
            playerdata.TotCarries = (string)BallCarryObj["totalCarries"];
            playerdata.LongestCarry = (string)BallCarryObj["longestCarry"];
            playerdata.FurthestCarry = (string)BallCarryObj["furthestCarry"];
            playerdata.TotCarryTime = (string)BallCarryObj["totalCarryTime"];
            playerdata.AvgCarryTime = (string)BallCarryObj["averageCarryTime"];
            playerdata.FastestCarrySpeed = (string)BallCarryObj["fastestCarrySpeed"];
            playerdata.TotCarryDistance = (string)BallCarryObj["totalCarryDistance"];
            playerdata.AvgCarrySpeed = (string)BallCarryObj["carryStats.averageCarrySpeed"];
            playerdata.DistanceAlongPath = (string)BallCarryObj["carryStats.distanceAlongPath"];

            JObject KickoffObj = JObject.FromObject(StatObj["kickoffStats"]);   //  Kickoff
            playerdata.TotKickoffs = (string)KickoffObj["totalKickoffs"];
            playerdata.NumTimeCheat = (string)KickoffObj["numTimeCheat"];
            playerdata.NumTimeGoToBall = (string)KickoffObj["numTimeGoToBall"];
            playerdata.NumTimeFirstTouch = (string)KickoffObj["numTimeFirstTouch"];
            playerdata.AvgBoostUsed = (string)KickoffObj["averageBoostUsed"];

            return playerdata;
        }

        public TeamData BuildTeamData(JObject jsonData)
        {
            JObject TeamDataObj = JObject.FromObject(jsonData["players"]);
            JObject PartyDataObj = JObject.FromObject(jsonData["parties"]);

            TeamData teamdata = new TeamData();   //  TeamData
            //teamdata.playerIds = jsonData["playerIds"].ToString().ToArray<string>();
            teamdata.Score = (string)jsonData["score"];
            teamdata.IsOrange = (string)jsonData["isOrange"];

            JObject PosessionObj = JObject.FromObject(jsonData["posession"]);
            teamdata.TotPosessionTime = (string)PosessionObj["posessionTime"];
            teamdata.Turnovers = (string)PosessionObj["turnovers"];
            teamdata.TurnoversOnMyHalf = (string)PosessionObj["turnoversOnMyHalf"];
            teamdata.TurnoversOnTheirHalf = (string)PosessionObj["turnoversOnTheirHalf"];
            teamdata.WonTurnovers = (string)PosessionObj["turnovwonTurnoversers"];

            JObject HitCountObj = JObject.FromObject(jsonData["hitCounts"]);
            teamdata.TotHits = (string)HitCountObj["totalHits"];
            teamdata.TotPasses = (string)HitCountObj["totalPasses"];
            teamdata.TotSaves = (string)HitCountObj["totalSaves"];
            teamdata.TotDribbleContinuations = (string)HitCountObj["totalDribbleConts"];
            teamdata.TotAerials = (string)HitCountObj["totalAerials"];

            JObject PositionObj = JObject.FromObject(jsonData["centerOfMass"]);
            teamdata.AvgDistanceFromCenter = (string)PositionObj["averageDistanceFromCenter"];
            teamdata.AvgMaxDistanceFromCenter = (string)PositionObj["averageMaxDistanceFromCenter"];
            teamdata.TimeClumped = (string)PositionObj["timeClumped"];
            teamdata.TimeBoondocks = (string)PositionObj["timeBoondocks"];
            teamdata.TimeOnGround = (string)PositionObj["positionalTendencies.timeOnGround"];
            teamdata.TimeLowInAir = (string)PositionObj["positionalTendencies.timeLowInAir"];
            teamdata.TimeHighInAir = (string)PositionObj["positionalTendencies.timeHighInAir"];
            teamdata.TimeInDefendingHalf = (string)PositionObj["positionalTendencies.timeInDefendingHalf"];
            teamdata.TimeInAttackingHalf = (string)PositionObj["positionalTendencies.timeInAttackingHalf"];
            teamdata.TimeInDefendingThird = (string)PositionObj["positionalTendencies.timeInDefendingThird"];
            teamdata.TimeInNeutralThird = (string)PositionObj["positionalTendencies.timeInNeutralThird"];
            teamdata.TimeInAttackingThird = (string)PositionObj["positionalTendencies.timeInAttackingThird"];
            teamdata.TimeBehindBall = (string)PositionObj["positionalTendencies.timeBehindBall"];
            teamdata.TimeInFrontBall = (string)PositionObj["positionalTendencies.timeInFrontBall"];
            teamdata.TimeNearWall = (string)PositionObj["positionalTendencies.timeNearWall"];
            teamdata.TimeInCorner = (string)PositionObj["positionalTendencies.timeInCorner"];
            teamdata.TimeOnWall = (string)PositionObj["positionalTendencies.timeOnWall"];

            return teamdata;
        }

        public BallData BuildBallData(JObject jsonData)
        {
            JObject GameStatObj = JObject.FromObject(jsonData["gameStats"]);
            JObject BallObj = JObject.FromObject(GameStatObj["ballStats"]);

            BallData balldata = new BallData();
            balldata.TimeOnGround = (string)BallObj["timeOnGround"];
            balldata.TimeHighInAir = (string)BallObj["timeHighInAir"];
            balldata.TimeInAttackingHalf= (string)BallObj["timeInAttackingHalf"];
            balldata.TimeInAttackingThird= (string)BallObj["timeInAttackingThird"];
            balldata.TimeNearWall= (string)BallObj["timeNearWall"];
            balldata.TimeOnWall= (string)BallObj["timeOnWall"];
            balldata.AvgSpeed= (string)BallObj["averageSpeed"];
            balldata.TimeInCorner= (string)BallObj["timeInCorner"];
            balldata.TimeInDefendingThird= (string)BallObj["timeInDefendingThird"];
            balldata.TimeInNeutralThird= (string)BallObj["timeInNeutralThird"];
            balldata.TimeInDefendingHalf= (string)BallObj["timeInDefendingHalf"];
            balldata.TimeLowInAir= (string)BallObj["timeLowInAir"];

            balldata.NeutralPosessionTime = (string)GameStatObj["neutralPosessionTime"]; // GameStats(FrameData)

            return balldata;
        }
            
    }
}
