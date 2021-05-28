using System;
using Newtonsoft.Json;

namespace SparkDotNet
{

    public class AdminEventData : WebexObject
    {
        /// <summary>
        /// The display name of the organization.
        /// </summary>
        [JsonProperty("actorOrgName")]
        public string ActorOrgName { get; set; }

        /// <summary>
        /// The name of the resource being acted upon.
        /// </summary>
        [JsonProperty("targetName")]
        public string TargetName { get; set; }

        /// <summary>
        /// A description for the event.
        /// </summary>
        [JsonProperty("eventDescription")]
        public string EventDescription { get; set; }

        /// <summary>
        /// The name of the person who performed the action.
        /// </summary>
        [JsonProperty("actorName")]
        public string ActorName { get; set; }

        /// <summary>
        /// The email of the person who performed the action.
        /// </summary>
        [JsonProperty("actorEmail")]
        public string ActorEmail { get; set; }

        /// <summary>
        /// Admin roles for the person.
        /// </summary>
        [JsonProperty("adminRoles")]
        public string[] AdminRoles { get; set; }

        /// <summary>
        /// A tracking identifier for the event.
        /// </summary>
        [JsonProperty("trackingId")]
        public string TrackingId { get; set; }

        /// <summary>
        /// The type of resource changed by the event.
        /// </summary>
        [JsonProperty("targetType")]
        public string TargetType { get; set; }

        /// <summary>
        /// The identifier for the resource changed by the event.
        /// </summary>
        [JsonProperty("targetId")]
        public string TargetId { get; set; }

        /// <summary>
        /// The category of resource changed by the event.
        /// </summary>
        [JsonProperty("eventCategory")]
        public string EventCategory { get; set; }

        /// <summary>
        /// The browser user agent of the person who performed the action.
        /// </summary>
        [JsonProperty("actorUserAgent")]
        public string ActorUserAgent { get; set; }

        /// <summary>
        /// The IP address of the person who performed the action.
        /// </summary>
        [JsonProperty("actorIp")]
        public string ActorIp { get; set; }

        /// <summary>
        /// The orgId of the organization.
        /// </summary>
        [JsonProperty("targetOrgId")]
        public string TargetOrgId { get; set; }

        /// <summary>
        /// A more detailed description of the change made by the person.
        /// </summary>
        [JsonProperty("actionText")]
        public string ActionText { get; set; }

        /// <summary>
        /// The name of the organization being acted upon.
        /// </summary>
        [JsonProperty("targetOrgName")]
        public string TargetOrgName { get; set; }
    }
}