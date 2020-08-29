namespace ReplayFx.Models
{
    public class Distance : Entry
    {
        public string DistanceBallHitForward { get; set; }
        public string DistanceBallHitBackward { get; set; }
        public string TimeClosestToBall { get; set; }
        public string TimeCloseToBall { get; set; }
        public string TimeFurthestFromBall { get; set; }

        public string TimeInFrontOfCenterOfMass { get; set; }
        public string TimeBehindCenterOfMass { get; set; }
        public string TimeMostForwardPlayer { get; set; }
        public string TimeMostBackPlayer { get; set; }
        public string TimeBetweenPlayers { get; set; }

    }
}
