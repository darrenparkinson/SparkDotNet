using Newtonsoft.Json;
using System;

namespace SparkDotNet
{
    /// <summary>
    /// Meetings are virtual conferences where users can collaborate in real time using audio, video, content sharing, chat,
    /// online whiteboards, and more to collaborate.
    /// This API focuses primarily on the scheduling and management of meetings.You can use the Meetings API to list, create,
    /// get, update, and delete meetings.
    /// Several types of meeting objects are supported by this API, such as meeting series, scheduled meeting, and meeting instances.
    /// See the Webex Meetings guide for more information about the types of meetings.
    /// </summary>
    public class Meeting : WebexObject
    {
        /// <summary>
        /// Unique identifier for meeting.
        /// If it's a meeting series, the id is used to identify the entire series;
        /// if it's a scheduled meeting from a series, the id is used to identify that scheduled meeting;
        /// if it's a meeting instance that is happening or has happened, the id is used to identify that instance.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Unique identifier for meeting series.
        /// If it's a meeting series, meetingSeriesId is the same as id;
        /// if it's a scheduled meeting from a series or a meeting instance that is happening or has happened, the meetingSeriesId is the id of the master series.
        /// </summary>
        [JsonProperty("meetingSeriesId")]
        public string MeetingSeriesId { get; set; }

        /// <summary>
        /// Unique identifier for scheduled meeting which current meeting is associated with.
        /// It only apples to scheduled meeting and meeting instance. If the meeting is a scheduled meeting,
        /// scheduledMeetingId is the same as id; if the meeting is a meeting instance that is happening
        /// or has happened, scheduledMeetingId is the id of the scheduled meeting this instance is associated with.
        /// </summary>
        [JsonProperty("scheduledMeetingId")]
        public string ScheduledMeetingId { get; set; }

        /// <summary>
        /// Meeting number.
        /// This attribute applies to meeting series, scheduled meeting and meeting instance, but it does not apply to meeting instances which have ended.
        /// </summary>
        [JsonProperty("meetingNumber")]
        public string MeetingNumber { get; set; }

        /// <summary>
        /// Meeting title.
        /// This attribute can be modified for meeting series or scheduled meeting by Update a Meeting API.
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// Meeting agenda.
        /// The agenda can be a maximum of 2500 characters long. This attribute can be modified for meeting series or scheduled meeting by Update a Meeting API.
        /// </summary>
        [JsonProperty("agenda")]
        public string Agenda { get; set; }

        /// <summary>
        /// Meeting password.
        /// This attribute applies to meeting series, scheduled meeting and meeting instance, but it does not apply to meeting instances which have ended.
        /// It can be modified for meeting series or scheduled meeting by Update a Meeting API.
        /// </summary>
        [JsonProperty("password")]
        public string Password { get; set; }

        /// <summary>
        /// 8-digit numeric password to join meeting from audio and video devices.
        /// This attribute applies to meeting series, scheduled meeting and in-progress meeting instance,
        /// but it does not apply to meeting instances which have ended.
        /// </summary>
        [JsonProperty("phoneAndVideoSystemPassword")]
        public string PhoneAndVideoSystemPassword  { get; set; }

        /// <summary>
        /// Meeting type.
        /// meetingSeries: Master of a scheduled series of meetings which consists of one or more scheduled meeting based on a recurrence rule.
        /// scheduledMeeting: Instance from a master meeting series.
        /// meeting: meeting instance that is actually happening or has happened.
        /// </summary>
        [JsonProperty("meetingType")]
        public string MeetingType { get; set; }

