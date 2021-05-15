using Newtonsoft.Json;

namespace SparkDotNet
{
    public class MeetingParticipantDevice : WebexObject
    {
        [JsonProperty("deviceType")]
        public string DeviceType { get; set; }
        [JsonProperty("audioType")]
        public string AudioType { get; set; }
        [JsonProperty("joinedTime")]
        public System.DateTime JoinedTime { get; set; }
        [JsonProperty("correlationId")]
        public bool CorrelationId { get; set; }
    }

}