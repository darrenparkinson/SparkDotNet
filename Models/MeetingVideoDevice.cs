namespace SparkDotNet
{
    public class MeetingVideoDevice : WebexObject
    {
        /// <summary>
        /// Video system name. It cannot be empty.
        /// This attribute can be modified by Update Video Options API.
        /// </summary>
        public string DeviceName { get; set; }

        /// <summary>
        /// Video address. It cannot be empty and must be in valid email format.
        /// This attribute can be modified by Update Video Options API.
        /// </summary>
        public string DeviceAddress { get; set; }

        /// <summary>
        /// Flag identifying the device as the default video device.
        /// If user's video device list is not empty, one and only one device must be set as default.
        /// This attribute can be modified by Update Video Options API.
        /// </summary>
        public bool IsDefault { get; set; }

    }
}