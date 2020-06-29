using System;
using Newtonsoft.Json;

namespace SparkDotNet {
    public class CallParkedAgainst
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "number")]
        public string Number { get; set; }
        [JsonProperty(PropertyName = "personId")]
        public string PersonId { get; set; }
        [JsonProperty(PropertyName = "placeId")]
        public string PlaceId { get; set; }
        [JsonProperty(PropertyName = "privacyEnabled")]
        public bool PrivacyEnabled { get; set; }
        [JsonProperty(PropertyName = "callType")]
        public string CallType { get; set; }

        public override string ToString() {
            return JsonConvert.SerializeObject(this);
        }
    }
}