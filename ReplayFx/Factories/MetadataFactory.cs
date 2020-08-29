using Newtonsoft.Json.Linq;
using ReplayFx.Helpers;
using ReplayFx.Models;
using System.Collections.Generic;

namespace ReplayFx.Factories
{
    public class MetadataFactory : _Factory
    {
        public static GameMetadata Build(JObject metadata)
        {
            GameMetadata _FinishedData = new GameMetadata();
            List<string> MetadataProps = JBot.GetMetadataProps();
            JObject PrimaryPlayerObj = JBot.GetObject(_Constants.PrimaryPlayer, metadata);
            JObject BallObj = JBot.GetObject(_Constants.BallData, metadata);

            _FinishedData = JBot.AddStats<GameMetadata>(_FinishedData, metadata, MetadataProps);
            _FinishedData.PrimaryPlayerId = JBot.GetInt(_Constants.Id, PrimaryPlayerObj);

            return _FinishedData;
        }
    }
}
