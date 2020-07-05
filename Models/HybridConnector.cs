using System;

namespace SparkDotNet {

    /// <summary>
    /// Hybrid Connectors are pieces of software that run on-premise and provide a link between the Cisco Webex Cloud and on-premise resources.
    /// For example, the Calendar Connector enables the linking of information from an on-premise Exchange server with the Cisco Webex Cloud.
    /// It allows, among other things, for the cloud to set up a Webex meeting when a user specifies @webex as the Location of a meeting in Outlook.
    /// Listing and viewing Hybrid Connectors requires an administrator auth token with the spark-admin:hybrid_connectors_read scope.
    /// Use this API to list the connectors configured in an organization and to determine if any connectors have any unresolved alarms
    /// associated with them.
    /// </summary>
    public class HybridConnector : WebexObject
    {
        /// <summary>
        /// A unique identifier for the connector.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The ID of the organization to which this hybrid connector belongs.
        /// </summary>
        public string OrgId { get; set; }

        /// <summary>
        /// The ID of the cluster this connector belongs to.
        /// </summary>
        public string HybridClusterId { get; set; }

        /// <summary>
        /// The hostname of the system the connector is running on.
        /// </summary>
        public string Hostname { get; set; }

        /// <summary>
        /// The status of the connector.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// The date and time the connector was created.
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// The type of connector.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// The version of the software installed.
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// A list of alarms raised on the connector.
        /// </summary>
        public HybridConnectorAlarm[] Alarms { get; set; }
    }
}