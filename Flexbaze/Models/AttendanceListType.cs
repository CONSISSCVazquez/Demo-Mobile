using System;
using System.Collections.Generic;

namespace Flexbaze.Models
{
    public class AttendanceListType
    {
        public string Id { get; set; }
        public DateTime Date { get; set; }
        public CellType Cell { get; set; }
        public ShiftTypeType ShiftType { get; set; }
        public List<AttendanceListItemType> Items { get; set; }
    }
}
