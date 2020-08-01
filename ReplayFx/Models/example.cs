using System;

namespace ReplayFx.Models
{
    public class example
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
