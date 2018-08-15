using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using static TheHome.Common.Enums;

namespace TheHome.Models
{

    public class ConfigEntry
    {
        [JsonProperty("valueType")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ValueTypeEnum ValueType { get; set; }

        [JsonProperty("stringConfig")]
        public StringConfig StringConfig { get; set; }

        [JsonProperty("deviceConfig")]
        public DeviceConfig DeviceConfig { get; set; }

        [JsonProperty("modeConfig")]
        public ModeConfig ModeConfig { get; set; }
    }

    public class StringConfig
    {
        [JsonProperty("value")]
        public string Value { get; set; }
    }

    public class DeviceConfig
    {
        [JsonProperty("deviceId")]
        public string DeviceId { get; set; }

        [JsonProperty("componentId")]
        public string ComponentId { get; set; }
    }

    public class ModeConfig
    {
        [JsonProperty("modeId")]
        public string ModeId { get; set; }
    }
}