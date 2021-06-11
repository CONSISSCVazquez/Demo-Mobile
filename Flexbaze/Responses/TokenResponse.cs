using Newtonsoft.Json;

namespace Flexbaze.Responses
{
    public class TokenData<T>
    {
        [JsonProperty("tokenAuth", NullValueHandling = NullValueHandling.Ignore)]
        public T WebToken { get; set; }
    }

    public class QueryResponse<T> : IGraphQueryResponse<T>
    {
        [JsonProperty("data", NullValueHandling = NullValueHandling.Ignore)]
        public T Data { get; set; }
    }
}
