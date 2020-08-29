using Newtonsoft.Json.Linq;
using ReplayFx.Helpers;
using ReplayFx.Models;
using System.Collections.Generic;

namespace ReplayFx.Factories
{
    public class FrameFactory : _Factory
    {
        public static List<Frame> Build( JObject frameJsonObj )
        {
            List<Frame> _FinishedData = JBot.CreateList<Frame>();
            List<List<string>> _MetadataFrameSet = JBot.GetFrameHeadProps();
            foreach (List<string> propList in _MetadataFrameSet)
            {
                foreach (var property in propList)
                {
                    if( JBot.HasProp(property, frameJsonObj))
                    {
                        JArray frameJsonList = JBot.GetArray( property, frameJsonObj);
                        foreach (var frame in frameJsonList)
                        {
                            Frame _FinishedFrame = CreateFrame();
                            JObject frameJson = JBot.CreateObject(frame);
                            _FinishedFrame = BuildFrame(frameJson);
                        }
                    }
                }
            }
            return _FinishedData;
        }

        private static Frame BuildFrame(JObject frameJson)
        {
            Frame _FinishedData = CreateFrame();
            List<List<string>> _FrameProps = JBot.GetFrameProps();
            foreach (var propList in _FrameProps)
            {
                _FinishedData = TryAddValue(_FinishedData, propList, frameJson);
            }
            _FinishedData.PlayerId = JBot.GetPlayerId(frameJson);
            _FinishedData.AttackerId = JBot.GetAttackerId(frameJson);
            _FinishedData.VictimId = JBot.GetVictimId(frameJson);
            return _FinishedData;
        }

        private static Frame TryAddValue(Frame modelObj, List<string> propList, JObject frameJson)
        {
            Frame _FinishedData = CreateFrame();
            //foreach (var item in _Constants.KickoffHeadProps)
            //{
            //    if(JBot.HasProp<JObject>(item , frameJson))
            //    {
            //        frameJson
            //    }
            //}
            foreach (string jsonProp in propList)
            {
                _FinishedData = JBot.TryAddStat<Frame>(jsonProp, modelObj, frameJson);
            }
            return _FinishedData;
        }

        private static void CheckForTouch()
        {

        }
    }
}
