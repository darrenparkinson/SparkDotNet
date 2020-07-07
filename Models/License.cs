namespace SparkDotNet {

    /// <summary>
    /// An allowance for features and services that are provided to users on a Webex Teams services subscription.
    /// Cisco and its partners manage the amount of licenses provided to administrators and users.
    /// This license resource can be accessed only by an admin.
    /// To learn about how to allocate Hybrid Services licenses, see the Managing Hybrid Services guide.
    /// </summary>
    public class License : WebexObject
    {

        /// <summary>
        /// A unique identifier for the license.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Name of the licensed feature.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Total number of license units allocated.
        /// </summary>
        public string TotalUnits { get; set; }

        /// <summary>
        /// Total number of license units consumed.
        /// </summary>
        public string ConsumedUnits { get; set; }

        /// <summary>
        /// The subscription ID associated with this license. This ID is used in other systems, such as Webex Control Hub.
        /// </summary>
        public string SubscriptionId { get; set; }

        /// <summary>
        /// The Webex Meetings site associated with this license.
        /// </summary>
        public string SiteUrl { get; set; }

        /// <summary>
        /// The type of site associated with this license.
        /// Control Hub managed site: the site is managed by Webex Control Hub
        /// Linked site: the site is a linked site
        /// Site Admin managed site: the site is managed by Site Administration
        /// </summary>
        public string SiteType { get; set; }
    }
}