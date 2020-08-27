using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using System.ComponentModel.DataAnnotations;

namespace ReplayFx.Models
{
    public class Player : Entry
    {
        public string Name { get; set; }
        public int TitleId { get; set; }
        public int CarId { get; set; }
        public int Score { get; set; }
        public int Goals { get; set; }
        public int Assists { get; set; }
        public double TimeInGame { get; set; }
        public PlayerStats PlayerStats { get; set; }
    }
}
