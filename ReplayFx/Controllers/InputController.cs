using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using ReplayFx.Factories;
using ReplayFx.Helpers;
using ReplayFx.Models;
using System.Collections.Generic;

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
            GameMetadata metadata = MetadataFactory.Build(metaData);
            _Context.Add(metadata);
            JObject FrameData = JBot.GetObject(_Constants.gameStats, jsonData);
            List<Frame> framedata = FrameFactory.Build(FrameData);
            _Context.Add(framedata);
            JArray playerData = JBot.GetArray(_Constants.Players, jsonData);
            List<Player> playerdata = PlayerFactory.Build(playerData);
            _Context.Add(playerdata);
            JArray teamData = JBot.GetArray(_Constants.Teams, jsonData);
            JArray rosterData = JBot.GetArray(_Constants.Parties, jsonData);
            JObject scoreData = JBot.GetObject(_Constants.Score, metaData);
            List<Team> teamdata = TeamFactory.Build(teamData, metadata);
            _Context.Add(teamdata);
            return _Context;
        }
    }
}
