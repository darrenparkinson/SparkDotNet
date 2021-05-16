using Newtonsoft.Json;

namespace SparkDotNet
{

    /// <summary>
    /// Admin Audit Events are available to full administrators for certain events performed in Webex Control Hub.
    /// Administrators with accounts created before 2019 who have never logged into Webex Control Hub will
    /// need to log into Webex Control Hub at least once to enable access to this API.
    /// </summary>
    public class AdminEvent : WebexObject
    {
        /// <summary>
        /// Event Data details
        /// </summary>
        [JsonProperty("data")]
        public AdminEventData Data { get; set; }

        /// <summary>
        /// The date and time the event took place.
        /// </summary>
        [JsonProperty("created")]
        public System.DateTime Created { get; set; }

        /// <summary>
        /// The orgId of the person who made the change.
        /// </summary>
        [JsonProperty("actorOrgId")]
        public string ActorOrgId { get; set; }

        /// <summary>
        /// A unique identifier for the event.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// The personId of the person who made the change.
        /// </summary>
        [JsonProperty("actorId")]
        public string ActorId { get; set; }
    }
}