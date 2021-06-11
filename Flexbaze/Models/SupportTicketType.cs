using System;

namespace Flexbaze.Models
{
    public class SupportTicketType
    {
        public string Id { get; set; }
        public MoldType Mold { get; set; }
        public PartType Part { get; set; }
        public CellType Cell { get; set; }
        public string Area { get; set; }
        public MachineType Machine { get; set; }
        public DateTime StartedAt { get; set; }
        public DateTime EndedAtCommitment { get; set; }
        public DateTime EndedAt { get; set; }
        public string Status { get; set; }
        public UserType ReportedBy { get; set; }
        public UserType AssignedTo { get; set; }
        public string Description { get; set; }
    }
}
