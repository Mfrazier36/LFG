using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReplayFx.Models
{
    public class Frame : Entry
    {
        //[Required] public FrameType FrameType { get; set; }
        //[Required] public int MatchId { get; set; }

        public int PlayerId { get; set; }
        public int AttackerId { get; set; }
        public int VictimId { get; set; }
        public int FrameNumber { get; set; }
        public int GoalNumber { get; set; }
        public int FirstTouchPlayerId { get; set; }


        public bool IsKickoff { get; set; } = false;
        public bool IsDemo { get; set; } = false;
        public bool HasFlick { get; set; } = false;
        public bool BoostUsed { get; set; } = false;
        public string TouchType { get; set; }
        public bool KickoffGoal { get; set; }
        public int NextHitFrameNumber { get; set; }
        public int StartFrameNumber { get; set; }
        public int EndFrameNumber { get; set; }
        public int StartFrame { get; set; }
        public int TouchFrame { get; set; }
        public double DistanceToGoal { get; set; }
        public double TouchTime { get; set; }
        public double CarryTime { get; set; }
        public double StraightLineDistance { get; set; }
        public double AvgCarrySpeed { get; set; }
        public double BallDistance { get; set; }
        public double Distance { get; set; }
        public double CollisionDistance { get; set; }
        public double DistanceAlongPath { get; set; }
        public double AvgZDistance { get; set; }
        public double AvgBallZVelocity { get; set; }
        public double VarianceZDistance { get; set; }
        public double VarianceBallZVelocity { get; set; }
        public string KickoffPosition { get; set; }
        public string TouchPosition { get; set; }
        public double KickoffStartPosX { get; set; }
        public double KickoffStartPosY { get; set; }
        public double KickoffStartPosZ { get; set; }
        public double PlayerPosX { get; set; }
        public double PlayerPosY { get; set; }
        public double PlayerPosZ { get; set; }
        public double BallPosX { get; set; }
        public double BallPosY { get; set; }
        public double BallPosZ { get; set; }
    }
}
