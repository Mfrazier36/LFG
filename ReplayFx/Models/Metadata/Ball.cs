using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ReplayFx.Models
{
    public class Ball : Entry
    {
		public string AvgSpeed { get; set; }
		public string TimeNeutral { get; set; }
		public string TimeDefendingHalf { get; set; }
		public string TimeAttackingHalf { get; set; }
		public string TimeNeutralThird { get; set; }
		public string TimeAttackingThird { get; set; }
		public string TimeDefendingThird { get; set; }
		public string TimeOnGround { get; set; }
		public string TimeLowInAir { get; set; }
		public string TimeHighInAir { get; set; }
		public string TimeNearWall { get; set; }
		public string TimeInCorner { get; set; }
		public string TimeOnWall { get; set; }
	}
}
