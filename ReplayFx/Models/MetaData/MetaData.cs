using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
//using ReplayFx.Constants;

namespace ReplayFx.Models.Data
{

    public class MetaData
    {
        public string SaveId { get; set; }
        public string SaveName { get; set; }
        public string MapName { get; set; }
        public string ReplayVersion { get; set; }
        public string totalGameTime { get; set; }
        public string totalFrames { get; set; }
        public string teamAlphaScore { get; set; }
        public string teamBravoScore { get; set; }
        public string primaryPlayerId { get; set; }
        public string fileLength { get; set; }
        public string gameServerId { get; set; }
        public string gameServerName { get; set; }
        public string matchGuid { get; set; }
        public string teamSize { get; set; }
        public string gameMode { get; set; }

        public MetaData (JObject rawData)
        {
            Console.WriteLine("Model: [MetaData]");
            SaveId = rawData["id"].ToString();
            SaveName = rawData["name"].ToString();
            MapName = rawData["map"].ToString();
            ReplayVersion = rawData["version"].ToString();
            totalGameTime = rawData["time"].ToString();
            totalFrames = rawData["frames"].ToString();
            teamAlphaScore = rawData["score.team0Score"].ToString();
            teamBravoScore = rawData["score.team1Score"].ToString();
            primaryPlayerId = rawData["primaryPlayer.id"].ToString();
            fileLength = rawData["length"].ToString();
            gameServerId = rawData["gameServerId"].ToString();
            gameServerName = rawData["serverName"].ToString();
            matchGuid = rawData["matchGuid"].ToString();
            teamSize = rawData["teamSize"].ToString();
            gameMode = rawData["playlist"].ToString();
        }
    }
}
