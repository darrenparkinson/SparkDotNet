using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SparkDotNet
{

    public partial class Spark
    {

        private string recordingsBase = "/v1/recordings";

        /// <summary>
        /// Lists recordings. You can specify a date range and the maximum number of recordings to return.
        /// Only recordings of meetings hosted by or shared with the authenticated user will be listed.
        /// The list returned is sorted in descending order by the date and time that the recordings were created.
        /// If meetingId is specified, only recordings associated with the specified meeting will be listed.
        /// Long result sets are split into pages.
        /// </summary>
        /// <param name="max">Maximum number of recordings to return in a single page. max must be equal to or greater than 1 and equal to or less than 100. Default: 10</param>
        /// <param name="from">Starting date and time (inclusive) for recordings to return, in any ISO 8601 compliant format. from cannot be after current date and time or after to. Default: If `to` is specified, the default value is 7 days before `to`; if `to` is not specified, the default value is 7 days before current date and time.</param>
        /// <param name="to">Ending date and time (exclusive) for List recordings to return, in any ISO 8601 compliant format. to cannot be after current date and time or before from. Default: Current date and time</param>
        /// <param name="meetingId">Unique identifier for the parent meeting series, scheduled meeting or meeting instance for which recordings are being requested. If a meeting series ID is specified, the operation returns an array of recordings for the specified meeting series; if a scheduled meeting ID is specified, the operation returns an array of recordings for the specified scheduled meeting; if a meeting instance ID is specified, the operation returns an array of recordings for the specified meeting instance. If not specified, the operation returns an array of recordings for all meetings of the current user.</param>
        /// <returns></returns>
        public async Task<List<Recording>> GetRecordingsAsync(int max = 0, DateTime? from = null, DateTime? to = null, string meetingId = null)
        {
            var queryParams = new Dictionary<string, string>();

            if (max > 0) queryParams.Add("max", max.ToString());
            if (from != null) queryParams.Add("from", ((DateTime)from).ToString("o"));
            if (to != null) queryParams.Add("to", ((DateTime)to).ToString("o"));
            if (meetingId != null) queryParams.Add("meetingId", meetingId);

            var path = getURL(recordingsBase, queryParams);

            return await GetItemsAsync<Recording>(path);
        }

        /// <summary>
        /// Lists recordings. You can specify a date range and the maximum number of recordings to return.
        /// Only recordings of meetings hosted by or shared with the authenticated user will be listed.
        /// The list returned is sorted in descending order by the date and time that the recordings were created.
        /// If meetingId is specified, only recordings associated with the specified meeting will be listed.
        /// Long result sets are split into pages.
        /// </summary>
        /// <param name="max">Maximum number of recordings to return in a single page. max must be equal to or greater than 1 and equal to or less than 100. Default: 10</param>
        /// <param name="from">Starting date and time (inclusive) for recordings to return, in any ISO 8601 compliant format. from cannot be after current date and time or after to. Default: If `to` is specified, the default value is 7 days before `to`; if `to` is not specified, the default value is 7 days before current date and time.</param>
        /// <param name="to">Ending date and time (exclusive) for List recordings to return, in any ISO 8601 compliant format. to cannot be after current date and time or before from. Default: Current date and time</param>
        /// <param name="meeting">Meeting object for the parent meeting series, scheduled meeting or meeting instance for which recordings are being requested. If a meeting is specified, the operation returns an array of recordings for the specified meeting series; if a scheduled meeting ID is specified, the operation returns an array of recordings for the specified scheduled meeting; if a meeting instance ID is specified, the operation returns an array of recordings for the specified meeting instance. If not specified, the operation returns an array of recordings for all meetings of the current user.</param>
        /// <returns></returns>
        public async Task<List<Recording>> GetRecordingsAsync(int max = 0, DateTime? from = null, DateTime? to = null, Meeting meeting)
        {
            return await GetRecordingsAsync(max, from, to, meeting.Id);
        }

        /// <summary>
        /// Retrieves details for a recording with a specified recording ID.
        /// Only recordings of meetings hosted by or shared with the authenticated user may be retrieved.
        /// </summary>
        /// <param name="recordingId">A unique identifier for the recording.</param>
        /// <returns></returns>
        public async Task<Recording>GetRecordingAsync(string recordingId)
        {
            var queryParams = new Dictionary<string, string>();
            var path = getURL($"{recordingsBase}/{recordingId}", queryParams);
            return await GetItemAsync<Recording>(path);
        }

        /// <summary>
        /// Removes a recording with a specified recording ID. The deleted recording cannot be recovered.
        /// Only recordings of meetings hosted by the authenticated user can be deleted.
        /// </summary>
        /// <param name="recordingId">A unique identifier for the recording.</param>
        /// <returns>true if the recording was deleted, false otherwise</returns>
        public async Task<bool> DeleteRecordingAsync(string recordingId)
        {
            return await DeleteItemAsync($"{recordingsBase}/{recordingId}");
        }

        /// <summary>
        /// Removes a recording object. The deleted recording cannot be recovered.
        /// Only recordings of meetings hosted by the authenticated user can be deleted.
        /// </summary>
        /// <param name="recordingId">A unique identifier for the recording.</param>
        /// <returns>true if the recording was deleted, false otherwise</returns>
        public async Task<bool> DeleteRecordingAsync(Recording recording)
        {
            return await DeleteRecordingAsync(recording.Id);
        }

    }


}