using Newtonsoft.Json;

namespace SparkDotNet
{
    public class MeetingPreferencesPMR : WebexObject
    {
        [JsonProperty("topic")]
        public string Topic { get; set; }
        [JsonProperty("hostPin")]
        public string HostPin { get; set; }
        [JsonProperty("personalMeetingRoomLink")]
        public string PersonalMeetingRoomLink { get; }
        [JsonProperty("enabledAutoLock")]
        public bool EnabledAutoLock { get; set; }
        [JsonProperty("autoLockMinutes")]
        public int AutoLockMinutes { get; set; }
        [JsonProperty("enabledNotifyHost")]
        public bool EnabledNotifyHost { get; set; }
        [JsonProperty("supportCoHost")]
        public bool SupportCoHost { get; set; }
        [JsonProperty("supportAnyoneAsCoHost")]
        public bool SupportAnyoneAsCoHost { get; set; }
        [JsonProperty("allowFirstUserToBeCoHost")]
        public bool AllowFirstUserToBeCoHost { get; set; }
        [JsonProperty("allowAuthenticatedDevices")]
        public bool AllowAuthenticatedDevices { get; set; }
        [JsonProperty("coHosts")]
        public MeetingPreferencesCoHost[] choHosts { get; set; }
        [JsonProperty("sipAddress")]
        public string SipAddress { get; set; }
        [JsonProperty("dialInIpAddress")]
        public string DialInIpAddress { get; set; }
        [JsonProperty("telephony")]
        public MeetingTelephony Telephony { get; set; }
   }


}