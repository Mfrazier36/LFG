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
        public string TitleId { get; set; }
        public string CarId { get; set; }
        public string Score { get; set; }
        public string Goals { get; set; }
        public string Assists { get; set; }
        public string TimeInGame { get; set; }
        public PlayerStats PlayerStats { get; set; }
    }
}
