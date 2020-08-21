using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ReplayFx.Models;
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
        public MetaData BuildMetaData(JObject jsonData)
        {
            JObject metadataObj = JObject.FromObject(jsonData["gameMetadata"]);

            MetaData metadata = new MetaData();
            metadata.SaveId = metadataObj["id"].ToString();
            metadata.SaveName = metadataObj["name"].ToString();
            metadata.MapName = metadataObj["map"].ToString();
            metadata.ReplayVersion = metadataObj["version"].ToString();
            metadata.totalGameTime = metadataObj["time"].ToString();
            metadata.totalFrames = metadataObj["frames"].ToString();
            metadata.teamAlphaScore = metadataObj["score.team0Score"].ToString();
            metadata.teamBravoScore = metadataObj["score.team1Score"].ToString();
            metadata.primaryPlayerId = metadataObj["primaryPlayer.id"].ToString();
            metadata.fileLength = metadataObj["length"].ToString();
            metadata.gameServerId = metadataObj["gameServerId"].ToString();
            metadata.gameServerName = metadataObj["serverName"].ToString();
            metadata.matchGuid = metadataObj["matchGuid"].ToString();
            metadata.teamSize = metadataObj["teamSize"].ToString();
            metadata.gameMode = metadataObj["playlist"].ToString();

            return metadata;
        }

        public PlayerData BuildPlayerData(JObject jsonData)
        {
            JObject playerdataObj = JObject.FromObject(jsonData["players"]);

            PlayerData playerdata = new PlayerData();

            playerdata.playerId = (string)playerdataObj["id"];
            playerdata.name = (string)playerdataObj["name"];
            playerdata.titleId = (string)playerdataObj["titleId"];
            playerdata.score = (string)playerdataObj["score"];
            playerdata.goals = (string)playerdataObj["goals"];
            playerdata.assists = (string)playerdataObj["assists"];
            playerdata.shots = (string)playerdataObj["shots"];
            playerdata.isOrange = (string)playerdataObj["isOrange"];
            playerdata.timeInGame = (string)playerdataObj["timeInGame"];
            playerdata.carId = (string)playerdataObj["loadout.carId"];

            JObject StatObj = JObject.FromObject(playerdataObj["stats"]); // PlayerStats

            JObject BoostObj = JObject.FromObject(StatObj["boost"]);    //  Boost
            playerdata.boostUsage = (string)BoostObj["boostUsage"];
            playerdata.numSmallBoost = (string)BoostObj["numSmallBoost"];
            playerdata.numLargeBoost = (string)BoostObj["numLargeBoost"];
            playerdata.totalWastedBoost = (string)BoostObj["totalWastedBoost"];
            playerdata.timeFullBoost = (string)BoostObj["timeFullBoost"];
            playerdata.timeLowBoost = (string)BoostObj["timeLowBoost"];
            playerdata.timeNoBoost = (string)BoostObj["timeNoBoost"];
            playerdata.numStolenBoost = (string)BoostObj["numStolenBoost"];
            playerdata.averageBoostLevel = (string)BoostObj["averageBoostLevel"];
            playerdata.totalWastedBigBoost = (string)BoostObj["totalWastedBigBoost"];
            playerdata.totalWastedSmallBoost = (string)BoostObj["totalWastedSmallBoost"];

            JObject DistanceObj = JObject.FromObject(StatObj["distance"]);  //  Distance
            playerdata.distanceBallHitBackward = (string)DistanceObj["ballHitBackward"];
            playerdata.distanceBallHitForward = (string)DistanceObj["ballHitForward"];
            playerdata.timeClosestToBall = (string)DistanceObj["timeClosestToBall"];
            playerdata.timeFurthestFromBall = (string)DistanceObj["timeFurthestFromBall"];
            playerdata.timeCloseToBall = (string)DistanceObj["timeCloseToBall"];

            JObject PosessionObj = JObject.FromObject(StatObj["posession"]);    //  Posession
            playerdata.totalPossessionTime = (string)PosessionObj["possessionTime"];
            playerdata.turnovers = (string)PosessionObj["turnovers"];
            playerdata.turnoversOnMyHalf = (string)PosessionObj["turnoversOnMyHalf"];
            playerdata.turnoversOnTheirHalf = (string)PosessionObj["turnoversOnTheirHalf"];
            playerdata.wonTurnovers = (string)PosessionObj["wonTurnovers"];

            JObject PositionObj = JObject.FromObject(StatObj["positionalTendencies"]);  //  Position
            playerdata.timeOnGround = (string)PositionObj["timeOnGround"];
            playerdata.timeLowInAir = (string)PositionObj["timeLowInAir"];
            playerdata.timeHighInAir = (string)PositionObj["timeHighInAir"];
            playerdata.timeInDefendingHalf = (string)PositionObj["timeInDefendingHalf"];
            playerdata.timeInAttackingHalf = (string)PositionObj["timeInAttackingHalf"];
            playerdata.timeInDefendingThird = (string)PositionObj["timeInDefendingThird"];
            playerdata.timeInAttackingThird = (string)PositionObj["timeInAttackingThird"];
            playerdata.timeInNeutralThird = (string)PositionObj["timeInNeutralThird"];
            playerdata.timeBehindBall = (string)PositionObj["timeBehindBall"];
            playerdata.timeInFrontBall = (string)PositionObj["timeInFrontBall"];
            playerdata.timeNearWall = (string)PositionObj["timeNearWall"];
            playerdata.timeInCorner = (string)PositionObj["timeInCorner"];
            playerdata.timeOnWall = (string)PositionObj["timeOnWall"];

            JObject RelativePosObj = JObject.FromObject(StatObj["relativePositioning"]);    //  RelativePosition
            playerdata.timeInFrontOfCenterOfMass = (string)RelativePosObj["timeInFrontOfCenterOfMass"];
            playerdata.timeBehindCenterOfMass = (string)RelativePosObj["timeBehindCenterOfMass"];
            playerdata.timeMostForwardPlayer = (string)RelativePosObj["timeMostForwardPlayer"];
            playerdata.timeMostBackPlayer = (string)RelativePosObj["timeMostBackPlayer"];
            playerdata.timeBetweenPlayers = (string)RelativePosObj["timeBetweenPlayers"];

            JObject AveragesObj = JObject.FromObject(StatObj["averages"]);  //  Averages
            playerdata.averageSpeed = (string)AveragesObj["averageSpeed"];
            playerdata.averageHitDistance = (string)AveragesObj["averageHitDistance"];
            playerdata.averageDistanceFromCenter = (string)AveragesObj["averageDistanceFromCenter"];

            JObject HitCountObj = JObject.FromObject(StatObj["hitCounts"]); //  HitCounts
            playerdata.totalHits = (string)HitCountObj["totalHits"];
            playerdata.totalPasses = (string)HitCountObj["totalPasses"];
            playerdata.totalSaves = (string)HitCountObj["totalSaves"];
            playerdata.totalDribbles = (string)HitCountObj["totalDribbles"];
            playerdata.totalDribbleContinuations = (string)HitCountObj["totalDribbleConts"];
            playerdata.totalAerials = (string)HitCountObj["totalAerials"];
            playerdata.totalClears = (string)HitCountObj["totalClears"];

            JObject SpeedObj = JObject.FromObject(StatObj["speed"]);    //  Speed
            playerdata.timeAtSlowSpeed = (string)SpeedObj["timeAtSlowSpeed"];
            playerdata.timeAtSuperSonic = (string)SpeedObj["timeAtSuperSonic"];
            playerdata.timeAtBoostSpeed = (string)SpeedObj["timeAtBoostSpeed"];

            JObject PerPosessionObj = JObject.FromObject(StatObj["perPossessionStats"]);    //  PerPosession
            playerdata.ppAverageDuration = (string)PerPosessionObj["averageDuration"];
            playerdata.ppAverageHits = (string)PerPosessionObj["averageHits"];
            playerdata.ppTotalCount = (string)PerPosessionObj["count"];
            playerdata.ppAveragePass = (string)PerPosessionObj["averageCounts.pass"];
            playerdata.ppAveragePassed = (string)PerPosessionObj["averageCounts.passed"];
            playerdata.ppAverageDribble = (string)PerPosessionObj["averageCounts.dribble"];
            playerdata.ppAverageDribbleContinuation = (string)PerPosessionObj["averageCounts.dribbleContinuation"];
            playerdata.ppAverageShot = (string)PerPosessionObj["averageCounts.shot"];
            playerdata.ppAverageGoal = (string)PerPosessionObj["averageCounts.goal"];
            playerdata.ppAverageAssist = (string)PerPosessionObj["averageCounts.assist"];
            playerdata.ppAverageAssisted = (string)PerPosessionObj["averageCounts.assisted"];
            playerdata.ppAverageSave = (string)PerPosessionObj["averageCounts.save"];
            playerdata.ppAverageAerial = (string)PerPosessionObj["averageCounts.aerial"];

            JObject BallCarryObj = JObject.FromObject(StatObj["ballCarries"]);  //  BallCarry
            playerdata.totalCarries = (string)BallCarryObj["totalCarries"];
            playerdata.longestCarry = (string)BallCarryObj["longestCarry"];
            playerdata.furthestCarry = (string)BallCarryObj["furthestCarry"];
            playerdata.totalCarryTime = (string)BallCarryObj["totalCarryTime"];
            playerdata.averageCarryTime = (string)BallCarryObj["averageCarryTime"];
            playerdata.fastestCarrySpeed = (string)BallCarryObj["fastestCarrySpeed"];
            playerdata.totalCarryDistance = (string)BallCarryObj["totalCarryDistance"];
            playerdata.averageCarrySpeed = (string)BallCarryObj["carryStats.averageCarrySpeed"];
            playerdata.distanceAlongPath = (string)BallCarryObj["carryStats.distanceAlongPath"];

            JObject KickoffObj = JObject.FromObject(StatObj["kickoffStats"]);   //  Kickoff
            playerdata.totalKickoffs = (string)KickoffObj["totalKickoffs"];
            playerdata.numTimeCheat = (string)KickoffObj["numTimeCheat"];
            playerdata.numTimeGoToBall = (string)KickoffObj["numTimeGoToBall"];
            playerdata.numTimeFirstTouch = (string)KickoffObj["numTimeFirstTouch"];
            playerdata.averageBoostUsed = (string)KickoffObj["averageBoostUsed"];

            return playerdata;
        }

        public TeamData BuildTeamData(JObject jsonData)
        {
            JObject TeamDataObj = JObject.FromObject(jsonData["players"]);
            JObject PartyDataObj = JObject.FromObject(jsonData["parties"]);

            TeamData teamdata = new TeamData();   //  TeamData
            //teamdata.playerIds = jsonData["playerIds"].ToString().ToArray<string>();
            teamdata.score = (string)jsonData["score"];
            teamdata.isOrange = (string)jsonData["isOrange"];

            JObject PosessionObj = JObject.FromObject(jsonData["posession"]);
            teamdata.totalPosessionTime = (string)PosessionObj["posessionTime"];
            teamdata.turnovers = (string)PosessionObj["turnovers"];
            teamdata.turnoversOnMyHalf = (string)PosessionObj["turnoversOnMyHalf"];
            teamdata.turnoversOnTheirHalf = (string)PosessionObj["turnoversOnTheirHalf"];
            teamdata.wonTurnovers = (string)PosessionObj["turnovwonTurnoversers"];

            JObject HitCountObj = JObject.FromObject(jsonData["hitCounts"]);
            teamdata.totalHits = (string)HitCountObj["totalHits"];
            teamdata.totalPasses = (string)HitCountObj["totalPasses"];
            teamdata.totalSaves = (string)HitCountObj["totalSaves"];
            teamdata.totalDribbleContinuations = (string)HitCountObj["totalDribbleConts"];
            teamdata.totalAerials = (string)HitCountObj["totalAerials"];

            JObject PositionObj = JObject.FromObject(jsonData["centerOfMass"]);
            teamdata.averageDistanceFromCenter = (string)PositionObj["averageDistanceFromCenter"];
            teamdata.averageMaxDistanceFromCenter = (string)PositionObj["averageMaxDistanceFromCenter"];
            teamdata.timeClumped = (string)PositionObj["timeClumped"];
            teamdata.timeBoondocks = (string)PositionObj["timeBoondocks"];
            teamdata.timeOnGround = (string)PositionObj["positionalTendencies.timeOnGround"];
            teamdata.timeLowInAir = (string)PositionObj["positionalTendencies.timeLowInAir"];
            teamdata.timeHighInAir = (string)PositionObj["positionalTendencies.timeHighInAir"];
            teamdata.timeInDefendingHalf = (string)PositionObj["positionalTendencies.timeInDefendingHalf"];
            teamdata.timeInAttackingHalf = (string)PositionObj["positionalTendencies.timeInAttackingHalf"];
            teamdata.timeInDefendingThird = (string)PositionObj["positionalTendencies.timeInDefendingThird"];
            teamdata.timeInNeutralThird = (string)PositionObj["positionalTendencies.timeInNeutralThird"];
            teamdata.timeInAttackingThird = (string)PositionObj["positionalTendencies.timeInAttackingThird"];
            teamdata.timeBehindBall = (string)PositionObj["positionalTendencies.timeBehindBall"];
            teamdata.timeInFrontBall = (string)PositionObj["positionalTendencies.timeInFrontBall"];
            teamdata.timeNearWall = (string)PositionObj["positionalTendencies.timeNearWall"];
            teamdata.timeInCorner = (string)PositionObj["positionalTendencies.timeInCorner"];
            teamdata.timeOnWall = (string)PositionObj["positionalTendencies.timeOnWall"];

            return teamdata;
        }

        public BallData BuildBallData(JObject jsonData)
        {
            JObject BallObj = JObject.FromObject(jsonData["ballStats"]);

            BallData balldata = new BallData();
            balldata.timeOnGround = (string)BallObj["timeOnGround"];
            balldata.timeHighInAir = (string)BallObj["timeHighInAir"];
            balldata.timeInAttackingHalf= (string)BallObj["timeInAttackingHalf"];
            balldata.timeInAttackingThird= (string)BallObj["timeInAttackingThird"];
            balldata.timeNearWall= (string)BallObj["timeNearWall"];
            balldata.timeOnWall= (string)BallObj["timeOnWall"];
            balldata.neutralPosessionTime= (string)BallObj["neutralPosessionTime"];
            balldata.averageSpeed= (string)BallObj["averageSpeed"];
            balldata.timeInCorner= (string)BallObj["timeInCorner"];
            balldata.timeInDefendingThird= (string)BallObj["timeInDefendingThird"];
            balldata.timeInNeutralThird= (string)BallObj["timeInNeutralThird"];
            balldata.timeInDefendingHalf= (string)BallObj["timeInDefendingHalf"];
            balldata.timeLowInAir= (string)BallObj["timeLowInAir"];

            return balldata;
        }
            
    }
}
