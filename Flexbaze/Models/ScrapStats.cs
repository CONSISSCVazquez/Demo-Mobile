using System.Collections.Generic;

namespace Flexbaze.Models
{
    public class ScrapStats
    {
        public List<ScrapCountStats> Today { get; set; }
        public List<ScrapCountStats> Week { get; set; }
        public List<ScrapCountStats> Month { get; set; }
    }
}
