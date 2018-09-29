using Newtonsoft.Json;

namespace TheHome.RequestModels
{
    public class PingRequest : ExecutionRequest
    {
        [JsonProperty("pingData")]
        public PingData PingData { get; set; }
    }

    public class PingResponse
    {
        [JsonProperty("pingData")]
        public object PingData { get; set; }
    }

    public class PingData
    {
        [JsonProperty("challenge")]
        public string Challenge { get; set; }
    }
}
