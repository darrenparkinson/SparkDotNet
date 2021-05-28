using Newtonsoft.Json;

namespace SparkDotNet
{
    public class MeetingPreferencesPMR : WebexObject
    {
        /// <summary>
        /// Personal Meeting Room topic. The length of topic is between 1 and 128.
        /// This attribute can be modified by Update Personal Meeting Room Options API.
        /// </summary>
        [JsonProperty("topic")]
        public string Topic { get; set; }

        /// <summary>
        /// PIN for joining the room as host. The host PIN must be digits of a predefined length, e.g. 4 digits.
        /// It cannot contain sequential digits, such as 1234 or 4321, or repeated digits of the predefined length,
        /// such as 1111. The predefined length for host PIN can be viewed in user's My Personal Room page and it
        /// can only be changed by site administrator. This attribute can be modified by Update Personal Meeting
        /// Room Options API.
        /// </summary>
        [JsonProperty("hostPin")]
        public string HostPin { get; set; }

        /// <summary>
        /// Personal Meeting Room link. It cannot be empty. Note: This is a read-only attribute.
        /// </summary>
        [JsonProperty("personalMeetingRoomLink")]
        public string PersonalMeetingRoomLink { get; }

        /// <summary>
        /// Option to automatically lock the Personal Room a number of minutes after a meeting starts.
        /// When a room is locked, invitees cannot enter until the owner admits them.
        /// The period after which the meeting is locked is defined by autoLockMinutes.
        /// This attribute can be modified by Update Personal Meeting Room Options API.
        /// </summary>
        [JsonProperty("enabledAutoLock")]
        public bool EnabledAutoLock { get; set; }

        /// <summary>
        /// Number of minutes after which the Personal Room is locked if enabledAutoLock is enabled. Valid options are 0, 5, 10, 15 and 20.
        /// This attribute can be modified by Update Personal Meeting Room Options API.
        /// </summary>
        [JsonProperty("autoLockMinutes")]
        public int AutoLockMinutes { get; set; }

        /// <summary>
        /// Flag to enable notifying the owner of a Personal Room when someone enters the Personal Room lobby while the owner is not in the room.
        /// This attribute can be modified by Update Personal Meeting Room Options API.
        /// </summary>
        [JsonProperty("enabledNotifyHost")]
        public bool EnabledNotifyHost { get; set; }

        /// <summary>
        /// Flag allowing other invitees to host a meeting in the Personal Room without the owner.
        /// This attribute can be modified by Update Personal Meeting Room Options API.
        /// </summary>
        [JsonProperty("supportCoHost")]
        public bool SupportCoHost { get; set; }

        /// <summary>
        /// Whether or not to allow any attendee with a host account on the target site to become a cohost when joining the Personal Room.
        /// The target site is user's preferred site. This attribute can be modified by Update Personal Meeting Room Options API.
        /// </summary>
        [JsonProperty("supportAnyoneAsCoHost")]
        public bool SupportAnyoneAsCoHost { get; set; }

        /// <summary>
        /// Whether or not to allow the first attendee with a host account on the target site to become a cohost when joining the Personal Room.
        /// The target site is user's preferred site. This attribute can be modified by Update Personal Meeting Room Options API.
        /// </summary>
        [JsonProperty("allowFirstUserToBeCoHost")]
        public bool AllowFirstUserToBeCoHost { get; set; }

        /// <summary>
        /// Whether or not to allow authenticated video devices in the user's organization to start or join the meeting without a prompt.
        /// This attribute can be modified by Update Personal Meeting Room Options API.
        /// </summary>
        [JsonProperty("allowAuthenticatedDevices")]
        public bool AllowAuthenticatedDevices { get; set; }

        /// <summary>
        /// Array defining cohosts for the room if both supportAnyoneAsCoHost and allowFirstUserToBeCoHost are false.
        /// This attribute can be modified by Update Personal Meeting Room Options API.
        /// </summary>
        [JsonProperty("coHosts")]
        public MeetingPreferencesCoHost[] choHosts { get; set; }

        /// <summary>
        /// SIP address for callback from a video system.
        /// </summary>
        [JsonProperty("sipAddress")]
        public string SipAddress { get; set; }

        /// <summary>
        /// IP address for callback from a video system.
        /// </summary>
        [JsonProperty("dialInIpAddress")]
        public string DialInIpAddress { get; set; }

        /// <summary>
        /// Information for callbacks from meeting to phone or for joining a teleconference using a phone.
        /// </summary>
        [JsonProperty("telephony")]
        public MeetingTelephony Telephony { get; set; }
   }


}