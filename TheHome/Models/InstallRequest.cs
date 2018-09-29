using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace TheHome.Models
{
    public class InstallRequest : ExecutionRequest
    {
        [JsonProperty("installData")]
        public InstallData InstallData { get; set; }

        [JsonProperty("settings")]
        public Dictionary<string, string> Settings { get; set; }
    }

    public class InstallData
    {
        [JsonProperty("authToken")]
        public string AuthToken { get; set; }

        [JsonProperty("refreshToken")]
        public string RefreshToken { get; set; }

        [JsonProperty("installedApp")]
        public InstalledApp InstalledApp { get; set; }
    }

    public class InstalledApp
    {
        [JsonProperty("installedAppId")]
        public string InstalledAppId { get; set; }

        [JsonProperty("locationId")]
        public string LocationId { get; set; }

        [JsonProperty("config")]
        public Dictionary<string, List<Config>> Config { get; set; }

        [JsonProperty("permissions")]
        public List<string> Permissions { get; set; }
    }

    public class InstallResponse
    {
        [JsonProperty("installData")]
        public Object InstallData { get; set; }
    }
}
