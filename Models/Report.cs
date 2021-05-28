namespace SparkDotNet {
    /// <summary>
    /// Reports available via Webex Control Hub may be generated and downloaded via the Reports API. To access this API, the authenticated user must be a read-only or full administrator of the organization to which the report belongs.
    /// For more information about Reports, see the Admin API guide.
    /// </summary>
    public class Report : WebexObject
    {
        /// <summary>
        /// A unique identifier for the report.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Name of the template that this report belongs to
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The service to which the report belongs
        /// </summary>
        public string Service { get; set; }

        /// <summary>
        /// The data in this report belongs to dates greater than or equal to this
        /// </summary>
        public System.DateTime StartDate { get; set; }

        /// <summary>
        /// The data in this report belongs to dates smaller than or equal to this
        /// </summary>
        public System.DateTime EndDate { get; set; }

        /// <summary>
        /// The site to which this report belongs to. This only exists if the report belongs to service 'Webex'
        /// </summary>
        public string SiteLIst { get; set; }

        /// <summary>
        /// Time of creation for this report
        /// </summary>
        public System.DateTime Created { get; set; }

        /// <summary>
        /// The person who created the report.
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// Whether this report was scheduled from API or Control Hub
        /// </summary>
        public string ScheduledFrom { get; set; }

        /// <summary>
        /// Completion status of this report
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// The link from which the report can be downloaded
        /// </summary>
        public string DownloadUrl { get; set; }
   }
}