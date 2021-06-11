using Newtonsoft.Json;

namespace Flexbaze.Models
{
    public class WebToken
    {
        [JsonProperty("token", NullValueHandling = NullValueHandling.Ignore)]
        public string Token { get; set; }

        [JsonProperty("user", NullValueHandling = NullValueHandling.Ignore)]
        public UserType User { get; set; }
    }
}
