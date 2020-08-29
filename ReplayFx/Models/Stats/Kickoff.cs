using System.Diagnostics.CodeAnalysis;

namespace ReplayFx.Models
{
    public class Kickoff : Entry
    {
        public string TotKickoffs { get; set; }

        public string NumTimeDefend { get; set; }
        public string AvgBoostUsed { get; set; }
        [AllowNull] public string NumTimeCheat { get; set; }
        [AllowNull] public string NumTimeBoost { get; set; }
        [AllowNull] public string NumTimeGoToBall { get; set; }
        [AllowNull] public string NumTimeFirstTouch { get; set; }
    }
}
