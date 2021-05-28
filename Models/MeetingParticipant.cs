using Newtonsoft.Json;

namespace SparkDotNet
{
    public class MeetingParticipant : WebexObject
    {
        /// <summary>
        /// The participant id to uniquely identify the meeting and the participant.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// The id to identify the orgnaization.
        /// </summary>
        [JsonProperty("orgId")]
        public string OrgId { get; set; }

        /// <summary>
        /// The value is true or flase, it indicates if the participant is the host of the meeting.
        /// </summary>
        [JsonProperty("host")]
        public bool Host { get; set; }

        /// <summary>
        /// The value is true or flase, it indicates if the participant has host privilege in the meeting.
        /// </summary>
        [JsonProperty("coHost")]
        public bool CoHost { get; set; }

        /// <summary>
        /// The value is true or false, it indicates if the participant is the team space moderator.
        /// This field returns only if the meeting is associated with a Webex Teams space.
        /// </summary>
        [JsonProperty("spaceModerator")]
        public bool SpaceModerator { get; set; }

        /// <summary>
        /// he email address of the participant.
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; set; }

        /// <summary>
        /// The name of the participant.
        /// </summary>
        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        /// <summary>
        /// The value is true or flase, it indicates if the participant is invited to the meeting or not.
        /// </summary>
        [JsonProperty("invitee")]
        public bool Invitee { get; set; }

        /// <summary>
        /// The value is on or off, it indicates the participant's video is on in the meeting.
        /// </summary>
        [JsonProperty("video")]
        public string Video { get; set; }

        /// <summary>
        /// The value is true or false, it indicates whether the participant's audio is muted.
        /// </summary>
        [JsonProperty("muted")]
        public bool Muted { get; set; }

        /// <summary>
        /// The value can be "lobby" or "joined".
        /// </summary>
        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("devices")]
        public MeetingParticipantDevice Devices { get; set; }
    }


}