using Newtonsoft.Json.Linq;
using ReplayFx.Helpers;
using ReplayFx.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReplayFx.Factories
{
    public class MetadataFactory : _Factory
    {
        public static GameMetadata Build(JObject metadata)
        {
            GameMetadata _FinishedData = new GameMetadata();

            _FinishedData = StatBot.AddStats<GameMetadata>(_FinishedData, metadata, _Constants.MetadataHeaderSet);
            _FinishedData.PrimaryPlayerId = (int)JBot.ExtractObject(_Constants.PrimaryPlayer, metadata)[_Constants.Id];

            return _FinishedData;
        }
    }
}