        /// <summary>
        /// Meeting state.
        /// active: This state only applies to meeting series.It indicates that one or more future scheduled meeting exist for this meeting series.
        /// scheduled: This state only applies to scheduled meeting. It indicates that the meeting is scheduled in the future.
        /// ready: This state only applies to scheduled meeting. It indicates that this scheduled meeting is ready to start or join now.
        /// lobby:This state only applies to meeting instance. It indicates that a locked meeting has been joined by participants, but no hosts.
        /// inProgress: This state applies to meeting series, scheduled meeting and meeting instance.For meeting series, this state indicates that a meeting instance of this series is happening; for scheduled meeting, it indicates a meeting instance of this scheduled meeting is happening; for meeting instance, the current instance is happening.
        /// ended: This state applies to scheduled meeting and meeting instance. For scheduled meeting, it indicates that one or more meeting instances have been started for this scheduled meeting and now the scheduled meeting is over since it has passed the scheduled end time of the scheduled meeting; for meeting instance, this state indicates that this instance is ended.
        /// missed: This state only applies to scheduled meeting. It indicates that the scheduled meeting was scheduled in the past but never happened.
        /// expired:This state only applies to meeting series. It indicates that all scheduled meeting instances of this series have passed.
        /// </summary>
        [JsonProperty("state")]
        public string State { get; set; }

        /// <summary>
        /// This state only applies to scheduled meeting. Flag identifying whether or not the scheduled meeting has been modified.
        /// </summary>
        [JsonProperty("isModified")]
        public bool IsModified { get; set; }


        /// <summary>
        /// Time zone of start and end, conforming with the IANA time zone database.
        /// </summary>
        [JsonProperty("timezone")]
        [JsonConverter(typeof(TimeZoneInfoConverter))]
        public System.TimeZoneInfo Timezone { get; set; }

        /// <summary>
        /// Start time for meeting in ISO 8601 compliant format.
        /// If the meeting is a meeting series, start is the date and time the first meeting of the series starts;
        /// if the meeting is a meeting series and current filter is true, start is the date and time the upcoming or ongoing meeting of the series starts;
        /// if the meeting is a scheduled meeting from a meeting series, start is the date and time when that scheduled meeting starts;
        /// if the meeting is a meeting instance that has happened or is happening, start is the date and time that instance actually starts.
        /// This attribute can be modified for meeting series or scheduled meeting by Update a Meeting API.
        /// </summary>
        [JsonProperty("start")]
        public System.DateTime Start { get; set; }

        /// <summary>
        /// End time for meeting in ISO 8601 compliant format.
        /// If the meeting is a meeting series, end is the date and time the first meeting of the series ends;
        /// if the meeting is a meeting series and current filter is true, end is the date and time the upcoming or ongoing meeting of the series ends;
        /// if the meeting is a scheduled meeting from a meeting series, end is the date and time when that scheduled meeting ends;
        /// if the meeting is a meeting instance that has happened, end is the date and time that instance actually ends;
        /// if a meeting intance is in progress, end is not available.
        /// This attribute can be modified for meeting series or scheduled meeting by Update a Meeting API.
        /// </summary>
        [JsonProperty("end")]
        public System.DateTime End { get; set; }

        /// <summary>
        /// Meeting series recurrence rule (conforming with RFC 2445), applying only to recurring meeting series.
        /// It does not apply to meeting series with only one scheduled meeting. This attribute can be modified
        /// for meeting series by Update a Meeting API.
        /// </summary>
        [JsonProperty("recurrence")]
        public string Recurrence { get; set; }

        /// <summary>
        /// Unique identifier for meeting host.
        /// It's in the format of Base64Encode(ciscospark://us/PEOPLE/hostUserId).
        /// For example, a hostUserId is 7BABBE99-B43E-4D3F-9147-A1E9D46C9CA0, the actual value for it is Y2lzY29zcGFyazovL3VzL1BFT1BMRS83QkFCQkU5OS1CNDNFLTREM0YtOTE0Ny
        /// </summary>
        [JsonProperty("hostUserId")]
        public string HostUserId { get; set; }

        /// <summary>
        /// Display name for meeting host.
        /// </summary>
        [JsonProperty("hostDisplayName")]
        public string HostDisplayName { get; set; }

        /// <summary>
        /// Email address for meeting host.
        /// </summary>
        [JsonProperty("hostEmail")]
        public string HostEmail { get; set; }

        /// <summary>
        /// Key for joining meeting as host.
        /// </summary>
        [JsonProperty("hostKey")]
        public string HostKey { get; set; }

        /// <summary>
        /// Site URL for the meeting.
        /// </summary>
        [JsonProperty("siteUrl")]
        public string SiteUrl { get; set; }

        /// <summary>
        /// Link to meeting information page where meeting client will be launched if the meeting is ready for start or join.
        /// </summary>
        [JsonProperty("webLink")]
        public string WebLink { get; set; }

