using System.Collections.Generic;

namespace Flexbaze.Models
{
    public class ShiftRoleType
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<AttendanceListItemType> AttendanceListItemSet { get; set; }
        public List<CellUserShiftType> CellUserShiftSet { get; set; }
    }
}
