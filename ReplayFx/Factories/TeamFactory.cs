using Newtonsoft.Json.Linq;
using ReplayFx.Helpers;
using ReplayFx.Models;
using System.Collections.Generic;

namespace ReplayFx.Factories
{
    public class TeamFactory
    {
        public static void Build(JObject rawJson)
        {
            //TODO: Create BuildMethod
        }
        public static List<Team> BuildTeamList( JArray teamListJson, GameMetadata metaData )
        {
            List<Team> _FinishedData = JBot.CreateList<Team>();
            foreach ( var item in teamListJson )
            {
                JObject teamJson = JBot.CreateObject(item);
                Team teamData = BuildTeam(teamJson);
                teamData.Name = teamData.Score == metaData.TeamAlphaScore ? TeamName.Alpha : TeamName.Bravo;
                _FinishedData.Add(teamData);
            }
            return _FinishedData;
        }

        private static Team BuildTeam( JObject teamJson )
        {
            Team _FinishedData = JBot.CreateNewTeam();
            JObject statsJson = JBot.GetObject( _Constants.Stats, teamJson );
            _FinishedData = BuildRoster( _FinishedData, teamJson );
            _FinishedData.TeamStats = BuildStats(statsJson);
            _FinishedData.Id = JBot.GetInt( _Constants.Id, teamJson );
            _FinishedData.Score = JBot.GetInt( _Constants.Score, teamJson );
            return _FinishedData;
        }

        private static Team BuildRoster( Team modelObj, JObject teamJson )
        {
            JArray rosterJson = JBot.GetArray( _Constants.PlayerIds, teamJson );
            JObject modelJson = JBot.CreateObject(modelObj);
            int count = 1;
            foreach (var playerId in rosterJson)
            {
                string MemberProp = BuildMemberProp(count);
                modelJson[MemberProp] = playerId;
            }
            Team _FinishedData = JBot.CreateFromObject<Team>(modelJson);
            return modelObj;
        }

        private static TeamStats BuildStats(  JObject statsJson )
        {
            TeamStats _FinishedData = JBot.CreateNewTeamStats();
            List<string> statHeaderList = JBot.GetStatHeadProps();
            _FinishedData = JBot.AddData<TeamStats>( _FinishedData, statsJson, statHeaderList );
            return _FinishedData;
        }

        private static string BuildMemberProp( int count ) { return _Constants.Player + count.ToString() + _Constants.Id; }
    }
}
