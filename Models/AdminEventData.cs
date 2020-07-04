using System;
using Newtonsoft.Json;

namespace SparkDotNet
{

    public class AdminEventData
    {
        /// <summary>
        /// The display name of the organization.
        /// </summary>
        public string ActorOrgName { get; set; }

        /// <summary>
        /// The name of the resource being acted upon.
        /// </summary>
        public string TargetName { get; set; }

        /// <summary>
        /// A description for the event.
        /// </summary>
        public string EventDescription { get; set; }

        /// <summary>
        /// The name of the person who performed the action.
        /// </summary>
        public string ActorName { get; set; }

        /// <summary>
        /// The email of the person who performed the action.
        /// </summary>
        public string ActorEmail { get; set; }

        /// <summary>
        /// Admin roles for the person.
        /// </summary>
        public string[] AdminRoles { get; set; }

        /// <summary>
        /// A tracking identifier for the event.
        /// </summary>
        public string TrackingId { get; set; }

        /// <summary>
        /// The type of resource changed by the event.
        /// </summary>
        public string TargetType { get; set; }

        /// <summary>
        /// The identifier for the resource changed by the event.
        /// </summary>
        public string TargetId { get; set; }

        /// <summary>
        /// The category of resource changed by the event.
        /// </summary>
        public string EventCategory { get; set; }

        /// <summary>
        /// The browser user agent of the person who performed the action.
        /// </summary>
        public string ActorUserAgent { get; set; }

        /// <summary>
        /// The IP address of the person who performed the action.
        /// </summary>
        public string ActorIp { get; set; }

        /// <summary>
        /// The orgId of the organization.
        /// </summary>
        public string TargetOrgId { get; set; }

        /// <summary>
        /// A more detailed description of the change made by the person.
        /// </summary>
        public string ActionText { get; set; }

        /// <summary>
        /// The name of the organization being acted upon.
        /// </summary>
        public string TargetOrgName { get; set; }

        public override string ToString()
        { 
            return JsonConvert.SerializeObject(this);
        }
    }
}