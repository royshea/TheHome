﻿using Newtonsoft.Json;

namespace TheHome.Models
{
    public class PingRequest : ExecutionRequest
    {
        [JsonProperty("pingData")]
        public PingData PingData { get; set; }
    }

    public class PingData
    {
        [JsonProperty("challenge")]
        public string Challenge { get; set; }
    }
}
