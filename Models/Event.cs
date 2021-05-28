using Newtonsoft.Json;

namespace SparkDotNet {

    /// <summary>
    /// Events are generated when actions take place within Webex Teams, such as when someone creates or deletes a message.
    /// Compliance Officers may use the Events API to retrieve events for all users within an organization.
    /// See the Compliance Guide for more information.
    /// </summary>
    public class Event : WebexObject
    {
        /// <summary>
        /// The unique identifier for the event.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// The type of resource in the event.
        /// </summary>
        [JsonProperty("resource")]
        public string Resource { get; set; }

        /// <summary>
        /// The action which took place in the event.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// The ID of the application for the event.
        /// </summary>
        [JsonProperty("appId")]
        public string AppId { get; set; }

        /// <summary>
        /// The ID of the person who performed the action.
        /// </summary>
        [JsonProperty("actorId")]
        public string ActorId { get; set; }

        /// <summary>
        /// The ID of the organization for the event.
        /// </summary>
        [JsonProperty("orgId")]
        public string OrgId { get; set; }

        /// <summary>
        /// The date and time of the event.
        /// </summary>
        [JsonProperty("created")]
        public System.DateTime Created { get; set; }

        /// <summary>
        /// The event’s data representation.
        /// This object will contain the event's resource, such as memberships, messages, meetings, tabs, rooms or attachmentActions at the time the event took place.
        /// </summary>
        [JsonProperty("data")]
        public EventData Data { get; set; }
    }
}