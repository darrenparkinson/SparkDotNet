namespace SparkDotNet
{
    /// <summary>
    /// HATEOAS information of global call-in numbers for joining teleconference from a phone.
    /// </summary>
    public class MeetingTelephonyLink : WebexObject
    {
        /// <summary>
        /// Link relation describing how the target resource is related to the current context (conforming with RFC5998).
        /// </summary>
        public string Rel { get; set; }

        /// <summary>
        /// Target resource URI (conforming with RFC5998).
        /// </summary>
        public string Href { get; set; }

        /// <summary>
        /// Target resource method (conforming with RFC5998).
        /// </summary>
        public string Method { get; set; }
    }
}