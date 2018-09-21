using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using static TheHome.Common.Enums;

namespace TheHome.Models
{
    //[JsonConverter(typeof(ConfigConverter))]
    public class Config
    {
        public Dictionary<string, ConfigEntry> ConfigEntries { get; set; }

        public List<string> Permissions { get; set; }

        public static Config ParseConfig(Dictionary<string, List<dynamic>> configDictionary)
        {
            var configData = configDictionary;
            var permissions = new List<string>();
            var configs = new Dictionary<string, ConfigEntry>();
            foreach (var pair in configData)
            {
                if (pair.Key == "permissions")
                {
                    permissions = pair.Value.Cast<string>().ToList();
                }
                else
                {
                    var key = pair.Key;
                    if (pair.Value.Count != 1)
                    {
                        throw new Exception("Shit");
                    }
                    var data = pair.Value[0];
                    if (key == "app" && data.Count == null)
                    {
                        // During the configuration stage it appears that there
                        // can be empty app blocks.  Not sure why...
                        continue;
                    }
                    else if (!data.ContainsKey("valueType"))
                    {
                        throw new Exception("bummer");
                    }
                    ConfigEntry entry;
                    ValueTypeEnum valueType = data.GetValue("valueType").ToObject<ValueTypeEnum>();
                    switch (valueType)
                    {
                        case ValueTypeEnum.STRING:
                            entry = new StringConfig();
                            break;
                        case ValueTypeEnum.DEVICE:
                            entry = new DeviceConfig();
                            break;
                        case ValueTypeEnum.MODE:
                            entry = new ModeConfig();
                            break;
                        default:
                            throw new NotImplementedException("Unknown value for ValueTypeEnum");
                    }
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Populate(data.CreateReader(), entry);
                    configs[key] = entry;
                }
            }
            var config = new Config()
            {
                ConfigEntries = configs,
                Permissions = permissions
            };
            return config;
        }
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