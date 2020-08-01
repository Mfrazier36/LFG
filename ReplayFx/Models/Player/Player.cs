using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks.Sources;
using System.Transactions;

namespace ReplayFx.Models.Data
{
    public class Player
    {
        public string id { get; set; }
        public string name { get; set; }
        public string titleId { get; set; }
        public BasicStats basicStats { get; set; }
        public PlayerStats playerStats { get; set; }
      
        public Player(JObject rawData)
        {
            Console.WriteLine("Model: [Player]");
            id = rawData["id"].ToString();
            name = rawData["name"].ToString();
            titleId = rawData["titleId"].ToString();
            basicStats = new BasicStats(rawData);
            JObject statsData = CreateObject(rawData["stats"]);
            PlayerStats stats = new PlayerStats(statsData);
            playerStats = stats;
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

        private JObject CreateObject(JToken data)
        {
            JObject dataObject = data.ToObject<JObject>();
            return dataObject;
        }
    }   
}
