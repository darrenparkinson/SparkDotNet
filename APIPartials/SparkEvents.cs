using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SparkDotNet
{

    public partial class Spark
    {

        private string eventsBase = "/v1/events";

        /// <summary>
        /// List events in your organization. Several query parameters are available to filter the response.
        /// Long result sets will be split into pages.
        /// </summary>
        /// <param name="resource">List events with a specific resource type. Possible values: messages, memberships</param>
        /// <param name="type">List events with a specific event type. Possible values: created, updated, deleted</param>
        /// <param name="actorId">List events performed by this person, by ID.</param>
        /// <param name="from">List events which occurred after a specific date and time.</param>
        /// <param name="to">List events which occurred before a specific date and time.</param>
        /// <param name="max">Limit the maximum number of events in the response. Default: 100</param>
        /// <returns></returns>
        public async Task<List<Event>> GetEventsAsync(string resource = null, string type = null, string actorId = null,
                                                       DateTime? from = null, DateTime? to = null, int max = 0)
        {
            var queryParams = new Dictionary<string, string>();

            if (resource != null) queryParams.Add("resource", resource);
            if (type != null) queryParams.Add("type", type);
            if (actorId != null) queryParams.Add("actorId", actorId);
            if (max > 0) queryParams.Add("max", max.ToString());
            if (from != null) queryParams.Add("from", ((DateTime)from).ToString("o"));
            if (to != null) queryParams.Add("to", ((DateTime)to).ToString("o"));
            
            var path = getURL(eventsBase, queryParams);
            return await GetItemsAsync<Event>(path);
        }

        /// <summary>
        /// Shows details for an event, by event ID.
        /// Specify the event ID in the eventId parameter in the URI.
        /// </summary>
        /// <param name="eventId">The unique identifier for the event.</param>
        /// <returns>the Event object of the requested Event id</returns>
        public async Task<Event> GetEventAsync(string eventId)
        {
            var queryParams = new Dictionary<string, string>();
            var path = getURL($"{eventsBase}/{eventId}", queryParams);
            return await GetItemAsync<Event>(path);
        }

    }

}