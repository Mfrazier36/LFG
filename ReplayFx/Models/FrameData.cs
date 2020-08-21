using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Text.RegularExpressions;

//    public class GameStats
//{
//    public Hits[] hits { get; set; }
//    public Bumps[] bumps { get; set; }
//    public BallStats[] ballStats { get; set; }
//    public Kickoffs[] kickoffs { get; set; }
//    public KickoffStats[] kickoffStats { get; set; }
//    public BallCarry[] ballCarries { get; set; }
//    public string neutralPossessionTime { get; set; } // BALLDATA
namespace ReplayFx.Models
{ 
    public enum FrameType
    {
        Kickoff, Carry, Bump, Hit, Demo, Goal,
    }
    public class FrameData : DbEntry
    {
        [Key]
        public string FrameId { get; set; }
        public Guid MatchGuid { get; set; }
        public string Type { get; set; } = null;
        public int? PlayerId { get; set; } = null;
        public int? AttackerId { get; set; } = null;
        public int? VictimId { get; set; } = null;
        public string FrameNumber { get; set; } = null;
        public string IsKickoff { get; set; } = null;
        public string KickoffGoal { get; set; } = null;
        public string HasFlick { get; set; } = null;
        public string IsDemo { get; set; } = null;
        public string BoostUsed { get; set; } = null;
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
        public string GoalNumber { get; set; } = null;
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

        public BallData BallData { get; set; }
        public MatchData MatchData { get; set; }
        public PlayerData PlayerData { get; set; }
    }
}
