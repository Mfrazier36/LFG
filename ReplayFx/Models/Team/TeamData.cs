using Newtonsoft.Json.Linq;
using ReplayFx.Models.Team;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace ReplayFx.Models.Team
{
    public class TeamData
    {
        public string[] playerIds { get; set; }
        public string score { get; set; }
        public string isOrange { get; set; }

        public TeamStats teamStats { get; set; }

        public TeamData(JObject rawData)
        {
            Console.WriteLine("Model: [Team]");
            playerIds = GetMemberIds(JArray.FromObject(rawData["playerIds"]));
            score = rawData["score"].ToString();
            isOrange = rawData["isOrange"].ToString();
            teamStats = new TeamStats(CreateObject(rawData["stats"]));
        }

        public static string[] GetMemberIds(JArray memberIdArray)
        {
            List<string> members = new List<string>();
            foreach (var item in memberIdArray)
            {
                JObject obj = item.ToObject<JObject>();
                string id = obj["id"].ToString();
                members.Add(id);
            }
            return members.ToArray();
        }

        private static JObject CreateObject(JToken data)
        {
            JObject dataObject = data.ToObject<JObject>();
            return dataObject;
        }
    }
}
