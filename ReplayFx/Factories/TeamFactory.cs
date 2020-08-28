using Newtonsoft.Json.Linq;
using ReplayFx.Helpers;
using ReplayFx.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReplayFx.Factories
{
    public class TeamFactory : _Factory
    {

        public static List<Team> BuildTeamData(JArray teamdata,
                                               JArray rosterdata,
                                               JObject scoredata)
        {
            List<Team> _FinishedData = new List<Team>();

            Team TeamAlpha = new Team();
            TeamAlpha.Name = TeamName.Alpha;
            TeamAlpha.Score = JBot.ExtractInt(_Constants.TeamAlphaScore, scoredata);

            Team TeamBravo = new Team();
            TeamBravo.Name = TeamName.Bravo;
            TeamBravo.Score = JBot.ExtractInt(_Constants.TeamBravoScore, scoredata);
            foreach (var item in teamdata)
            {
                JObject team = JBot.CreateObject(item);
                var score = JBot.ExtractInt(_Constants.Score, team);
                if (score == TeamAlpha.Score)
                {
                    int count = 1;
                    JArray playerIds = JBot.ExtractArray(_Constants.PlayerIds, team);
                    JObject ModelObj = JBot.CreateObject(TeamAlpha);
                    foreach (var id in playerIds)
                    {
                        string propertyString = _Constants.Player
                                                + count.ToString()
                                                + _Constants.Id;
                        ModelObj[propertyString] = id;
                        count++;
                    }
                    TeamAlpha = JBot.CreateObject<Team>(ModelObj);
                }
                else
                {
                    int count = 1;
                    JArray playerIds = JBot.ExtractArray(_Constants.PlayerIds, team);
                    JObject ModelObj = JBot.CreateObject(TeamBravo);
                    foreach (var playerId in playerIds)
                    {
                        string propertyString = _Constants.Player
                                                + count.ToString()
                                                + _Constants.Id;
                        ModelObj[propertyString] = playerId;
                        count++;
                    }
                    TeamBravo = ModelObj.ToObject<Team>();
                }
                foreach (var Roster in rosterdata)
                {
                    JObject RosterData = JBot.CreateObject(Roster);
                    JArray playerIds = JBot.ExtractArray(_Constants.Members, RosterData);
                    if (StatBot.HasKey(playerIds, TeamAlpha.Player1Id))
                    {
                        TeamAlpha.LeaderId = JBot.ExtractInt(_Constants.LeaderId, RosterData);
                        JObject stats = JBot.ExtractObject(_Constants.Stats, RosterData);
                        //TeamAlpha.TeamStats = BuildStats<TeamStats>(TeamAlpha.TeamStats, stats);
                    }
                    else
                    {
                        TeamBravo.LeaderId = JBot.ExtractInt(_Constants.LeaderId, RosterData);
                        JObject stats = JBot.ExtractObject(_Constants.Stats, RosterData);
                        //TeamBravo.TeamStats = BuildStats<TeamStats>(TeamBravo.TeamStats, stats);
                    }
                }
            }
            _FinishedData.Add(TeamAlpha);
            _FinishedData.Add(TeamBravo);
            return _FinishedData;
        }

        public static void AddTeamMembers(JArray dataList, Team team)
        {
            string PropertyString = "";
            foreach (var item in dataList)
            {
                JObject _temp = JBot.CreateObject(item);
                var _score = JBot.ExtractInt(_Constants.Score, _temp);
                if (_score == team.Score)
                {
                    JArray playerIds = JBot.ExtractArray(_Constants.PlayerIds, _temp);
                    JObject modelObj = JBot.CreateObject(team);
                    int count = 1;
                    foreach (var playerId in playerIds)
                    {
                        PropertyString += _Constants.Player;
                        PropertyString += count.ToString();
                        PropertyString += _Constants.Id;
                        modelObj[PropertyString] = playerId;
                        count++;
                    }
                    //Team _FinishedData = JBot.CreateObject<Team>(team){ ...team };
                }
            }
        }
    }
}

