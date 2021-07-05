using System.Collections.Generic;

namespace Flexbaze.Models
{
    public class SendPasswordResetEmail
    {
        public bool Success { get; set; }
        public List<ExpectedErrorType> Errors { get; set; }
    }
}