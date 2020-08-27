using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Extensions.FileProviders;
using System.ComponentModel.DataAnnotations;

namespace ReplayFx.Models
{
    public class FileInput
    {
        [
            Required(ErrorMessage = "Please select file"),
            RegularExpression(@"([a-zA-Z0-s_\\.\-:])+(.Replay|.replay)$", ErrorMessage = "Only .replay files allowed")
        ]
        public virtual FileInput File { get; set; }
        public DateTime DateTime { get; set; }
    }
}
