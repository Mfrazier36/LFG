using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json.Linq;
using ReplayFx.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ReplayFx.Helpers
{
    public class JBot : Bot
    {
        public static int ExtractInt(string Key, JObject Obj) { return (int)Obj[Key]; }
        public static string ExtractString(string key, JObject Obj) { return (string)Obj[key]; }
        public static double ExtractDouble(string Key, JObject Obj) { return (double)Obj[Key]; }
        public static List<string> CreateList(ICollection<string> dataObj) { return dataObj.ToList<string>(); }
        public static List<Obj> CreateList<Obj>() { return new List<Obj>(); }
        public static List<Obj> CreateList<Obj>(Obj dataObj) { return CreateObject(dataObj).ToObject<List<Obj>>(); }
        public static List<Obj> CreateList<Obj>(JObject dataObj) { return dataObj.ToObject<List<Obj>>(); }
        public static JArray CreateArray() { return new JArray(); }
        public static JArray ExtractArray(string Key, JObject Obj) { return JArray.FromObject(Obj[Key]); }
        public static JObject CreateObject() { return new JObject(); }
        public static JObject ExtractObject(string Key, JObject Obj) { return JObject.FromObject(Obj[Key]); }
        public static JObject CreateObject<Obj>(Obj dataObj) { return JObject.FromObject(dataObj); }
    }
}
