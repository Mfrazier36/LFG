using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ReplayFx.Models
{
    public class TeamStats : Entry
    {
        [Required] public Posession Posession { get; set; }
        [Required] public HitCount HitCount { get; set; }
        [Required] public PositionalTendencies PositionalTendencies { get; set; }
    }
}
