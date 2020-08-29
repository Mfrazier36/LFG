using Newtonsoft.Json.Linq;
using ReplayFx.Helpers;
using ReplayFx.Models;
using System.Collections.Generic;

namespace ReplayFx.Factories
{
    public class PlayerFactory : _Factory
    {
        public List<Player> Build( JArray playerListJson )
        {
            List<Player> _FinishedData = JBot.CreateList<Player>();
            foreach ( var item in playerListJson )
            {
                JObject playerJson = item.ToObject<JObject>();
                Player playerData = Build(playerJson);
                _FinishedData.Add(playerData);
            }
            return _FinishedData;
        }

        private static Player Build( JObject playerJson )
        {
            JObject loadoutJson = JBot.GetObject(  _Constants.Loadout, playerJson );
            JObject statsJson = JBot.GetObject( _Constants.Stats, playerJson );
            Player _FinishedData = CreatePlayer();
            _FinishedData.PlayerStats = BuildStats(statsJson);
            _FinishedData.CarId = JBot.GetInt( _Constants.Car, playerJson );
            _FinishedData.Id = JBot.GetPlayerId(playerJson);
            return _FinishedData;
        }

        private static PlayerStats BuildStats( JObject statsJson )
        {
            PlayerStats _FinishedData = CreatePlayerStats();
            List<string> StatHeadPropList= JBot.GetStatHeadProps();
            _FinishedData = JBot.AddStats<PlayerStats>( _FinishedData, statsJson, StatHeadPropList);
            return _FinishedData;
        }
    }
}
