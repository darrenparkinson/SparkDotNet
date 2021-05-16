using Newtonsoft.Json;

namespace SparkDotNet {

    /// <summary>
    /// To retrieve quality information, you must use an administrator token with the analytics:read_all scope.
    /// The authenticated user must be a read-only or full administrator of the organization to which the
    /// meeting belongs and must not be an external administrator.
    /// To use this endpoint the org needs to be licensed for pro pack.
    /// For CI-Native site, no additional setting is needed.
    /// For CI-linked site, the admin must also be set as the Full/ReadOnly Site Admin of the site.
    /// Minimal Webex and Teams client version is required, details info is in Troubleshooting Help Doc.
    /// Quality information is available 10 minutes after a meeting has started and may be retrieved for
    /// up to 7 days.
    /// A rate limit of 1 API call every 5 minutes for the same meeting instance id applies.
    /// </summary>
    public class MeetingQuality : WebexObject
    {
        /// <summary>
        /// The meeting identifier for the specific meeting instance.
        /// </summary>
        [JsonProperty("meetingId")]
        public string MeetingId { get; set; }

        /// <summary>
        /// The display name of the participant of this media session.
        /// </summary>
        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        /// <summary>
        /// The email address of the participant of this media session.
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; set; }

        /// <summary>
        /// The date and time when this participant joined the meeting.
        /// </summary>
        [JsonProperty("joined")]
        public System.DateTime Joined { get; set; }

        /// <summary>
        /// The type of the client (and OS) used by this media session.
        /// </summary>
        [JsonProperty("client")]
        public string Client { get; set; }

        /// <summary>
        /// The version of the client used by this media session.
        /// </summary>
        [JsonProperty("clientVersion")]
        public string ClientVersion { get; set; }

        /// <summary>
        /// The operating system used for the client.
        /// </summary>
        [JsonProperty("osType")]
        public string OsType { get; set; }

        /// <summary>
        /// The version of the operating system used for the client.
        /// </summary>
        [JsonProperty("osVersion")]
        public string OsVersion { get; set; }

        /// <summary>
        /// The type of hardware used to attend the meeting
        /// </summary>
        [JsonProperty("hardwareType")]
        public string HardwareType { get; set; }

        /// <summary>
        /// A description of the speaker used in the meeting.
        /// </summary>
        [JsonProperty("speakerName")]
        public string SpeakerName { get; set; }

        /// <summary>
        /// The type of network.
        /// Possible values are: wifi, cellular, ethernet, unknown
        /// </summary>
        [JsonProperty("networkType")]
        public string NetworkType { get; set; }

        /// <summary>
        /// The local IP address of the client.
        /// </summary>
        [JsonProperty("localIP")]
        public string LocalIP { get; set; }

        /// <summary>
        /// The public IP address of the client.
        /// </summary>
        [JsonProperty("remoteIP")]
        public string RemoteIP { get; set; }

        /// <summary>
        /// A description of the camera used in the meeting.
        /// </summary>
        [JsonProperty("camera")]
        public string Camera { get; set; }

        /// <summary>
        /// A description of the microphone used in the meeting.
        /// </summary>
        [JsonProperty("microphone")]
        public string Microphone { get; set; }

        /// <summary>
        /// The server region.
        /// </summary>
        [JsonProperty("serverRegion")]
        public string ServerRegion { get; set; }

        /// <summary>
        /// Used to identify the participant.
        /// </summary>
        [JsonProperty("participantId")]
        public string ParticipantId { get; set; }

        /// <summary>
        /// Used to identify a specific session the participant has in a given meeting.
        /// </summary>
        [JsonProperty("participantSessionId")]
        public string ParticipantSessionId { get; set; }
    }
}