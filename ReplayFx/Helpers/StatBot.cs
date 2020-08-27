using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json.Linq;
using ReplayFx.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReplayFx.Helpers
{
    public class StatBot
    {
        public static ObjTyp AddData<ObjTyp>(ObjTyp modelObject, JObject jsonObject, List<string> propertyList)
        {
            JObject modelJson = JObject.FromObject(modelObject);
            foreach (var jsonLabel in propertyList)
            {
                var NetLabel = nameof(jsonLabel);
                if (
                    modelJson.Properties().Contains((JProperty)NetLabel)
                    && jsonObject.Properties().Contains((JProperty)jsonLabel)
                    )
                {
                    var propertyValue = JBot.GetObject(jsonLabel, jsonObject);
                    modelJson[NetLabel] = propertyValue;
                }
            }
            ObjTyp _FinishedData = modelJson.ToObject<ObjTyp>();
            return _FinishedData;
        }

        public static List<Frame> FilterFrames(JObject jsonObj)
        {
            List<Frame> _FinishedData = new List<Frame>();
            foreach (var header in _Constants.GameStatsFrameSet)
            {
                if (jsonObj.ContainsKey(header))
                {
                    var frameJson = JBot.GetObject(header, jsonObj);
                    Frame Frame = JBot.BuildFrameData(frameJson);
                    _FinishedData.Add(Frame);
                }
            }
            foreach (var header in _Constants.MetadataFrameSet)
            {
                if (jsonObj.ContainsKey(header))
                {
                    var frameJson = JBot.GetObject(header, jsonObj);
                    Frame Frame = JBot.BuildFrameData(frameJson);
                    _FinishedData.Add(Frame);
                }
            }
            return _FinishedData;
        }

        public static ObjTyp FilterStats<ObjTyp>(ObjTyp modelObj, JObject jsonObj)
        {
            JObject modelJson = JObject.FromObject(modelObj);
            foreach (var prop in _Constants.HitCountSet)
            {
                var NetProp = JBot.GetNetKey(prop);
                if (modelJson.ContainsKey(NetProp))
                {
                    modelJson[NetProp] = jsonObj[prop];
                }
            }
            foreach (var prop in _Constants.BoostSet)
            {
                var NetProp = JBot.GetNetKey(prop);
                if (modelJson.ContainsKey(NetProp))
                {
                    modelJson[NetProp] = jsonObj[prop];
                }
            }
            foreach (var prop in _Constants.DistanceSet)
            {
                var NetProp = JBot.GetNetKey(prop);
                if (modelJson.ContainsKey(NetProp))
                {
                    modelJson[NetProp] = jsonObj[prop];
                }
            }
            foreach (var prop in _Constants.TendenciesSet)
            {
                var NetProp = JBot.GetNetKey(prop);
                if (modelJson.ContainsKey(NetProp))
                {
                    modelJson[NetProp] = jsonObj[prop];
                }
            }
            foreach (var prop in _Constants.BallCarrySet)
            {
                var NetProp = JBot.GetNetKey(prop);
                if (modelJson.ContainsKey(NetProp))
                {
                    modelJson[NetProp] = jsonObj[prop];
                }
            }
            foreach (var prop in _Constants.KickoffStatSet)
            {
                var NetProp = JBot.GetNetKey(prop);
                if (modelJson.ContainsKey(NetProp))
                {
                    modelJson[NetProp] = jsonObj[prop];
                }
            }
            ObjTyp _FinishedData = modelJson.ToObject<ObjTyp>();
            return _FinishedData;
        }
        public static ObjTyp ExtractPosition<ObjTyp>(ObjTyp destination, JObject source)
        {
            JObject destJson = JObject.FromObject(destination);

            destJson[_Constants.Pos_X] = source[_Constants.Pos_X];
            destJson[_Constants.Pos_Y] = source[_Constants.Pos_Y];
            destJson[_Constants.Pos_Z] = source[_Constants.Pos_Z];

            ObjTyp _FinishedData = destJson.ToObject<ObjTyp>();
            return _FinishedData;
        }
        public static Frame ExtractIdsFromFrame(Frame modelObj ,JObject jsonObj)
        {
            if( jsonObj.ContainsKey(_Constants.Player) 
                || jsonObj.ContainsKey(_Constants.PlayerId))
            {
                modelObj.PlayerId = GetPlayerId(jsonObj);
            }
            if (jsonObj.ContainsKey(_Constants.VictimId))
            {
                modelObj.VictimId = GetVictimId(jsonObj);
            }
            if (jsonObj.ContainsKey(_Constants.AttackerId))
            {
                modelObj.VictimId = GetAttackerId(jsonObj);
            }
            return modelObj;
        }
        public static int GetPlayerId(JObject playerdata)
        {
            string ConstantKey = (playerdata.ContainsKey(_Constants.Player) 
                                 ? _Constants.Player 
                                 : _Constants.PlayerId );
            JObject keyObj = JBot.GetObject(ConstantKey, playerdata);
            int Id = GetInt(_Constants.Id, keyObj);
            return Id;
        }
        public static int GetVictimId(JObject playerdata)
        {
            JObject keyObj = JBot.GetObject(_Constants.VictimId, playerdata);
            int Id = GetInt(_Constants.Id, keyObj);
            return Id;
        }
        public static int GetAttackerId(JObject playerdata)
        {
            JObject keyObj = JBot.GetObject(_Constants.AttackerId, playerdata);
            int Id = GetInt(_Constants.Id, keyObj);
            return Id;
        }
        public static int GetInt(string Key, JObject Obj) { return (int)Obj[Key]; }
    public static string GetString(string key, JObject Obj) { return (string)Obj[key]; }
    public static double GetDouble(string Key, JObject Obj) { return (double)Obj[Key]; }

    }
}
