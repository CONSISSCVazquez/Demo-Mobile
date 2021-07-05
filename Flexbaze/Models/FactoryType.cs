using Newtonsoft.Json;
using System.Collections.Generic;

namespace Flexbaze.Models
{
    public class FactoryType
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        public List<CellType> Cells { get; set; }
    }
}
