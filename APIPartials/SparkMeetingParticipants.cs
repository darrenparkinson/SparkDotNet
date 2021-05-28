
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SparkDotNet
{

    public partial class Spark
    {

        private readonly string meetingParticipantsBase = "/v1/meetingParticipants";

        /// <summary>
        /// List all participants in a live or post meeting.
        /// The meetingId parameter is required, which is the unique identifier for the meeting.
        /// </summary>
        /// <param name="meetingId">The unique identifier for the meeting.</param>
        /// <param name="hostEmail">Email address for the meeting host. This parameter is only used if the user or application calling the API has the admin-level scopes, the admin may specify the email of a user in a site they manage and the API will return meeting participants of the meetings that are hosted by that user.</param>
        /// <returns>A list of all meeting participants.</returns>
        public async Task<List<MeetingParticipant>> GetMeetingParticipantsAsync(string meetingId, string hostEmail = null)
        {
            var queryParams = new Dictionary<string, string>();
            queryParams.Add("meetingId", meetingId);
            if (hostEmail != null) queryParams.Add("hostEmail", hostEmail);

            var path = getURL(meetingParticipantsBase, queryParams);
            return await GetItemsAsync<MeetingParticipant>(path);
        }

        /// <summary>
        /// Get a meeting participant details of a live or post meeting.
        /// The participantId is required to identify the meeting and the participant.
        /// </summary>
        /// <param name="participantId">The unique identifier for the meeting and the participant.</param>
        /// <returns>The requested meeting participant.</returns>
        public async Task<MeetingParticipant> GetMeetingParticipantDetailsAsync(string participantId)
        {
            return await GetItemAsync<MeetingParticipant>($"{meetingParticipantsBase}/{participantId}");
        }

        /// <summary>
        /// To mute, unmute, expel, or admit a participant in a live meeting.
        /// The participantId is required to identify the meeting and the participant.
        /// The attribute 'expel' always takes precedence over 'admit' and 'muted'.
        /// The request can have all 'expel', 'admit' and 'muted' or any of them.
        /// </summary>
        /// <param name="participantId">The unique identifier for the meeting and the participant.</param>
        /// <param name="muted">The value is true or false, and means to mute or unmute the audio of a participant.</param>
        /// <param name="admin">The value can be true or false. The value of true is to admit a participant to the meeting if the participant is in the lobby, No-Op if the participant is not in the lobby or when the value is set to false.</param>
        /// <param name="expel">The attribute is exclusive and its value can be true or false. The value of true means that the participant will be expelled from the meeting, the value of false means No-Op.</param>
        /// <returns>The updated meeting participant object</returns>
        public async Task<Meeting> UpdateMeetingParticipantAsync(string participantId, bool? muted = null, bool? admin = null, bool? expel = null)
        {
            var bodyParameters = new Dictionary<string, object>();

            if (muted != null) bodyParameters.Add("muted", muted);
            if (admin != null) bodyParameters.Add("admin", admin);
            if (expel != null) bodyParameters.Add("expel", expel);

            return await PostItemAsync<Meeting>($"{meetingParticipantsBase}/{participantId}", bodyParameters);
        }

    }
}