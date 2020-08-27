using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReplayFx.Models
{
    public class Speed : Entry
    {
        public string TimeAtSlowSpeed { get; set; }
        public string TimeAtSuperSonic { get; set; }
        public string TimeAtBoostSpeed { get; set; }
    }
}
