using Newtonsoft.Json.Linq;
using ReplayFx.Models.Team;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace ReplayFx.Models.Data
{
    public class Team
    {
        public string[] playerIds { get; set; }
        public string score { get; set; }
        public string isOrange { get; set; }

        public TeamStats teamStats { get; set; }

        public Team(JObject rawData)
        {
            playerIds = GetMemberIds(JArray.FromObject(rawData["playerIds"]));
            score = rawData["score"].ToString();
            isOrange = rawData["isOrange"].ToString();
            teamStats = new TeamStats(CreateObject(rawData["stats"]));
        }

        public static string[] GetMemberIds(JArray playerArray)
        {
            List<string> players = new List<string>();
            bool isFinished = false;
            int count = 0;
            while (!isFinished)
            {
                string playerID = "";
                try
                {
                    playerID = playerArray[count]["id"].ToString();
                    players.Add(playerID);
                }
                catch
                {
                    isFinished = false;
                }
                count++;
            }
            string[] playerIdArray = players.ToArray();
            return playerIdArray;
        }
        private static JObject CreateObject(JToken data)
        {
            JObject dataObject = data.ToObject<JObject>();
            return dataObject;
        }
    }
}
