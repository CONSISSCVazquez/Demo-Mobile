using Newtonsoft.Json;

namespace Flexbaze.Models
{
    class MessagesModel
    {
        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }
        [JsonProperty("body", NullValueHandling = NullValueHandling.Ignore)]
        public string Body { get; set; }
        [JsonProperty("image", NullValueHandling = NullValueHandling.Ignore)]
        public string Image { get; set; }
        [JsonProperty("timeLapse", NullValueHandling = NullValueHandling.Ignore)]
        public string TimeLapse { get; set; }
        [JsonProperty("stamp", NullValueHandling = NullValueHandling.Ignore)]
        public string Stamp { get; set; }
        [JsonProperty("node", NullValueHandling = NullValueHandling.Ignore)]
        public string Node { get; set; }
    }
}