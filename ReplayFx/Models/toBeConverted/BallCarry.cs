using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReplayFx.Models.Data
{
    public class BallCarry
    {
        public string playerId { get; set; }
        public bool hasFlick { get; set; }
        public double carryTime { get; set; }
        public double straightLineDistance { get; set; }
        public double averageZDistance { get; set; }
        public double averageBallZVelocity { get; set; }
        public double varianceZDistance { get; set; }
        public double varianceBallZVelocity { get; set; }
        public double averageCarrySpeed { get; set; }
        public double distanceAlongPath { get; set; }
    }
}
