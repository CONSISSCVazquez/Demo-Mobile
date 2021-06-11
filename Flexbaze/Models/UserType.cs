using System;
using System.Collections.Generic;

namespace Flexbaze.Models
{
    public class UserType
    {
        public string Id { get; set; }
        public string Password { get; set; }
        public DateTime LastLogin { get; set; }
        public Boolean IsSuperUser { get; set; }
        public List<GroupType> Groups { get; set; }
        public List<PermissionType> UserPermissions { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Boolean IsStaff { get; set; }
        public Boolean IsActive { get; set; }
        public DateTime DateJoined { get; set; }
        public List<CellType> Cells { get; set; }
        public List<CertificationType> Certifications { get; set; }
        public List<SupportTicketType> ReportedByTickets { get; set; }
        public List<SupportTicketType> AssignedToTickets { get; set; }
        public List<AttendanceListItemType> AttendanceListItemSet { get; set; }
        public List<CellUserShiftType> CellUserShiftSet { get; set; }
        public List<ShiftType> ShiftSet { get; set; }
    }
}
