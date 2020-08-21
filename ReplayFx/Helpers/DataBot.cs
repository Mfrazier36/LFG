using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ReplayFx.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;

namespace ReplayFx.Helpers
{
    public class DataBot
    {
        private List<string> ReplayFiles;

        private void InitializeDataBot()
        {
            ReplayFiles = new List<string>();
        }

        public List<string> LoadReplayFile(string? file)
        {
            try
            {
                ReplayFiles.Add(file);
            }
            catch
            {
                InitializeDataBot();

                ReplayFiles.Add(file);
            }

            return ReplayFiles;
        }

        public List<GameData> ProcessData()
        {
            List<GameData> GameDataList = new List<GameData>();
            foreach (string FilePath in ReplayFiles)
            {
                GameData GameData = DecompileReplayData(FilePath);

                GameDataList.Add(GameData);
            }

            return GameDataList;
        }

        private GameData DecompileReplayData(string FilePath)
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

        private void BuildGameData(JObject jsonData)
        {
            string MatchDataJsonKey = "gameMetadata";
            string FrameDataJsonKey = "gameStats";
            string BallDataJsonKey = "ballStats";
            string PartyDataJsonKey = "parties";
            string PlayerDataJsonKey = "players";
            string TeamDataJsonKey = "teams";


            Console.WriteLine("Building FrameData");
            List<FrameData> frameData = new List<FrameData>();
            JObject FrameData = JObject.FromObject(jsonData[FrameDataJsonKey]);

            
            JObject BallData = JObject.FromObject(FrameData[BallDataJsonKey]);
            BallData ballData = BuildBallData(BallData);
            ballData.NeutralPosessionTime = (string)FrameData["neutralPosessionTime"];

            JObject MatchData = JObject.FromObject(jsonData[MatchDataJsonKey]);
            MatchData matchData = BuildMatchData(MatchData);

            JArray PlayerList = JArray.FromObject(jsonData[PlayerDataJsonKey]);
            List<PlayerData> playerData = new List<PlayerData>();
            foreach (var player in PlayerList)
            {
                JObject playerObject = JObject.FromObject(player);
                PlayerData playerStats = BuildPlayerData(playerObject);
                playerData.Add(playerStats);
            }

            JArray PartyList = JArray.FromObject(jsonData[PartyDataJsonKey]);
            List<TeamData> teamData = new List<TeamData>();
            JArray TeamList = JArray.FromObject(jsonData[TeamDataJsonKey]);
            foreach (var team in TeamList)
            {
                JObject teamObject = JObject.FromObject(team);
                TeamData teamStats = BuildTeamData(teamObject);

                string ScoreLabel = teamStats.IsOrange ? "TeamBravoScore" : "TeamAlphaScore";
                matchData.[ScoreLabel] = teamStats.Score;

                teamData.Add(teamStats);
            }
        }

        private MatchData BuildMatchData(JObject metadataObj)
        {
            Console.WriteLine("Building Match Data");
            MatchData metadata = new MatchData
            {
                ReplayId = metadataObj["id"].ToString(),
                ReplayName = metadataObj["name"].ToString(),
                MapName = metadataObj["map"].ToString(),
                ReplayVersion = metadataObj["version"].ToString(),
                TotGameTime = metadataObj["time"].ToString(),
                TotFrames = metadataObj["frames"].ToString(),
                TeamAlphaScore = metadataObj["score.team0Score"].ToString(),
                TeamBravoScore = metadataObj["score.team1Score"].ToString(),
                PrimaryPlayerId = metadataObj["primaryPlayer.id"].ToString(),
                FileLength = metadataObj["length"].ToString(),
                GameServerId = metadataObj["gameServerId"].ToString(),
                GameServerName = metadataObj["serverName"].ToString(),
                MatchGuid = metadataObj["matchGuid"].ToObject<Guid>(),
                TeamSize = metadataObj["teamSize"].ToString(),
                GameMode = metadataObj["playlist"].ToString()
            };

            Console.WriteLine($"Match ${metadata.MatchGuid} Finished Building!");
            return metadata;
        }

