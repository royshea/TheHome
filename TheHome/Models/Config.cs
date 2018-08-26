using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections;
using System.Collections.Generic;
using TheHome.Common;
using static TheHome.Common.Enums;

namespace TheHome.Models
{
    //[JsonConverter(typeof(ConfigConverter))]
    public class Config
    {
        public object ConfigEntries { get; set; }

        public string Permissions { get; set; }
    }

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