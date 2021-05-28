namespace SparkDotNet
{
    public class MeetingSchedulingOptions : WebexObject
    {
        /// <summary>
        /// Flag to enable/disable Join Before Host.
        /// The period during which invitees can join before the start time is defined by autoLockMinutes.
        /// This attribute can be modified by Update Scheduling Options API.
        /// Note: This feature is only effective if the site supports the Join Before Host feature.
        /// This attribute can be modified by Update Scheduling Options API.
        /// </summary>
        public bool EnabledJoinBeforeHost { get; set; }

        /// <summary>
        /// Number of minutes before the start time that an invitee can join a meeting if enabledJoinBeforeHost is true.
        /// Valid options are 0, 5, 10 and 15. This attribute can be modified by Update Scheduling Options API.
        /// </summary>
        public int JoinBeforeHostMinutes { get; set; }

        /// <summary>
        /// Flag to enable/disable the automatic sharing of the meeting recording with invitees when it is available.
        /// This attribute can be modified by Update Scheduling Options API.
        /// </summary>
        public bool EnabledAutoShareRecording { get; set; }

    }


}