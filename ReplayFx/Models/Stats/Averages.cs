﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReplayFx.Models
{
    public class Averages : Entry
    {
        public string AvgSpeed { get; set; }
        public string AvgHitDistance { get; set; }
        public string AvgDistanceFromCenter { get; set; }

        public PerPossAverages PerPosession { get; set; }
    }
}
