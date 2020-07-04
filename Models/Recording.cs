using System;
using Newtonsoft.Json;

namespace SparkDotNet
{
    /// <summary>
    /// Recordings are meeting content captured in a meeting or files uploaded via the upload page for your Webex site.
    /// This API manages recordings.Recordings may be retrieved via download or playback links defined by downloadUrl or playbackUrl in the response body.
    /// </summary>
    public class Recording
    {
        /// <summary>
        /// A unique identifier for recording.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The recording's topic.
        /// </summary>
        public string Topic { get; set; }

        /// <summary>
        /// The date and time recording was created in ISO 8601 compliant format.
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// The download link for recording.
        /// </summary>
        public string DownloadUrl { get; set; }

        /// <summary>
        /// The playback link for recording.
        /// </summary>
        public string PlaybackUrl { get; set; }

        /// <summary>
        /// The recording's password.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// MP4: Recording file format is MP4.
        /// ARF: Recording file format is ARF, a private format of Webex recordings.This format requires the Cisco ARF recording player.
        /// </summary>
        public string Format { get; set; }

        /// <summary>
        /// The duration of the recording, in seconds.
        /// </summary>
        public int DurationSeconds { get; set; }

        /// <summary>
        /// The size of the recording file, in bytes.
        /// </summary>
        public int SizeBytes { get; set; }

        /// <summary>
        /// Whether or not the recording has been shared to the current user.
        /// </summary>
        public bool ShareToMe { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }


}