using System.ComponentModel.DataAnnotations;

namespace ReplayFx.Models
{
    public class TeamStats : Entry
    {
        [Required] public Posession Posession { get; set; }
        [Required] public HitCount HitCount { get; set; }
        [Required] public PositionalTendencies PositionalTendencies { get; set; }
    }
}
