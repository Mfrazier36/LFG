using System;
using System.ComponentModel.DataAnnotations;

namespace ReplayFx.Models
{
    public partial class Entry
    {
        [Key] public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public EntryType EntryType { get; set; }
    }
}
