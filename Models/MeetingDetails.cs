namespace SparkDotNet
{
    public class MeetingDetails : WebexObject
    {
        /// <summary>
        /// A unique identifier for the room.
        /// </summary>
        public string roomId { get; set; }

        /// <summary>
        /// The Webex meeting URL for the room.
        /// </summary>
        public string meetingLink { get; set; }

        /// <summary>
        /// The SIP address for the room.
        /// </summary>
        public string sipAddress { get; set; }

        /// <summary>
        /// The Webex meeting number for the room.
        /// </summary>
        public string meetingNumber { get; set; }

        /// <summary>
        /// The toll-free PSTN number for the room.
        /// </summary>
        public string callInTollFreeNumber { get; set; }

        /// <summary>
        /// The toll (local) PSTN number for the room.
        /// </summary>
        public string callInTollNumber { get; set; }
    }
}
