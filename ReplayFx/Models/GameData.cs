using ReplayFx.Models.Data;
using ReplayFx.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;
using ReplayFx.Models.Player;
using ReplayFx.Models.Team;
using Newtonsoft.Json.Linq;

namespace ReplayFx.Models
{
    public class GameData
    {
        public MetaData metaData;
        public GameStats gameStatData;
        public Parties partyData;
        public PlayerProfile[] playerData;
        public TeamData[] teamData;

        public GameData(JObject rawData)
        {
            metaData = rawData["gameMetadata"].ToObject<MetaData>();
            gameStatData = rawData["gameStats"].ToObject<GameStats>();
            partyData = rawData["parties"].ToObject<Parties>();

            JArray playerDataObj = JArray.FromObject(rawData["players"]);

            List<PlayerProfile> playerDataList = new List<PlayerProfile>();

            foreach (var item in playerDataObj)
            {
                PlayerProfile playerDataHolder = new PlayerProfile(item.ToObject<JObject>());
                playerDataList.Add(playerDataHolder);
            }
            JArray teamDataObj = JArray.FromObject(rawData["teams"]);

            List<TeamData> teamDataList = new List<TeamData>();

            foreach (var item in teamDataObj)
            {
                TeamData teamDataHolder = new TeamData(item.ToObject<JObject>());
                teamDataList.Add(teamDataHolder);
            }

            playerData = playerDataList.ToArray();
            teamData = teamDataList.ToArray();
        }
    }
}
