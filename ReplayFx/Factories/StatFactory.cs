using Newtonsoft.Json.Linq;
using ReplayFx.Helpers;
using ReplayFx.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReplayFx.Factories
{
    public class StatFactory : _Factory
    {

        public static ObjTyp Build<ObjTyp>(ObjTyp modelObj, JObject statsObj)
        {
            List<string> headerProps = _Constants.StatsHeaderSet;

            JObject modelJson = JObject.FromObject(modelObj);

            foreach (var jsonLabel in headerProps)
            {
                JObject statJson = ExtractObject(jsonLabel, statsObj);

                if (statJson.HasValues)
                {
                    modelJson = StatBot.ExtractStats<JObject>(statJson, modelJson);
                }
            }

            ObjTyp _FinishedData = JObject.FromObject(statsObj).ToObject<ObjTyp>();

            return _FinishedData;
        }
       

       

    }
}
