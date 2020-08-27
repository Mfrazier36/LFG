using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json.Linq;
using ReplayFx.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ReplayFx.Helpers
{
    public class JBot : Bot
    {
        private static FileStream _Reader;
        private static string _CommandString;
        readonly static string _CurrentLocation = ".";
        readonly static string _CarballPath = "~\\wwwroot\\lib\\carball\\init.py";
        readonly static string InputOutputFilePath = Path.GetRelativePath(_CurrentLocation, _CarballPath);
        readonly static string InputFileName = "Input.replay";
        readonly static string OutputFileName = "Output.json";


        private ProcessStartInfo BuildCarballProcess(ICollection<string> _FilePaths)
        {
            Console.WriteLine("FilePaths", _FilePaths.ToString());

            _CommandString = "TODO: BuildCommandStringArgs";

            ProcessStartInfo cmdProcess = new ProcessStartInfo();

            cmdProcess.WorkingDirectory = Path.GetDirectoryName(_CarballPath);
            cmdProcess.FileName = Path.GetFileName(_CarballPath);
            cmdProcess.Arguments = _CommandString;
            cmdProcess.Verb = "runas";
            cmdProcess.UseShellExecute = true;
            cmdProcess.RedirectStandardOutput = true;
            cmdProcess.WindowStyle = ProcessWindowStyle.Hidden;

            return cmdProcess;
        }
        public static List<Team> BuildTeamData(JArray teamdata, 
                                               JArray rosterdata, 
                                               JObject scoredata)
        {
            List<Team> _FinishedData = new List<Team>();

            Team TeamAlpha = new Team();
            TeamAlpha.Name = TeamName.Alpha;
            TeamAlpha.Score = StatBot.GetInt(_Constants.TeamAlphaScore, scoredata);

            Team TeamBravo = new Team();
            TeamBravo.Name = TeamName.Bravo;
            TeamBravo.Score = StatBot.GetInt(_Constants.TeamBravoScore, scoredata);
            foreach (var item in teamdata)
            {
                JObject team = JObject.FromObject(item);
                var score = StatBot.GetInt(_Constants.Score, team);
                if (score == TeamAlpha.Score)
                {
                    int count = 1;
                    JArray playerIds = GetArray(_Constants.PlayerIds, team);
                    JObject ModelObj = JObject.FromObject(TeamAlpha);
                    foreach (var id in playerIds)
                    {
                        string propertyString = "Player" + count.ToString() + "Id";
                        ModelObj[propertyString] = id;
                        count++;
                    }
                    TeamAlpha = ModelObj.ToObject<Team>();
                }
                else
                {
                    int count = 1;
                    JArray playerIds = GetArray(_Constants.PlayerIds, team);
                    JObject ModelObj = JObject.FromObject(TeamBravo);
                    foreach (var playerId in playerIds)
                    {
                        string propertyString = _Constants.Player 
                                                + count.ToString() 
                                                + _Constants.Id;
                        ModelObj[propertyString] = playerId;
                        count++;
                    }
                    TeamBravo = ModelObj.ToObject<Team>();
                }
                foreach (var Roster in rosterdata)
                {
                    JObject RosterData = JObject.FromObject(Roster);
                    JArray playerIds = GetArray(_Constants.Members, RosterData);
                   if (playerIds.Contains(TeamAlpha.Player1Id))
                    {
                        TeamAlpha.LeaderId = StatBot.GetInt(_Constants.LeaderId, RosterData);
                        JObject stats = GetObject(_Constants.Stats, RosterData);
                        TeamAlpha.TeamStats = BuildStats<TeamStats>(TeamAlpha.TeamStats, stats);
                    }
                    else
                    {
                        TeamBravo.LeaderId = StatBot.GetInt(_Constants.LeaderId, RosterData);
                        JObject stats = GetObject(_Constants.Stats, RosterData);
                        TeamBravo.TeamStats = BuildStats<TeamStats>(TeamBravo.TeamStats, stats);
                    }
                }
            }
            _FinishedData.Add(TeamAlpha);
            _FinishedData.Add(TeamBravo);
            return _FinishedData;
        }

        public static List<Player> BuildPlayerData(JArray playerdata)
        {
            List<Player> _FinishedData = new List<Player>();

            foreach (var player in playerdata)
            {
                JObject playerJson = JObject.FromObject(player);
                Player playerNet = new Player();
                JObject loadoutJson = GetObject(_Constants.Loadout, playerJson);
                JObject statsJson = GetObject(_Constants.Stats, playerJson);
                playerNet = StatBot.AddData<Player>(playerNet,playerJson, _Constants.PlayerHeaderSet);
                playerNet.Id = StatBot.GetPlayerId(playerJson);
                playerNet.CarId = StatBot.GetInt(_Constants.Car, loadoutJson);
                playerNet.PlayerStats = BuildStats<PlayerStats>(playerNet.PlayerStats, statsJson);

                _FinishedData.Add(playerNet);
            }

            return _FinishedData;
        }

        public static ObjTyp BuildStats<ObjTyp>(ObjTyp modelObj , JObject statsObj)
        {
            List<string> headerProps = _Constants.StatsHeaderSet;

            JObject modelJson = JObject.FromObject(modelObj);

            foreach (var jsonLabel in headerProps)
            {
                JObject statJson = GetObject(jsonLabel, statsObj);

                if (statJson.HasValues)
                {
                    modelJson = StatBot.FilterStats<JObject>(statJson, modelJson);
                }
            }

            ObjTyp _FinishedData = JObject.FromObject(statsObj).ToObject<ObjTyp>();

            return _FinishedData;
        }


        public static Frame BuildFrameData(JObject framedata)
        {
            Frame _FinishedData = new Frame();

            bool hasStartFrame = framedata.ContainsKey(_Constants.StartFrame);
            bool hasStartFrameNbr = framedata.ContainsKey(_Constants.StartFrameNumber);
            bool hasEndFrame = framedata.ContainsKey(_Constants.EndFrameNumber);
            bool isHitFrame = framedata.ContainsKey(_Constants.CollisionDistance);
            bool isKickoffFrame = framedata.ContainsKey(_Constants.Touch);
            bool isBumpFrame = framedata.ContainsKey(_Constants.IsDemo); // Attacker Victim
            

            _FinishedData.FrameNumber = StatBot.GetInt(_Constants.FrameNumber, framedata);
            _FinishedData = StatBot.ExtractIdsFromFrame(_FinishedData, framedata);
            if (framedata.ContainsKey(_Constants.IsDemo))
            {
                _FinishedData.IsDemo = (bool)framedata[_Constants.IsDemo];
            }
            if (framedata.ContainsKey(_Constants.CollisionDistance))
            {
                _FinishedData = StatBot.AddData<Frame>(_FinishedData, framedata, _Constants.HitFrameSet);
            }
            if (framedata.ContainsKey(_Constants.Touch))
            {
                _FinishedData = StatBot.AddData<Frame>(_FinishedData, framedata, _Constants.KickoffFrameSet);
            }
            return _FinishedData;
        }

        public static GameMetadata BuildMetaData(JObject metadata)
        {
            GameMetadata _FinishedData = new GameMetadata();

            _FinishedData = StatBot.AddData<GameMetadata>(_FinishedData, metadata, _Constants.MetadataHeaderSet);
            _FinishedData.PrimaryPlayerId = (int)GetObject(_Constants.PrimaryPlayer, metadata)[_Constants.Id];

            return _FinishedData;
        }

        
    }

    public class Bot
    {
        public static string GetNetKey(string Key) { return nameof(Key); }
        public static JObject GetObject(string Key, JObject Obj) { return JObject.FromObject(Obj[Key]); }
        public static JArray GetArray(string Key, JObject Obj) { return JArray.FromObject(Obj[Key]); }
      
    }
}
