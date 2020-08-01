using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ReplayFx.Models.Frame
{
    class Hit
    {
        public int frameNumber { get; set; }
        public string playerId { get; set; }
        public double collisionDistance { get; set; }
        public double ballPosX { get; set; }
        public double ballPosY { get; set; }
        public double ballPosZ { get; set; }
        public double distance { get; set; }
        public double distanceToGoal { get; set; }
        public int nextHitFrameNumber { get; set; }
        public int goalNumber { get; set; }
        public bool isKickoff { get; set; }
    }
}
