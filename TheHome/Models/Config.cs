using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using TheHome.Common;
using static TheHome.Common.Enums;

namespace TheHome.Models
{
    public class Config
    {
        public Dictionary<string, ConfigEntry> ConfigEntries { get; set; }
    }

    [JsonConverter(typeof(ConfigConverter))]
    abstract public class ConfigEntry
    {
        [JsonProperty("valueType")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ValueTypeEnum ValueType { get; set; }
    }

    public class StringConfig : ConfigEntry
    {
        [JsonProperty("value")]
        public string Value { get; set; }

        public static implicit operator Type(StringConfig v)
        {
            throw new NotImplementedException();
        }
    }

    public class DeviceConfig : ConfigEntry
    {
        [JsonProperty("deviceId")]
        public string DeviceId { get; set; }

        [JsonProperty("componentId")]
        public string ComponentId { get; set; }
    }

    public class ModeConfig : ConfigEntry
    {
        [JsonProperty("modeId")]
        public string ModeId { get; set; }
    }
}