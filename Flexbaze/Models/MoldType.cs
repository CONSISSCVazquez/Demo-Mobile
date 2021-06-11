namespace Flexbaze.Models
{
    public class MoldType
    {
        public string Id { get; set; }
        public string Code { get; set; }
        public PartType Part { get; set; }
        public SupportTicketType SupportTicketSet { get; set; }
    }
}
