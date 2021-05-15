using Newtonsoft.Json;

namespace SparkDotNet
{
    public class MeetingParticipantDevice : WebexObject
    {
        /// <summary>
        /// The type of device.
        /// </summary>
        [JsonProperty("deviceType")]
        public string DeviceType { get; set; }

        /// <summary>
        /// The audio call type, it can be "pstn" or "voip".
        /// </summary>
        [JsonProperty("audioType")]
        public string AudioType { get; set; }

        /// <summary>
        /// The time when the device joined.
        /// </summary>
        [JsonProperty("joinedTime")]
        public System.DateTime JoinedTime { get; set; }

        /// <summary>
        /// An internal id that associated with each join.
        /// </summary>
        [JsonProperty("correlationId")]
        public bool CorrelationId { get; set; }
    }

}