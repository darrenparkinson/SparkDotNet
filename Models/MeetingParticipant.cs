using Newtonsoft.Json;

namespace SparkDotNet
{
    public class MeetingParticipant : WebexObject
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("orgId")]
        public string OrgId { get; set; }
        [JsonProperty("host")]
        public bool Host { get; set; }
        [JsonProperty("coHost")]
        public bool CoHost { get; set; }
        [JsonProperty("spaceModerator")]
        public bool SpaceModerator { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("displayName")]
        public string DisplayName { get; set; }
        [JsonProperty("invitee")]
        public bool Invitee { get; set; }
        [JsonProperty("video")]
        public string Video { get; set; }
        [JsonProperty("muted")]
        public bool Muted { get; set; }
        [JsonProperty("state")]
        public string State { get; set; }
        [JsonProperty("devices")]
        public MeetingParticipantDevice Devices { get; set; }
    }


}