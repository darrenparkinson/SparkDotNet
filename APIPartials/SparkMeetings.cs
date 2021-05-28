
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SparkDotNet
{

    public partial class Spark
    {

        private readonly string meetingsBase = "/v1/meetings";


        /// <summary>
        /// Retrieves details for meetings with a specified meeting number, web link, meeting type, etc.
        /// * If meetingNumber is specified, the operation returns an array of meeting objects specified by the meetingNumber. Each object in the array can be a scheduled meeting or a meeting series depending on whether the current parameter is true or false. When meetingNumber is specified, parameters of from, to, meetingType, state, isModified and participantEmail will be ignored. Please note that meetingNumber and webLink are mutually exclusive and they cannot be specified simultaneously.
        /// * If webLink is specified, the operation returns an array of meeting objects specified by the webLink.Each object in the array is a scheduled meeting.When webLink is specified, parameters of current, from, to, meetingType, state, isModified and participantEmail will be ignored. Please note that meetingNumber and webLink are mutually exclusive and they cannot be specified simultaneously.
        /// * If state parameter is specified, the returned array only has items in the specified state.If state is not specified, return items of all states.
        /// * If isModified parameter is specified, the returned array only has items which have been modified to exceptional meetings.This parameter only applies to scheduled meeting.
        /// * The current parameter only applies to meeting series. If it's true, the start and end attributes of each returned meeting series object are for the first scheduled meeting of that series. If it's true or not specified, the start and end attributes are for the scheduled meeting which is ready to start or join or the upcoming scheduled meeting of that series.
        /// * If from and to are specified, the operation returns an array of meeting objects in that specified time range.
        /// </summary>
        /// <param name="meetingNumber">Meeting number for the meeting objects being requested. meetingNumber and webLink are mutually exclusive.</param>
        /// <param name="webLink">URL encoded link to information page for the meeting objects being requested. meetingNumber and webLink are mutually exclusive.</param>
        /// <param name="meetingType">Meeting type for the meeting objects being requested. The default value is meetingSeries. Possible values: meetingSeries, scheduledMeeting, meeting</param>
        /// <param name="state">Meeting state for the meeting objects being requested. If not specified, return meetings of all states. Possible values: active, scheduled, ready, lobby, inProgress, ended, missed, expired</param>
        /// <param name="participantEmail">Meeting participant email address for the meeting objects being requested.</param>
        /// <param name="current">Whether or not to only retrieve the current scheduled meeting of the meeting series, i.e. the meeting ready to join or start or the upcoming meeting of the meeting series. Default: true</param>
        /// <param name="from">Start date and time (inclusive) in any ISO 8601 compliant format for the meeting objects being requested. Default: Current date and time</param>
        /// <param name="to">End date and time (exclusive) in any ISO 8601 compliant format for the meeting objects being requested. Default: If `from` is specified, the default value is `from` plus 7 days; if `from` is not specified, the default value is current date and time plus 7 days.</param>
        /// <param name="max">Limit the maximum number of meetings in the response, up to 100. Default: 10</param>
        /// <param name="hostEmail">Email address for the meeting host. This parameter is only used if the user or application calling the API has the admin-level scopes. If set, the admin may specify the email of a user in a site they manage and the API will return details for meetings that are hosted by that user.</param>
        /// <param name="siteUrl">URL of the Webex site which the API lists meetings from. If not specified, the API lists meetings from user's preferred site. All available Webex sites and preferred site of the user can be retrieved by Get Site List API.</param>
        /// <param name="integrationTag">External key created by an integration application. This parameter is used by the integration application to query meetings by a key in its own domain such as a Zendesk ticket ID, a Jira ID, a Salesforce Opportunity ID, etc.</param>
        /// <returns>A list of Meeting objects</returns>
        public async Task<List<Meeting>> GetMeetingsAsync(string meetingNumber = null, string webLink = null, string meetingType = null,
                                                          string state = null, string participantEmail = null, bool? current = null,
                                                          string from = null, string to = null,
                                                          int max = 0, string hostEmail = null, string siteUrl = null,
                                                          string integrationTag = null)
        {
            var queryParams = new Dictionary<string, string>();
            if (meetingNumber != null) queryParams.Add("meetingNumber", meetingNumber);
            if (webLink != null) queryParams.Add("webLink", webLink);
            if (meetingType != null) queryParams.Add("meetingType", meetingType);
            if (state != null) queryParams.Add("state", state);
            if (participantEmail != null) queryParams.Add("participantEmail", participantEmail);
            if (current != null) queryParams.Add("current", current.ToString());
            if (from != null) queryParams.Add("from", from);
            if (to != null) queryParams.Add("to", to);
            if (max > 0) queryParams.Add("max", max.ToString());
            if (hostEmail != null) queryParams.Add("hostEmail", hostEmail);
            if (siteUrl != null) queryParams.Add("siteUrl", siteUrl);
            if (integrationTag != null) queryParams.Add("integrationTag", integrationTag);

            var path = getURL(meetingsBase, queryParams);
            return await GetItemsAsync<Meeting>(path);
        }

        /// <summary>
        /// Retrieves details for a meeting with a specified meeting ID.
        /// * If the meetingId value specified is for a meeting series, the operation returns details for the first scheduled meeting of the series.
        /// * If the meetingId value specified is for a meeting series and current is "true", the operation returns details for the current scheduled meeting of the series, i.e.the scheduled meeting ready to join or start or the upcoming scheduled meeting of the meeting series.
        /// * If the meetingId value specified is for a scheduled meeting from a meeting series, the operation returns details for that scheduled meeting.
        /// * If the meetingId value specified is for a meeting instance which is happening or has happened, the operation returns details for that meeting instance.
        /// </summary>
        /// <param name="meetingId">Unique identifier for the meeting being requested.</param>
        /// <param name="current">Whether or not to retrieve only the current scheduled meeting of the meeting series, i.e. the meeting ready to join or start or the upcoming meeting of the meeting series. Default: false</param>
        /// <param name="hostEmail">Email address for the meeting host. This parameter is only used if the user or application calling the API has the admin-level scopes. If set, the admin may specify the email of a user in a site they manage and the API will return details for a meeting that is hosted by that user.</param>
        /// <param name="siteUrl">Webex site URL to query. If siteUrl is not specified, the users' preferred site will be used. If the authorization token has the admin-level scopes, the admin can set the Webex site URL on behalf of the user specified in the hostEmail parameter.</param>
        /// <returns></returns>
        public async Task<Meeting> GetMeetingAsync(string meetingId, bool? current = null, string hostEmail = null, string siteUrl = null)
        {
            var queryParams = new Dictionary<string, string>();
            if (current != null) queryParams.Add("current", current.ToString());
            if (hostEmail != null) queryParams.Add("hostEmail", hostEmail);
            if (siteUrl != null) queryParams.Add("siteUrl", siteUrl);

            var path = getURL($"{meetingsBase}/{meetingId}", queryParams);
            return await GetItemAsync<Meeting>(path);
        }

        /// <summary>
        /// Creates a new meeting.
        /// If the value of the parameter recurrence is null, a non-recurring meeting is created.
        /// If the parameter recurrence has a value, a recurring meeting is created based on the rule defined by the value of recurrence.
        /// </summary>
        /// <param name="title">Meeting title.</param>
        /// <param name="password">Meeting password.</param>
        /// <param name="start">Date and time for the start of meeting in any ISO 8601 compliant format. start cannot be before current date and time or after end. Duration between start and end cannot be shorter than 10 minutes or longer than 24 hours.</param>
        /// <param name="end">Date and time for the end of meeting in any ISO 8601 compliant format. end cannot be before current date and time or before start. Duration between start and end cannot be shorter than 10 minutes or longer than 24 hours.</param>
        /// <param name="enabledAutoRecordMeeting">Whether or not meeting is recorded automatically.</param>
        /// <param name="allowAnyUserToBeCoHost">Whether or not to allow any invitee to be a cohost.</param>
        /// <param name="agenda">Meeting agenda. The agenda can be a maximum of 2500 characters long.</param>
        /// <param name="timezone">Time zone in which meeting was originally scheduled (conforming with the IANA time zone database).</param>
        /// <param name="recurrence">Meeting series recurrence rule (conforming with RFC 2445), applying only to meeting series. This attribute is not allowed for a scheduled meeting or a meeting instance that is happening or has happended.</param>
        /// <param name="invitees">Invitees for meeting.</param>
        /// <returns>The new created Meeting object.</returns>
        /// <remarks>This method is kept due to compatibility</remarks>
        public async Task<Meeting> CreateMeetingAsync(string title, string password, DateTime start, DateTime end,
                                                    bool enabledAutoRecordMeeting, bool allowAnyUserToBeCoHost,
                                                    string agenda = null, TimeZoneInfo timezone = null, string recurrence = null,
                                                    MeetingInvitee[] invitees = null)
        {
            return await CreateMeetingAsync(title, start, end, enabledAutoRecordMeeting, allowAnyUserToBeCoHost, password);
        }

        /// <summary>
        /// Creates a new meeting.
        /// If the value of the parameter recurrence is null, a non-recurring meeting is created.
        /// If the parameter recurrence has a value, a recurring meeting is created based on the rule defined by the value of recurrence.
        /// If the parameter siteUrl has a value, the meeting is created on the specified site. Otherwise, the meeting is created on the user's preferred site.
        /// All available Webex sites and preferred site of the user can be retrieved by Get Site List API.
        /// </summary>
        /// <param name="title">Meeting title.</param>
        /// <param name="password">Meeting password.</param>
        /// <param name="start">Date and time for the start of meeting in any ISO 8601 compliant format. start cannot be before current date and time or after end. Duration between start and end cannot be shorter than 10 minutes or longer than 24 hours.</param>
        /// <param name="end">Date and time for the end of meeting in any ISO 8601 compliant format. end cannot be before current date and time or before start. Duration between start and end cannot be shorter than 10 minutes or longer than 24 hours.</param>
        /// <param name="enabledAutoRecordMeeting">Whether or not meeting is recorded automatically.</param>
        /// <param name="allowAnyUserToBeCoHost">Whether or not to allow any invitee to be a cohost.</param>
        /// <param name="agenda">Meeting agenda. The agenda can be a maximum of 2500 characters long.</param>
        /// <param name="timezone">Time zone in which meeting was originally scheduled (conforming with the IANA time zone database).</param>
        /// <param name="recurrence">Meeting series recurrence rule (conforming with RFC 2445), applying only to meeting series. This attribute is not allowed for a scheduled meeting or a meeting instance that is happening or has happended.</param>
        /// <param name="invitees">Invitees for meeting.</param>
        /// <param name="hostEmail">Email address for the meeting host. This attribute should only be set if the user or application calling the API has the admin-level scopes. When used, the admin may specify the email of a user in a site they manage to be the meeting host.</param>
        /// <param name="siteUrl">URL of the Webex site which the meeting is created on. If not specified, the meeting is created on user's preferred site. All available Webex sites and preferred site of the user can be retrieved by Get Site List API.</param>
        /// <param name="enabledJoinBeforeHost">Whether or not to allow any attendee to join the meeting before the host joins the meeting. The enabledJoinBeforeHost attribute can be modified for meeting series or scheduled meeting by Update a Meeting API.</param>
        /// <param name="enableConnectAudioBeforeHost">Whether or not to allow any attendee to connect audio in the meeting before host joins the meeting. This attribute is only applicable if the enabledJoinBeforeHost attribute is set to true. The enableConnectAudioBeforeHost attribute can be modified for meeting series or scheduled meeting by Update a Meeting API.</param>
        /// <param name="joinBeforeHostMinutes">the number of minutes an attendee can join the meeting before the meeting start time and the host joins. This attribute is only applicable if the enabledJoinBeforeHost attribute is set to true. The joinBeforeHostMinutes attribute can be modified for meeting series or scheduled meeting by Update a Meeting API. Valid options are 0, 5, 10 and 15. Default is 0 if not specified.</param>
        /// <param name="allowFirstUserToBeCoHost">Whether or not to allow the first attendee of the meeting with a host account on the target site to become a cohost. The target site is specified by siteUrl parameter when creating the meeting; if not specified, it's user's preferred site. The allowFirstUserToBeCoHost attribute can be modified for meeting series or scheduled meeting by Update a Meeting API.</param>
        /// <param name="allowAuthenticatedDevices">Whether or not to allow authenticated video devices in the meeting's organization to start or join the meeting without a prompt. This attribute can be modified for meeting series or scheduled meeting by Update a Meeting API.</param>
        /// <param name="sendEmail">Whether or not to send emails to host and invitees. It is an optional field and default value is true.</param>
        /// <param name="registration">Meeting registration. When this option is enabled, meeting invitee must register personal information in order to join the meeting. Meeting invitee will receive an email with a registration link for the registration. When the registration form has been submitted and approved, an email with a real meeting link will be received. By clicking that link the meeting invitee can join the meeting. Please note that meeting registration does not apply to a meeting when it's a recurring meeting with recurrence field or it has no password, or the Join Before Host option is enabled for the meeting. Read Register for a Meeting in Cisco Webex Meetings for details.</param>
        /// <param name="integrationTags">External keys created by an integration application in its own domain. They could be Zendesk ticket IDs, Jira IDs, Salesforce Opportunity IDs, etc. The integration application queries meetings by a key in its own domain. The maximum size of integrationTags is 3 and each item of integrationTags can be a maximum of 64 characters long.</param>
        /// <returns>The new created Meeting object.</returns>
        public async Task<Meeting> CreateMeetingAsync(string title, DateTime start, DateTime end,
                                                    bool enabledAutoRecordMeeting, bool allowAnyUserToBeCoHost,
                                                    string password = null, string agenda = null, TimeZoneInfo timezone = null, string recurrence = null,
                                                    MeetingInvitee[] invitees = null, string hostEmail = null,
                                                    string siteUrl = null, bool? enabledJoinBeforeHost = null,
                                                    bool? enableConnectAudioBeforeHost = null, int? joinBeforeHostMinutes = null,
                                                    bool? allowFirstUserToBeCoHost = null, bool? allowAuthenticatedDevices = null,
                                                    bool? sendEmail = null, MeetingRegistration registration = null,
                                                    string[] integrationTags = null)
        {
            var bodyParameters = new Dictionary<string, object>();
            bodyParameters.Add("title", title);
            bodyParameters.Add("start", start);
            bodyParameters.Add("end", end);
            bodyParameters.Add("enabledAutoRecordMeeting", enabledAutoRecordMeeting);
            bodyParameters.Add("allowAnyUserToBeCoHost", allowAnyUserToBeCoHost);

            if (password != null) bodyParameters.Add("password", password);
            if (agenda != null) bodyParameters.Add("agenda", agenda);
            if (timezone != null) bodyParameters.Add("timezone", timezone);
            if (recurrence != null) bodyParameters.Add("recurrence", recurrence);
            if (invitees != null) bodyParameters.Add("invitees", invitees);
            if (hostEmail != null) bodyParameters.Add("hostEmail", hostEmail);
            if (siteUrl != null) bodyParameters.Add("siteUrl", siteUrl);
            if (enabledJoinBeforeHost != null) bodyParameters.Add("enabledJoinBeforeHost", enabledJoinBeforeHost);
            if (enableConnectAudioBeforeHost != null) bodyParameters.Add("enableConnectAudioBeforeHost", enableConnectAudioBeforeHost);
            if (joinBeforeHostMinutes != null) bodyParameters.Add("joinBeforeHostMinutes", joinBeforeHostMinutes);
            if (allowFirstUserToBeCoHost != null) bodyParameters.Add("allowFirstUserToBeCoHost", allowFirstUserToBeCoHost);
            if (allowAuthenticatedDevices != null) bodyParameters.Add("allowAuthenticatedDevices", allowAuthenticatedDevices);
            if (sendEmail != null) bodyParameters.Add("sendEmail", sendEmail);
            if (registration != null) bodyParameters.Add("registration", registration);
            if (integrationTags != null) bodyParameters.Add("integrationTags", integrationTags);

            return await PostItemAsync<Meeting>(meetingsBase, bodyParameters);
        }

        /// <summary>
        /// Creates a new meeting.
        /// If the value of the parameter recurrence is null, a non-recurring meeting is created.
        /// If the parameter recurrence has a value, a recurring meeting is created based on the rule defined by the value of recurrence.
        /// </summary>
        /// <param name="meeting">Meeting object with details for the meeting to be created.</param>
        /// <param name="invitees">Invitees for meeting.</param>
        /// <param name="integrationTags">External keys created by an integration application in its own domain. They could be Zendesk ticket IDs, Jira IDs, Salesforce Opportunity IDs, etc. The integration application queries meetings by a key in its own domain. The maximum size of integrationTags is 3 and each item of integrationTags can be a maximum of 64 characters long.</param>
        /// <param name="sendEmail">Whether or not to send emails to host and invitees. It is an optional field and default value is true.</param>
        /// <returns>The new created Meeting object.</returns>
        public async Task<Meeting> CreateMeetingAsync(Meeting meeting, MeetingInvitee[] invitees = null, string[] integrationTags = null, bool? sendEmail = null )
        {
            return await CreateMeetingAsync(meeting.Title, meeting.Start, meeting.End, meeting.EnabledAutoRecordMeeting,
                                            meeting.AllowAnyUserToBeCoHost, meeting.Password, meeting.Agenda, meeting.Timezone, meeting.Recurrence,
                                            invitees, meeting.HostEmail, meeting.SiteUrl, meeting.EnabledJoinBeforeHost, meeting.EnableConnectAudioBeforeHost,
                                            meeting.JoinBeforeHostMinutes, meeting.AllowFirstUserToBeCoHost, meeting.AllowAuthenticatedDevices, sendEmail,
                                            meeting.Registration, integrationTags);
        }

        /// <summary>
        /// Deletes a meeting with a specified meeting ID. The deleted meeting cannot be recovered.
        /// If the meetingId value specified is for a scheduled meeting, the operation deletes that scheduled meeting without impact on other scheduled meeting of the parent meeting series.
        /// If the meetingId value specified is for a meeting series, the operation deletes the entire meeting series.
        /// </summary>
        /// <param name="meetingId">Unique identifier for the meeting to be deleted.</param>
        /// <param name="hostEmail">Email address for the meeting host. This parameter is only used if the user or application calling the API has the admin-level scopes. If set, the admin may specify the email of a user in a site they manage and the API will delete a meeting that is hosted by that user.</param>
        /// <param name="siteUrl">Webex site URL to query. If siteUrl is not specified, the users' preferred site will be used. If the authorization token has the admin-level scopes, the admin can set the Webex site URL on behalf of the user specified in the hostEmail parameter.</param>
        /// <returns>true if the Meeting was deleted, false otherwise</returns>
        public async Task<bool> DeleteMeetingAsync(string meetingId, string hostEmail = null, string siteUrl = null)
        {
            var queryParams = new Dictionary<string, string>();
            if (hostEmail != null) queryParams.Add("hostEmail", hostEmail);
            if (siteUrl != null) queryParams.Add("siteUrl", siteUrl);

            var path = getURL($"{meetingsBase}/{meetingId}", queryParams);

            return await DeleteItemAsync(path);
        }

        /// <summary>
        /// Deletes a meeting with a specified meeting ID. The deleted meeting cannot be recovered.
        /// If the meetingId value specified is for a scheduled meeting, the operation deletes that scheduled meeting without impact on other scheduled meeting of the parent meeting series.
        /// If the meetingId value specified is for a meeting series, the operation deletes the entire meeting series.
        /// </summary>
        /// <param name="meeting">Meeting object for the meeting to be deleted.</param>
        /// <returns>true if the Meeting was deleted, false otherwise</returns>
        public async Task<bool> DeleteMeetingAsync(Meeting meeting)
        {
            return await DeleteMeetingAsync(meeting.Id, meeting.HostEmail, meeting.SiteUrl);
        }

        /// <summary>
        /// Lists scheduled meeting and meeting instances of a meeting series identified by meetingSeriesId.
        /// Each scheduled meeting or meeting instance of a meeting series has its own start, end, etc. Thus, for example, when a daily meeting has been scheduled from 2019-04-01 to 2019-04-10, there are 10 scheduled meeting instances in this series, one instance for each day, and each one has its own attributes.When a scheduled meeting has started or is happening, there are even more meeting instances.
        /// Use this operation to list scheduled meeting and meeting instances of a meeting series within a specific date range.
        /// Long result sets are split into pages.
        /// </summary>
        /// <param name="meetingSeriesId">Unique identifier for the meeting series.</param>
        /// <param name="from">Start date and time (inclusive) for the range for which meetings are to be returned in any ISO 8601 compliant format. from cannot be before current date and time or after to. Default: Current date and time</param>
        /// <param name="to">End date and time (exclusive) for the range for which meetings are to be returned in any ISO 8601 compliant format. to cannot be before current date and time or before from. Default: If `from` is specified, the default value is `from` plus 7 days; if `from` is not specified, the default value is current date and time plus 7 days.</param>
        /// <param name="state">Meeting state for the meetings being requested. If not specified, return meetings of all states. Possible values: active, scheduled, ready, lobby, inProgress, ended, missed, expired</param>
        /// <param name="isModified">Flag identifying whether or not only to retrieve scheduled meeting instances which have been modified. This parameter only applies to scheduled meetings. If isModified value is true, only return modified scheduled meeting instances; if isModified value is false, only return unmodified scheduled meeting instances; if isModified is not specified, return all scheduled meeting and meeting instances.</param>
        /// <param name="max">Limit the maximum number of meetings in the response, up to 100. Default: 10</param>
        /// <param name="hostEmail">Email address for the meeting host. This parameter is only used if the user or application calling the API has the admin-level scopes. If set, the admin may specify the email of a user in a site they manage and the API will return details for meetings that are hosted by that user.</param>
        /// <param name="siteUrl">URL of the Webex site which the API lists meetings from. If not specified, the API lists meetings from user's preferred site. All available Webex sites and preferred site of the user can be retrieved by Get Site List API.</param>
        /// <returns>A list of Meeting objects of the given meetin series</returns>
        public async Task<List<Meeting>> GetMeetingsOfSeriesAsync(string meetingSeriesId, DateTime? from = null, DateTime? to = null,
                                                                  string state = null, bool? isModified = null, int max = 0,
                                                                  string hostEmail = null, string siteUrl = null)
        {
            var queryParams = new Dictionary<string, string>();
            queryParams.Add("meetingSeriesId", meetingSeriesId);

            if (from != null) queryParams.Add("from", from.ToString());
            if (to != null) queryParams.Add("to", to.ToString());
            if (state != null) queryParams.Add("state", state);
            if (isModified != null) queryParams.Add("isModified", isModified.ToString());
            if (max > 0) queryParams.Add("max", max.ToString());
            if (hostEmail != null) queryParams.Add("hostEmail", hostEmail);
            if (siteUrl != null) queryParams.Add("siteUrl", siteUrl);

            var path = getURL($"{meetingsBase}", queryParams);
            return await GetItemsAsync<Meeting>(path);
        }

        /// <summary>
        /// Update a recurring meeting series
        /// </summary>
        /// <param name="meetingId">Unique identifier for the meeting to be updated.</param>
        /// <param name="title">Meeting title.</param>
        /// <param name="password">Meeting password.</param>
        /// <param name="start">Date and time for the start of meeting in any ISO 8601 compliant format. start cannot be before current date and time or after end. Duration between start and end cannot be shorter than 10 minutes or longer than 24 hours.</param>
        /// <param name="end">Date and time for the end of meeting in any ISO 8601 compliant format. end cannot be before current date and time or before start. Duration between start and end cannot be shorter than 10 minutes or longer than 24 hours.</param>
        /// <param name="enabledAutoRecordMeeting">Whether or not meeting is recorded automatically.</param>
        /// <param name="allowAnyUserToBeCoHost">Whether or not to allow any invitee to be a cohost.</param>
        /// <param name="agenda">Meeting agenda. The agenda can be a maximum of 2500 characters long.</param>
        /// <param name="timezone">Time zone in which meeting was originally scheduled (conforming with the IANA time zone database).</param>
        /// <param name="recurrence">Meeting series recurrence rule (conforming with RFC 2445), applying only to meeting series. This attribute is not allowed for a scheduled meeting or a meeting instance that is happening or has happended.</param>
        /// <param name="hostEmail">Email address for the meeting host. This attribute should only be set if the user or application calling the API has the admin-level scopes. When used, the admin may specify the email of a user in a site they manage to be the meeting host.</param>
        /// <param name="siteUrl">URL of the Webex site which the meeting is updated on. If not specified, the meeting is created on user's preferred site. All available Webex sites and preferred site of the user can be retrieved by Get Site List API.</param>
        /// <param name="enabledJoinBeforeHost">Whether or not to allow any attendee to join the meeting before the host joins the meeting.</param>
        /// <param name="enableConnectAudioBeforeHost">Whether or not to allow any attendee to connect audio in the meeting before the host joins the meeting. This attribute is only applicable if the enabledJoinBeforeHost attribute is set to true.</param>
        /// <param name="joinBeforeHostMinutes">the number of minutes an attendee can join the meeting before the meeting start time and the host joins. This attribute is only applicable if the enabledJoinBeforeHost attribute is set to true. Valid options are 0, 5, 10 and 15. Default is 0 if not specified.</param>
        /// <param name="allowFirstUserToBeCoHost">Whether or not to allow the first attendee of the meeting with a host account on the target site to become a cohost. The target site is specified by siteUrl parameter when creating the meeting; if not specified, it's user's preferred site.</param>
        /// <param name="allowAuthenticatedDevices">Whether or not to allow authenticated video devices in the meeting's organization to start or join the meeting without a prompt.</param>
        /// <param name="sendEmail">Whether or not to send emails to host and invitees. It is an optional field and default value is true.</param>
        /// <param name="registration">Meeting registration. When this option is enabled, meeting invitee must register personal information in order to join the meeting. Meeting invitee will receive an email with a registration link for the registration. When the registration form has been submitted and approved, an email with a real meeting link will be received. By clicking that link the meeting invitee can join the meeting. Please note that meeting registration does not apply to a meeting when it's a recurring meeting with recurrence field or it has no password, or the Join Before Host option is enabled for the meeting. Read Register for a Meeting in Cisco Webex Meetings for details.</param>
        /// <returns>The updated Meeting object.</returns>
        public async Task<Meeting> UpdateMeetingAsync(string meetingId, string title, string password, DateTime start, DateTime end,
                                            bool enabledAutoRecordMeeting, bool? allowAnyUserToBeCoHost = null,
                                            string agenda = null, TimeZoneInfo timezone = null, string recurrence = null,
                                            string hostEmail = null, string siteUrl = null, bool? enabledJoinBeforeHost = null,
                                            bool? enableConnectAudioBeforeHost = null, int? joinBeforeHostMinutes = null,
                                            bool? allowFirstUserToBeCoHost = null, bool? allowAuthenticatedDevices = null,
                                            bool? sendEmail = null, MeetingRegistration registration = null)
        {
            var bodyParameters = new Dictionary<string, object>();
            bodyParameters.Add("title", title);
            bodyParameters.Add("password", password);
            bodyParameters.Add("start", start);
            bodyParameters.Add("end", end);
            bodyParameters.Add("enabledAutoRecordMeeting", enabledAutoRecordMeeting);

            if (allowAnyUserToBeCoHost != null) bodyParameters.Add("allowAnyUserToBeCoHost", allowAnyUserToBeCoHost);
            if (agenda != null) bodyParameters.Add("agenda", agenda);
            if (timezone != null) bodyParameters.Add("timezone", timezone);
            if (recurrence != null) bodyParameters.Add("recurrence", recurrence);
            if (hostEmail != null) bodyParameters.Add("hostEmail", hostEmail);
            if (siteUrl != null) bodyParameters.Add("siteUrl", siteUrl);
            if (enabledJoinBeforeHost != null) bodyParameters.Add("enabledJoinBeforeHost", enabledJoinBeforeHost);
            if (enableConnectAudioBeforeHost != null) bodyParameters.Add("enableConnectAudioBeforeHost", enableConnectAudioBeforeHost);
            if (joinBeforeHostMinutes != null) bodyParameters.Add("joinBeforeHostMinutes", joinBeforeHostMinutes);
            if (allowFirstUserToBeCoHost != null) bodyParameters.Add("allowFirstUserToBeCoHost", allowFirstUserToBeCoHost);
            if (allowAuthenticatedDevices != null) bodyParameters.Add("allowAuthenticatedDevices", allowAuthenticatedDevices);
            if (sendEmail != null) bodyParameters.Add("sendEmail", sendEmail);
            if (registration != null) bodyParameters.Add("registration", registration);

            return await PostItemAsync<Meeting>($"{meetingsBase}/{meetingId}", bodyParameters);
        }

        /// <summary>
        /// Update a recurring meeting series
        /// </summary>
        /// <param name="meeting">The Meeting object to be updated</param>
        /// <param name="sendEmail">Whether or not to send emails to host and invitees. It is an optional field and default value is true.</param>
        /// <returns>The updated Meeting object.</returns>
        public async Task<Meeting> UpdateMeetingAsync(Meeting meeting, bool? sendEmail = null)
        {
            return await UpdateMeetingAsync(meeting.Id, meeting.Title, meeting.Password, meeting.Start, meeting.End,
                                            meeting.EnabledAutoRecordMeeting, meeting.AllowAnyUserToBeCoHost, meeting.Agenda,
                                            meeting.Timezone, meeting.Recurrence, meeting.HostEmail, meeting.SiteUrl,
                                            meeting.EnabledJoinBeforeHost, meeting.EnableConnectAudioBeforeHost,
                                            meeting.JoinBeforeHostMinutes, meeting.AllowFirstUserToBeCoHost,
                                            meeting.AllowAuthenticatedDevices, sendEmail, meeting.Registration);
        }

        /// <summary>
        /// Get the meeting control of a live meeting, which is consisted of meeting control status on "locked" and "recording" to reflect whether the meeting is currently locked and there is recording in progress.
        /// </summary>
        /// <param name="meetingId">Unique identifier for the meeting.</param>
        /// <returns>The controls status objects for the meeting</returns>
        public async Task<MeetingControls> GetMeetingControlsAsync(string meetingId)
        {
            var queryParams = new Dictionary<string, string>();
            queryParams.Add("meetingId", meetingId);

            var path = getURL($"{meetingsBase}/controls", queryParams);

            return await GetItemAsync<MeetingControls>(path);
        }

        /// <summary>
        /// Get the meeting control of a live meeting, which is consisted of meeting control status on "locked" and "recording" to reflect whether the meeting is currently locked and there is recording in progress.
        /// </summary>
        /// <param name="meeting">The meeting object.</param>
        /// <returns>The controls status objects for the meeting</returns>
        public async Task<MeetingControls> GetMeetingControlsAsync(Meeting meeting)
        {
            return await GetMeetingControlsAsync(meeting.Id);
        }

        /// <summary>
        /// To start, pause, resume, or stop a meeting recording; To lock or unlock an on-going meeting.
        /// </summary>
        /// <param name="meetingId">Unique identifier for the meeting.</param>
        /// <param name="recordingStarted">The value can be true or false. true means to start the recording, false to end the recording.</param>
        /// <param name="recordingPaused">The value can be true or false, will be ignored if 'recordingStarted' sets to false, and true to resume the recording only if the recording is paused vise versa.</param>
        /// <param name="locked">The value is true or false.</param>
        /// <returns>The updated meeting state object</returns>
        public async Task<MeetingControls> UpdateMeetingControlsAsync(string meetingId, bool? recordingStarted = null,
                                                                      bool? recordingPaused = null, bool? locked = null)
        {
            var queryParams = new Dictionary<string, string>();
            queryParams.Add("meetingId", meetingId);

            var path = getURL($"{meetingsBase}/controls", queryParams);

            var bodyParameters = new Dictionary<string, object>();
            if (recordingStarted != null) bodyParameters.Add("recordingStarted", recordingStarted);
            if (recordingPaused != null) bodyParameters.Add("recordingPaused", recordingPaused);
            if (locked != null) bodyParameters.Add("locked", locked);

            return await UpdateItemAsync<MeetingControls>(path, bodyParameters);
        }

        /// <summary>
        /// To start, pause, resume, or stop a meeting recording; To lock or unlock an on-going meeting.
        /// </summary>
        /// <param name="meeting">The meeting object to be updated</param>
        /// <param name="controls">The new meeting control settings</param>
        /// <returns>The updated meeting state object</returns>
        public async Task<MeetingControls> UpdateMeetingControlsAsync(Meeting meeting, MeetingControls controls)
        {
            return await UpdateMeetingControlsAsync(meeting.Id, controls.RecordingStarted, controls.RecordingPaused, controls.Locked);
        }


    }

}