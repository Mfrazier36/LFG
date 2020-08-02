using System;
using ReplayFx.Services;

namespace ReplayFx
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Replay File Name!");
            var userInput = Console.ReadLine();
            Svc_Carball.AnalyzeReplay(userInput.ToString());
            Console.ReadLine();
        }
    }
}
