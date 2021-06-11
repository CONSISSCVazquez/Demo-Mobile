using System.Collections.Generic;

namespace Flexbaze.Models
{
    public class PartType
    {
        public string Id { get; set; }
        public string Code { get; set; }
        public List<MoldType> Molds { get; set; }
        public List<CertificationType> CertificationSet { get; set; }
        public List<SupportTicketType> SupportTicketSet { get; set; }
    }
}
