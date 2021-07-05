using System.Collections.Generic;

namespace Flexbaze.Models
{
    public class StopsStats
    {
        public List<StopsCountStats> Today { get; set; }
        public List<StopsCountStats> Week { get; set; }
        public List<StopsCountStats> Month { get; set; }
    }
}
