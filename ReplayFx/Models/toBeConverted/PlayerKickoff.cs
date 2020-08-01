using System;
using System.Collections.Generic;
using System.Text;

namespace ReplayFx.Models.Data
{
    class PlayerKickoff
    {
        public string playerId { get; set; }
        public string kickoffPosition { get; set; }
        public string touchPosition { get; set; }
        public double playerPosX { get; set; }
        public double playerPosY { get; set; }
        public double playerPosZ { get; set; }
        public double boostUsed { get; set; }
        public double ballDistance { get; set; }
        public double startPosX { get; set; }
        public double startPosY { get; set; }
        public double startPosZ { get; set; }
    }
}
