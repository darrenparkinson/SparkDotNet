using Newtonsoft.Json;

namespace SparkDotNet
{
    public class MeetingPreferencesCoHost : WebexObject
    {
        /// <summary>
        /// Email address for cohost. This attribute can be modified by Update Personal Meeting Room Options API.
        /// Possible values: john.andersen @example.com
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; set; }

        /// <summary>
        /// Display name for cohost. This attribute can be modified by Update Personal Meeting Room Options API.
        /// Possible values: John Andersen
        /// </summary>
        [JsonProperty("displayName")]
        public string DisplayName { get; set; }
   }


}