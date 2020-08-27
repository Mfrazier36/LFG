using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReplayFx.Models
{
    public class Posession : Entry
    {
        public string Turnovers { get; set; }
        public string WonTurnovers { get; set; }
        public string TurnoversOnMyHalf { get; set; }
        public string TurnoversOnTheirHalf { get; set; }
        public string TotPossessionTime { get; set; }
    }
}
