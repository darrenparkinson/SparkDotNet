
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SparkDotNet
{

    public partial class Spark
    {

        private string meetingsBase = "/v1/meetings";


        /// <summary>
        /// Retrieves details for meetings with a specified meeting number, web link, meeting type, etc.
        /// * If neither meetingNumber nor webLink is specified, the operation returns an array of all scheduled meeting instances.
        /// * If meetingNumber or webLink is specified, the operation returns an array of meeting objects specified by the meetingNumber or webLink value.Each object in the array can be a meeting series, a scheduled meeting, or a meeting instance which has actually happened or is happening, depending on the meetingType parameter.Please note that meetingNumber and webLink are mutually exclusive, which cannot be specified simultaneously.
        /// * If state parameter is specified, the returned array only has items in the specified state.If state is not specified, return items of all states.
        /// * If isModified parameter is specified, the returned array only has items which have been modified to exceptional meetings.This parameter only applies to scheduled meeting.
        /// * The current parameter only applies to meeting series. If current value is false, the start and end attributes of each returned meeting series object are for the first scheduled meeting of that series.If current value is true or not specified, the start and end attributes are for the meeting instance which is actually happening or the upcoming scheduled meeting.
        /// * If from and to are specified, the operation returns an array of meeting objects in that specified time range.
        /// </summary>
        /// <param name="meetingNumber">Meeting number for the meeting objects being requested. meetingNumber and webLink are mutually exclusive.</param>
        /// <param name="webLink">URL encoded link to information page for the meeting objects being requested. meetingNumber and webLink are mutually exclusive.</param>
        /// <param name="meethingType">Meeting type for the meeting objects being requested. The default value is meetingSeries. Possible values: meetingSeries, scheduledMeeting, meeting</param>
        /// <param name="state">Meeting state for the meeting objects being requested. If not specified, return meetings of all states. Possible values: active, scheduled, ready, lobby, inProgress, ended, missed, expired</param>
        /// <param name="participantEmail">Meeting participant email address for the meeting objects being requested.</param>
        /// <param name="current">Whether or not to only retrieve the current scheduled meeting of the meeting series, i.e. the meeting ready to join or start or the upcoming meeting of the meeting series. Default: true</param>
        /// <param name="from">Start date and time (inclusive) in any ISO 8601 compliant format for the meeting objects being requested. Default: Current date and time</param>
        /// <param name="to">End date and time (exclusive) in any ISO 8601 compliant format for the meeting objects being requested. Default: If `from` is specified, the default value is `from` plus 7 days; if `from` is not specified, the default value is current date and time plus 7 days.</param>
        /// <param name="max">Limit the maximum number of meetings in the response, up to 100. Default: 10</param>
        /// <returns>A list of Meeting objects</returns>
        public async Task<List<Meeting>> GetMeetingsAsync(string meetingNumber = null, string webLink = null, string meethingType = null,
                                                          string state = null, string participantEmail = null, bool? current = null,
                                                          string from = null, string to = null,
                                                          int max = 0)
        {
            var queryParams = new Dictionary<string, string>();
            if (meetingNumber != null) queryParams.Add("meetingNumber", meetingNumber);
            if (webLink != null) queryParams.Add("webLink", webLink);
            if (meethingType != null) queryParams.Add("meethingType", meethingType);
            if (state != null) queryParams.Add("state", state);
            if (participantEmail != null) queryParams.Add("participantEmail", participantEmail);
            if (current != null) queryParams.Add("current", current.ToString());
            if (from != null) queryParams.Add("from", from);
            if (to != null) queryParams.Add("to", to);
            if (max > 0) queryParams.Add("max", max.ToString());

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
        /// <returns></returns>
        public async Task<Meeting> GetMeetingAsync(string meetingId, bool? current = null)
        {
            var queryParams = new Dictionary<string, string>();
            if (current != null) queryParams.Add("current", current.ToString());

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
        public async Task<Meeting> CreateMeetingAsync(string title, string password, DateTime start, DateTime end,
                                                    bool enabledAutoRecordMeeting, bool allowAnyUserToBeCoHost, 
                                                    string agenda = null, TimeZoneInfo timezone = null, string recurrence = null,
                                                    MeetingInvitee[] invitees = null)
        {
            var bodyParameters = new Dictionary<string, object>();
            bodyParameters.Add("title", title);
            bodyParameters.Add("password", password);
            bodyParameters.Add("start", start);
            bodyParameters.Add("end", end);
            bodyParameters.Add("enabledAutoRecordMeeting", enabledAutoRecordMeeting);
            bodyParameters.Add("allowAnyUserToBeCoHost", allowAnyUserToBeCoHost);

            if (agenda != null) bodyParameters.Add("agenda", agenda);
            if (timezone != null) bodyParameters.Add("timezone", timezone);
            if (recurrence != null) bodyParameters.Add("recurrence", recurrence);
            if (invitees != null) bodyParameters.Add("invitees", invitees);

            return await PostItemAsync<Meeting>(meetingsBase, bodyParameters);
        }

        /// <summary>
        /// Creates a new meeting.
        /// If the value of the parameter recurrence is null, a non-recurring meeting is created.
        /// If the parameter recurrence has a value, a recurring meeting is created based on the rule defined by the value of recurrence.
        /// </summary>
        /// <param name="meeting">Meeting object with details for the meeting to be created.</param>
        /// <param name="invitees">Invitees for meeting.</param>
        /// <returns>The new created Meeting object.</returns>
        public async Task<Meeting> CreateMeetingAsync(Meeting meeting, MeetingInvitee[] invitees = null)
        {
            return await CreateMeetingAsync(meeting.Title, meeting.Password, meeting.Start, meeting.End, meeting.EnabledAutoRecordMeeting,
                                            meeting.AllowAnyUserToBeCoHost, meeting.Agenda, meeting.Timezone, meeting.Recurrence,
                                            invitees);
        }

        /// <summary>
        /// Deletes a meeting with a specified meeting ID. The deleted meeting cannot be recovered.
        /// If the meetingId value specified is for a scheduled meeting, the operation deletes that scheduled meeting without impact on other scheduled meeting of the parent meeting series.
        /// If the meetingId value specified is for a meeting series, the operation deletes the entire meeting series.
        /// </summary>
        /// <param name="meetingId">Unique identifier for the meeting to be deleted.</param>
        /// <returns>true if the Meeting was deleted, false otherwise</returns>
        public async Task<bool> DeleteMeetingAsync(string meetingId)
        {
            return await DeleteItemAsync($"{meetingsBase}/{meetingId}");
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
            return await DeleteMeetingAsync(meeting.Id);
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
        /// <returns>A list of Meeting objects of the given meetin series</returns>
        public async Task<List<Meeting>> GetMeetingsOfSeriesAsync(string meetingSeriesId, DateTime? from = null, DateTime? to = null,
                                                                  string state = null, bool? isModified = null, int max = 0 )
        {
            var queryParams = new Dictionary<string, string>();
            queryParams.Add("meetingSeriesId", meetingSeriesId);

            if (from != null) queryParams.Add("from", from.ToString());
            if (to != null) queryParams.Add("to", to.ToString());
            if (state != null) queryParams.Add("state", state);
            if (isModified != null) queryParams.Add("isModified", isModified.ToString());
            if (max > 0) queryParams.Add("max", max.ToString());

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
        /// <returns>The updated Meeting object.</returns>
        public async Task<Meeting> UpdateMeetingAsync(string meetingId, string title, string password, DateTime start, DateTime end,
                                            bool enabledAutoRecordMeeting, bool allowAnyUserToBeCoHost,
                                            string agenda = null, TimeZoneInfo timezone = null, string recurrence = null)
        {
            var bodyParameters = new Dictionary<string, object>();
            bodyParameters.Add("title", title);
            bodyParameters.Add("password", password);
            bodyParameters.Add("start", start);
            bodyParameters.Add("end", end);
            bodyParameters.Add("enabledAutoRecordMeeting", enabledAutoRecordMeeting);
            bodyParameters.Add("allowAnyUserToBeCoHost", allowAnyUserToBeCoHost);

            if (agenda != null) bodyParameters.Add("agenda", agenda);
            if (timezone != null) bodyParameters.Add("timezone", timezone);
            if (recurrence != null) bodyParameters.Add("recurrence", recurrence);

            return await PostItemAsync<Meeting>($"{meetingsBase}/{meetingId}", bodyParameters);
        }

        /// <summary>
        /// Update a recurring meeting series
        /// </summary>
        /// <param name="meeting">The Meeting object to be updated</param>
        /// <returns>The updated Meeting object.</returns>
        public async Task<Meeting> UpdateMeetingAsync(Meeting meeting)
        {
            return await UpdateMeetingAsync(meeting.Id, meeting.Title, meeting.Password, meeting.Start, meeting.End,
                                            meeting.EnabledAutoRecordMeeting, meeting.AllowAnyUserToBeCoHost, meeting.Agenda,
                                            meeting.Timezone, meeting.Recurrence);
        }


    }

}