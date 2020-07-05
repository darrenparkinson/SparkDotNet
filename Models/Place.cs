using System;

namespace SparkDotNet
{
    /// <summary>
    /// Places represent where people work, such as conference rooms, meeting spaces, lobbies, and lunch rooms. Devices may be associated with places.
    /// Viewing details for places you have access to requires an auth token with a scope of spark:places_read.
    /// Updating or deleting your places requires an auth token with the spark:places_write scope.
    /// Viewing the list of all places in an organization requires an administrator auth token with the spark-admin:places_read scope.
    /// Adding, updating, or deleting all places in an organization requires an administrator auth token with the spark-admin:places_write scope.
    /// </summary>
    public class Place : WebexObject
    {
        /// <summary>
        /// Unique identifier for the Place.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// A friendly name for the place.
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// OrgId associate with the place
        /// </summary>
        public string OrgId { get; set; }

        /// <summary>
        /// SipUrl to call all the devices associated with the place.
        /// </summary>
        public string SipAddress { get; set; }

        /// <summary>
        /// The date and time that the place was registered, in ISO8601 format.
        /// </summary>
        public DateTime Created { get; set; }
    }
}