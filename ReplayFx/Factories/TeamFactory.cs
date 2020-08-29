using Newtonsoft.Json.Linq;
using ReplayFx.Helpers;
using ReplayFx.Models;
using System.Collections.Generic;

namespace ReplayFx.Factories
{
    public class TeamFactory : _Factory
    {
        public static List<Team> Build( JArray teamListJson, GameMetadata metaData )
        {
            List<Team> _FinishedData = JBot.CreateList<Team>();
            foreach ( var item in teamListJson )
            {
                JObject teamJson = item.ToObject<JObject>();
                Team teamData = Build(teamJson);
                teamData.Name = teamData.Score == metaData.TeamAlphaScore ? TeamName.Alpha : TeamName.Bravo;
                _FinishedData.Add(teamData);
            }
            return _FinishedData;
        }

        private static Team Build( JObject teamJson )
        {
            Team _FinishedData = CreateTeam();
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
                string MemberProp = CreateMemberProp(count);
                modelJson[MemberProp] = playerId;
            }
            Team _FinishedData = _Factory.CreateModel<Team>(modelJson);
            return modelObj;
        }

        private static TeamStats BuildStats(  JObject statsJson )
        {
            TeamStats _FinishedData = CreateTeamStats();
            List<string> statHeader = JBot.GetStatHeadProps();
            _FinishedData = JBot.AddStats<TeamStats>( _FinishedData, statsJson, statHeader );
            return _FinishedData;
        }

        private static string CreateMemberProp( int count ) { return _Constants.Player + count.ToString() + _Constants.Id; }
    }
}
