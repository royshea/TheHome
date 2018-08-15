using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;
using static TheHome.Common.Enums;

namespace TheHome.Models
{
    public class ConfigurationRequest : ExecutionRequest
    {
        [JsonProperty("configurationData")]
        public ConfigurationData ConfigurationData { get; set; }

        public Dictionary<string, string> Settings { get; set; }
    }

    public class ConfigurationData
    {
        public string InstalledAppId { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public PhaseEnum Phase { get; set; }

        public string PageId { get; set; }

        public string PreviousPageId { get; set; }

        public Dictionary<string, ConfigEntry> Config { get; set; }
    }
}