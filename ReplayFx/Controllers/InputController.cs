using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using ReplayFx.Factories;
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

            JObject metaData = JBot.ExtractObject(_Constants.GameMetadata, jsonData);
            GameMetadata metadata = MetadataFactory.Build(metaData);
            _Context.Add(metadata);

            JObject FrameData = JBot.ExtractObject(_Constants.gameStats, jsonData);
            List<Frame> framedata = JBot.CreateList<Frame>(FrameData);
            _Context.Add(framedata);
            
            JArray playerData = JBot.ExtractArray(_Constants.Players, jsonData);
            List<Player> playerdata = PlayerFactory.Build(playerData);
            _Context.Add(playerdata);
            
            JArray teamData = JBot.ExtractArray(_Constants.Teams, jsonData);
            JArray rosterData = JBot.ExtractArray(_Constants.Parties, jsonData);
            JObject scoreData = JBot.ExtractObject(_Constants.Score, metaData);
            List<Team> teamdata = TeamFactory.BuildTeamData(teamData,rosterData, scoreData);
            _Context.Add(teamdata);

            return _Context;
        }
    }
}
