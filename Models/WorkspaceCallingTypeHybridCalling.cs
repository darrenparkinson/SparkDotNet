using Newtonsoft.Json;

namespace SparkDotNet
{
    public class WorkspaceCallingTypeHybridCalling : WebexObject
    {
        /// <summary>
        /// End user email address in Cisco Unified CM.
        /// </summary>
        [JsonProperty("emailAddress")]
        public string EmailAddress { get; set; }
    }
}