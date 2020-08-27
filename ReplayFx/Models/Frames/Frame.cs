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

        //public int PlayerId { get; set; }
        //public int AttackerId { get; set; }
        //public int VictimId { get; set; }
        public string FrameNumber { get; set; } = null;
        public string GoalNumber { get; set; } = null;


        public bool IsKickoff { get; set; } = false;
        public bool IsDemo { get; set; } = false;
        public bool HasFlick { get; set; } = false;
        public bool BoostUsed { get; set; } = false;
        public string TouchType { get; set; } = null;
        public string KickoffGoal { get; set; } = null;
        public string NextHitFrameNumber { get; set; } = null;
        public string StartFrameNumber { get; set; } = null;
        public string EndFrameNumber { get; set; } = null;
        public string StartFrame { get; set; } = null;
        public string TouchFrame { get; set; } = null;
        public string DistanceToGoal { get; set; } = null;
        public string TouchTime { get; set; } = null;
        public string FirstTouchPlayerId { get; set; } = null;
        public string CarryTime { get; set; } = null;
        public string StraightLineDistance { get; set; } = null;
        public string AvgCarrySpeed { get; set; } = null;
        public string BallDistance { get; set; } = null;
        public string Distance { get; set; } = null;
        public string CollisionDistance { get; set; } = null;
        public string DistanceAlongPath { get; set; } = null;
        public string AvgZDistance { get; set; } = null;
        public string AvgBallZVelocity { get; set; } = null;
        public string VarianceZDistance { get; set; } = null;
        public string VarianceBallZVelocity { get; set; } = null;
        public string KickoffPosition { get; set; } = null;
        public string TouchPosition { get; set; } = null;
        public string KickoffStartPosX { get; set; } = null;
        public string KickoffStartPosY { get; set; } = null;
        public string KickoffStartPosZ { get; set; } = null;
        public string PlayerPosX { get; set; } = null;
        public string PlayerPosY { get; set; } = null;
        public string PlayerPosZ { get; set; } = null;
        public string BallPosX { get; set; } = null;
        public string BallPosY { get; set; } = null;
        public string BallPosZ { get; set; } = null;
    }
}
