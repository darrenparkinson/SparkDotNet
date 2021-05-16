using Newtonsoft.Json;

namespace SparkDotNet
{
    public class MeetingInvitee : WebexObject
    {
        /// <summary>
        /// Unique identifier for meeting invitee.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Email address for meeting invitee. This attribute can be modified by Update a Meeting Invitee API.
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; set; }

        /// <summary>
        /// Display name for meeting invitee. This attribute can be modified by Update a Meeting Invitee API.
        /// </summary>
        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        /// <summary>
        /// Whether or not invitee is a designated alternate host for the meeting.
        /// See Add Alternate Hosts for Cisco Webex Meetings for more details.
        /// </summary>
        [JsonProperty("coHost")]
        public bool CoHost { get; set; }

        /// <summary>
        /// Unique identifier for the meeting for which invitees are being requested.
        /// The meeting can be meeting series, scheduled meeting or meeting instance which has ended or is ongoing.
        /// </summary>
        [JsonProperty("meetingId")]
        public string MeetingId { get; set; }
    }


}