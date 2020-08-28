using Newtonsoft.Json.Linq;
using ReplayFx.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Xps.Serialization;

namespace ReplayFx.Helpers
{
    public class Bot
    {
        public static string ExtractNetKey(string Key) { return nameof(Key); }
        public static bool HasProp(IConvertible Key, JObject Obj) { return Obj.ContainsKey(Key.ToString()); }
        public static bool HasProp(IConvertible Key, JArray arr) { return arr.Contains(Key.ToString()); }
        public static bool HasProp<Obj>(IConvertible Key, Obj obj) { return JObject.FromObject(obj).ContainsKey(Key.ToString()); }
        public static IConvertible ReturnIf (bool condition, IConvertible isTrue, IConvertible isFalse ) { return (condition ? isTrue : isFalse); }
        public static string ReturnIf(bool condition, string isTrue, string isFalse ) { return (condition ? isTrue : isFalse); } 
    }
}
