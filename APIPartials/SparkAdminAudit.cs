using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SparkDotNet
{

    public partial class Spark
    {

        private readonly string adminEventsBase = "/v1/adminAudit";

        /// <summary>
        /// List admin audit events in your organization. Several query parameters are available to filter the response.
        /// Long result sets will be split into pages.
        /// </summary>
        /// <param name="orgId">List events in this organization, by ID.</param>
        /// <param name="from">List events which occurred after a specific date and time.</param>
        /// <param name="to">List events which occurred before a specific date and time.</param>
        /// <param name="actorId">List events performed by this person, by ID.</param>
        /// <param name="max">Limit the maximum number of events in the response. The maximum value is 200. Default: 100</param>
        /// <param name="offsett">Offset from the first result that you want to fetch. Default: 0</param>
        /// <returns>A list of AdminEvent objects</returns>
        public async Task<List<AdminEvent>> GetAdminAuditEventsAsync(string orgId, DateTime from, DateTime to, string actorId,
                                                                     int max = 0, int offsett = 0)
        {
            var queryParams = new Dictionary<string, string>();

            queryParams.Add("orgId", actorId);
            queryParams.Add("actorId", actorId);
            queryParams.Add("from", from.ToString("o"));
            queryParams.Add("to", to.ToString("o"));
            if (max > 0) queryParams.Add("max", Math.Min(max, 200).ToString());
            if (offsett > 0) queryParams.Add("offsett", offsett.ToString());

            var path = getURL($"{adminEventsBase}/events", queryParams);
            return await GetItemsAsync<AdminEvent>(path);
        }

    }

}