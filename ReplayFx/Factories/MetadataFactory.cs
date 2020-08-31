using Newtonsoft.Json.Linq;
using ReplayFx.Helpers;
using ReplayFx.Models;
using System.Collections.Generic;

namespace ReplayFx.Factories
{
    public class MetadataFactory
    {
        public static GameMetadata BuildMetadata( JObject metadata )
        {
            GameMetadata _FinishedData = JBot.CreateNewMetadata();
            List<string> MetadataProps = JBot.GetMetadataProps();
            JObject PrimaryPlayerObj = JBot.GetObject( _Constants.PrimaryPlayer, metadata );
            JObject BallObj = JBot.GetObject( _Constants.BallData, metadata );

            _FinishedData = JBot.AddData<GameMetadata>( _FinishedData, metadata, MetadataProps );
            _FinishedData.PrimaryPlayerId = JBot.GetInt( _Constants.Id, PrimaryPlayerObj );

            return _FinishedData;
        }
        public static Ball BuildBalldata(JObject ballData)
        {
            Ball _FinishedData = JBot.CreateNewBall();

            //TODO: Create Build Ball Data Method

            return _FinishedData;
        }
    }
}
