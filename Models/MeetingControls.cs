using Newtonsoft.Json;

namespace SparkDotNet
{
    public class MeetingControls : WebexObject
    {
        /// <summary>
        /// Whether the meeting is locked or not.
        /// </summary>
        [JsonProperty("locked")]
        public bool Locked { get; set; }

        /// <summary>
        /// The value can be true or false, it indicates the meeting recording started or not.
        /// </summary>
        [JsonProperty("recordingStarted")]
        public bool RecordingStarted { get; set; }

        /// <summary>
        /// The value can be true or false, it indicates the meeting recording paused or not.
        /// </summary>
        [JsonProperty("recordingPaused")]
        public bool RecordingPaused { get; set; }
    }
}