using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace ReplayFx.Models
{
    public class Team : Entry
    {
        [Required] public TeamName Name { get; set; }
        [Required] public int Score { get; set; }

        [Required] public TeamStats TeamStats { get; set; }

        [Required] public string LeaderId { get; set; }
        public string Player1Id { get; set; }
        public string Player2Id { get; set; }
        [AllowNull] public string Player3Id { get; set; }
        [AllowNull] public string Player4Id { get; set; }
        [AllowNull] public string Player5Id { get; set; }
        [AllowNull] public string Player6Id { get; set; }
        [AllowNull] public string Player7Id { get; set; }
        [AllowNull] public string Player8Id { get; set; }

        public Player Player1 { get; set; }
        public Player Player2 { get; set; }
        [AllowNull] public Player Player3 { get; set; }
        [AllowNull] public Player Player4 { get; set; }
        [AllowNull] public Player Player5 { get; set; }
        [AllowNull] public Player Player6 { get; set; }
        [AllowNull] public Player Player7 { get; set; }
        [AllowNull] public Player Player8 { get; set; }
    }
}
