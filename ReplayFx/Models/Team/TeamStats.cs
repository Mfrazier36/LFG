using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading.Tasks;

namespace ReplayFx.Models.Team
{
    public class TeamStats
    {
        public Posession posession { get; set; }
        public HitCounts hitCounts { get; set; }
        public Position position { get; set; }

        public TeamStats(JObject rawData)
        {
            JObject posessionData = CreateObject(rawData["posession"]);
            JObject hitCountsData = CreateObject(rawData["hitCounts"]);
            JObject positionData = CreateObject(rawData["centerOfMass"]);

            posession = new Posession(posessionData);
            hitCounts = new HitCounts(hitCountsData);
            position = new Position(positionData);
        }
        
        public class Posession
        {
            public string totalPosessionTime { get; set; }
            public string turnovers { get; set; }
            public string turnoversOnMyHalf { get; set; }
            public string turnoversOnTheirHalf { get; set; }
            public string wonTurnovers { get; set; }

            public Posession(JObject rawData)
            {
                totalPosessionTime = rawData["posessionTime"].ToString();
                turnovers = rawData["turnovers"].ToString();
                turnoversOnMyHalf = rawData["turnoversOnMyHalf"].ToString();
                turnoversOnTheirHalf = rawData["turnoversOnTheirHalf"].ToString();
                wonTurnovers = rawData["turnovwonTurnoversers"].ToString();
            }
        }

        public class HitCounts
        {
            public string totalHits { get; set; }
            public string totalPasses { get; set; }
            public string totalSaves { get; set; }
            public string totalShots { get; set; }
            public string totalDribbleContinuations { get; set; }
            public string totalAerials { get; set; }
            public string totalClears { get; set; }

            public HitCounts(JObject rawData)
            {
                totalHits = rawData["totalHits"].ToString();
                totalPasses = rawData["totalPasses"].ToString();
                totalSaves = rawData["totalSaves"].ToString();
                totalDribbleContinuations = rawData["totalDribbleConts"].ToString();
                totalAerials = rawData["totalAerials"].ToString();
            }
        }

        public class Position
        {
            public string timeOnGround { get; set; }
            public string timeLowInAir { get; set; }
            public string timeHighInAir { get; set; }
            public string timeInDefendingHalf { get; set; }
            public string timeInAttackingHalf { get; set; }
            public string timeInDefendingThird { get; set; }
            public string timeInNeutralThird { get; set; }
            public string timeInAttackingThird { get; set; }
            public string timeBehindBall { get; set; }
            public string timeInFrontBall { get; set; }
            public string timeNearWall { get; set; }
            public string timeInCorner { get; set; }
            public string timeOnWall { get; set; }
            public string averageDistanceFromCenter { get; set; }
            public string averageMaxDistanceFromCenter { get; set; }
            public string timeClumped { get; set; }
            public string timeBoondocks { get; set; }

            public Position(JObject rawData)
            {
                timeOnGround = rawData["positionalTendencies.timeOnGround"].ToString();
                timeLowInAir = rawData["positionalTendencies.timeLowInAir"].ToString();
                timeHighInAir = rawData["positionalTendencies.timeHighInAir"].ToString();
                timeInDefendingHalf = rawData["positionalTendencies.timeInDefendingHalf"].ToString();
                timeInAttackingHalf = rawData["positionalTendencies.timeInAttackingHalf"].ToString();
                timeInDefendingThird = rawData["positionalTendencies.timeInDefendingThird"].ToString();
                timeInNeutralThird = rawData["positionalTendencies.timeInNeutralThird"].ToString();
                timeInAttackingThird = rawData["positionalTendencies.timeInAttackingThird"].ToString();
                timeBehindBall = rawData["positionalTendencies.timeBehindBall"].ToString();
                timeInFrontBall = rawData["positionalTendencies.timeInFrontBall"].ToString();
                timeNearWall = rawData["positionalTendencies.timeNearWall"].ToString();
                timeInCorner = rawData["positionalTendencies.timeInCorner"].ToString();
                timeOnWall = rawData["positionalTendencies.timeOnWall"].ToString();
                averageDistanceFromCenter = rawData["averageDistanceFromCenter"].ToString();
                averageMaxDistanceFromCenter = rawData["averageMaxDistanceFromCenter"].ToString();
                timeClumped = rawData["timeClumped"].ToString();
                timeBoondocks = rawData["timeBoondocks"].ToString();
            }
        }

        private JObject CreateObject(JToken data)
        {
            JObject dataObject = data.ToObject<JObject>();
            return dataObject;
        }
    }
}
