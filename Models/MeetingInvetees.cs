using Newtonsoft.Json;

namespace SparkDotNet
{
    public class MeetingInvitee : WebexObject
    {
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("displayName")]
        public string DisplayName { get; set; }
        [JsonProperty("coHost")]
        public bool CoHost { get; set; }
        [JsonProperty("meetingId")]
        public string MeetingId { get; set; }
    }


}