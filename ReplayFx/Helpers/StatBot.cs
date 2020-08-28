using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json.Linq;
using ReplayFx.Factories;
using ReplayFx.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReplayFx.Helpers
{
    public class StatBot : Bot
    {
        public static int ExtractPlayerId(JObject playerdata)
        {
            string _ConstantKey = ReturnIf( HasProp( _Constants.Player, playerdata ),
                                             _Constants.Player, _Constants.PlayerId );

            JObject keyObj = JBot.ExtractObject(_ConstantKey, playerdata);

            return JBot.ExtractInt(_Constants.Id, keyObj); ;
        }
        public static int ExtractVictimId(JObject playerdata)
        {
            JObject keyObj = JBot.ExtractObject(_Constants.VictimId, playerdata);

            return JBot.ExtractInt(_Constants.Id, keyObj);
        }
        public static int ExtractAttackerId(JObject playerdata)
        {
            JObject keyObj = JBot.ExtractObject(_Constants.AttackerId, playerdata);
            return JBot.ExtractInt(_Constants.Id, keyObj);
        }

        public static ObjTyp AddStats<ObjTyp>(ObjTyp modelObject, JObject jsonObject, List<string> propertyList)
        {
            JObject modelJson = JBot.CreateObject(modelObject);
            foreach (var jsonLabel in propertyList)
            {
                var NetLabel = nameof(jsonLabel);
                if (
                    HasProp(NetLabel, modelJson)
                    && HasProp(jsonLabel, jsonObject)
                    )
                {
                    var propertyValue = JBot.ExtractObject(jsonLabel, jsonObject);
                    modelJson[NetLabel] = propertyValue;
                }
            }
            ObjTyp _FinishedData = _Factory.CreateModel<ObjTyp>(modelJson);
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
        public static ObjTyp ExtractStats<ObjTyp>(ObjTyp modelObj, JObject jsonObj)
        {
            JObject modelJson = JBot.CreateObject(modelObj);
            foreach (var prop in _Constants.HitCountSet)
            {
                var NetProp = ExtractNetKey(prop);
                if (HasProp(NetProp,modelJson))
                {
                    modelJson[NetProp] = jsonObj[prop];
                }
            }
            foreach (var prop in _Constants.BoostSet)
            {
                var NetProp = ExtractNetKey(prop);
                if (HasProp(NetProp,modelJson))
                {
                    modelJson[NetProp] = jsonObj[prop];
                }
            }
            foreach (var prop in _Constants.DistanceSet)
            {
                var NetProp = ExtractNetKey(prop);
                if (HasProp(NetProp, modelJson))
                {
                    modelJson[NetProp] = jsonObj[prop];
                }
            }
            foreach (var prop in _Constants.TendenciesSet)
            {
                var NetProp = ExtractNetKey(prop);
                if (HasProp(NetProp, modelJson))
                {
                    modelJson[NetProp] = jsonObj[prop];
                }
            }
            foreach (var prop in _Constants.BallCarrySet)
            {
                var NetProp = ExtractNetKey(prop);
                if (HasProp(NetProp,modelJson))
                {
                    modelJson[NetProp] = jsonObj[prop];
                }
            }
            foreach (var prop in _Constants.KickoffStatSet)
            {
                var NetProp = ExtractNetKey(prop);
                if (HasProp(NetProp,modelJson))
                {
                    modelJson[NetProp] = jsonObj[prop];
                }
            }
            ObjTyp _FinishedData = modelJson.ToObject<ObjTyp>();
            return _FinishedData;
        }
    }
}
