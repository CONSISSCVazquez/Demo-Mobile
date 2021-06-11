namespace Flexbaze.Models
{
    public class CellUserShiftType
    {
        public string Id { get; set; }
        public UserType User { get; set; }
        public CellType Cell { get; set; }
        public ShiftTypeType ShiftType { get; set; }
        public ShiftRoleType ShiftRole { get; set; }
    }
}
