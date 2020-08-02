﻿using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IronPython;
using IronPython.Hosting;
using System.IO;
//using IronPython.Hosting;
//using Microsoft.Scripting;
using Microsoft.Scripting.Hosting;
using Newtonsoft.Json.Linq;

namespace ReplayFx.Services
{
    public class Svc_Carball
    {

        public static void AnalyzeReplay(string fileString)
        {
            //var carBallFunc = "decompile_replay";

            var pythonEngine = Python.CreateEngine();

            var EngineScope = pythonEngine.CreateScope();
            string carballFileName =  Path.GetRelativePath("../..", "../lib/carball/carball/__init__.py");

            var source = pythonEngine.CreateScriptSourceFromFile(carballFileName);

            var compiledCode = source.Compile();

            var carballCmd = $"carball -i ${fileString} --json dumpFile.json";

            var carballScript = new JObject(carballCmd)
                                        .ToObject<ScriptScope>();

            var result = compiledCode.Execute(carballScript);
            

        }
    }
}
