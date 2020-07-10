using System;
using System.Data;
using System.IO;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using Newtonsoft.Json;
using ConsoleApp1.Models;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader f = new StreamReader(args[0]))
            {
                String json = f.ReadToEnd();
            }
        }

        //DataSet gameData = JsonConvert.DeserializeObject<DataSet>(args[);

        static void BuildModel(String jsonData)
        {   
            DataSet data = JsonConvert.DeserializeObject<DataSet>(jsonData);
            GameStats gameStats = new GameStats();
            gameStats.id = data.id;
        }

         class GameStats
        {
            public int id { get; set; } //Game ID
            public int gameServerId { get; set; }
            public int time { get; set; }
            public int frames { get; set; }
            public string name { get; set; }  //Local Saved Name
            public string map { get; set; }
            public string playlist { get; set; }
            public Array goals { get; set; }
            public Object score { get; set; }
            public Object primaryPlayer { get; set; }
            public Guid matchGuid { get; set; }
        }

        class Player
        {
            public string id { get; set; }
            public string name { get; set; }
            public int titleId { get; set; }
            public int score { get; set; }
            public int goals { get; set; }
            public int assists { get; set; }
            public int saves { get; set; }
            public int shots { get; set; }
            public bool isOrange { get; set; }
            public Boost boost { get; set; }
            public HitCount hitCount { get; set; }
            public PlayerAverages averages { get; set; }
        }

        class Boost
        {
            public double boostUsage { get; set; }
            public int numSmallBoosts { get; set; }
            public int numLargeBoosts { get; set; }
            public double wastedCollection { get; set; }
            public double wastedUsage { get; set; }
            public double timeFullBoost { get; set; }
            public double timeLowBoost { get; set; }
            public double timeNoBoost { get; set; }
            public double numStolenBoost { get; set; }
            public double averageBoostLevel { get; set; }
            public double wastedBig { get; set; }
            public double wastedSmall { get; set; }
        }

        class HitCount
        {
            public int totalHits { get; set; }
            public int totalPasses { get; set; }
            public int totalShots { get; set; }
            public int totalDribbles { get; set; }
            public int totalDribbleConts { get; set; }
            public int totalAerials { get; set; }
            public int totalClears { get; set; }
        }

        class PlayerAverages
        {
            public int totalHits { get; set; }
            public double hits { get; set; }
            public double pass { get; set; }
            public double passed { get; set; }
            public double dribble { get; set; }
            public double dribbleContinuation { get; set; }
            public double shot { get; set; }
            public double goal { get; set; }
            public double assist { get; set; }
            public double assisted { get; set; }
            public double save { get; set; }
            public double aerial { get; set; }
        }
    }
}
