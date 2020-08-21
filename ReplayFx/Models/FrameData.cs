using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

//    public class GameStats
//{
//    public Hits[] hits { get; set; }
//    public Bumps[] bumps { get; set; }
//    public BallStats[] ballStats { get; set; }
//    public Kickoffs[] kickoffs { get; set; }
//    public KickoffStats[] kickoffStats { get; set; }
//    public BallCarry[] ballCarries { get; set; }
//    public string neutralPossessionTime { get; set; }
namespace ReplayFx.Models
{ 
    public enum FrameType
    {
        Kickoff, Carry, Bump, Hit, Demo, Goal,
    }
    public class FrameData
    {
        [Key]
        public string id { get; set; }
        public string type { get; set; } = null;
        public Guid matchGuid { get; set; }
        public int? playerId { get; set; } = null;
        public int? attackerId { get; set; } = null;
        public int? victimId { get; set; } = null;
        public string frameNumber { get; set; } = null;
        public string isKickoff { get; set; } = null;
        public string kickoffGoal { get; set; } = null;
        public string hasFlick { get; set; } = null;
        public string isDemo { get; set; } = null;
        public string boostUsed { get; set; } = null;
        public string nextHitFrameNumber { get; set; } = null;
        public string startFrameNumber { get; set; } = null;
        public string endFrameNumber { get; set; } = null;
        public string startFrame { get; set; } = null;
        public string touchFrame { get; set; } = null;
        public string distanceToGoal { get; set; } = null;
        public string touchTime { get; set; } = null;
        public string firstTouchPlayerId { get; set; } = null;
        public string carryTime { get; set; } = null;
        public string straightLineDistance { get; set; } = null;
        public string averageCarrySpeed { get; set; } = null;
        public string ballDistance { get; set; } = null;
        public string distance { get; set; } = null;
        public string collisionDistance { get; set; } = null;
        public string goalNumber { get; set; } = null;
        public string distanceAlongPath { get; set; } = null;
        public string averageZDistance { get; set; } = null;
        public string averageBallZVelocity { get; set; } = null;
        public string varianceZDistance { get; set; } = null;
        public string varianceBallZVelocity { get; set; } = null;
        public string kickoffPosition { get; set; } = null;
        public string touchPosition { get; set; } = null;
        public string kickoffStartPosX { get; set; } = null;
        public string kickoffStartPosY { get; set; } = null;
        public string kickoffStartPosZ { get; set; } = null;
        public string playerPosX { get; set; } = null;
        public string playerPosY { get; set; } = null;
        public string playerPosZ { get; set; } = null;
        public string ballPosX { get; set; } = null;
        public string ballPosY { get; set; } = null;
        public string ballPosZ { get; set; } = null;

            
    }
}
