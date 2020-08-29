using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

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
        //public static List<IT> CreateList<IT>( IConvertible dataObj ) { return JObject.FromObject(dataObj ).ToObject<List<IT>>(); }
        public static List<IT> CreateList<IT>( IT dataObj ) { return JObject.FromObject(dataObj ).ToObject<List<IT>>(); }
        public static List<string> CreateList( ICollection<string> dataObj ) { return dataObj.ToList<string>(); }

        public static JObject CreateObject() { return new JObject(); }
        public static JObject CreateObject<IT>(IT Obj) { return JObject.FromObject(Obj); }
    }
}
