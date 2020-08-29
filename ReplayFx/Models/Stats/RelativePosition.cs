namespace ReplayFx.Models
{
    public class RelativePosition : Entry
    {
        public string TimeBehindCenterOfMass { get; set; }
        public string TimeInFrontOfCenterOfMass { get; set; }
        public string TimeMostForwardPlayer { get; set; }
        public string TimeMostBackPlayer { get; set; }
        public string TimeBetweenPlayers { get; set; }
    }
}
