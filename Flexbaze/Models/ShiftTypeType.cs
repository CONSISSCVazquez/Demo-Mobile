using System.Collections.Generic;

namespace Flexbaze.Models
{
    public class ShiftTypeType
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<AttendanceListType> Rolls { get; set; }
        public List<CellUserShiftType> CellUserShiftSet { get; set; }
        public List<ShiftType> Shifts { get; set; }
    }
}
