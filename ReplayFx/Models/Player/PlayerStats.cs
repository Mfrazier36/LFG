using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ReplayFx.Models
{
    public class PlayerStats : Entry
    {
        [Required] public Boost Boost { get; set; }
        [Required] public Distance Distance { get; set; }
        [Required] public Posession Posession { get; set; }
        [Required] public PositionalTendencies PositionalTendencies { get; set; }
        [Required] public Averages Averages { get; set; }
        [Required] public HitCount HitCount { get; set; }
        [Required] public Speed Speed { get; set; }
        [Required] public RelativePosition RelativePosition { get; set; }
        [Required] public Kickoff Kickoff { get; set; }
    }
}
