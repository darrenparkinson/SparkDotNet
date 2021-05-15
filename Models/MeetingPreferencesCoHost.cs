using Newtonsoft.Json;

namespace SparkDotNet
{
    public class MeetingPreferencesCoHost : WebexObject
    {
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("displayName")]
        public string DisplayName { get; set; }
   }


}