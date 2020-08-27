using Microsoft.AspNetCore.DataProtection;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ReplayFx.Helpers
{
    public class JBot : Bot
    {
        private static FileStream _Reader;
        readonly static string RootPath = "~\\";
        readonly static string CarballPath = "~\\wwwroot\\lib\\carball\\init.py";

        readonly static string InputOutputFilePath = Path.GetRelativePath(RootPath, CarballPath);
        readonly static string InputFileName = "Input.replay";
        readonly static string OutputFileName = "Output.json";
        

        private ProcessStartInfo BuildCarballProcess(ICollection<string> _FilePaths)
        {
            Console.WriteLine("FilePaths", _FilePaths.ToString());

            //string commandString = BuildCommandString(_FilePaths);

            ProcessStartInfo cmdProcess = new ProcessStartInfo();

            //cmdProcess.WorkingDirectory = CarballDirectory;
            //cmdProcess.FileName = CarballFileName;
            //cmdProcess.Arguments = commandString;
            cmdProcess.Verb = "runas";
            cmdProcess.UseShellExecute = true;
            cmdProcess.RedirectStandardOutput = true;
            cmdProcess.WindowStyle = ProcessWindowStyle.Hidden;

            return cmdProcess;
        }
    }

    public class Bot
    {
        public static string GetNetKey(string Key) { return nameof(Key); }
        public static JObject GetObject(string Key, JObject Obj) { return JObject.FromObject(Obj[Key]); }
        public static JArray GetArray(string Key, JObject Obj) { return JArray.FromObject(Obj[Key]); }
        public static int GetInt(string Key, JObject Obj) { return (int)Obj[Key]; }
        public static string GetString(string key, JObject Obj) { return (string)Obj[key]; }
        public static double GetDouble(string Key, JObject Obj) { return (double)Obj[Key]; }
    }
}