        /// <summary>
        /// SIP address for callback from a video system.
        /// </summary>
        [JsonProperty("sipAddress")]
        public string SipAddress { get; set; }

        /// <summary>
        /// IP address for callback from a video system.
        /// </summary>
        [JsonProperty("dialInIpAddress")]
        public string DialInIpAddress { get; set; }

        /// <summary>
        /// Whether or not meeting is recorded automatically.
        /// This attribute can be modified for meeting series or scheduled meeting by Update a Meeting API.
        /// </summary>
        [JsonProperty("enabledAutoRecordMeeting")]
        public bool EnabledAutoRecordMeeting { get; set; }

        /// <summary>
        /// Whether or not to allow any invitee to be a cohost.
        /// This attribute can be modified for meeting series or scheduled meeting by Update a Meeting API.
        /// </summary>
        [JsonProperty("allowAnyUserToBeCoHost")]
        public bool AllowAnyUserToBeCoHost { get; set; }

        /// <summary>
        /// Whether or not to allow any attendee to join the meeting before the host joins the meeting.
        /// The enabledJoinBeforeHost attribute can be modified for meeting series or scheduled meeting by
        /// Update a Meeting API.
        /// </summary>
        [JsonProperty("enabledJoinBeforeHost")]
        public bool EnabledJoinBeforeHost { get; set; }

        /// <summary>
        /// Whether or not to allow any attendee to connect audio in the meeting before host joins the meeting.
        /// This attribute is only applicable if the enabledJoinBeforeHost attribute is set to true.
        /// The enableConnectAudioBeforeHost attribute can be modified for meeting series or scheduled
        /// meeting by Update a Meeting API.
        /// </summary>
        [JsonProperty("enableConnectAudioBeforeHost")]
        public bool EnableConnectAudioBeforeHost { get; set; }

        /// <summary>
        /// the number of minutes an attendee can join the meeting before the meeting start time and the host joins.
        /// This attribute is only applicable if the enabledJoinBeforeHost attribute is set to true.
        /// The joinBeforeHostMinutes attribute can be modified for meeting series or scheduled meeting
        /// by Update a Meeting API. Valid options are 0, 5, 10 and 15. Default is 0 if not specified.
        /// </summary>
        [JsonProperty("joinBeforeHostMinutes")]
        public int JoinBeforeHostMinutes { get; set; }

        /// <summary>
        /// Whether or not to allow the first attendee of the meeting with a host account on the target site to become
        /// a cohost. The target site is specified by siteUrl parameter when creating the meeting; if not specified,
        /// it's user's preferred site. The allowFirstUserToBeCoHost attribute can be modified for meeting series
        /// or scheduled meeting by Update a Meeting API.
        /// </summary>
        [JsonProperty("allowFirstUserToBeCoHost")]
        public bool AllowFirstUserToBeCoHost { get; set; }

        /// <summary>
        /// Whether or not to allow authenticated video devices in the meeting's organization to start or join the meeting
        /// without a prompt. This attribute can be modified for meeting series or scheduled meeting by Update a Meeting API.
        /// </summary>
        [JsonProperty("allowAuthenticatedDevices")]
        public bool AllowAuthenticatedDevices { get; set; }

        /// <summary>
        /// Information for callbacks from meeting to phone or for joining a teleconference using a phone.
        /// </summary>
        [JsonProperty("telephony")]
        public MeetingTelephony Telephony { get; set; }

        /// <summary>
        /// Meeting registration.
        /// When this option is enabled, meeting invitee must register personal information in order to join the meeting.
        /// Meeting invitee will receive an email with a registration link for the registration.
        /// When the registration form has been submitted and approved, an email with a real meeting link will be received.
        /// By clicking that link the meeting invitee can join the meeting. Please note that meeting registration does
        /// not apply to a meeting when it's a recurring meeting with recurrence field or it has no password,
        /// or the Join Before Host option is enabled for the meeting. Read Register for a Meeting in
        /// Cisco Webex Meetings for details.
        /// </summary>
        [JsonProperty("registration")]
        public MeetingRegistration Registration { get; set; }
    }
}