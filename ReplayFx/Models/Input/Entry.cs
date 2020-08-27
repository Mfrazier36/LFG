using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ReplayFx.Models
{
    public partial class Entry
    {
        [Key] public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public EntryType EntryType { get; set; }
    }
}
