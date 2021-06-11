using System;

namespace Flexbaze.Models
{
    public class EntryType
    {
        public string Id { get; set; }
        public DateTime TimeStamp { get; set; }
        public string Event { get; set; }
        public Int32 Duration { get; set; }
        public MachineType Machine { get; set; }
    }
}
