using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace ReplayFx.Models.Frame
{
    class Kickoff
    {
        public int startFrame { get; set; }
        public int touchFrame { get; set; }
        public double touchTime { get; set; }
        public string type { get; set; }
        public double kickoffGoal { get; set; }
        public string firstTouchPlayerId { get; set; }
    }
}
