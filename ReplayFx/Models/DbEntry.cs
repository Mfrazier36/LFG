using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ReplayFx.Models
{
    public class DbEntry
    {
        [Key]
        public int EntryId {get;set;}
    }
}
