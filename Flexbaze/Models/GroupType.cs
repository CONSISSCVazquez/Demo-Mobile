using System.Collections.Generic;

namespace Flexbaze.Models
{
    public class GroupType
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<PermissionType> Permissions { get; set; }
        public List<UserType> UserSet { get; set; }
    }
}
