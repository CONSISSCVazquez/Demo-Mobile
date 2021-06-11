using System.Collections.Generic;

namespace Flexbaze.Models
{
    public class MachineType
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public CellType Cell { get; set; }
        public List<EntryType> Entries { get; set; }
        public List<SupportTicketType> SupportTicketSet { get; set; }
        public List<AttendanceListItemType> AttendanceListItemSet { get; set; }
        public List<ShiftType> ShiftSet { get; set; }
    }
}
