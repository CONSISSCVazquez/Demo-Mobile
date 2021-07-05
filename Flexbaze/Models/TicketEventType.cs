using System;

namespace Flexbaze.Models
{
    public class TicketEventType
    {
        public string Id { get; set; }
        public SupportTicketType Ticket { get; set; }
        public string Description { get; set; }
        public DateTime Timestamp { get; set; }
        public UserType User { get; set; }
        public string EventType { get; set; }
    }
}
