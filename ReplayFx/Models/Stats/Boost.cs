namespace ReplayFx.Models
{
    public class Boost : Entry
    {
        public string BoostUsage { get; set; }
        public string AvgBoostLevel { get; set; }
        public string NumSmallBoost { get; set; }
        public string NumLargeBoost { get; set; }
        public string TotStolenBoost { get; set; }
        public string TotWastedBoost { get; set; }
        public string TotWastedBigBoost { get; set; }
        public string TotWastedSmallBoost { get; set; }
    }
}
