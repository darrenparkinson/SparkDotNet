using Newtonsoft.Json;

namespace SparkDotNet
{
    public class WorkspaceCalendar : WebexObject
    {
        /// <summary>
        /// Calendar type. Calendar of type none does not include an emailAddress field.
        /// Possible values are:
        /// * none: No calendar.
        /// * google: Google Calendar.
        /// * microsoft: Microsoft Exchange or Office 365.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// Workspace email address. Will not be set when the calendar type is none.
        /// </summary>
        [JsonProperty("emailAddress")]
        public string EmailAddress { get; set; }
    }
}