        private PlayerData BuildPlayerData(JObject playerJson)
        {
            Console.WriteLine("Building Player Data");
            PlayerData playerdata = new PlayerData
            {
                PlayerId = (string)playerJson["playerId"]["id"],
                Name = (string)playerJson["name"],
                TitleId = (string)playerJson["titleId"],
                Score = (string)playerJson["score"],
                Goals = (string)playerJson["goals"],
                Assists = (string)playerJson["assists"],
                Shots = (string)playerJson["shots"],
                IsOrange = (string)playerJson["isOrange"],
                TimeInGame = (string)playerJson["timeInGame"],
                CarId = (string)playerJson["loadout"]["carId"],
            };

            JObject StatObj = JObject.FromObject(playerJson["stats"]); // PlayerStats

            Console.WriteLine("Building Player Boost Data");
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

            Console.WriteLine("Building Player Distance Data");
            JObject DistanceObj = JObject.FromObject(StatObj["distance"]);  //  Distance
            playerdata.DistanceBallHitBackward = (string)DistanceObj["ballHitBackward"];
            playerdata.DistanceBallHitForward = (string)DistanceObj["ballHitForward"];
            playerdata.TimeClosestToBall = (string)DistanceObj["timeClosestToBall"];
            playerdata.TimeFurthestFromBall = (string)DistanceObj["timeFurthestFromBall"];
            playerdata.TimeCloseToBall = (string)DistanceObj["timeCloseToBall"];

            Console.WriteLine("Building Player Posession Data");
            JObject PosessionObj = JObject.FromObject(StatObj["posession"]);    //  Posession
            playerdata.TotPossessionTime = (string)PosessionObj["possessionTime"];
            playerdata.Turnovers = (string)PosessionObj["turnovers"];
            playerdata.TurnoversOnMyHalf = (string)PosessionObj["turnoversOnMyHalf"];
            playerdata.TurnoversOnTheirHalf = (string)PosessionObj["turnoversOnTheirHalf"];
            playerdata.WonTurnovers = (string)PosessionObj["wonTurnovers"];

            Console.WriteLine("Building Player Positional Data");
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

            Console.WriteLine("Building Player Relative Position Data");
            JObject RelativePosObj = JObject.FromObject(StatObj["relativePositioning"]);    //  RelativePosition
            playerdata.TimeInFrontOfCenterOfMass = (string)RelativePosObj["timeInFrontOfCenterOfMass"];
            playerdata.TimeBehindCenterOfMass = (string)RelativePosObj["timeBehindCenterOfMass"];
            playerdata.TimeMostForwardPlayer = (string)RelativePosObj["timeMostForwardPlayer"];
            playerdata.TimeMostBackPlayer = (string)RelativePosObj["timeMostBackPlayer"];
            playerdata.TimeBetweenPlayers = (string)RelativePosObj["timeBetweenPlayers"];

            Console.WriteLine("Building Player Averages Data");
            JObject AvgsObj = JObject.FromObject(StatObj["averages"]);  //  Avgs
            playerdata.AvgSpeed = (string)AvgsObj["averageSpeed"];
            playerdata.AvgHitDistance = (string)AvgsObj["averageHitDistance"];
            playerdata.AvgDistanceFromCenter = (string)AvgsObj["averageDistanceFromCenter"];

            Console.WriteLine("Building Player Hit Count Data");
            JObject HitCountObj = JObject.FromObject(StatObj["hitCounts"]); //  HitCounts
            playerdata.TotHits = (string)HitCountObj["totalHits"];
            playerdata.TotPasses = (string)HitCountObj["totalPasses"];
            playerdata.TotSaves = (string)HitCountObj["totalSaves"];
            playerdata.TotDribbles = (string)HitCountObj["totalDribbles"];
            playerdata.TotDribbleContinuations = (string)HitCountObj["totalDribbleConts"];
            playerdata.TotAerials = (string)HitCountObj["totalAerials"];
            playerdata.TotClears = (string)HitCountObj["totalClears"];

            Console.WriteLine("Building Player Speed Data");
            JObject SpeedObj = JObject.FromObject(StatObj["speed"]);    //  Speed
            playerdata.TimeAtSlowSpeed = (string)SpeedObj["timeAtSlowSpeed"];
            playerdata.TimeAtSuperSonic = (string)SpeedObj["timeAtSuperSonic"];
            playerdata.TimeAtBoostSpeed = (string)SpeedObj["timeAtBoostSpeed"];

            Console.WriteLine("Building Player PerPosession Data");
            JObject PerPosessionObj = JObject.FromObject(StatObj["perPossessionStats"]);    //  PerPosession
            playerdata.PpAvgDuration = (string)PerPosessionObj["averageDuration"];
            playerdata.PpAvgHits = (string)PerPosessionObj["averageHits"];
            playerdata.PpTotCount = (string)PerPosessionObj["count"];

            Console.WriteLine("Building Player Average Count Data");
            JObject AverageCountObj = JObject.FromObject(PerPosessionObj["averageCounts"]);
            playerdata.PpAvgPass = (string)AverageCountObj["pass"];
            playerdata.PpAvgPassed = (string)AverageCountObj["passed"];
            playerdata.PpAvgDribble = (string)AverageCountObj["dribble"];
            playerdata.PpAvgDribbleContinuation = (string)AverageCountObj["dribbleContinuation"];
            playerdata.PpAvgShot = (string)AverageCountObj["shot"];
            playerdata.PpAvgGoal = (string)AverageCountObj["goal"];
            playerdata.PpAvgAssist = (string)AverageCountObj["assist"];
            playerdata.PpAvgAssisted = (string)AverageCountObj["assisted"];
            playerdata.PpAvgSave = (string)AverageCountObj["save"];
            playerdata.PpAvgAerial = (string)AverageCountObj["aerial"];

            Console.WriteLine("Building Player Ball Carry Data");
            JObject BallCarryObj = JObject.FromObject(StatObj["ballCarries"]);  //  BallCarry
            playerdata.TotCarries = (string)BallCarryObj["totalCarries"];
            playerdata.LongestCarry = (string)BallCarryObj["longestCarry"];
            playerdata.FurthestCarry = (string)BallCarryObj["furthestCarry"];
            playerdata.TotCarryTime = (string)BallCarryObj["totalCarryTime"];
            playerdata.AvgCarryTime = (string)BallCarryObj["averageCarryTime"];
            playerdata.FastestCarrySpeed = (string)BallCarryObj["fastestCarrySpeed"];
            playerdata.TotCarryDistance = (string)BallCarryObj["totalCarryDistance"];

            Console.WriteLine("Building Player Ball Carry Stat Data");
            JObject CarryStatObj = JObject.FromObject(BallCarryObj["carryStats"]); 
            playerdata.AvgCarrySpeed = (string)CarryStatObj["averageCarrySpeed"];
            playerdata.DistanceAlongPath = (string)CarryStatObj["distanceAlongPath"];

            Console.WriteLine("Building Player Kickoff Data");
            JObject KickoffObj = JObject.FromObject(StatObj["kickoffStats"]);   //  Kickoff
            playerdata.TotKickoffs = (string)KickoffObj["totalKickoffs"];
            playerdata.NumTimeCheat = (string)KickoffObj["numTimeCheat"];
            playerdata.NumTimeGoToBall = (string)KickoffObj["numTimeGoToBall"];
            playerdata.NumTimeFirstTouch = (string)KickoffObj["numTimeFirstTouch"];
            playerdata.AvgBoostUsed = (string)KickoffObj["averageBoostUsed"];

            Console.WriteLine($"Player ${playerdata.PlayerId} Finished Building!");
            return playerdata;
        }

