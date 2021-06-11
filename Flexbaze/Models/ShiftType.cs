using System;

namespace Flexbaze.Models
{
    public class ShiftType
    {
        public string Id { get; set; }
        public DateTime StartedAt { get; set; }
        public DateTime EndedAt { get; set; }
        public MachineType Machine { get; set; }
        public UserType StartedBy { get; set; }
        public ShiftTypeType Type { get; set; }
    }
}
