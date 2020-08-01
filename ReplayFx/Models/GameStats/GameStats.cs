using Newtonsoft.Json.Linq;
using ReplayFx.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReplayFx.Models.GameStats
{
    public class GameStats
    {
        public Hits[] hits { get; set; }
        public Bumps[] bumps { get; set; }
        public BallStats[] ballStats { get; set; }
        public Kickoffs[] kickoffs { get; set; }
        public KickoffStats[] kickoffStats { get; set; }
        public BallCarry[] ballCarries { get; set; }
        public string neutralPossessionTime { get; set; }

        public GameStats(JObject rawData)
        {
            Console.WriteLine("Model: [GameStats]");
            JArray hitData = CreateArray(rawData["hits"]);
            JArray bumpData = CreateArray(rawData["bumps"]);
            JArray ballStatData = CreateArray(rawData["ballStats"]);
            JArray kickoffFrameData = CreateArray(rawData["kickoffs"]);
            JArray kickoffStatData = CreateArray(rawData["kickoffStats"]);
            JArray ballCarryData = CreateArray(rawData["ballCarries"]);

            List<Hits> hitFrames = new List<Hits>();
            List<Bumps> BumpFrames = new List<Bumps>();
            List<BallStats> ballFrames = new List<BallStats>();
            List<Kickoffs> kickoffFrames = new List<Kickoffs>();
            List<KickoffStats> kickoffFrameStats = new List<KickoffStats>();
            List<BallCarry> ballCarryFrames = new List<BallCarry>();

            neutralPossessionTime = rawData["neutralPossessionTime"].ToString();
            foreach (var frame in hitData)
            {
                Hits hFrame = new Hits(CreateObject(frame));
                hitFrames.Add(hFrame);
            }
            foreach (var frame in hitData)
            {
                Bumps bFrame = new Bumps(CreateObject(frame));
                BumpFrames.Add(bFrame);
            }
            foreach (var frame in hitData)
            {
                BallStats bsFrame = new BallStats(CreateObject(frame));
                ballFrames.Add(bsFrame);
            }
            foreach (var frame in hitData)
            {
                Kickoffs koFrame = new Kickoffs(CreateObject(frame));
                kickoffFrames.Add(koFrame);
            }
            foreach (var frame in hitData)
            {
                KickoffStats kosFrame = new KickoffStats(CreateObject(frame));
                kickoffFrameStats.Add(kosFrame);
            }
            foreach (var frame in hitData)
            {
                BallCarry bcFrame = new BallCarry(CreateObject(frame));
                ballCarryFrames.Add(bcFrame);
            }
            hits = hitFrames.ToArray();
            bumps = BumpFrames.ToArray();
            ballStats = ballFrames.ToArray();
            kickoffs = kickoffFrames.ToArray();
            kickoffStats = kickoffFrameStats.ToArray();
            ballCarries = ballCarryFrames.ToArray();
        }

        public class Hits
        {
            public string frameNumber { get; set; }
            public string playerId { get; set; }
            public string collisionDistance { get; set; }
            public string ballPosX { get; set; }
            public string ballPosY { get; set; }
            public string ballPosZ { get; set; }
            public string distance { get; set; }
            public string distanceToGoal { get; set; }
            public string nextHitFrameNumber { get; set; }
            public string goalNumber { get; set; }
            public string isKickoff { get; set; }
            public Hits(JObject rawData)
            {
                Console.WriteLine("Model: [GameStats.Hits]");
                frameNumber = rawData["frameNumber"].ToString();
                playerId = rawData["playerId"].ToString();
                collisionDistance = rawData["collisionDistance"].ToString();
                ballPosX = rawData["ballPosX"].ToString();
                ballPosY = rawData["ballPosY"].ToString();
                ballPosZ = rawData["ballPosZ"].ToString();
                distance = rawData["distance"].ToString();
                distanceToGoal = rawData["distanceToGoal"].ToString();
                nextHitFrameNumber = rawData["nextHitFrameNumber"].ToString();
                goalNumber = rawData["goalNumber"].ToString();
                isKickoff = rawData["isKickoff"].ToString();
            }
        }
        public class Bumps
        {
            public string frameNumber { get; set; }
            public string attackerId { get; set; }
            public string victimId { get; set; }
            public string isDemo { get; set; }
            public Bumps(JObject rawData)
            {
                Console.WriteLine("Model: [GameStats.Bumps]");
                frameNumber = rawData["frameNumber"].ToString();
                attackerId = rawData["attackerId"].ToString();
                victimId = rawData["victimId"].ToString();
                isDemo = rawData["isDemo"].ToString();
            }
        }
        public class BallStats
        {
            public string timeOnGround { get; set; }
            public string timeLowInAir { get; set; }
            public string timeHighInAir { get; set; }
            public string timeInDefendingHalf { get; set; }
            public string timeInAttackingHalf { get; set; }
            public string timeInNeutralThird { get; set; }
            public string timeInAttackingThird { get; set; }
            public string timeInDefendingThird { get; set; }
            public string timeNearWall { get; set; }
            public string timeInCorner { get; set; }
            public string timeOnWall { get; set; }
            public string averageSpeed { get; set; }
            public string neutralPosessionTime { get; set; }
            public BallStats(JObject rawData)
            {
                Console.WriteLine("Model: [GameStats.BallStats]");
                timeOnGround = rawData["timeOnGround"].ToString();
                timeLowInAir = rawData["timeLowInAir"].ToString();
                timeHighInAir = rawData["timeHighInAir"].ToString();
                timeInDefendingHalf = rawData["timeInDefendingHalf"].ToString();
                timeInAttackingHalf = rawData["timeInAttackingHalf"].ToString();
                timeInNeutralThird = rawData["timeInNeutralThird"].ToString();
                timeInAttackingThird = rawData["timeInAttackingThird"].ToString();
                timeInDefendingThird = rawData["timeInDefendingThird"].ToString();
                timeNearWall = rawData["timeNearWall"].ToString();
                timeInCorner = rawData["timeInCorner"].ToString();
                timeOnWall = rawData["timeOnWall"].ToString();
                averageSpeed = rawData["averageSpeed"].ToString();
                neutralPosessionTime = rawData["neutralPosessionTime"].ToString();
            }
        }
        public class Kickoffs
        {
            public string startFrameNumber { get; set; }
            public string endFrameNumber { get; set; }
            public Kickoffs(JObject rawData)
            {
                Console.WriteLine("Model: [GameStats.Kickoffs]");
                startFrameNumber = rawData["startFrameNumber"].ToString();
                endFrameNumber = rawData["endFrameNumber"].ToString();
            }
        }
        public class KickoffStats
        {
            public string startFrame { get; set; }
            public string touchFrame { get; set; }
            public string touchTime { get; set; }
            public string type { get; set; }
            public string kickoffGoal { get; set; }
            public string firstTouchPlayerId { get; set; }
            public PlayerKickoffStats[] playerData { get; set; }

            public KickoffStats(JObject rawData)
            {
                Console.WriteLine("Model: [GameStats.KickoffStats]");
                startFrame = rawData["startFrame"].ToString();
                touchFrame = rawData["touchFrame"].ToString();
                touchTime = rawData["touchTime"].ToString();
                type = rawData["type"].ToString();
                kickoffGoal = rawData["touch.kickoffGoal"].ToString();
                firstTouchPlayerId = rawData["touch.firstTouchPlayer.id"].ToString();
                playerData = GetPlayerData(JArray.FromObject(rawData["touch.players"]));
            }
        }
        public class PlayerKickoffStats
        {
            public string playerId { get; set; }
            public string kickoffPosition { get; set; }
            public string touchPosition { get; set; }
            public string playerPosX { get; set; }
            public string playerPosY { get; set; }
            public string playerPosZ { get; set; }
            public string boostUsed { get; set; }
            public string ballDistance { get; set; }
            public string startPosX { get; set; }
            public string startPosY { get; set; }
            public string startPosZ { get; set; }

            public PlayerKickoffStats(JObject rawData)
            {
                Console.WriteLine("Model: [GameStats.PlayerKickoffStats]");
                playerId = rawData["player.id"].ToString();
                kickoffPosition = rawData["kickoffPosition"].ToString();
                touchPosition = rawData["touchPosition"].ToString();
                playerPosX = rawData["playerPosition.posX"].ToString();
                playerPosY = rawData["playerPosition.posY"].ToString();
                playerPosZ = rawData["playerPosition.posZ"].ToString();
                boostUsed = rawData["boostUsed"].ToString();
                ballDistance = rawData["ballDistance"].ToString();
                startPosX = rawData["startPosition.posX"].ToString();
                startPosY = rawData["startPosition.posY"].ToString();
                startPosZ = rawData["startPosition.posZ"].ToString();
            }
        }
        public class BallCarry
        {
            public string startFrameNumber { get; set; }
            public string endFrameNumber { get; set; }
            public string playerId { get; set; }
            public string hasFlick { get; set; }
            public string carryTime { get; set; }
            public string straightLineDistance { get; set; }
            public string averageZDistance { get; set; }
            public string averageBallZVelocity { get; set; }
            public string varianceZDistance { get; set; }
            public string varianceBallZVelocity { get; set; }
            public string averageCarrySpeed { get; set; }
            public string distanceAlongPath { get; set; }
            public BallCarry(JObject rawData)
            {
                Console.WriteLine("Model: [GameStats.BallCarry]");
                startFrameNumber = rawData["startFrameNumber"].ToString();
                endFrameNumber = rawData["endFrameNumber"].ToString();
                playerId = rawData["playerId.id"].ToString();
                hasFlick = rawData["hasFlick"].ToString();
                carryTime = rawData["carryTime"].ToString();
                straightLineDistance = rawData["straightLineDistance"].ToString();
                averageZDistance = rawData["carryStats.averageZDistance"].ToString();
                averageBallZVelocity = rawData["carryStats.averageBallZVelocity"].ToString();
                varianceZDistance = rawData["carryStats.varianceZDistance"].ToString();
                varianceBallZVelocity = rawData["carryStats.varianceBallZVelocity"].ToString();
                averageCarrySpeed = rawData["carryStats.averageCarrySpeed"].ToString();
                distanceAlongPath = rawData["carryStats.distanceAlongPath"].ToString();
            }
        }

        private JObject CreateObject(JToken data)
        {
            JObject dataObject = data.ToObject<JObject>();
            return dataObject;
        }
        private JArray CreateArray(JToken data)
        {
            JObject obj = CreateObject(data);
            JArray arr = obj.ToObject<JArray>();
            return arr;
        }

        public static JObject[] GetFrameData(JArray rawFrameData)
        {
            List<JObject> frameList = new List<JObject>();
            bool isFinished = false;
            int count = 0;
            while(!isFinished)
            {
                JObject frame;
                try
                {
                    frame = rawFrameData[count].ToObject<JObject>();
                    frameList.Add(frame);
                }
                catch
                {
                    isFinished = true;
                }
                count++;
            }
            JObject[] frameData = frameList.ToArray();
            return frameData;
        }

        public static PlayerKickoffStats[] GetPlayerData(JArray playerArray)
        {
            List<PlayerKickoffStats> playerData = new List<PlayerKickoffStats>();
            bool isFinished = false;
            int count = 0;
            while(!isFinished)
            {
                JObject player;
                try
                {
                    player = playerArray[count].ToObject<JObject>();
                    PlayerKickoffStats PlayerStats = new PlayerKickoffStats(player);
                    playerData.Add(PlayerStats);
                }
                catch
                {
                    isFinished = true;
                }
                count++;
            }
            PlayerKickoffStats[] playerStatList = playerData.ToArray();
            return playerStatList;
        }
    }
}
