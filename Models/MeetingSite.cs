namespace SparkDotNet
{
    public class MeetingSite : WebexObject
    {

        /// <summary>
        /// Access URL for the site. Note: This is a read-only attribute.
        /// The value can be assigned as user's default site by Update Default Site of Meeting Preference API.
        /// </summary>
        public string SiteUrl { get; set; }

        /// <summary>
        /// Flag identifying the site as the default site.
        /// Users can list meetings and recordings, and create meetings on the default site.
        /// </summary>
        public bool Default { get; set; }

    }


}