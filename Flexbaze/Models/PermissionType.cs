using System.Collections.Generic;

namespace Flexbaze.Models
{
    public class PermissionType
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string CodeName { get; set; }
        public List<GroupType> GroupSet { get; set; }
        public List<UserType> UserSet { get; set; }
    }
}
