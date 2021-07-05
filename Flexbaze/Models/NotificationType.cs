using System;

namespace Flexbaze.Models
{
    public class NotificationType
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public bool Read { get; set; }
        public DateTime CreatedAt { get; set; }
        public ProfileType Profile { get; set; }
    }
}
