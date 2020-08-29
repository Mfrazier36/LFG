﻿using Newtonsoft.Json.Linq;
using ReplayFx.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Xps.Serialization;

namespace ReplayFx.Helpers
{ 
    public class Tool_Props : Tool_Console
    {
        public static string GetNetProp( string Key) { return nameof( Key); }

        public static bool HasProp( IConvertible Key, JObject Obj ) { return Obj.ContainsKey( Key.ToString() ); }
        public static bool HasProp( IConvertible Key, JArray arr ) { return arr.Contains( Key.ToString() ); }
        public static bool HasProp<IT>( IConvertible Key, IT obj ) { return JObject.FromObject(obj ).ContainsKey( Key.ToString() ); }

        public static IConvertible ReturnIf (bool condition, IConvertible isTrue, IConvertible isFalse ) { return (condition ? isTrue : isFalse); }
        public static string ReturnIf(bool condition, string isTrue, string isFalse ) { return (condition ? isTrue : isFalse); }
        public static string ReturnIf(bool condition, string isTrue ) { return (condition ? isTrue : ""); }

    }
}