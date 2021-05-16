using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SparkDotNet
{

    public partial class Spark
    {
        private readonly string meetingInviteesBase = "/v1/meetingInvitees";

        /// <summary>
        /// Lists meeting invitees for a meeting with a specified meetingId.
        /// You can set a maximum number of invitees to return.
        /// This operation can be used for meeting series, scheduled meeting and ended or
        /// ongoing meeting instance objects.If the specified meetingId is for a meeting series,
        /// the invitees for the series will be listed; if the meetingId is for a scheduled meeting,
        /// the invitees for the particular scheduled meeting will be listed;
        /// if the meetingId is for an ended or ongoing meeting instance, the invitees for the particular
        /// meeting instance will be listed.See the Webex Meetings guide for more information
        /// about the types of meetings.
        /// The list returned is sorted in ascending order by email address.
        /// Long result sets are split into pages.
        /// </summary>
        /// <param name="meetingId">Unique identifier for the meeting for which invitees are being requested. The meeting can be meeting series, scheduled meeting or meeting instance which has ended or is ongoing.</param>
        /// <param name="max">Limit the maximum number of meeting invitees in the response, up to 100. Default: 10</param>
        /// <param name="hostEmail">Email address for the meeting host. This parameter is only used if the user or application calling the API has the admin on-behalf-of scopes. If set, the admin may specify the email of a user in a site they manage and the API will return meeting invitees that are hosted by that user.</param>
        /// <returns>List of MeetingInvitee objects for the given meeting</returns>
        public async Task<List<MeetingInvitee>> GetMeetingInviteesAsync(string meetingId, int max = 10, string hostEmail = null)
        {
            var queryParams = new Dictionary<string, string>();

            if (max > 0) queryParams.Add("max", max.ToString());
            if (hostEmail != null) queryParams.Add("hostEmail", hostEmail);

            var path = getURL($"{meetingInviteesBase}/{meetingId}", queryParams);
            return await GetItemsAsync<MeetingInvitee>(path);
        }

        /// <summary>
        /// Retrieves details for a meeting invitee identified by a meetingInviteeId in the URI.
        /// </summary>
        /// <param name="meetingInviteeId">Unique identifier for the invitee whose details are being requested.</param>
        /// <param name="hostEmail">Email address for the meeting host. This parameter is only used if the user or application calling the API has the admin on-behalf-of scopes. If set, the admin may specify the email of a user in a site they manage and the API will return details for a meeting invitee that is hosted by that user.</param>
        /// <returns>The queries MeetingInvitee object</returns>
        public async Task<MeetingInvitee> GeMeetingInviteeAsync(string meetingInviteeId, string hostEmail = null)
        {
            var queryParams = new Dictionary<string, string>();
            if (hostEmail != null) queryParams.Add("hostEmail", hostEmail);

            var path = getURL($"{meetingInviteesBase}/{meetingInviteeId}", queryParams);
            return await GetItemAsync<MeetingInvitee>(path);
        }

        /// <summary>
        /// Invites a person to attend a meeting.
        /// Identify the invitee in the request body, by email address.
        /// </summary>
        /// <param name="meetingId">Unique identifier for the meeting to which a person is being invited. This attribute only applies to meeting series and scheduled meeting. If it's a meeting series, the meeting invitee is invited to the entire meeting series; if it's a scheduled meeting, the meeting invitee is invited to this individual scheduled meeting. It doesn't apply to an ended or ongoing meeting instance.</param>
        /// <param name="email">Email address for meeting invitee.</param>
        /// <param name="displayName">Display name for meeting invitee. The maximum length of displayName is 384 bytes. If displayName is not specified and the email has been associated with an existing Webex account, the display name associated with the Webex account will be used. If displayName is not specified and the email has not been associated with an existing Webex account, the email will be used instead.</param>
        /// <param name="coHost">Whether or not invitee is a designated alternate host for the meeting. See Add Alternate Hosts for Cisco Webex Meetings for more details.</param>
        /// <param name="hostEmail">Email address for the meeting host. This attribute should only be set if the user or application calling the API has the admin on-behalf-of scopes. When used, the admin may specify the email of a user in a site they manage to be the meeting host.</param>
        /// <returns>The created MeetingInvitee object</returns>
        public async Task<MeetingInvitee> CreateMeetingInviteeAsync(string meetingId, string email, string displayName = null,
                                                                    bool? coHost = null, string hostEmail = null)
        {
            var bodyParameters = new Dictionary<string, object>();
            bodyParameters.Add("meetingId", meetingId);
            bodyParameters.Add("email", email);
            if (displayName != null) bodyParameters.Add("displayName", displayName);
            if (coHost != null) bodyParameters.Add("coHost", coHost);
            if (hostEmail != null) bodyParameters.Add("hostEmail", hostEmail);

            return await PostItemAsync<MeetingInvitee>($"{meetingInviteesBase}", bodyParameters);
        }

        /// <summary>
        /// Updates details for a meeting invitee identified by a meetingInviteeId in the URI.
        /// </summary>
        /// <param name="meetingInviteeId">Unique identifier for the invitee to be updated. This parameter only applies to an invitee to a meeting series or a scheduled meeting. It doesn't apply to an invitee to an ended or ongoing meeting instance.</param>
        /// <param name="email">Email address for meeting invitee.</param>
        /// <param name="displayName">Display name for meeting invitee. The maximum length of displayName is 384 bytes. If displayName is not specified and the email has been associated with an existing Webex account, the display name associated with the Webex account will be used. If displayName is not specified and the email has not been associated with an existing Webex account, the email will be used instead.</param>
        /// <param name="coHost">Whether or not invitee is a designated alternate host for the meeting. See Add Alternate Hosts for Cisco Webex Meetings for more details.</param>
        /// <param name="hostEmail">Email address for the meeting host. This attribute should only be set if the user or application calling the API has the admin on-behalf-of scopes. When used, the admin may specify the email of a user in a site they manage to be the meeting host.</param>
        /// <returns>The updated MeetingInvitee object</returns>
        public async Task<MeetingInvitee> UpdateMeetingInviteeAsync(string meetingInviteeId, string email, string displayName = null,
                                                                    bool? coHost = null, string hostEmail = null)
        {
            var bodyParameters = new Dictionary<string, object>();
            bodyParameters.Add("email", email);
            if (displayName != null) bodyParameters.Add("displayName", displayName);
            if (coHost != null) bodyParameters.Add("coHost", coHost);
            if (hostEmail != null) bodyParameters.Add("hostEmail", hostEmail);

            return await UpdateItemAsync<MeetingInvitee>($"{meetingInviteesBase}/{meetingInviteeId}", bodyParameters);
        }

        /// <summary>
        /// Updates details for a meeting invitee identified by a MeetingInvitee object.
        /// </summary>
        /// <param name="meetingInvitee">The meeting invitee object to be updated</param>
        /// <param name="hostEmail">Email address for the meeting host. This attribute should only be set if the user or application calling the API has the admin on-behalf-of scopes. When used, the admin may specify the email of a user in a site they manage to be the meeting host.</param>
        /// <returns>The updated MeetingInvitee object</returns>
        public async Task<MeetingInvitee> UpdateMeetingInviteeAsync(MeetingInvitee meetingInvitee, string hostEmail = null)
        {
            return await UpdateMeetingInviteeAsync(meetingInvitee.Id, meetingInvitee.Email, meetingInvitee.DisplayName,
                                                   meetingInvitee.CoHost, hostEmail);
        }

        /// <summary>
        /// Removes a meeting invitee identified by a meetingInviteeId specified in the URI.
        /// The deleted meeting invitee cannot be recovered.
        /// If the meeting invitee is associated with a meeting series, the invitee will
        /// be removed from the entire meeting series.If the invitee is associated with a
        /// scheduled meeting, the invitee will be removed from only that scheduled meeting.
        /// </summary>
        /// <param name="meetingInviteeId">Unique identifier for the invitee to be removed. This parameter only applies to an invitee to a meeting series or a scheduled meeting. It doesn't apply to an invitee to an ended or ongoing meeting instance.</param>
        /// <param name="hostEmail">Email address for the meeting host. This parameter is only used if the user or application calling the API has the admin on-behalf-of scopes. If set, the admin may specify the email of a user in a site they manage and the API will delete a meeting invitee that is hosted by that user.</param>
        /// <returns>True if the meeting invitee was deleted, false otherwise.</returns>
        public async Task<bool> DeleteMeetingInviteeAsync(string meetingInviteeId, string hostEmail = null)
        {
            var queryParams = new Dictionary<string, string>();
            if (hostEmail != null) queryParams.Add("hostEmail", hostEmail);

            var path = getURL($"{meetingInviteesBase}/{meetingInviteeId}", queryParams);
            return await DeleteItemAsync(path);
        }

        /// <summary>
        /// Removes a meeting invitee object.
        /// The deleted meeting invitee cannot be recovered.
        /// If the meeting invitee is associated with a meeting series, the invitee will
        /// be removed from the entire meeting series.If the invitee is associated with a
        /// scheduled meeting, the invitee will be removed from only that scheduled meeting.
        /// </summary>
        /// <param name="meetingInvitee">The invitee to be removed. This parameter only applies to an invitee to a meeting series or a scheduled meeting. It doesn't apply to an invitee to an ended or ongoing meeting instance.</param>
        /// <param name="hostEmail">Email address for the meeting host. This parameter is only used if the user or application calling the API has the admin on-behalf-of scopes. If set, the admin may specify the email of a user in a site they manage and the API will delete a meeting invitee that is hosted by that user.</param>
        /// <returns>True if the meeting invitee was deleted, false otherwise.</returns>
        public async Task<bool> DeleteMeetingInviteeAsync(MeetingInvitee meetingInvitee, string hostEmail = null)
        {
            return await DeleteMeetingInviteeAsync(meetingInvitee.Id, hostEmail);
        }
    }

}