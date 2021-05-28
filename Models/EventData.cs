using Newtonsoft.Json;

namespace SparkDotNet {
    public class EventData : WebexObject
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("roomId")]
        public string RoomId { get; set; }

        [JsonProperty("roomType")]
        public string RoomType { get; set; }

        [JsonProperty("orgId")]
        public string OrgId { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("personId")]
        public string PersonId { get; set; }

        [JsonProperty("personEmail")]
        public string PersonEmail { get; set; }

        [JsonProperty("meetingId")]
        public string MeetingId { get; set; }

        [JsonProperty("creatorId")]
        public string CreatorId { get; set; }

        [JsonProperty("created")]
        public System.DateTime Created { get; set; }
    }
}