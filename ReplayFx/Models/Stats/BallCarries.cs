using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReplayFx.Models
{
    public class BallCarries : Entry
    {
        public string AvgCarrySpeed { get; set; }
        public string DistanceAlongPath { get; set; }
        public string AvgCarryTime { get; set; }
        public string TotBallCarries { get; set; }
        public string LongestCarry { get; set; }
        public string FurthestCarry { get; set; }
        public string FastestCarrySpeed { get; set; }
        public string TotCarryDistance { get; set; }
        public string TotCarryTime { get; set; }
    }
}
