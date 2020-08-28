using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ReplayFx.Helpers
{
    public class DataBot
    {
        readonly static string _CurrentLocation = ".";
        readonly static string _CarballPath = "~\\wwwroot\\lib\\carball\\init.py";
        readonly static string InputOutputFilePath = Path.GetRelativePath(_CurrentLocation, _CarballPath);
        readonly static string InputFileName = "Input.replay";
        readonly static string OutputFileName = "Output.json";


        private ProcessStartInfo BuildCarballProcess(ICollection<string> _filePaths)
        {
            Console.WriteLine("FilePaths", _filePaths.ToString());

            var _CommandString = BuildCommandString(_filePaths);
            ProcessStartInfo cmdProcess = new ProcessStartInfo();

            cmdProcess.WorkingDirectory = Path.GetDirectoryName(_CarballPath);
            cmdProcess.FileName = Path.GetFileName(_CarballPath);
            cmdProcess.Arguments = _CommandString;
            cmdProcess.Verb = "runas";
            cmdProcess.UseShellExecute = true;
            cmdProcess.RedirectStandardOutput = true;
            cmdProcess.WindowStyle = ProcessWindowStyle.Hidden;

            return cmdProcess;
        }

        private static string BuildCommandString(ICollection<string> _filePaths)
        {
            string CarballCmd = "/c carball -i ";
            int length = _filePaths.Count;
            int count = 1;
            foreach (var path in _filePaths)
            {
                CarballCmd += path;
                if (count != length) CarballCmd += ", ";
                count++;
            }
            CarballCmd += "--json ";
            CarballCmd += OutputFileName;
            return CarballCmd;
        }
    }
}
