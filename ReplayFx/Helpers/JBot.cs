using Newtonsoft.Json.Linq;
using ReplayFx.Models;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;

namespace ReplayFx.Helpers
{
    public class JBot : _ToolBag
    {
        public static int GetInt( string Key, JObject Obj ) { return (int)Obj[Key]; }
        public static string GetString( string key, JObject Obj ) { return ( string)Obj[key]; }
        public static double GetDouble( string Key, JObject Obj ) { return (double)Obj[Key]; }
        public static JArray GetArray( string Key, JObject Obj ) { return JArray.FromObject(Obj[Key]); }
        public static JObject GetObject( string Key, JObject Obj ) { return JObject.FromObject(Obj[Key]); }
        public static JArray CreateArray() { return new JArray(); }
        public static List<IT> CreateList<IT>() { return new List<IT>(); }
        public static List<IT> CreateList<IT>( IT dataObj ) { return JObject.FromObject(dataObj ).ToObject<List<IT>>(); }
        public static List<string> CreateList( ICollection<string> dataObj ) { return dataObj.ToList<string>(); }
        public static JObject CreateObject() { return new JObject(); }
        public static JObject CreateObject<IT>( IT Obj ) { return JObject.FromObject(Obj); }
        public static Obj CreateFromObject<Obj>( JObject dataObj ) { return dataObj.ToObject<Obj>(); }
        public static List<Obj> AddData<Obj>( List<Obj> target, List<Obj> source )
        {
            List<Obj> _FinishedData = new List<Obj>(target);
            foreach (var item in source)
            {
                _FinishedData.Add(item);
            }
            return _FinishedData;
        }
        public static ObjTyp AddData<ObjTyp>( ObjTyp modelObject, JObject jsonObject, List<string> propertyList )
        {
            JObject modelJson = CreateObject(modelObject);
            foreach (var jsonLabel in propertyList)
            {
                var NetLabel = nameof(jsonLabel);
                if (
                    HasProp(NetLabel, modelJson)
                    && HasProp(jsonLabel, jsonObject)
                    )
                {
                    var propertyValue = GetObject(jsonLabel, jsonObject);
                    modelJson[NetLabel] = propertyValue;
                }
            }
            ObjTyp _FinishedData = CreateFromObject<ObjTyp>(modelJson);
            return _FinishedData;
        }


        public static ObjTyp TryAddData<ObjTyp>( string Prop, ObjTyp modelObj, JObject jsonObj )
        {
            string netProp = GetNetProp(Prop);
            JObject modelJson = CreateObject(modelObj);
            if (HasProp(netProp, modelJson) && HasProp(Prop, jsonObj))
            {
                modelJson[netProp] = jsonObj[Prop];
            }
            ObjTyp _FinishedData = CreateFromObject<ObjTyp>(modelJson);
            return _FinishedData;
        }
    }
}
