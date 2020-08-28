using Newtonsoft.Json.Linq;
using ReplayFx.Helpers;
using ReplayFx.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReplayFx.Factories
{
    public class PlayerFactory : _Factory
    {
        public static List<Player> Build(JArray playerdata)
        {
            List<Player> _FinishedData = new List<Player>();

            foreach (var player in playerdata)
            {
                JObject playerJson = JObject.FromObject(player);
                Player playerNet = new Player();
                JObject loadoutJson = JBot.ExtractObject(_Constants.Loadout, playerJson);
                JObject statsJson = JBot.ExtractObject(_Constants.Stats, playerJson);
                playerNet = StatBot.AddStats<Player>(playerNet, playerJson, _Constants.PlayerHeaderSet);
                playerNet.Id = StatBot.ExtractPlayerId(playerJson);
                playerNet.CarId = JBot.ExtractInt(_Constants.Car, loadoutJson);
                playerNet.PlayerStats = StatFactory.Build<PlayerStats>(playerNet.PlayerStats, statsJson);

                _FinishedData.Add(playerNet);
            }

            return _FinishedData;
        }
    }
}
