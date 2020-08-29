using System;
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
