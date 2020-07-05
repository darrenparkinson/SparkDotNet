using System;

namespace SparkDotNet {

    /// <summary>
    /// A set of people in Webex Teams.
    /// Organizations may manage other organizations or be managed themselves.
    /// This organizations resource can be accessed only by an admin.
    /// </summary>
    public class Organization : WebexObject
    {
        /// <summary>
        /// A unique identifier for the organization.
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// Full name of the organization.
        /// </summary>
        public string displayName { get; set; }

        /// <summary>
        /// The date and time the organization was created.
        /// </summary>
        public DateTime created { get; set; }

        #region XSI Properties, only available with XSI enabled Organizations and spark:xsi_read scope
        /// <summary>
        /// The base path to xsi-actions.
        /// </summary>
        public string XsiActionsEndpoint  { get; set; }

        /// <summary>
        /// The base path to xsi-events.
        /// </summary>
        public string XsiEventsEndpoint { get; set; }

        /// <summary>
        /// The base path to xsi-events-channel.
        /// </summary>
        public string XsiEventsChannelEndpoint { get; set; }

        /// <summary>
        /// "api-" prepended to the bcBaseDomain value for the organization.
        /// </summary>
        public string XsiDomain { get; set; }
        #endregion XSI Properties
    }
}