        private TeamData BuildTeamData(JObject teamJson)
        {
            Console.WriteLine("Building Team Data");

            TeamData teamdata = new TeamData   //  TeamData
            {
                Score = (string)teamJson["score"],
                IsOrange = (bool)teamJson["isOrange"]
            };

            Console.WriteLine("Building Team Posession Data");
            JObject PosessionObj = JObject.FromObject(teamJson["posession"]);
            teamdata.TotPosessionTime = (string)PosessionObj["posessionTime"];
            teamdata.Turnovers = (string)PosessionObj["turnovers"];
            teamdata.TurnoversOnMyHalf = (string)PosessionObj["turnoversOnMyHalf"];
            teamdata.TurnoversOnTheirHalf = (string)PosessionObj["turnoversOnTheirHalf"];
            teamdata.WonTurnovers = (string)PosessionObj["turnovwonTurnoversers"];

            Console.WriteLine("Building Team HitCount Data");
            JObject HitCountObj = JObject.FromObject(teamJson["hitCounts"]);
            teamdata.TotHits = (string)HitCountObj["totalHits"];
            teamdata.TotPasses = (string)HitCountObj["totalPasses"];
            teamdata.TotSaves = (string)HitCountObj["totalSaves"];
            teamdata.TotDribbleContinuations = (string)HitCountObj["totalDribbleConts"];
            teamdata.TotAerials = (string)HitCountObj["totalAerials"];

            Console.WriteLine("Building Team Positional Data");
            JObject PositionObj = JObject.FromObject(teamJson["centerOfMass"]);
            // TODO: TOUCH !
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

            string teamName = teamdata.IsOrange ? "Bravo" : "Alpha";
            Console.WriteLine($"Team ${teamName} Finished Building!");
            return teamdata;
        }

        private BallData BuildBallData(JObject ballJson)
        {
            Console.WriteLine("Building Ball Data");
            JObject GameStatObj = JObject.FromObject(ballJson["gameStats"]);
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

            //balldata.NeutralPosessionTime = (string)GameStatObj["neutralPosessionTime"]; // GameStats(FrameData)

            Console.WriteLine("Ball Data Finished Building!");
            return balldata;
        }
            
    }
}
