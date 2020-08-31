using Newtonsoft.Json.Linq;
using ReplayFx.Helpers;
using ReplayFx.Models;
using System.Collections.Generic;

namespace ReplayFx.Factories
{
    public class PlayerFactory
    {
        public static void Build( JObject rawJson )
        {
            //TODO: Create BuildMethod
        }
        public static List<Player> BuildPlayerList( JArray playerListJson )
        {
            List<Player> _FinishedData = JBot.CreateList<Player>();
            foreach ( var item in playerListJson )
            {
                JObject playerJson = JBot.CreateObject(item);
                Player playerData = BuildPlayer(playerJson);
                _FinishedData.Add(playerData);
            }
            return _FinishedData;
        }

        private static Player BuildPlayer( JObject playerJson )
        {
            JObject loadoutJson = JBot.GetObject(  _Constants.Loadout, playerJson );
            JObject statsJson = JBot.GetObject( _Constants.Stats, playerJson );
            Player _FinishedData = JBot.CreateNewPlayer();
            _FinishedData.PlayerStats = BuildStats(statsJson);
            _FinishedData.CarId = JBot.GetInt( _Constants.Car, playerJson );
            _FinishedData.Id = JBot.GetPlayerId(playerJson);
            return _FinishedData;
        }

        private static PlayerStats BuildStats( JObject statsJson )
        {
            PlayerStats _FinishedData = JBot.CreateNewPlayerStats();
            List<string> StatHeadPropList= JBot.GetStatHeadProps();
            _FinishedData = JBot.AddData<PlayerStats>( _FinishedData, statsJson, StatHeadPropList);
            return _FinishedData;
        }
    }
}
