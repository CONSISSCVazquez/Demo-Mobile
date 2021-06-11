using System.Collections.Generic;

namespace Flexbaze.Models
{
    public class CellType
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<UserType> Users { get; set; }
        public List<MachineType> Machines { get; set; }
        public List<SupportTicketType> SupportTicketSet { get; set; }
        public List<AttendanceListType> Rolls { get; set; }
        public List<CellUserShiftType> CellUserShiftSet { get; set; }
    }
}
