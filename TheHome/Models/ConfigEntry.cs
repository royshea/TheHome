using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using static TheHome.Common.Enums;

namespace TheHome.Models
{

    public class ConfigEntry
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public ValueTypeEnum ValueType { get; set; }

        public StringConfig StringConfig { get; set; }

        public DeviceConfig DeviceConfig { get; set; }

        public ModeConfig ModeConfig { get; set; }
    }

    public class StringConfig
    {
        public string Value { get; set; }
    }

    public class DeviceConfig
    {
        public string DeviceId { get; set; }

        public string ComponentId { get; set; }
    }

    public class ModeConfig
    {
        public string ModeId { get; set; }
    }
}