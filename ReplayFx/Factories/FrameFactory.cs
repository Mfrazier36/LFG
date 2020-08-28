using Newtonsoft.Json.Linq;
using ReplayFx.Helpers;
using ReplayFx.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReplayFx.Factories
{
    public class FrameFactory : _Factory
    {
        public static Frame Build(JObject framedata)
        {
            Frame _FinishedData = new Frame();

            bool hasStartFrame = framedata.ContainsKey(_Constants.StartFrame);
            bool hasStartFrameNbr = framedata.ContainsKey(_Constants.StartFrameNumber);
            bool hasEndFrame = framedata.ContainsKey(_Constants.EndFrameNumber);
            bool isHitFrame = framedata.ContainsKey(_Constants.CollisionDistance);
            bool isKickoffFrame = framedata.ContainsKey(_Constants.Touch);
            bool isBumpFrame = framedata.ContainsKey(_Constants.IsDemo); // Attacker Victim


            _FinishedData.FrameNumber = JBot.ExtractInt(_Constants.FrameNumber, framedata);
            _FinishedData = ExtractIdsFromFrame(_FinishedData, framedata);
            if (framedata.ContainsKey(_Constants.IsDemo))
            {
                _FinishedData.IsDemo = (bool)framedata[_Constants.IsDemo];
            }
            if (framedata.ContainsKey(_Constants.CollisionDistance))
            {
                _FinishedData = StatBot.AddStats<Frame>(_FinishedData, framedata, _Constants.HitFrameSet);
            }
            if (framedata.ContainsKey(_Constants.Touch))
            {
                _FinishedData = StatBot.AddStats<Frame>(_FinishedData, framedata, _Constants.KickoffFrameSet);
            }
            return _FinishedData;
        }

        public static List<Frame> Build(JArray framedata)
        {
            List <Frame> _FinishedData = JBot.CreateList<Frame>();



            return _FinishedData;
        }
        public static List<Frame> ExtractFrames(JObject jsonObj)
        {
            List<Frame> _FinishedData = JBot.CreateList<Frame>();
            foreach (var header in _Constants.GameStatsFrameSet)
            {
                if (jsonObj.ContainsKey(header))
                {
                    var frameJson = JBot.ExtractObject(header, jsonObj);
                    Frame Frame = FrameFactory.Build(frameJson);
                    _FinishedData.Add(Frame);
                }
            }
            foreach (var header in _Constants.MetadataFrameSet)
            {
                if (jsonObj.ContainsKey(header))
                {
                    var frameJson = JBot.ExtractObject(header, jsonObj);
                    Frame Frame = FrameFactory.Build(frameJson);
                    _FinishedData.Add(Frame);
                }
            }
            return _FinishedData;
        }

        public static Frame ExtractIdsFromFrame(Frame modelObj, JObject jsonObj)
        {
            if (JBot.HasProp(_Constants.Player, jsonObj)
                || JBot.HasProp<Frame>( _Constants.PlayerId, modelObj))
            {
                modelObj.PlayerId = StatBot.ExtractPlayerId(jsonObj);
            }
            if (jsonObj.ContainsKey(_Constants.VictimId))
            {
                modelObj.VictimId = StatBot.ExtractVictimId(jsonObj);
            }
            if (jsonObj.ContainsKey(_Constants.AttackerId))
            {
                modelObj.VictimId = StatBot.ExtractAttackerId(jsonObj);
            }
            return modelObj;
        }
    }
}
