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

            JObject metaData = JBot.GetObject(_Constants.GameMetadata, jsonData);
            //GameMetadata metadata = XMetadataFactory.Build(metaData);
            //_Context.Add(metadata);

            JObject FrameData = JBot.GetObject(_Constants.gameStats, jsonData);
            //List<Frame> framedata = JBot.CreateList<Frame>(FrameData);
            //_Context.Add(framedata);
            
            JArray playerData = JBot.GetArray(_Constants.Players, jsonData);
            //List<Player> playerdata = XPlayerFactory.Build(playerData);
            //_Context.Add(playerdata);
            
            JArray teamData = JBot.GetArray(_Constants.Teams, jsonData);
            JArray rosterData = JBot.GetArray(_Constants.Parties, jsonData);
            JObject scoreData = JBot.GetObject(_Constants.Score, metaData);

            //List<Team> teamdata = XTeamFactory.BuildTeamData(teamData,rosterData, scoreData);
            //_Context.Add(teamdata);

            return _Context;
        }
    }
}
