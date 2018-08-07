using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using TheHome.Common;
using static TheHome.Common.Enums;

namespace TheHome.Models
{
    [JsonConverter(typeof(ExecutionRequestConverter))]
    public class ExecutionRequest
    {
        [JsonProperty("lifeCycle")]
        [JsonConverter(typeof(StringEnumConverter))]
        public LifeCycleEnum LifeCycle { get; set; }

        [JsonProperty("executionId")]
        public string ExecutionId { get; set; }

        [JsonProperty("local")]
        public string Local { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }
    }
}
