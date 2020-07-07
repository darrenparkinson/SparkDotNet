using System;

namespace SparkDotNet {

    /// <summary>
    /// Locations are used to organize Webex Calling (BroadCloud) features within physical locations.
    /// Webex Control Hub may be used to define new locations.
    /// Searching and viewing locations in your organization requires an administrator auth token
    /// with the spark-admin:people_read or spark-admin:device_read scope.
    /// </summary>
    public class Location : WebexObject
    {
        /// <summary>
        /// A unique identifier for the location.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The name of the location.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The ID of the organization to which this location belongs.
        /// </summary>
        public string OrgId { get; set; }

        /// <summary>
        /// The address of the location.
        /// </summary>
        public LocationAddress Address { get; set; }
   }
}