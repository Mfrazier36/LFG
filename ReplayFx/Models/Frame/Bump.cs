using System;
using System.Collections.Generic;
using System.Text;

namespace ReplayFx.Models.Frame
{
    class Bump
    {
        public int frameNumber { get; set; }
        public string attackerId { get; set; }
        public string victimId { get; set; }
        public bool isDemo { get; set; }
    }
}
