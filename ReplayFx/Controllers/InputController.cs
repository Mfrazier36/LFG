using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using ReplayFx.Helpers;
using ReplayFx.Models;

namespace ReplayFx.Controllers
{
    public class InputController : ControllerBase
    {
        private protected _DbContext _Context;
        public InputController(_DbContext Context)
        {
            _Context = Context;
        }
        public _DbContext DecompileReplay([FromBody] JObject jsonData)
        {

            JObject metaData = JBot.GetObject(_Constants.GameMetadata, jsonData);
            GameMetadata metadata = JBot.BuildMetaData(metaData);
            _Context.Add(metadata);

            JObject FrameData = JBot.GetObject(_Constants.gameStats, jsonData);
            List<Frame> framedata = JBot.BuildFrameData(FrameData);
            _Context.Add(framedata);
            
            JArray playerData = JBot.GetArray(_Constants.Players, jsonData);
            List<Player> playerdata = JBot.BuildPlayerData(playerData);
            _Context.Add(playerdata);
            
            JArray teamData = JBot.GetArray(_Constants.Teams, jsonData);
            JArray rosterData = JBot.GetArray(_Constants.Parties, jsonData);
            JObject scoreData = JBot.GetObject(_Constants.Score, metaData);
            List<Team> teamdata = JBot.BuildTeamData(teamData,rosterData, scoreData);
            _Context.Add(teamdata);

            return _Context;
        }
    }
}
