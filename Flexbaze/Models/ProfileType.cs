using System.Collections.Generic;

namespace Flexbaze.Models
{
    public class ProfileType
    {
        public string Id { get; set; }
        public UserType User { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
        public List<NotificationType> Notifications { get; set; }
    }
}
