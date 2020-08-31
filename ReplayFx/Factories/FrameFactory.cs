using Newtonsoft.Json.Linq;
using ReplayFx.Helpers;
using ReplayFx.Models;
using System.Collections.Generic;

namespace ReplayFx.Factories
{
    public class FrameFactory
    {
        public static List<Frame> Build(JObject rawJson)
        {
            List<Frame> _FinishedData = JBot.CreateList<Frame>();
            JObject metaJson = JBot.GetObject( _Constants.GameMetadata, rawJson );
            JObject gamestatJson = JBot.GetObject( _Constants.gameStats, rawJson );
            _FinishedData = JBot.AddData<Frame>( _FinishedData, BuildFrameList(metaJson) );
            _FinishedData = JBot.AddData<Frame>( _FinishedData, BuildFrameList(gamestatJson) );
            return _FinishedData;
        }

        public static List<Frame> BuildFrameList( JObject frameJsonObj )
        {
            List<Frame> _FinishedData = JBot.CreateList<Frame>();
            List<List<string>> _MetadataFrameSet = JBot.GetFrameHeadProps();
            foreach (List<string> propList in _MetadataFrameSet)
            {
                foreach (var jsonProp in propList)
                {
                    if( JBot.HasProp(jsonProp, frameJsonObj) )
                    {
                        JArray frameJsonList = JBot.GetArray( jsonProp, frameJsonObj);
                        foreach (var frameJsonData in frameJsonList)
                        {
                            JObject frameJson = JBot.CreateObject(frameJsonData);
                            Frame _FinishedFrame = JBot.CreateNewFrame();
                            _FinishedFrame = BuildFrame(frameJson);
                        }
                    }
                }
            }
            return _FinishedData;
        }

        private static Frame BuildFrame(JObject frameJson)
        {
            Frame _FinishedData = JBot.CreateNewFrame();
            List<List<string>> _FrameProps = JBot.GetFrameProps();
            foreach (var propList in _FrameProps)
            {
                _FinishedData = BuildFrameData( _FinishedData, propList, frameJson );
            }
            _FinishedData.PlayerId = JBot.GetPlayerId(frameJson);
            _FinishedData.AttackerId = JBot.GetAttackerId(frameJson);
            _FinishedData.VictimId = JBot.GetVictimId(frameJson);
            return _FinishedData;
        }

        private static Frame BuildFrameData(Frame modelObj, List<string> propList, JObject frameJson)
        {
            Frame _FinishedData = JBot.CreateNewFrame();
            foreach (string jsonProp in propList)
            {
                _FinishedData = JBot.TryAddData<Frame>( jsonProp, modelObj, frameJson );
            }
            //TODO: Create Build Touch Frame Process
            return _FinishedData;
        }

        private static void CheckForTouch()
        {
            //TODO: Create CheckMethod
        }
    }
}
