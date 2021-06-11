namespace Flexbaze.Models
{
    public class AttendanceListItemType
    {
        public string Id { get; set; }
        public ShiftRoleType ShiftRole { get; set; }
        public UserType User { get; set; }
        public AttendanceListType AttendanceList { get; set; }
        public MachineType Machine { get; set; }
    }
}
