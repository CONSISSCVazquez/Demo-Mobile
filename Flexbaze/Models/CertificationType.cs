namespace Flexbaze.Models
{
    public class CertificationType
    {
        public string Id { get; set; }
        public PartType Part { get; set; }
        public string Level { get; set; }
        public UserType User { get; set; }
    }
}
