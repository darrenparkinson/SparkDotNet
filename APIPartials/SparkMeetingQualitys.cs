using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SparkDotNet
{

    public partial class Spark
    {
        private readonly string meetingQualitiesBase = "/v1/meeting/qualities";

        /// <summary>
        /// Provides quality data for a meeting, by meetingId.
        /// Only organization administrators can retrieve meeting quality data.
        /// </summary>
        /// <param name="meetingId">Unique identifier for the specific meeting instance. - Note: The meetingId can be obtained via the Meeting List API when meetingType=meeting. The id attribute in the Meeting List Response is what is needed, e.g. e5dba9613a9d455aa49f6ffdafb6e7db_I_191395283063545470</param>
        /// <param name="max">Limit the maximum number of media sessions in the response. Default: 100</param>
        /// <param name="offset">Offset from the first result that you want to fetch. Default: 0</param>
        /// <returns>Returns the Meeting Qualities for the specified meeting</returns>
        public async Task<List<MeetingQuality>> GetMeetingQualitiesAsync(string meetingId, int max = 100, int offset = 0)
        {
            var queryParams = new Dictionary<string, string>();
            queryParams.Add("meetingId", meetingId);
            if (max > 0) queryParams.Add("max", max.ToString());
            if (offset > 0) queryParams.Add("offset", offset.ToString());

            var path = getURL(meetingQualitiesBase, queryParams, "https://analytics.webexapis.com");
            return await GetItemsAsync<MeetingQuality>(path);

        }

    }

}