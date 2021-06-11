using Newtonsoft.Json;
using System.Collections.Generic;

namespace Flexbaze.Models
{
    class NotificationsModel
    {        
        [JsonProperty("code", NullValueHandling = NullValueHandling.Ignore)]
        public int code { get; set; }
        [JsonProperty("msg", NullValueHandling = NullValueHandling.Ignore)]
        public string msg { get; set; }
        [JsonProperty("result", NullValueHandling = NullValueHandling.Ignore)]
        public Notifications result { get; set; } = new Notifications();
    }
    class Notifications
    {
        [JsonProperty("header", NullValueHandling = NullValueHandling.Ignore)]
        public Alerts Header { get; set; } = new Alerts();
        [JsonProperty("messages", NullValueHandling = NullValueHandling.Ignore)]
        public List<MessagesModel> Messages { get; set; } = new List<MessagesModel>();
    }
}