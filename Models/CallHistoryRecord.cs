using System;
using Newtonsoft.Json;

namespace SparkDotNet {
    public class CallHistoryRecord
    {
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "number")]
        public string number { get; set; }
        [JsonProperty(PropertyName = "privacyEnabled")]
        public bool PrivacyEnabled { get; set; }
        [JsonProperty(PropertyName = "time")]
        public DateTime time { get; set; }

        public override string ToString() {
            return JsonConvert.SerializeObject(this);
        }
    }
}