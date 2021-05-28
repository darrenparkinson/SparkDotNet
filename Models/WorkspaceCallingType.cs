using Newtonsoft.Json;

namespace SparkDotNet
{
    public class WorkspaceCallingType : WebexObject
    {
        /// <summary>
        /// Calling type.
        /// Possible values:
        /// * freeCalling: Free Calling.
        /// * hybridCalling: Hybrid Calling.
        /// * webexCalling: Webex Calling.
        /// * webexEdgeForDevices: Webex Edge For Devices.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// The hybridCalling object only applies when calling type is hybridCalling.
        /// </summary>
        [JsonProperty("hybridCalling")]
        public WorkspaceCallingTypeHybridCalling HybridCalling { get; set; }
    }
}