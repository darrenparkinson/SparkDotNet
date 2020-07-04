using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SparkDotNet
{

    public partial class Spark
    {

        private string adminEventsBase = "/v1/adminAudit";

        
        public async Task<List<AdminEvent>> GetAdminAuditEventsAsync(string orgId, DateTime from, DateTime to, string actorId,
                                                                     int max = 0, int offsett = 0)
        {
            var queryParams = new Dictionary<string, string>();

            queryParams.Add("orgId", actorId);
            queryParams.Add("actorId", actorId);
            queryParams.Add("from", from.ToString("o"));
            queryParams.Add("to", to.ToString("o"));
            if (max > 0) queryParams.Add("max", max.ToString());
            if (offsett > 0) queryParams.Add("offsett", offsett.ToString());

            var path = getURL($"{adminEventsBase}/events", queryParams);
            return await GetItemsAsync<AdminEvent>(path);
        }

    }

}